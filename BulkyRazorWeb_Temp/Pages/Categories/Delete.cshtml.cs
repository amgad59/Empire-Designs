using BulkyRazorWeb_Temp.Data;
using BulkyRazorWeb_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
    {

		private readonly ApplicationDbContext _db;
		public Category Category { get; set; }
		public DeleteModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult OnGet(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category = _db.Categories.FirstOrDefault(c => c.Id == id);
			if (Category == null)
			{
				return NotFound();
			}
			return Page();
		}
		public IActionResult OnPost()
		{
			Category? category = _db.Categories.FirstOrDefault(c => c.Id == Category.Id);
			_db.Categories.Remove(category);
			_db.SaveChanges();
			TempData["error"] = "category deleted";
			return RedirectToPage("/categories/Index");
		}
    }
}
