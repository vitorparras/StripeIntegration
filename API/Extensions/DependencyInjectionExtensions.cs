using Application.Services;
using Application.Services.Interfaces;

namespace API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            builder.Services
              .AddEndpointsApiExplorer()
              .AddSwaggerGen();

            builder.ConfigureContext();
            builder.ConfigureRepositories();
            builder.ConfigureServices();
            builder.ConfigureSwagger();
            builder.ConfigureCors();

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            
            return builder;
        }

        public static void ConfigureMiddlewares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.ImplementMigrations();
        }

        public static void ImplementMigrations(this WebApplication app)
        {
          /*  using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SchedulerContext>();
            dbContext.Database.Migrate();*/
        }

        public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            return builder;
        }

        public static WebApplicationBuilder ConfigureRepositories(this WebApplicationBuilder builder)
        {

            return builder;
        }

        public static WebApplicationBuilder ConfigureContext(this WebApplicationBuilder builder)
        {
            /*  var connString = builder.Configuration.GetConnectionString("SqlServer");
              builder.Services.AddDbContext<SchedulerContext>(options => options
                  .UseSqlServer(connString)
                  .EnableSensitiveDataLogging());*/
            return builder;
        }

        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStripeService, StripeService>();

            return builder;
        }
    }
}
