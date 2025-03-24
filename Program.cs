using ListaTarefasAPI.Aplicacao;
using ListaTarefasAPI.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefasAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o da string de conex�o para o banco de dados
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registro da interface e implementa��o do reposit�rio
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

            // Registro do servi�o TarefaServico
            builder.Services.AddScoped<TarefaServico>();

            // Habilitando CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  // Permite qualquer origem
                          .AllowAnyMethod()  // Permite qualquer m�todo HTTP (GET, POST, etc)
                          .AllowAnyHeader(); // Permite qualquer cabe�alho
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // Configura��o do Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAll");

            app.UseStaticFiles();

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
