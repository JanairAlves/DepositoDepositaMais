using DepositoDepositaMais.API.Models;
using DepositoDepositaMais.Application.Services.Implementations;
using DepositoDepositaMais.Application.Services.Interfaces;
using DepositoDepositaMais.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DepositoDepositaMais.API
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
            services.Configure<OpeningTimeOption>(Configuration.GetSection("OpeningTime"));

            services.AddSingleton<DepositoDepositaMaisDbContext>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDepositService, DepositService>();
            services.AddScoped<IIncomingInvoiceService, IncomingInvoiceService>();
            services.AddScoped<IIncomingOrderService, IncomingOrderService>();
            services.AddScoped<IOutgoingInvoiceService, OutgoingInvoiceService>();
            services.AddScoped<IOutgoingOrderService, OutgoingOrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IRepresentativeService, RepresentativeService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DepositoDepositaMais.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DepositoDepositaMais.API v1"));
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
