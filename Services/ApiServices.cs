using Newtonsoft.Json;
using Core.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services;

public class ApiService(HttpClient httpClient)
{
    public async Task<User> GetUser(int id)
    {
        var response = await httpClient.GetAsync($"api/user/{id}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<User>(jsonResponse);
    }

    public async Task<Tickets> GetTicket(int id)
    {
        var response = await httpClient.GetAsync($"api/ticket/{id}");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Tickets>(jsonResponse);
    }

    public async Task<List<User>> GetAllUsers()
    {
        var response = await httpClient.GetAsync("/getAllUser");
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<User>>(jsonResponse);
    }
    
    /*public async Task<ApiResponse> GetUsersAsync()
{
    _httpClient.DefaultRequestHeaders.Add("X-Access-Key", "$2a$10$B27YEKYz4UFtpGWJw3ETHOeWq.3aQhLQuosXho6mMzawJC5veV70i");
    var response = await _httpClient.GetAsync("https://api.jsonbin.io/v3/b/66f32e7cad19ca34f8ac31b5");

    if (response.IsSuccessStatusCode)
    {
        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ApiResponse>(json);
    }
    else
    {
        throw new HttpRequestException($"Error fetching data: {response.StatusCode}")
    }
}*/
}