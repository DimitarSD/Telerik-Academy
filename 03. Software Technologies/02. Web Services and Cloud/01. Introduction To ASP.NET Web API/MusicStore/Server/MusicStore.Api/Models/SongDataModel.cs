namespace MusicStore.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MusicStore.Common.Constants;
    using MusicStore.Models;

    public class SongDataModel
    {
        public static Func<Song, SongDataModel> FromDataToModel
        {
            get
            {
                return song => new SongDataModel()
                {
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre,
                    Artist = song.Artist.Name,
                    Album = song.Album.Title
                };
            }
        }

        public int SongId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SongTitleMaxLength)]
        [MinLength(ValidationConstants.SognTitleMinLength)]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        [MaxLength(ValidationConstants.GenreTypeMaxLength)]
        [MinLength(ValidationConstants.GenreTypeMinLength)]
        public string Genre { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public static Song FromModelToData(SongDataModel model)
        {
            return new Song()
            {
                Title = model.Title,
                Year = model.Year,
                Genre = model.Genre
            };
        }
    }
}