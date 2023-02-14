using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using NodeApp.Entity.Entities;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net;

namespace NodeApp.UI.Controllers
{
    public class NoteController : Controller
    {
        private readonly HttpClient _httpClient;

        public NoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("http://localhost:5266/api/Note");
            var notes = JsonSerializer.Deserialize<IEnumerable<Note>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5266/api/note", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5266/api/note/{id}");
            response.EnsureSuccessStatusCode();

            var note = JsonSerializer.Deserialize<Note>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(note);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5266/api/note/{id}");
            response.EnsureSuccessStatusCode();
            var note = JsonSerializer.Deserialize<Note>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"http://localhost:5266/api/note/{id}", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5266/api/note/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle other possible HTTP errors
                return StatusCode((int)response.StatusCode);
            }
        }

    }
}
