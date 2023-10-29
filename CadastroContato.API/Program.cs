using CadastroContato.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroContato.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            builder.Services.AddDbContext<APIDbContext>(option => option.UseMySql(
            connectionStringMysql,
            ServerVersion.Parse("8.0.34-mysql")));

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