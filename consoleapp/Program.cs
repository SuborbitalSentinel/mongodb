using MongoDB.Bson;
using MongoDB.Driver;

var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB_URI' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);
var collection = client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("movies");
var movie1Filter = Builders<BsonDocument>.Filter.Eq("title", "Back to the Future");
var movie2Filter = Builders<BsonDocument>.Filter.Eq("title", "Terminator");
var movie1 = collection.Find(movie1Filter).First();
var movie2 = collection.Find(movie2Filter).First();

Console.WriteLine($"movie1: {movie1}");
Console.WriteLine($"movie2: {movie2}");
