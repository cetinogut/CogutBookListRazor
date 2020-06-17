using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CogutBookListRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace CogutBookListRazor
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id) // if we create a new book then id can be null so we put a ?
        {
            Book = new Book();
            if (id == null)
            {
                //create
                return Page(); // aynı sayfaya dönebilmes iiçin Task yanına IActionREsult ekledik...
            }

            //update
            Book = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);  //FinfAsync de aynı işi yapacaktı...
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Book.Id == 0)
                {
                    _db.Books.Add(Book);
                }
                else
                {
                    _db.Books.Update(Book); // bu update methodu EF Core içindedir.. herşeyi günceller.. Edit methodundaki gibi de te tek property ler ile de yapılabilir...
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}