using MongoDB.Bson;
using MongoDB.Driver;

internal class Program 
{
    static IMongoClient client;
    static IMongoDatabase database;
    static IMongoCollection<BsonDocument> collection;

    static void Main(string[] args)
    {
        // --- Dein Program einfach hier reinschreiben ---

        client = new MongoClient("mongodb://localhost:27017");
        Console.WriteLine("Verbunden mit MongoDB-Server");

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("===== MongoDB Menü =====");
            Console.WriteLine("[1] Datenbanken anzeigen");
            Console.WriteLine("[2] Datenbank auswählen oder erstellen");
            Console.WriteLine("[3] Collections anzeigen");
            Console.WriteLine("[4] Collection auswählen oder erstellen");
            Console.WriteLine("[5] Dokumente einfügen");
            Console.WriteLine("[6] Dokumente anzeigen");
            Console.WriteLine("[7] Einzelnes Dokument löschen");
            Console.WriteLine("[0] Beenden");

            Console.Write("\nAuswahl: ");

            var input = Console.ReadLine().Trim();

            switch (input)
            {
                case "1":
                    ListDatabases();
                    break;
                case "2":
                    SelectOrCreateDatabase();
                    break;
                case "3":
                    ListCollections();
                    break;
                case "4":
                    SelectOrCreateCollection();
                    break;
                case "5":
                    InsertDocument();
                    break;
                case "6":
                    DisplayDocument();
                    break;
                case "7":
                    DeleteSingleDocument();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Programm wird beendet...");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nDrücken Sie eine Taste, um fortzufahren...");
                Console.ReadKey();
            }
        }

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

    static void SelectOrCreateCollection()
    {
        if (database == null)
        {
            Console.WriteLine("Bitte eine Datenbank auswählen soll");
            return;
        }

        Console.WriteLine("\nGeben Sie den Namen der Collection ein");
        var colName = Console.ReadLine().Trim();
        collection = database.GetCollection<BsonDocument>(colName);
        Console.WriteLine($"Collection '{colName}' ausgewählt. (oder bei Bedarf erstellt)");
    }

    static void InsertDocument()
    {
        if (collection == null)
        {
            Console.WriteLine("Bitte eine Collection auswählen");
            return;
        }

        Console.WriteLine("\nGeben Sie den Name ein: ");
        var name = Console.ReadLine().Trim();

        Console.WriteLine("\nGeben Sie das Alter ein: ");
        var alterInput = Console.ReadLine().Trim();
        int alter = int.TryParse(alterInput, out var parsedAlter) ? parsedAlter : 0;

        var dokument = new BsonDocument
        {
            { "Name", name },
            { "Alter", alter }
        };

        collection.InsertOne(dokument);
        Console.WriteLine("Dokument erfolgreich eingefügt");    
    }

    static void DisplayDocument()
    {
        if (collection == null)
        {
            Console.WriteLine("Bitte eine Collection auswählen");
            return;
        }

        var document = collection.Find(new BsonDocument()).ToList();
        Console.WriteLine("\nAlle Dokumente");
        foreach (var doc in document)
        {
            Console.WriteLine(doc.ToString());
        }
    }

    static void DeleteSingleDocument()
    {
        if (collection == null)
        {
            Console.WriteLine("Bitte zuerst eine Collection auswählen");
            return;
        }

        Console.Write("\ngebe Sie den Namen des zu löschenden Dokuments ein: ");
        var name = Console.ReadLine().Trim();

        var filter = Builders<BsonDocument>.Filter.Eq("Name", name);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount > 0)
            Console.WriteLine($"Dokument '{name}' erfolgreich gelöscht");
        else
            Console.WriteLine($"Dokument '{name}' nicht gefunden");
    }

}
