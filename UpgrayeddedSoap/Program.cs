using SoapCore;
using UpgrayeddedSoap.SoapCalls;
using static SoapCore.DocumentationWriter.SoapDefinition;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddSoapCore();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICustomerService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();
