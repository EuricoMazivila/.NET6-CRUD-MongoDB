using MongoDB.Driver;

namespace API.Extensions;

public static class DatabaseServicesExtensions
{
    public class MongoDbSettings
    {
        public string? ConnectionString {get; set;}
        public string? DatabaseName {get; set;}
    }
    
    public static IConfiguration? Configuration { get; set; }
    
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        Configuration = configuration;
        
        services.Configure<MongoDbSettings>(
            Configuration.GetSection("MongoDBSettings")
        );

        services.AddSingleton<IMongoDatabase>(options => {
            var settings = Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
            var client = new MongoClient(settings.ConnectionString);
            return client.GetDatabase(settings.DatabaseName);
        });
        
        return services;
    }
}