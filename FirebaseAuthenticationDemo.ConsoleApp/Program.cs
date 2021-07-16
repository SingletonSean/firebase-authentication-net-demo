using Firebase.Auth;
using Refit;
using System;
using System.Threading.Tasks;

namespace FirebaseAuthenticationDemo.ConsoleApp
{
    class Program
    {
        private const string API_KEY = "AIzaSyBAMWRcYFY2awFzMmDiVdukxZvErKdNfJA";

        static async Task Main(string[] args)
        {
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));

            //FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("singletonsean@gmail.com", "test123", "SingletonSean");
            FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("singletonsean@gmail.com", "test123");

            Console.WriteLine(firebaseAuthLink.FirebaseToken);

            IDataService dataService = RestService.For<IDataService>("http://localhost:5000");
            await dataService.GetData(firebaseAuthLink.FirebaseToken);
        }
    }

    public interface IDataService
    {
        [Get("/")]
        Task GetData([Authorize("Bearer")] string token);
    }
}
