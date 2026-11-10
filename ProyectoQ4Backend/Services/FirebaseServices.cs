using Google.Cloud.Firestore;

namespace ProyectoQ4Backend.Services;

public class FirebaseServices
{
    private readonly FirestoreDb _firestoreDb;

    public FirebaseServices()
    {
        var credentialPath = Path.Combine(AppContext.BaseDirectory, "Config", "firebase-credentials.json");
        
        // Esta variable de entorno es la que usa el SDK (Software Development Kit)
        // es utilizada para saber dónde estan las credenciales
                 
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
        
        _firestoreDb = FirestoreDb.Create("web-759-q4-g1-vsma");
        
    }

    public CollectionReference GetCollection(string collectionName)
    {
        return _firestoreDb.Collection(collectionName);
    }
}