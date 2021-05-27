using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PdaHub.Helpers;
using PdaHub.Repositories.BasicData;
using PdaHub.Repositories.Items;
using PdaHub.Repositories.Stock;
using PdaHub.Services.Items;
using PdaHub.Services.Stock;

namespace SwaggerTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "bGomla API",
                    Description = "Stock , BasicData, Items"

                });
                c.SchemaFilter<NSwageSchemaFilter>();

            });



            services.AddSingleton<iHelper, Helper>();
            services.AddSingleton<IStockOrderRepository, StockRepository>();
            services.AddSingleton<IStockService, StockService>();
            services.AddSingleton<IBasicDataRepository, BasicDataRepository>();
            services.AddSingleton<IItemsRepository, ItemsRepository>();
            services.AddSingleton<IItemsServices, ItemsServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "bGomla API V1");
             });

        }
    }
}
