using Duende.IdentityServer.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class CustomCorsPolicyService : ICorsPolicyService
{
    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        // Adicione aqui as origens permitidas
        var allowedOrigins = new[]
        {
            "http://localhost:60553"
        };

        var isAllowed = allowedOrigins.Contains(origin);
        return Task.FromResult(isAllowed);
    }
}