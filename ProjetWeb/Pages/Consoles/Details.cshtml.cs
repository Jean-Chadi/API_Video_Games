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
    public class DetailsModel : PageModel
    {
        private readonly IConsoleJeus _console;

        public DetailsModel(IConsoleJeus console)
        {
            _console = console;
        }

        public ConsoleJeu ConsoleJeu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsoleJeu = await _console.ConsoleJeusGETAsync(id.Value);

            if(ConsoleJeu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
