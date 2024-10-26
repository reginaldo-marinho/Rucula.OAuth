namespace Rucula.OAuth.LocalCredentials.WebApi;

public class LocalCredentialsOptions
{
    public IServiceCollection Services;
    public ConfigurationManager Configuration;

    public LocalCredentialsOptions(WebApplicationBuilder webApplication)
    {
        this.Services = webApplication.Services;
        this.Configuration = webApplication.Configuration;
    }
}