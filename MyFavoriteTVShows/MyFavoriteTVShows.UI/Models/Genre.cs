﻿using System.ComponentModel.DataAnnotations;

namespace MyFavoriteTVShows.UI.Models
{
    public enum Genre
    {
        Drama,
        Comedy,
        Romance,
        [Display(Name ="Romantic Comedy")]
        RomCom,
        Crime,
        Mystery
    }
}
