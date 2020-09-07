﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShipIt.Controllers;
using ShipIt.Exceptions;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;
using ShipIt.Repositories;
using ShipItTest.Builders;

namespace ShipItTest
{
    public class InboundOrderControllerTests : AbstractBaseTest
    {
        InboundOrderController inboundOrderController = new InboundOrderController(
            new EmployeeRepository(),
            new CompanyRepository(),
            new ProductRepository(),
            new StockRepository()
        );
        StockRepository stockRepository = new StockRepository();
        CompanyRepository companyRepository = new CompanyRepository();
        ProductRepository productRepository = new ProductRepository();
        EmployeeRepository employeeRepository = new EmployeeRepository();

        private static Employee OPS_MANAGER = new EmployeeBuilder().CreateEmployee();
        private static Company COMPANY = new CompanyBuilder().CreateCompany();
        private static readonly int WAREHOUSE_ID = OPS_MANAGER.WarehouseId;
        private static readonly String GCP = COMPANY.Gcp;

        private Product product;
        private int productId;
        private const string GTIN = "0000";

        public new void onSetUp()
        {
            base.onSetUp();
            employeeRepository.AddEmployees(new List<Employee>() { OPS_MANAGER });
            companyRepository.AddCompanies(new List<Company>() { COMPANY });
            var productDataModel = new ProductBuilder().setGtin(GTIN).CreateProductDatabaseModel();
            productRepository.AddProducts(new List<ProductDataModel>() { productDataModel });
            product = new Product(productRepository.GetProductByGtin(GTIN));
            productId = product.Id;
        }

        [Test]
        public void TestCreateOrderNoProductsHeld()
        {
            onSetUp();

            var inboundOrder = inboundOrderController.Get(WAREHOUSE_ID);

            Assert.AreEqual(inboundOrder.WarehouseId, WAREHOUSE_ID);
            Assert.IsTrue(EmployeesAreEqual(inboundOrder.OperationsManager, OPS_MANAGER));
            Assert.AreEqual(inboundOrder.OrderSegments.Count(), 0);
        }

        [Test]
        public void TestCreateOrderProductHoldingNoStock()
        {
            onSetUp();
            stockRepository.AddStock(WAREHOUSE_ID, new List<StockAlteration>() { new StockAlteration(productId, 0) });

            var inboundOrder = inboundOrderController.Get(WAREHOUSE_ID);

            Assert.AreEqual(inboundOrder.OrderSegments.Count(), 1);
            var orderSegment = inboundOrder.OrderSegments.First();
            Assert.AreEqual(orderSegment.Company.Gcp, GCP);
        }

        [Test]
        public void TestCreateOrderProductHoldingSufficientStock()
        {
            onSetUp();
            stockRepository.AddStock(WAREHOUSE_ID, new List<StockAlteration>() { new StockAlteration(productId, product.LowerThreshold) });

            var inboundOrder = inboundOrderController.Get(WAREHOUSE_ID);

            Assert.AreEqual(inboundOrder.OrderSegments.Count(), 0);
        }

        [Test]
        public void TestCreateOrderDiscontinuedProduct()
        {
            onSetUp();
            stockRepository.AddStock(WAREHOUSE_ID, new List<StockAlteration>() { new StockAlteration(productId, product.LowerThreshold - 1) });
            productRepository.DiscontinueProductByGtin(GTIN);

            var inboundOrder = inboundOrderController.Get(WAREHOUSE_ID);

            Assert.AreEqual(inboundOrder.OrderSegments.Count(), 0);
        }

        [Test]
        public void TestProcessManifest()
        {
            onSetUp();
            var quantity = 12;
            var inboundManifest = new InboundManifestRequestModel()
            {
                WarehouseId = WAREHOUSE_ID,
                Gcp = GCP,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        gtin = GTIN,
                        quantity = quantity
                    }
                }
            };

            inboundOrderController.Post(inboundManifest);

            var stock = stockRepository.GetStockByWarehouseAndProductIds(WAREHOUSE_ID, new List<int>() {productId})[productId];
            Assert.AreEqual(stock.held, quantity);
        }

        [Test]
        public void TestProcessManifestRejectsDodgyGcp()
        {
            onSetUp();
            var quantity = 12;
            var dodgyGcp = GCP + "XYZ";
            var inboundManifest = new InboundManifestRequestModel()
            {
                WarehouseId = WAREHOUSE_ID,
                Gcp = dodgyGcp,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        gtin = GTIN,
                        quantity = quantity
                    }
                }
            };

            try
            {
                inboundOrderController.Post(inboundManifest);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ValidationException e)
            {
                Assert.IsTrue(e.Message.Contains(dodgyGcp));
            }
        }

        [Test]
        public void TestProcessManifestRejectsUnknownProduct()
        {
            onSetUp();
            var quantity = 12;
            var unknownGtin = GTIN + "XYZ";
            var inboundManifest = new InboundManifestRequestModel()
            {
                WarehouseId = WAREHOUSE_ID,
                Gcp = GCP,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        gtin = GTIN,
                        quantity = quantity
                    },
                    new OrderLine()
                    {
                        gtin = unknownGtin,
                        quantity = quantity
                    }
                }
            };

            try
            {
                inboundOrderController.Post(inboundManifest);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ValidationException e)
            {
                Assert.IsTrue(e.Message.Contains(unknownGtin));
            }
        }

        [Test]
        public void TestProcessManifestRejectsDuplicateGtins()
        {
            onSetUp();
            var quantity = 12;
            var inboundManifest = new InboundManifestRequestModel()
            {
                WarehouseId = WAREHOUSE_ID,
                Gcp = GCP,
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine()
                    {
                        gtin = GTIN,
                        quantity = quantity
                    },
                    new OrderLine()
                    {
                        gtin = GTIN,
                        quantity = quantity
                    }
                }
            };

            try
            {
                inboundOrderController.Post(inboundManifest);
                Assert.Fail("Expected exception to be thrown.");
            }
            catch (ValidationException e)
            {
                Assert.IsTrue(e.Message.Contains(GTIN));
            }
        }

        private bool EmployeesAreEqual(Employee A, Employee B)
        {
            return A.WarehouseId == B.WarehouseId
                   && A.Name == B.Name
                   && A.role == B.role
                   && A.ext == B.ext;
        }
    }
}
