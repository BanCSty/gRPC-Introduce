using System;
using System.Threading.Tasks;
using gRPC.Client;
using Grpc.Net.Client;

class Program
{
    static async Task Main(string[] args)
    {
        // Установите адрес вашего gRPC сервера
        var channel = GrpcChannel.ForAddress("https://localhost:7161");

        // Создайте клиентский объект
        var client = new UserService.UserServiceClient(channel);

        // Пример вызова метода CreateUser
        var createUserResponse = await client.CreateUserAsync(new User
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Test User5"
        });
        Console.WriteLine("CreateUser: Completed");

        // Пример вызова метода GetAllUsers
        var users = await client.GetAllUsersAsync(new Empty());
        foreach (var user in users.Users)
        {
            Console.WriteLine($"User: {user.Id}, {user.Name}");
        }

        // Пример вызова метода GetUserDetails
        var userDetails = await client.GetUserDetailsAsync(new UserRequest
        {
            Id = users.Users[0].Id
        });
        Console.WriteLine($"UserDetails: {userDetails.Id}, {userDetails.Name}");

        // Пример вызова метода UpdateUser
        var updateUserResponse = await client.UpdateUserAsync(new User
        {
            Id = users.Users[0].Id,
            Name = "Updated Test User"
        });
        Console.WriteLine("UpdateUser: Completed");

        // Пример вызова метода DeleteUser
        var deleteUserResponse = await client.DeleteUserAsync(new UserRequest
        {
            Id = users.Users[0].Id
        });
        Console.WriteLine("DeleteUser: Completed");
    }
}
