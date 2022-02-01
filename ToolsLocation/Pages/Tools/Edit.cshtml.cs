#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolsLocation.Data;
using ToolsLocation.Models;
using ToolsLocation.Repository;

namespace ToolsLocation.Pages.Tools
{
    public class EditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public EditModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Tool Tool { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var includes = new List<string> { "Location" };

            Tool = await _unitOfWork.Tools.Get(m => m.ToolId == id, includes: includes);

            if (Tool == null)
            {
                return NotFound();
            }

            IEnumerable<Location> locations = await _unitOfWork.Locations.GetAll();

            var temp = new List<object>();

            foreach (var location in locations)
            {
                temp.Add(new { LocationId = location.LocationId, Name = $"{location.ShelfName}-{location.ShelfFloor}" });
            }

            ViewData["LocationId"] = new SelectList(temp, "LocationId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Todo: fix later
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _unitOfWork.Tools.Update(Tool);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ToolExists(Tool.ToolId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ToolExists(int id)
        {
            var tool = await _unitOfWork.Tools.Get(q => q.LocationId == id);
            return tool != null;
        }
    }
}
