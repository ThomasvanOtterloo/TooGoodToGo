using Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApi.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool ContainsAlcohol { get; set; }
        public string? Image { get; set; }
    }
}
