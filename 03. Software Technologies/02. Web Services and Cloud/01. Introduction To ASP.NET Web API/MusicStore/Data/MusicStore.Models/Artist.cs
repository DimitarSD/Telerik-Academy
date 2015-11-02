namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new HashSet<Album>();
        }

        [Key]
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

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
