using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetWeb.API;

namespace ProjetWeb.Pages.Consoles
{
    public class CreateModel : PageModel
    {
        private readonly IConsoleJeus _console;

        public CreateModel(IConsoleJeus console)
        {
            _console = console;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _console.ConsoleJeusPOSTAsync(ConsoleJeu);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
