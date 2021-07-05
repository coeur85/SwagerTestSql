using PdaHub.Models.Stock;
using PdaHub.Repositories.Stock.Order;
using PdaHub.Repositories.Stock.OrderItems;
using System.Threading.Tasks;


namespace PdaHub.Repositories.Stock
{
    public class StockRepository : IStockRepository
    {

        private readonly IStockOrder _stockOrde;
        private readonly IStockOrderItems _stockOrderItems;

        public StockRepository(IStockOrder stockOrde, IStockOrderItems stockOrderItems)
        {
            _stockOrde = stockOrde;
            _stockOrderItems = stockOrderItems;
        }


        public async Task<StockDetailModel> GetOrderDetailAsync(StockReviewModel model, string connectionString)
        {
            StockDetailModel output = new StockDetailModel();
            output.StockOrder = await _stockOrde.GetOrderAsync(model, connectionString);
            if (output.StockOrder is null)
                return null;
            output.StockOrderItems = await _stockOrderItems.GetOrderItemsAsync(model, connectionString);
            return output;

        }


    }
}
