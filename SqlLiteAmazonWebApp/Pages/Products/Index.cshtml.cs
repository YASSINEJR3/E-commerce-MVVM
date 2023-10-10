using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlLiteAmazonWebApp.Data;
using SqlLiteAmazonWebApp.Models;

namespace SqlLiteAmazonWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext _context;

        public IndexModel(SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = default!;
        public SelectList? Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ProductCategory { get; set; }
        public async Task OnGetAsync()
        {
            
            IQueryable<string> categoryQuery = from m in _context.Categorie
                                                select m.Name;

            var products = from m in _context.Product.Include(p => p.Categorie)
                            select m;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                products = products.Where(p => p.Name == SearchTerm);
            }
            if (!string.IsNullOrEmpty(ProductCategory))
            {
                products = products.Where(p => p.Categorie.Name == ProductCategory);
            }
                
            Categories = new SelectList(await _context.Categorie.ToListAsync(), "Name", "Name");
            Product = await products.ToListAsync();


            
        }

        //Search
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("------------------------------------\n");
            Console.WriteLine(SearchTerm);            
            Console.WriteLine("------------------------------------\n");
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Product = await _context.Product.ToListAsync();
                
            }
            else
            {
                Product = await _context.Product.Where(p => p.Name.Contains(SearchTerm)).ToListAsync();
            }
            foreach (var product in Product)
            {
                product.Categorie = await _context.Categorie.FindAsync(product.CategoryId);
            }

            return Page();
        }
    }
}
