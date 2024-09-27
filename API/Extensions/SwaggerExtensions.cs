namespace API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Stripe Integration API", Version = "v1" });
                c.EnableAnnotations();
            });
        }
    }
}
