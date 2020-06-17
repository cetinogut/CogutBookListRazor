using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogutBookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CogutBookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> listeBooks { get; set; }
        public async Task OnGet()
        {
            listeBooks = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id) // Task IActionResult because we will be redirecting to the same page
        {
            var book = await _db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }



    }
}