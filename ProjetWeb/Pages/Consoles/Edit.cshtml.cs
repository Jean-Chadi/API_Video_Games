using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWeb.API;

namespace ProjetWeb.Pages.Consoles
{
    public class EditModel : PageModel
    {
        private readonly IConsoleJeus _console;

        public EditModel(IConsoleJeus console)
        {
            _console = console;
        }

        [BindProperty]
        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consolejeu = await _console.ConsoleJeusGETAsync(id.Value);
            if (consolejeu == null)
            {
                return NotFound();
            }
            ConsoleJeu = consolejeu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _console.ConsoleJeusPUTAsync(ConsoleJeu.Id, ConsoleJeu);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
