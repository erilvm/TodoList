using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Database.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public class FirebaseDataService : IDataService
    {
        public List<Tarea> Tasks { get; set; } = new();

        FirebaseClient firebaseClient;


        public FirebaseDataService()
        {
            firebaseClient = new FirebaseClient("https://to-do-list-641f8-default-rtdb.firebaseio.com/");
            firebaseClient
                .Child("Todo")
                .AsObservable<Tarea>()
                .Subscribe(item => Tasks.Add(item.Object));

        }

        public async Task AddTask(Tarea tarea)
        {
            await firebaseClient.Child("Todo").PostAsync(tarea);
        }

        public List<Tarea> GetTasks()
        {
            return Tasks;
        }
    }
}