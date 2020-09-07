using ShipIt.Models.DataModels;

namespace ShipItTest.Builders
{
    public class StockBuilder
    {
        private int WarehouseId = 1;
        private int ProductId = 1;
        private int Held = 0;

        public StockBuilder SetWarehouseId(int warehouseId)
        {
            this.WarehouseId = warehouseId;
            return this;
        }

        public StockBuilder SetProductId(int productId)
        {
            this.ProductId = productId;
            return this;
        }

        public StockBuilder SetHeld(int held)
        {
            this.Held = held;
            return this;
        }

        public StockDataModel CreateStock()
        {
            return new StockDataModel()
            {
                WarehouseId = this.WarehouseId,
                ProductId = this.ProductId,
                held = this.Held
            };
        }
    }
}
