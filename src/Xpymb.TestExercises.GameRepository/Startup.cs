using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Xpymb.TestExercises.GameRepository.Configuration.AutoMapper;
using Xpymb.TestExercises.GameRepository.Data;
using Xpymb.TestExercises.GameRepository.Infrastructure;
using Xpymb.TestExercises.GameRepository.Infrastuture;

namespace Xpymb.TestExercises.GameRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), 
                    o => o.MigrationsAssembly(typeof(Startup).Assembly.FullName)));
            
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xpymb.TestExercises.GameRepository", Version = "v1" });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GameInfoProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddScoped<IDbRepository, EfDbRepository>();
            services.AddTransient<IGameInfoService, GameInfoService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xpymb.TestExercises.GameRepository v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}