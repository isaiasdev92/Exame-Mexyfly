using MexiFly.Infrastructure;
using MexiFly.Application;
using Newtonsoft.Json.Serialization;
using MexiFly.Services.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy()
        {
            OverrideSpecifiedNames = true
        }
    };

});

builder.Services.AddMvc();

builder.Services.AddRouting(opt =>  
{
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInjectionInfrastructure(builder.Configuration);
builder.Services.AddInjectionApplication(builder.Configuration);

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MiddlewareMexiFly>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
