using Duende.IdentityServer.Models;
using System.Collections.Generic;

public static class Config
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new[]
        {
            new ApiScope("api1", "Authorized API"),
            new ApiScope("mobile_app", "Authorized Mobile App"),
            new ApiScope("web_app", "Authorized Web App")
        };

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "client_app",
                ClientName = "Aplicação Cliente",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1","mobile_app", "web_app" }
            }
        };
}
