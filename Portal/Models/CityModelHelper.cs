using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Models
{
    public class CityModelHelper
    {
        public string selectedCity {get; set; }

        public List<SelectListItem> CitySelectList { get; set; }
    }
}
