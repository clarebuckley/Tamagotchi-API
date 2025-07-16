using Tamagotchi_API.Data;
using Tamagotchi_API.Domain.Entities;

namespace Tamagotchi_API.Repositories
{
    public class ChecklistRepository
    {
        private ChecklistContext _context;

        public ChecklistRepository(ChecklistContext context) {
            _context = context;
        }

        public async Task<ChecklistItem> AddNewChecklistItemAsync(ChecklistItem newChecklistItem) {
            var checklistItem = await _context.ChecklistItem.AddAsync(newChecklistItem);
            await _context.SaveChangesAsync();
            return checklistItem.Entity;
        }
    }
}
