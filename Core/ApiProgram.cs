using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WallyTest.Services;
using System;
using System.Threading.Tasks;
using WallyTest.Models;

public class ApiProgram
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var apiService = host.Services.GetRequiredService<ApisService>();

        try
        {
            var apiResponse = await apiService.GetUsersAsync();
            
            Console.WriteLine("Users");
            foreach (var user in apiResponse.Record.Users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, ID: {user.Id}");
            }
            
            Console.WriteLine("\nTickets:");
            foreach (var ticket in apiResponse.Record.Tickets)    
            {
                Console.WriteLine($"ID: {ticket.Id}, Priority: {ticket.Priority}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw;
        }
        
        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHttpClient<ApiService>();
            });
}