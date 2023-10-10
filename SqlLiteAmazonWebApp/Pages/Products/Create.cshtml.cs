using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SqlLiteAmazonWebApp.Data;
using SqlLiteAmazonWebApp.Models;

namespace SqlLiteAmazonWebApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext _context;

        public CreateModel(SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Categorie>(), "Id", "Name");
            Console.WriteLine(_context.Set<Categorie>().ToList());
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // associe la catégorie au produit
            Categorie category = _context.Categorie.Where(c => c.Id == Product.CategoryId).FirstOrDefault();
            Product.Categorie = category;
            /*Console.WriteLine("ModelState " + ModelState.IsValid);
            if (!ModelState.IsValid || _context.Product == null || Product == null)
            {
                return Page();
            }*/
            // récupère l'image
            if (Product.Image != null)
            {
                var fileName = Path.GetFileName(Product.Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Product.Image.CopyToAsync(stream);
                }
                Product.ImageUrl = fileName;
            }
            Console.WriteLine(Product.Image == null);
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
