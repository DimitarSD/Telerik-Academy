namespace MusicStore.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using MusicStore.Common.Constants;
    using MusicStore.Models;

    public class ArtistDataModel
    {
        public static Func<Artist, ArtistDataModel> FromDataToModel
        {
            get
            {
                return artist => new ArtistDataModel
                {
                    Name = artist.Name,
                    Country = artist.Country,
                    DateOfBirth = artist.DateOfBirth,
                    Albums = artist.Albums.Select(al => al.Title)
                };
            }
        }

        public int ArtistId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ArtistNameMaxLength)]
        [MinLength(ValidationConstants.ArtistNameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        [MinLength(ValidationConstants.CountryNameMinLength)]
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual IEnumerable<string> Albums { get; set; }

        public static Artist FromModelToData(ArtistDataModel model)
        {
            return new Artist()
            {
                Name = model.Name,
                Country = model.Country,
                DateOfBirth = model.DateOfBirth
            };
        }
    }
}