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

            // Configuração da string de conexão para o banco de dados
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registro da interface e implementação do repositório
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

            // Registro do serviço TarefaServico
            builder.Services.AddScoped<TarefaServico>();

            // Habilitando CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()  // Permite qualquer origem
                          .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc)
                          .AllowAnyHeader(); // Permite qualquer cabeçalho
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // Configuração do Swagger/OpenAPI
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
