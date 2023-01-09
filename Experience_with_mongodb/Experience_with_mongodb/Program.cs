
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

MongoClient client=new MongoClient("mongodb://localhost:27017");
var db = client.GetDatabase("social");


var collection = db.GetCollection<Person>("users");
var builder = Builders<Person>.Filter;

var filter = builder.All("languages", new BsonArray {"english", "spanish"});

var sortDefinition = Builders<Person>.Sort.Ascending("name").Descending("age");
var users = await collection.Find("{}").Sort(sortDefinition).ToListAsync();

foreach(var i in users)
{
  //  Console.WriteLine(i.name+"   "+i.age+" ");

    Console.WriteLine(i.name+  "    "+ i.age);
}
[BsonIgnoreExtraElements]
class Person
{
    public ObjectId _id { get; set; }
    public string name { get; set; } = "";
    public int age { get; set; }
    List<string>? languages { get; set; }
}