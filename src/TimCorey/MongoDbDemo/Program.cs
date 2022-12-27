// See https://aka.ms/new-console-template for more information

using MongoDB.Driver;

string connectionString = "mongodb://127.0.0.1:27017";
string databaseName = "tim_corey";
string collectionName = "people";

MongoClient client = new(connectionString);
IMongoDatabase db = client.GetDatabase(databaseName);
IMongoCollection<PersonModel> collection = db.GetCollection<PersonModel>(collectionName);

PersonModel personModel = new() {FirstName = "Johnny", LastName = "Cage"};

await collection.InsertOneAsync(personModel);

IAsyncCursor<PersonModel> people = await collection.FindAsync(_ => true);

foreach (PersonModel person in people.ToList())
{
    Console.WriteLine($"{person.Id}: {person.FirstName} {person.LastName}");
}