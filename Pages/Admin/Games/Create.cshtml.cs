using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cybergames.Models;
using Cybergames.Data;
#nullable disable

namespace Cybergames.Pages.Admin.Games
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; }

        public SelectList CategoryOptions { get; set; }

        public void OnGet()
        {
            CategoryOptions = new SelectList(new[]
            {
                "Action",
                "Adventure",
                "Arcade",
                "Casual",
                "Fighting",
                "FPS",
                "Platform",
                "Puzzle",
                "Racing",
                "RPG",
                "Simulation",
                "Sports",
                "Strategy"
            });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the category options if the model is invalid
                CategoryOptions = new SelectList(new[]
                {
                    "Action",
                    "Adventure",
                    "Arcade",
                    "Casual",
                    "Fighting",
                    "FPS",
                    "Platform",
                    "Puzzle",
                    "Racing",
                    "RPG",
                    "Simulation",
                    "Sports",
                    "Strategy"
                });
                return Page();
            }

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}