using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Services;
using Core.Models;

namespace Api;

public class Worker : BackgroundService
{
    private readonly ApiService _apiService;

    public Worker(ApiService apiService)
    {
        _apiService = apiService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var user = await _apiService.GetUser(1);
            if (user != null)
            {
                Console.WriteLine($"Usuario: {user.name}, Email: {user.email}");
            }
            
            var ticket = await _apiService.GetTicket(1);
            if (ticket != null)
            {
                Console.WriteLine($"Ticket Id: {ticket.Id}, Prioridad: {ticket.Priority}");
            }
            
            var users = await _apiService.GetUsers();
            foreach (var u in users)
            {
                Console.WriteLine($"Usuario: {u.name}");
            }
            
            await Task.Delay(60000, stoppingToken);
        }
    }
}