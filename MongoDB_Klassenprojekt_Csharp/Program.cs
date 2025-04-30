using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Linq;

internal class Program 
{
    static IMongoClient client;
    static IMongoDatabase database;
    static void Main(string[] args)
    {
        // --- Dein Program einfach hier reinschreiben ---

        client = new MongoClient("mongodb://localhost:27017");
        Console.WriteLine("Verbunden mit MongoDB-Server");

        ListDatabases();
        SelectOrCreateDatabase();
        ListCollections();

        // -----------------------------------------------
    }


    static void ListDatabases()
    {
        var databases = client.ListDatabaseNames().ToList();
        Console.WriteLine("\nVerfügbare Datenbanken: ");
        foreach (var db in databases)
        {
            Console.WriteLine($"- {db}");
        }
    }


    static void SelectOrCreateDatabase()
    {
        Console.WriteLine("\nGeben Sie den Namen der Datenbank ein");
        var dbName = Console.ReadLine().Trim();
        database = client.GetDatabase(dbName);
        Console.WriteLine($"Datanbank '{dbName}' wurde ausgewählt oder wird erstellt");
    }


    static void ListCollections()
    {
        if (database == null)
        {
            Console.WriteLine("Bitte eine Datenbank auswählen soll");
            return;
        }

        var collections = database.ListCollectionNames().ToList();
        Console.WriteLine("\nVerfügbare Sammlungen: ");
        foreach (var col in collections)
        {
            Console.WriteLine($"- {col}");
        } 
    }


}
