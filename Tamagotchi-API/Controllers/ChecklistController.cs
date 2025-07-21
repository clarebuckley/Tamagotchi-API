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
            try
            {
                await _checklistService.AddChecklistItemAsync(checklistItem);
                return Created();
            }
            catch(Exception ex)
            {
                throw new Exception("Error",ex);
            }
        }

        [HttpGet]
        public List<ChecklistItemDto> GetChecklistItems()
        {
            try
            {
                var response = _checklistService.GetAllChecklistItems();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpGet("{id:Guid}")]
        public ChecklistItemDto GetChecklistItem(Guid id)
        {
            try
            {
                var response = _checklistService.GetChecklistItemById(id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateChecklistItem(ChecklistItemDto checklistItem)
        {
            try
            {
                await _checklistService.UpdateChecklistItem(checklistItem);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteChecklistItem(Guid id)
        {
            try
            {
                await _checklistService.DeleteChecklistItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}