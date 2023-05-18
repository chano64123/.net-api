using System.Text.Json.Serialization;

namespace API.Models;
public class Task
{
    public Guid IdTask { get; set; }
    public Guid IdCategory { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? CulminationDate { get; set; }

    public string Resume { get; set; } = string.Empty;

    public virtual Category Category { get; set; }
}

public enum Priority {
    Low,
    Medium,
    Hight
}