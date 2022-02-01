#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolsLocation.Data;
using ToolsLocation.Models;
using ToolsLocation.Repository;

namespace ToolsLocation.Pages.Locations
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Location Location { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _unitOfWork.Locations.Get(m => m.LocationId == id);

            if (Location == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = await _unitOfWork.Locations.Get(m => m.LocationId == id);

            if (Location != null)
            {
                await _unitOfWork.Locations.Delete(Location.LocationId);
                await _unitOfWork.Save(HttpContext);
            }

            return RedirectToPage("./Index");
        }
    }
}
