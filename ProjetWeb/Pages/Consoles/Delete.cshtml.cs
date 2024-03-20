using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetWeb.API;

namespace ProjetWeb.Pages.Consoles
{
    public class DeleteModel : PageModel
    {
        private readonly IConsoleJeus _console;

        public DeleteModel(IConsoleJeus console)
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
            else
            {
                ConsoleJeu = consolejeu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                await _console.ConsoleJeusDELETEAsync(id.Value);
            }
            catch (Exception ex)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}
