namespace Tamagotchi_API.Domain.Dto
{
    public class ChecklistItemDto(string title, string description, bool isComplete)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; } = title;
        public string Description { get; } = description;
        public bool IsComplete { get; } = isComplete;
    }
}
