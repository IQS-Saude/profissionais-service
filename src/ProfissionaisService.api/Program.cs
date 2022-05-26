using ProfissionaisService.infra.Crosscutting.IoC.Configuration;
using ProfissionaisService.infra.Crosscutting.IoC.Configuration.Database;
using ProfissionaisService.infra.Crosscutting.IoC.Configuration.Swagger;

//TODO Renomear projetos
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDependencyInjection();

var app = builder.Build();

app.AddSwagger("profissionais");

app.UseHttpsRedirection();

app.UsePathBase(new PathString("/profissionais"));
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCors(policy =>
{
    policy.WithOrigins("*");
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
});

app.Run();