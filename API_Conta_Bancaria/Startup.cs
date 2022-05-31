using API_Conta_Bancaria.Repository.Deposito;
using API_Conta_Bancaria.Repository.Extrato;
using API_Conta_Bancaria.Repository.Saque;
using API_Conta_Bancaria.Repository.Transferencia;
using API_Conta_Bancaria.Services.Deposito;
using API_Conta_Bancaria.Services.Extrato;
using API_Conta_Bancaria.Services.Saque;
using API_Conta_Bancaria.Services.Transferencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Conta_Bancaria
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
            services.AddScoped<IDepositoService, DepositoService>();
            services.AddScoped<ISaqueService, SaqueService>();
            services.AddScoped<IExtratoService, ExtratoService>();
            services.AddScoped<ITransferenciaService, TransferenciaService>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();
            services.AddScoped<IExtratoRepository, ExtratoRepository>();
            services.AddScoped<ISaqueRepository, SaqueRepository>();
            services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

            services.AddSingleton<IConfiguration>(provider => Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Conta Bancaria", Version = "v1", });
            });
        }

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
