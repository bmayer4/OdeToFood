namespace MvcCoreTest.Entities
{
    using System.ComponentModel.DataAnnotations;
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Mexican
    }
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]
        [Display(Name="Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}