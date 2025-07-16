using Microsoft.AspNetCore.Mvc;
using Tamagotchi_API.Domain.Dto;
using Tamagotchi_API.Services;

namespace Tamagotchi_API.Controllers
{
    [ApiController]
    [Route(Routes.Checklist)]
    public class ChecklistController : ControllerBase
    {
        private readonly ILogger<ChecklistController> _logger;
        private readonly IChecklistService _checklistService;

        public ChecklistController(ILogger<ChecklistController> logger, IChecklistService checklistService)
        {
            _logger = logger;
            _checklistService = checklistService;
        }

        [HttpPost]
        public async Task<IActionResult> PostChecklistItem(ChecklistItemDto checklistItem)
        {
            await _checklistService.AddChecklistItemAsync(checklistItem);
            return Created();
        }
    }
}