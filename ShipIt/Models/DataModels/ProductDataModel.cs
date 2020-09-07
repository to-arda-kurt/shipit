﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Npgsql;
using ShipIt.Models.ApiModels;

namespace ShipIt.Models.DataModels
{
    public class DatabaseColumnName : Attribute
    {
        public string Name { get; set; }

        public DatabaseColumnName(string name)
        {
            Name = name;
        }
    }


    public abstract class DataModel
    {
        protected DataModel()
        {
        }

        public DataModel(IDataReader dataReader)
        {
            var type = GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attribute = (DatabaseColumnName)property.GetCustomAttributes(typeof(DatabaseColumnName), false).First();
                property.SetValue(this, dataReader[attribute.Name], null);
            }
        }

        public IEnumerable<NpgsqlParameter> GetNpgsqlParameters()
        {
            var type = GetType();
            var properties = type.GetProperties();
            var parameters = new List<NpgsqlParameter>();

            foreach (var property in properties)
            {
                var attribute = (DatabaseColumnName)property.GetCustomAttributes(typeof(DatabaseColumnName), false).First();
                parameters.Add(new NpgsqlParameter("@" + attribute.Name,property.GetValue(this, null)));
            }

            return parameters;
        }
    }

    public class ProductDataModel : DataModel
    {
        [DatabaseColumnName("p_id")]
        public int Id { get; set; }

        [DatabaseColumnName("gtin_cd")]
        public string Gtin { get; set; }

        [DatabaseColumnName("gcp_cd")]
        public string Gcp { get; set; }

        [DatabaseColumnName("gtin_nm")]
        public string Name { get; set; }

        [DatabaseColumnName("m_g")]
        public double Weight { get; set; }

        [DatabaseColumnName("l_th")]
        public int LowerThreshold { get; set; }

        [DatabaseColumnName("ds")]
        public int Discontinued { get; set; }

        [DatabaseColumnName("min_qt")]
        public int MinimumOrderQuantity { get; set; }

        public ProductDataModel(IDataReader dataReader) : base(dataReader)
        { }

        public ProductDataModel()
        { }

        public ProductDataModel(Product apiModel)
        {
            Id = apiModel.Id;
            Gtin = apiModel.Gtin;
            Gcp = apiModel.Gcp;
            Name = apiModel.Name;
            Weight = apiModel.Weight;
            LowerThreshold = apiModel.LowerThreshold;
            Discontinued = apiModel.Discontinued ? 1 : 0;
            MinimumOrderQuantity = apiModel.MinimumOrderQuantity;
        }
    }

}