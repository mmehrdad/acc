using Acc.Api.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Acc.Infrastructure.DBContexts;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Acc.Infrastructure.Helper;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.WebHost.ConfigureKestrel(
    (context, options) =>
    {
        options.Configure(context.Configuration.GetSection("Kestrel"));
    });

//AppDomain.CurrentDomain.GetAssemblies()

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

LoggerFactory m = new();

builder.Services.AddSingleton<AutoMapper.IConfigurationProvider>(sp =>
{
    return new MapperConfiguration(cfg =>
    {
        cfg.AddMaps(typeof(Program).Assembly);
    },m);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            //.WithOrigins("http://localhost",
            //               "http://localhost:4200",
            //                "http://172.30.240.36")

            .AllowAnyMethod()
            .AllowAnyHeader();
            // .WithMethods("GET", "POST", "PUT", "DELETE"); ;
            // builder.WithOrigins("http://pbackend.";
            //.SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});

string conn = AppConfig.GetConnectionString("WebRazorDatabase");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InjectDependency();
builder.Services.AddDbContext<AccDbContext>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Amlak API", Version = "v1" });
    c.CustomSchemaIds(type => type.FullName);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
        new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }});

});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();

app.UseCors("MyAllowSpecificOrigins");





app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client.");
    });

});

app.UseSwagger(c =>
{
    //c.RouteTemplate = "v1/swagger/{documentName}/swagger.json";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint("v1/swagger.json", "Amlak API v1");

    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
