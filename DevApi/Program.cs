using DevApi;
using DevApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationService();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:83", "http://localhost:86", "https://68.178.164.44:82", "http://68.178.164.44:86", "http://68.178.164.44:91", "https://68.178.164.44:91", "http://dhanvatikaa.dvprop.co.in", "https://dhanvatikaa.dvprop.co.in")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(m => m.Value.Errors.Count > 0)
                .Select(m => new {
                    Field = m.Key,
                    Error = m.Value.Errors.First().ErrorMessage
                });

            return new BadRequestObjectResult(new
            {
                Message = "Invalid request",
                Errors = errors
            });
        };
    });


var app = builder.Build();

// === ORDER MATTERS ===

// Enable Swagger
app.UseSwagger(); // this must come BEFORE UseSwaggerUI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // access via /swagger
});

// Uncomment only if you want HTTPS
// app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.UseMiddleware<SessionValidationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();



app.Run();
