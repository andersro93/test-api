using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        o =>
        {
            o.Authority = builder.Configuration["OIDC_ADDRESS"];
        });

builder.Services
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app
    .UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen();

app.Run();
