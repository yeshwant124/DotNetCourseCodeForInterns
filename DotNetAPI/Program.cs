
namespace DotNetAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors((options) =>
                {
                    options.AddPolicy("DevCors", (corsBuilder) =>
                    {
                        corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
                    options.AddPolicy("ProdCors", (corsBuilder) =>
                    {
                        corsBuilder.WithOrigins("https://myProductionSite.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // SwaggerUI will be false in production app.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("DevCors");
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseCors("ProdCors");
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}