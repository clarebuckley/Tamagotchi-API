using Microsoft.EntityFrameworkCore;
using Tamagotchi_API.Domain.Dto;

public class ChecklistItemContext : DbContext
{
    public DbSet<ChecklistItemDto> ChecklistItem { get; set; }
}