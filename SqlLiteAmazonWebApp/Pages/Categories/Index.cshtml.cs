using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlLiteAmazonWebApp.Data;
using SqlLiteAmazonWebApp.Models;

namespace SqlLiteAmazonWebApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext _context;

        public IndexModel(SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categorie != null)
            {
                Categorie = await _context.Categorie.ToListAsync();
            }
        }
    }
}
