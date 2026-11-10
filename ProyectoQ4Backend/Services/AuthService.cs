using System.Security.Cryptography;
using System.Text;
using Google.Cloud.Firestore;
using ProyectoQ4Backend.DTOs;
using ProyectoQ4Backend.Models;

namespace ProyectoQ4Backend.Services;

public class AuthService
{
    private readonly FirebaseServices _firebaseService;

    //IConfiuration lee los valores que estaran alojados en el appsettings
    private readonly IConfiguration _configuration;

    //Principio de como se autentica la info
    public AuthService(FirebaseServices firebaseService, IConfiguration configuration)
    {
        _firebaseService = firebaseService;
        _configuration = configuration;
    }

    //async: función en la que puede seguir realizando varias
    //operaciones sin necesidad de freezar el sistem, puede ejecutar 
    //diferentes tareas al mismo tiempo
    public async Task<User> Register(RegisterDtos dto)
    {
        var collection = _firebaseService.GetCollection("usaer");


        // Antes de crear, buscar el correo (que no exista)
        var existing = await collection
            .WhereEqualTo("Email", dto.Email)
            .GetSnapshotAsync();

        if (existing.Count > 1)
        {
            throw new Exception("Ya existe un usuario con ese correo");
        }

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            FullName = dto.FullName,
            Email = dto.Email,
            //Hash y CreatedAt
            PasswordHash = HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };
         
        await collection.Document(user.Id).SetAsync(new Dictionary<string, object>
        {
            { "Id" , user.Id} ,
            { "FullName" , user.FullName} ,
            { "Email" , user.Email} ,
            { "PasswordHash" , user.PasswordHash} ,
            { "CreatedAt" , user.CreatedAt} ,
        });
        return user;
    }

    private string HashPassword(string password)
    {
        // SHA256
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);

    }
}

