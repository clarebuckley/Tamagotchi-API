using Microsoft.Data.SqlClient;
using Tamagotchi_API.Domain.Dto;
using Tamagotchi_API.Domain.Entities;
using Tamagotchi_API.Repositories;

namespace Tamagotchi_API.Services;

public interface IChecklistService
{
    Task<ChecklistItem> AddChecklistItemAsync(ChecklistItemDto item);
    List<ChecklistItemDto> GetAllChecklistItems();
    ChecklistItemDto GetChecklistItemById(Guid id);
    Task<ChecklistItem> UpdateChecklistItem(ChecklistItemDto item);
    Task DeleteChecklistItem(Guid id);
}

public class ChecklistService(ChecklistRepository checklistRepository) : IChecklistService
{
    private List<ChecklistItemDto> _cachedChecklistItems;

    public async Task<ChecklistItem> AddChecklistItemAsync(ChecklistItemDto checklistItem)
    {
        try
        {
            var newChecklistItem = new ChecklistItem(checklistItem.Title, checklistItem.Description, checklistItem.IsComplete);
            newChecklistItem.Id = Guid.NewGuid();
            return await checklistRepository.AddNewChecklistItemAsync(newChecklistItem);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            throw new Exception("SQL exception", e);
        }
    }

    public List<ChecklistItemDto> GetAllChecklistItems()
    {
        try
        {
            var response = checklistRepository.GetAllChecklistItemsAsync();
            var result = response.Select(x => new ChecklistItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsComplete = x.IsComplete
            }).ToList();

            if (_cachedChecklistItems == null)
            {
                _cachedChecklistItems = result;
            }

            return result;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            throw new Exception("SQL exception", e);
        }
    }

    public ChecklistItemDto GetChecklistItemById(Guid id)
    {
        var response = checklistRepository.GetChecklistItem(id);
        return new ChecklistItemDto()
        {
            Id = response.Id,
            Description = response.Description,
            Title = response.Title,
            IsComplete = response.IsComplete
        };
    }

    public async Task<ChecklistItem> UpdateChecklistItem(ChecklistItemDto updatedDto)
    {
        var updatedItem = new ChecklistItem(updatedDto.Title, updatedDto.Description, updatedDto.IsComplete);
        updatedItem.Id = updatedDto.Id;
        return await checklistRepository.UpdateChecklistItemAsync(updatedItem);
    }

    public async Task DeleteChecklistItem(Guid id)
    {
        await checklistRepository.DeleteChecklistItemAsync(id);
    }
}