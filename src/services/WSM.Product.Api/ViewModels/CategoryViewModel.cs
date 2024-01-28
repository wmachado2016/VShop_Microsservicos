using System.ComponentModel.DataAnnotations;
using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.ViewModels
{
    public class CategoryViewModel : Base
    {
        public int CategoryId { get; set; }

        [Required (ErrorMessage ="The name us requerid")]
        [MinLength(3)]
        [MaxLength (100)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
