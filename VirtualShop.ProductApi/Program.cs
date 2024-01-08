using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;

namespace VirtualShop.ProductApi
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

            //var mySqlConnection = builder.Configuration.GetConnectionString("DataBase");

            //builder.Services.AddDbContext<AppDbContext>(options => 
            //                 options.UseMySql(mySqlConnection, 
            //                 ServerVersion.AutoDetect(mySqlConnection)));


            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>
                (
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            //builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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
