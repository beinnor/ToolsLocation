#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolsLocation.Data;
using ToolsLocation.Models;
using ToolsLocation.Repository;

namespace ToolsLocation.Pages.Tools
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnGet()
        {
            

            IEnumerable<Location> locations = await _unitOfWork.Locations.GetAll();

            var temp = new List<object>();

            foreach (var location in locations)
            {
                temp.Add(new { LocationId = location.LocationId, Name = $"{location.ShelfName}-{location.ShelfFloor}"});
            }

            ViewData["LocationId"] = new SelectList(temp, "LocationId", "Name");
            return Page();
        }

        [BindProperty]
        public Tool Tool { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {          

           // Todo: Fix this later
           // if (!ModelState.IsValid)
           // {
           //     return Page();
           // }

            await _unitOfWork.Tools.Insert(Tool);
            await _unitOfWork.Save(HttpContext);

            return RedirectToPage("./Index");
        }
    }
}
