using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public class BookDetailsModel : PageModel
{
    public Book? Book { get; set; }

    public IActionResult OnGet(int id)
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Books", "books.json");
        if (System.IO.File.Exists(jsonPath))
        {
            var json = System.IO.File.ReadAllText(jsonPath, System.Text.Encoding.UTF8);
            var books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            Book = books.Find(b => b.Id == id);
            if (Book == null)
                return NotFound();
        }
        else
        {
            return NotFound();
        }
        return Page();
    }
}
