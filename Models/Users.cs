using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OurLockingApp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        [ConcurrencyCheck]
        public byte[]? RowVersion { get; set; }
    }
}
