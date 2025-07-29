using System.ComponentModel.DataAnnotations;

namespace Tamagotchi_API.Domain.Entities
{
    public class TamagotchiItem(string name)
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; private set; } = name;
        public string Age { get; private set; }
        public int Happiness { get; private set; } = 0;

        public void SetAge(string age)
        {
            Age = age;
        }
        public void IncreaseHappiness()
        {
            Happiness++;
        }
        public void DecreaseHappiness()
        {
            Happiness--;
        }
    }
}
