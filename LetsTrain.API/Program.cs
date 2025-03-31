using LetsTrain.API.Model;
using LetsTrain.API.Repositories.Aluno;
using LetsTrain.API.Repositories.Aula;
using LetsTrain.API.Repositories.Exercicio;
using LetsTrain.API.Repositories.Exercicios;
using LetsTrain.API.Repositories.Professor;
using LetsTrain.API.Repositories.Treino;
using LetsTrain.API.Services.Aluno;
using LetsTrain.API.Services.Aula;
using LetsTrain.API.Services.Exercicio;
using LetsTrain.API.Services.Professor;
using LetsTrain.API.Services.Treino;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro de dependências
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAulaService, AulaService>();
builder.Services.AddScoped<IAulaRepository, AulaRepository>();
builder.Services.AddScoped<IExercicioService, ExercicioService>();
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITreinoService, TreinoService>();
builder.Services.AddScoped<ITreinoRepository, TreinoRepository>();


builder.Services.AddDbContext<LetsTrainDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);

var app = builder.Build();

app.UseCors(options =>
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
);

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
