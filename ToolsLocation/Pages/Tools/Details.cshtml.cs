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

namespace ToolsLocation.Pages.Tools
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

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
            return Page();
        }
    }
}
