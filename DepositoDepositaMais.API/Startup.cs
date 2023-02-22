using DepositoDepositaMais.Application.Commands.CreateCategory;
using DepositoDepositaMais.Application.Commands.CreateDeposit;
using DepositoDepositaMais.Application.Commands.CreateIncomingInvoice;
using DepositoDepositaMais.Application.Commands.CreateIncomingOrder;
using DepositoDepositaMais.Application.Commands.CreateOutgoingInvoice;
using DepositoDepositaMais.Application.Commands.CreateOutgoingOrder;
using DepositoDepositaMais.Application.Commands.CreateProvider;
using DepositoDepositaMais.Application.Commands.CreateRepresentative;
using DepositoDepositaMais.Application.Commands.CreateStorageLocation;
using DepositoDepositaMais.Application.Commands.CreateUser;
using DepositoDepositaMais.Core.Repositories;
using DepositoDepositaMais.Infrastructure.Persistence;
using DepositoDepositaMais.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            var connectionString = Configuration.GetConnectionString("DepositoDepositaMaisCs");
            services.AddDbContext<DepositoDepositaMaisDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDepositRepository, DepositRepository>();
            services.AddScoped<IIncomingInvoiceRepository, IncomingInvoiceRepository>();
            services.AddScoped<IIncomingOrderRepository, IncomingOrderRepository>();
            services.AddScoped<IOutgoingInvoiceRepository, OutgoingInvoiceRepository>();
            services.AddScoped<IOutgoingOrderRepository, OutgoingOrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IStorageLocationRepository, StorageLocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
            services.AddMediatR(typeof(CreateCategoryCommand));
            services.AddMediatR(typeof(CreateDepositCommand));
            services.AddMediatR(typeof(CreateIncomingInvoiceCommand));
            services.AddMediatR(typeof(CreateIncomingOrderCommand));
            services.AddMediatR(typeof(CreateOutgoingInvoiceCommand));
            services.AddMediatR(typeof(CreateOutgoingOrderCommand));
            services.AddMediatR(typeof(CreateProviderCommand));
            services.AddMediatR(typeof(CreateRepresentativeCommand));
            services.AddMediatR(typeof(CreateStorageLocationCommand));
            services.AddMediatR(typeof(CreateUserCommand));

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
