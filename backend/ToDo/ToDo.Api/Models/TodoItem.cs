namespace ToDo.Api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }           // Foreign Key
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime? DueDate { get; set; }    // optional
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property - each item belongs to one user
        public User User { get; set; } = null!;
    }
}
