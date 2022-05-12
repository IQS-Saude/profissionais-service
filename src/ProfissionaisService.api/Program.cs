using Microsoft.OpenApi.Models;
using ProfissionaisService.infra.Crosscutting.IoC.Configuration;
using ProfissionaisService.infra.Crosscutting.IoC.Configuration.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseSwagger(swagger =>
{
    swagger.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
    {
        swaggerDoc.Servers = new List<OpenApiServer>
            { new() { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}/profissionais" } };
    });
});
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UsePathBase(new PathString("/profissionais"));
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();