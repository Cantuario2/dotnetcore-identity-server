using Duende.IdentityServer;
using Duende.IdentityServer.Services; //CORS resolution
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
    {
        options.EmitStaticAudienceClaim = true;
    })
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddDeveloperSigningCredential()
    .AddCorsPolicyService<CustomCorsPolicyService>(); //CORS resolution

builder.Services.AddTransient<ICorsPolicyService, CustomCorsPolicyService>(); //CORS resolution

 //CORS resolution
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterWeb",
        policy => policy.WithOrigins("http://localhost:60553")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
//CORS resolution
 
var app = builder.Build();

app.UseRouting();
app.UseIdentityServer();

app.UseCors("AllowFlutterWeb"); //CORS resolution

app.MapGet("/", () => "IdentityServer running...");

app.Run();