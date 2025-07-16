namespace Tamagotchi_API.Domain.Entities
{
    public class ChecklistItem(string title, string description, bool isComplete)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; } = title;
        public string Description { get; private set; } = description;
        public bool IsComplete { get; private set; } = isComplete;
        public void SetIsComplete(bool isComplete)
        {
            IsComplete = isComplete;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }

    }
}
