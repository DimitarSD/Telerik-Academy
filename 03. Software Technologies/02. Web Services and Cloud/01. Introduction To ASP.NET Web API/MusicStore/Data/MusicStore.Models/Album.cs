﻿namespace MusicStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;

    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        [Key]
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

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}
