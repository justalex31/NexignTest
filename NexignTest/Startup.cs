using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NexignTest.Entity;
using NexignTest.Helper;
using NexignTest.Interfaces;
using NexignTest.Models;
using NexignTest.Models.Game;
using NexignTest.Repositories;
using NexignTest.Services;
using NexignTest.Validation;

namespace NexignTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Game>, GameRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepositoryExt<Round>, RoundRepository>();

            services.AddTransient<IHandler<JoinModel>, JoinGameHandler>();
            services.AddTransient<IHandler<CreateModel>, CreateGameHandler>();
            services.AddTransient<IHandler<TurnModel>, TurnGameHandler>();
            services.AddTransient<IHandler<StatModel, HttpResult>, StatGameHandler>();

            services.AddTransient<IValidation<JoinModel>, JoinModelValidation>();
            services.AddTransient<IValidation<CreateModel>, CreateModelValidation>();
            services.AddTransient<IValidation<TurnModel>, TurnModelValidation>();
            services.AddTransient<IValidation<StatModel>, StatModelValidation>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NexignTest", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NexignTest v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => 
                endpoints.MapControllers());
        }
    }
}
