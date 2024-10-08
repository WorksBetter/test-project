using MongoDB.Driver;
using Microsoft.Extensions.Options;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var settings = mongoDbSettings.Value; // Assigning the value to a local variable
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);

        // Create compound index during initialization
        CreateIndexes(settings);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");

    private void CreateIndexes(MongoDbSettings settings)
    {
        var indexKeysDefinition = Builders<User>.IndexKeys.Combine(
            Builders<User>.IndexKeys.Ascending(u => u.Name),
            Builders<User>.IndexKeys.Ascending(u => u.Email)
        );

        // Ensure the index exists on the "Users" collection
        Users.Indexes.CreateOne(new CreateIndexModel<User>(indexKeysDefinition));
    }
}