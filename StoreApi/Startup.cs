using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Database;
using StoreApi.Services.Interfaces;
using StoreApi.Services.Implimentation;
using StoreApi.Repositories.Implementations;
using StoreApi.Repositories.Interfaces;

namespace StoreApi
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IRepairService, RepairService>();
            services.AddTransient<IBaseRepository<StoreModel>, BaseRepository<StoreModel>>();
            services.AddTransient<IBaseRepository<ProductModel>, BaseRepository<ProductModel>>();
            services.AddTransient<IBaseRepository<StoreBalanceModel>, BaseRepository<StoreBalanceModel>>();

            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
