using System.ComponentModel.DataAnnotations;

namespace Tamagotchi_API.Domain.Dto
{
    public class ChecklistItemDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set;  }
        public string Description { get; set; }
        public bool IsComplete { get; set;  }
    }
}
