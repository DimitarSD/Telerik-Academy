namespace MusicStore.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Song
    {
        [Key]
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

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
