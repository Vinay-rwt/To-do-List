namespace ToDo.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property - one user has many todo items
        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
