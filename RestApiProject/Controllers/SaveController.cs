using Microsoft.AspNetCore.Mvc;
using RestApiProject.Models;
using System.Text.Json;

namespace RestApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly string savePath = Path.Combine(Directory.GetCurrentDirectory(), "save.json");

        // POST /save
        [HttpPost]
        public IActionResult Save([FromBody] SaveData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(savePath, json);

            return Ok(new { message = "Save success!" });
        }

        // GET /save
        [HttpGet]
        public IActionResult Load()
        {
            if (!System.IO.File.Exists(savePath))
            {
                return NotFound(new { message = "No save file found" });
            }

            var json = System.IO.File.ReadAllText(savePath);
            var data = JsonSerializer.Deserialize<SaveData>(json);

            return Ok(data);
        }
    }
}
