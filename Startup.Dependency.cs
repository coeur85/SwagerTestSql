using Microsoft.Extensions.DependencyInjection;
using PdaHub.Broker.DataAccess;
using PdaHub.Broker.RunAs;
using PdaHub.Helpers;
using PdaHub.Repositories.Accounts;
using PdaHub.Repositories.BasicData;
using PdaHub.Repositories.Items;
using PdaHub.Repositories.Stock;
using PdaHub.Repositories.Stock.Order;
using PdaHub.Repositories.Stock.OrderItems;
using PdaHub.Services.Accounts;
using PdaHub.Services.Items;
using PdaHub.Services.Stock;

namespace PdaHub
{
    public partial class Startup
    {

        private static void AddDependency(IServiceCollection services)
        {
            services.AddSingleton<iHelper, Helper>();
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            services.AddSingleton<IRunAs, RunAs>();


            services.AddSingleton<IBasicDataRepository, BasicDataRepository>();
            services.AddSingleton<IStockOrder, StockOrder>();
            services.AddSingleton<IStockOrderItems, StockOrderItems>();
            services.AddSingleton<IStockRepository, StockRepository>();
            services.AddSingleton<IStockService, StockService>();

            services.AddSingleton<IItemsRepository, ItemsRepository>();
            services.AddSingleton<IItemsServices, ItemsServices>();

            services.AddSingleton<IAccountsServices, AccountsServices>();
            services.AddSingleton<IAccountsRepository, AccountsRepository>();
           
        }
    }
}
