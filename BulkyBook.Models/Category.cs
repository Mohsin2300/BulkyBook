using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key] // this make Id and identity column
        public int Id { get; set; }
        [Required] // this means that Name is not a nullable property
        public string Name { get; set; }
        [DisplayName("Display Order")] // this does that everytime we show the name of this it will be shown as Display Order 
        [Range(1, 100, ErrorMessage = "Display Order must be within 1-100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
