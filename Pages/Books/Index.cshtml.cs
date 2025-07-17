using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public class BooksIndexModel : PageModel
{
    public List<Book> Books { get; set; } = new();

    public void OnGet()
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Books", "books.json");
        if (System.IO.File.Exists(jsonPath))
        {
            var json = System.IO.File.ReadAllText(jsonPath, System.Text.Encoding.UTF8);
            Books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
    }
}
