using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogutBookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CogutBookListRazor
{

    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] // once you bind the property, it is assumed that you'll get an objejt of book in OnPost method..
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost() // because we are redirecting to a new page
        {
            if (ModelState.IsValid) // checks validation.
            {
                await _db.Books.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}