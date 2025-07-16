using Microsoft.Data.SqlClient;
using Tamagotchi_API.Domain.Dto;
using Tamagotchi_API.Domain.Entities;
using Tamagotchi_API.Repositories;

namespace Tamagotchi_API.Services;

public interface IChecklistService
{
    Task<ChecklistItem> AddChecklistItemAsync(ChecklistItemDto name);
}

public class ChecklistService(ChecklistRepository checklistRepository) : IChecklistService
{
    public async Task<ChecklistItem> AddChecklistItemAsync(ChecklistItemDto checklistItem)
    {
        try
        {
            var newChecklistItem = new ChecklistItem(checklistItem.Title, checklistItem.Description, checklistItem.IsComplete);
            return await checklistRepository.AddNewChecklistItemAsync(newChecklistItem);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
            throw new Exception("SQL exception", e);
        }
    }
}