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

        public List<ChecklistItem> GetAllChecklistItemsAsync()
        {
            return _context.ChecklistItem.ToList();
        }

        public ChecklistItem GetChecklistItem(Guid id)
        {
            var item = _context.ChecklistItem.FirstOrDefault(x => Guid.Equals(x.Id, id));
            if (item == null)
            {
                throw new Exception("Not found");
            }
            return item;
        }

        public async Task<ChecklistItem> UpdateChecklistItemAsync(ChecklistItem existingChecklistItem)
        {
            var result = _context.ChecklistItem.Update(existingChecklistItem);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteChecklistItemAsync(Guid id)
        {
            var match = _context.ChecklistItem.FirstOrDefault(x => Guid.Equals(x.Id, id));
            if(match == null)
            {
                throw new Exception("no match found");
            }
            _context.ChecklistItem.Remove(match);
            await _context.SaveChangesAsync();
        }
    }

}
