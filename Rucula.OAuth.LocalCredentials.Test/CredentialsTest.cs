using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rucula.OAuth.LocalCredentials.WebApi;

namespace Rucula.OAuth.LocalCredentials.Test;

[TestClass]
public class CredentialsTest
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var builder = WebApplication.CreateBuilder();
                
        builder.AddLocalCredentials(options => {
            options.Services.AddDbContext<DbContext>();
        });
        
        var app = builder.Build();

        await app.RunAsync();
        
    }
}
