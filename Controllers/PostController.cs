using System.Net.Http.Json;
using HospitalAppointmentManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentManagement.Controllers;

public class PostController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PostController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("JsonPlaceholder");
        var posts = await client.GetFromJsonAsync<List<PostItem>>("posts") ?? new List<PostItem>();
        return View(posts);
    }
}
