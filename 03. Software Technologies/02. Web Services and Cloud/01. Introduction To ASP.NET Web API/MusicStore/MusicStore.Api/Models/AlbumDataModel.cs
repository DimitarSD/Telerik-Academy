namespace MusicStore.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using MusicStore.Common.Constants;
    using MusicStore.Models;

    public class AlbumDataModel
    {
        public static Func<Album, AlbumDataModel> FromDataToModel
        {
            get
            {
                return album => new AlbumDataModel
                {
                    Title = album.Title,
                    Year = album.Year,
                    Producer = album.Producer,
                    Songs = album.Songs.Select(song => new Song
                    {
                        Title = song.Title,
                        Genre = song.Genre,
                        Artist = song.Artist
                    })
                };
            }
        }

        public int AlbumId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.AlbumTitleMaxLength)]
        [MinLength(ValidationConstants.AlbumTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ProducerNameMaxLength)]
        [MinLength(ValidationConstants.ProducerNameMinLength)]
        public string Producer { get; set; }

        public virtual IEnumerable<Song> Songs { get; set; }

        public static Album FromModelToData(AlbumDataModel model)
        {
            return new Album()
            {
                Title = model.Title,
                Year = model.Year,
                Producer = model.Producer
            };
        }
    }
}