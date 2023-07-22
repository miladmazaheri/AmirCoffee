using System.ComponentModel.DataAnnotations;

namespace AmirCoffee.Web.Database.Entities
{
    public class Carousel
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Title { get; set; }
        [MaxLength(128)]
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
