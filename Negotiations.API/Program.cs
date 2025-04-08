using Negotiations.API.Extensions;
using Negotiations.API.Middleware;
using Negotiations.Application.Extensions;
using Negotiations.Domain.Entities;
using  Negotiations.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<Employee>();

app.UseAuthorization();

app.MapControllers();

app.Run();
