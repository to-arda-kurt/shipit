﻿using System.Data;

namespace ShipIt.Models.DataModels
{
    public class StockDataModel : DataModel
    {
        [DatabaseColumnName("p_id")]
        public int ProductId { get; set; }
        [DatabaseColumnName("w_id")]
        public int WarehouseId { get; set; }
        [DatabaseColumnName("hld")]
        public int held { get; set; }

        public StockDataModel(IDataReader dataReader): base(dataReader) { }
        
        public StockDataModel() {}
    }
}