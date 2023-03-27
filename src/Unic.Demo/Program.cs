using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Unic.Core.Cryptography;
using Unic.Core.TokenAuthorization;
using Unic.Core.UseCases;
using Unic.Demo.Utils;
using Unic.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.IgnoreNullValues = true;
});
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddUseCases();
builder.Services.AddTokenAuthorization();
builder.Services.AddHashing();

// disabling validations - only for demo purposes, to be avoided in production
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = false,
            ValidateIssuerSigningKey = false, RequireSignedTokens = false,
            SignatureValidator = (token, parameters) => new JwtSecurityToken(token)
        };
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c => {

        OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            BearerFormat = "JWT",
            Scheme = "Bearer",
            Description = "Specify the authorization token (tip: generate the token using the Authentication endpoint)",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
        };
        c.AddSecurityDefinition("Bearer", securityDefinition);
        c.OperationFilter<SwaggerOperationFilter>();
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Services.InitializeDatabase();
app.Run();
