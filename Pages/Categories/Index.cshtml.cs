using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Berar_Denisa_Lab2.Data;
using Berar_Denisa_Lab2.Models;
using Berar_Denisa_Lab2.Models.ViewModels;

namespace Berar_Denisa_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Berar_Denisa_Lab2.Data.Berar_Denisa_Lab2Context _context;

        public IndexModel(Berar_Denisa_Lab2.Data.Berar_Denisa_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoriesData { get; set; } 
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoriesData = new CategoryIndexData();
            CategoriesData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(bc => bc.Book)
            .ThenInclude(b => b.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                //varianta asta apareau toate cartile tot timpul pe categorii
                /* CategoryID = id.Value;
                 Category category = CategoriesData.Categories
                 .Where(i => i.ID == id.Value).Single();
                 CategoriesData.Books = category.BookCategories
                     .Select(bc => bc.Book)
                     .ToList();*/

                CategoryID = id.Value;

                var selectedCategory = CategoriesData.Categories
                    .FirstOrDefault(i => i.ID == CategoryID);

                
                if (selectedCategory != null)
                {
                    CategoriesData.Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book)
                        .ToList();
                }
                else
                {
                    CategoriesData.Books = new List<Book>();
                }
            }
        }
    }
}

