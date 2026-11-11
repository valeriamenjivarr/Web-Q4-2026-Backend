﻿using System.IdentityModel.Tokens.Jwt;
 using System.Security.Claims;
 using System.Security.Cryptography;
using System.Text;
using Google.Cloud.Firestore;
using Microsoft.IdentityModel.Tokens;
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
        var collection = _firebaseService.GetCollection("user");


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

    public async Task<string> Login(LoginDtos dto)
    {
        var collection = _firebaseService.GetCollection("user");
        
        // Antes de crear, buscar el correo (que no exista)
        var snapshot = await collection
            .WhereEqualTo("Email", dto.Email)
            .GetSnapshotAsync();

        if (snapshot.Count == 0)
        {
            throw new Exception("Credenciales inválidas");
        }
        
        var data = snapshot.Documents[0].ToDictionary();

        var user = new User()
        {
            Id = data["Id"].ToString()!,
            FullName = data["FullName"].ToString()!,
            Email = data["Email"].ToString()!,
            PasswordHash = data["PasswordHash"].ToString()!,
            CreatedAt = ((Google.Cloud.Firestore.Timestamp)data["CreatedAt"]).ToDateTime()
        };

        if (!VerifyPassword(dto.Password, user.PasswordHash))
        {
            throw new Exception("Credenciales invalidas");
        }
        return GenerateToken(user);

    }

    private string GenerateToken(User user)
    {
        //Claims: datos que viajan dentro del token, genera una cadena de texto ramdom
        //donde viene la info del usuario
        
        var claims = new []
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
        };
        
        //La clave secreta firma el token, si alguien lo altera,
        //el servidor lo rechaza
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer : _configuration["Jwt:Issuer"], //quien genera el token?
            audience : _configuration["Jwt:Audience"], //para quien es el token?
            claims : claims,
            expires : DateTime.UtcNow.AddHours(8),
            signingCredentials : creds
            );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }


    private string HashPassword(string password)
    {
        // SHA256
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);

    }
}