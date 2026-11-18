using ProyectoQ4Backend.DTOs;
using ProyectoQ4Backend.Models;

namespace ProyectoQ4Backend.Services;

public class TaskServices
{
    private readonly FirebaseServices _firebaseService;

    //Inyección de dependecnias
    public TaskServices(FirebaseServices firebaseService)
    {
        _firebaseService = firebaseService;
    }

    public async Task<TaskItem> Create(TaskDto dto, string userId)
    {
        var task = new TaskItem()
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        await _firebaseService.GetCollection("task")
            .Document(task.Id)
            .SetAsync(new Dictionary<string, object>
            {
                { "Id", task.Id },
                { "Title", task.Title },
                { "Description", task.Description },
                { "Priority", task.Priority },
                { "UserId", userId },
                { "CreatedAt", task.CreatedAt }
            });
        return task;
    }

    public async Task<List<TaskItem>> GetByUser(string userId)
    {
        //snapshot: busca en la base de datos,capturar lo que tiene en ese momento
        //y retorna un objeto de tipo colección o lista
        var snapshot = await _firebaseService.GetCollection("task")
            .WhereEqualTo("UserId", userId)
            .GetSnapshotAsync();

        var task = new List<TaskItem>();

        foreach (var doc in snapshot.Documents)
        {
            var data = doc.ToDictionary();
            task.Add(new TaskItem
            {
                Id = data["Id"].ToString()!,
                Title = data["Title"].ToString()!,
                Description = data["Description"].ToString()!,
                Priority = data["Priority"].ToString()!,
                UserId = data["userId"].ToString()!,
                CreatedAt = ((Google.Cloud.Firestore.Timestamp)data["CreatedAt"]).ToDateTime()
            });
        }

        return task;
    }
}
