using System.ComponentModel.DataAnnotations;
using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.ViewModels
{
    public class ProductViewModel:Base
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is requerid")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The name is requerid")]
        [MinLength(3)]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price is requerid")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The stock is requerid")]
        public long Stock { get; set; }
        public string ImagenUrl { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
