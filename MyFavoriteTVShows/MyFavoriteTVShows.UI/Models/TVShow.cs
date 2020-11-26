using System.ComponentModel.DataAnnotations;

namespace MyFavoriteTVShows.UI.Models
{
    public class TVShow
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60, MinimumLength =3)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:0.0#}")]
        public decimal Rating { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Imdb Link")]
        public string ImdbURL { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Poster")]
        public string ImageURL { get; set; }
    }
}
