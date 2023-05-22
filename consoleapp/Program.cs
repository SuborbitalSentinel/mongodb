using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine(
        "You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable"
    );
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);
var collection = client.GetDatabase("sample_mflix").GetCollection<Movie>("movies");

var results = collection
    .Find(f => f.runtime < 100)
    .Sort(Builders<Movie>.Sort.Descending(f => f.runtime))
    .ToList();

results.ForEach(r => Console.WriteLine(r));

[BsonIgnoreExtraElements]
record Movie(
    string title,
    bool active,
    int year,
    int runtime,
    string[] genres,
    string director,
    string actors,
    string plot,
    string posterUrl
);
