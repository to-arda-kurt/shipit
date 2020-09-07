using Microsoft.AspNetCore.Mvc;
using ShipIt.Repositories;

namespace ShipIt.Controllers
{
    [Route("")]
    public class Status
    {
        public int WarehouseCount { get; set; }
        public int EmployeeCount { get; set; }
        public int ItemsTracked { get; set; }
        public int StockHeld { get; set; }
        public int ProductCount { get; set; }
        public int CompanyCount { get; set; }
    }

    public class StatusController : ControllerBase
    {
        private IEmployeeRepository employeeRepository;
        private ICompanyRepository companyRepository;
        private IProductRepository productRepository;
        private IStockRepository stockRepository;

        public StatusController(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IProductRepository productRepository, IStockRepository stockRepository)
        {
            this.employeeRepository = employeeRepository;
            this.stockRepository = stockRepository;
            this.companyRepository = companyRepository;
            this.productRepository = productRepository;
        }

        [HttpGet("")]
        [HttpGet("status")]
        public Status Get()
        {
            return new Status()
            {
                EmployeeCount = employeeRepository.GetCount(),
                ItemsTracked = stockRepository.GetTrackedItemsCount(),
                CompanyCount = companyRepository.GetCount(),
                ProductCount = productRepository.GetCount(),
                StockHeld = stockRepository.GetStockHeldSum(),
                WarehouseCount = employeeRepository.GetWarehouseCount()
            };
        }
    }
}