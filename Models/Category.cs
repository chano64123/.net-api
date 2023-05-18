using System.Text.Json.Serialization;

namespace API.Models;
public class Category
{
    public Guid IdCategory { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Impact { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}