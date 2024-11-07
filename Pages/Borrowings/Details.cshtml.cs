using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Berar_Denisa_Lab2.Data;
using Berar_Denisa_Lab2.Models;

namespace Berar_Denisa_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Berar_Denisa_Lab2.Data.Berar_Denisa_Lab2Context _context;

        public DetailsModel(Berar_Denisa_Lab2.Data.Berar_Denisa_Lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var borrowing = await _context.Borrowing
            .Include(b => b.Member)  
            .Include(b => b.Book)
            .ThenInclude(book => book.Author)
            .FirstOrDefaultAsync(m => m.ID == id);

            if (borrowing == null)
            {
                return NotFound();
            }
            else
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
