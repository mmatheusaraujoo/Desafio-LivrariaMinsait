using LivrariaApi.Data;
using LivrariaApi.Profiles;
using LivrariaApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LivrariaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LivrariaDataContext>();

            // Add services to the container.
            
            builder.Services.AddScoped<LivroService>();
            builder.Services.AddScoped<AutorService>();
            builder.Services.AddAutoMapper(typeof(LivroProfile));
            builder.Services.AddAutoMapper(typeof(AutorProfile));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}