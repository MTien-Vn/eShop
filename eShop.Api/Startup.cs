using eShop.Business.Entity.System;
using eShop.Business.Interface.IDBConnector;
using eShop.Business.Interface.IRepository;
using eShop.Business.Interface.IRepository.IVendorRepository;
using eShop.Business.Interface.IService;
using eShop.Business.Interface.IService.IVendorService;
using eShop.Business.Interface.ISystem;
using eShop.Business.ServiceImp;
using eShop.Business.ServiceImp.VendorServiceImp;
using eShop.Business.System.Service;
using eShop.Repository.DBConnectorImp;
using eShop.Repository.RepositoryImp;
using eShop.Repository.RepositoryImp.VendorRepositoryImp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Misa.BL.ServiceImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Api
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
            // add scope dbconnector
            services.AddScoped<IDBConnector, DBConnectorImp>();

            // add scope repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepositoryImp<>));
            services.AddScoped<IVendorRepository, VendorRepositoryImp>();
            services.AddScoped<IItemModelRepository, ItemModelRepositoryImp>();
            services.AddScoped<IStatisticTotalAmountByMonthRepository, StatisticTotalAmountByMonthRepositoryImp>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            // add scope service
            services.AddScoped(typeof(IBaseService<>), typeof(BaseServiceImp<>));
            services.AddScoped<IVendorService, VendorServiceImp>();
            services.AddScoped<IItemModelService, ItemModelServiceImp>();
            services.AddScoped<IStatisticTotalAmountByMonthService, StatisticTotalAmountByMonthServiceImp>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            /*services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<SignInManager<User>, SignInManager<User>>();*/

            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eShop.Api", Version = "v1" });
            });

            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eShop.Api v1"));
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
