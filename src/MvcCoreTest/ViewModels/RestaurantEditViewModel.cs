using System.ComponentModel.DataAnnotations;
using MvcCoreTest.Entities;

namespace MvcCoreTest.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}