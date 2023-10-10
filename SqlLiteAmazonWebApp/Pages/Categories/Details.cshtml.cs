﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext _context;

        public DetailsModel(SqlLiteAmazonWebApp.Data.SqlLiteAmazonWebAppContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
