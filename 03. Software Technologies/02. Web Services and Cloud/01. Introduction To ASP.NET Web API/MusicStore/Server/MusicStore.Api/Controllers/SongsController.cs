namespace MusicStore.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Common.Constants;
    using Data;
    using Models;
    using MusicStore.Data.Contracts;

    public class SongsController : BaseController
    {
        public SongsController(IMusicStoreData data)
            : base(data)
        {
        }

        public SongsController()
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Songs
                .All()
                .Select(SongDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.SongInvalidIdErrorMessage);
            }

            return this.Ok(this.Data.Songs
                .All()
                .Where(s => s.SongId == id)
                .Select(SongDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] SongDataModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = SongDataModel.FromModelToData(songModel);
            this.Data.Songs.Add(song);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), song);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] SongDataModel songModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.SongInvalidIdErrorMessage);
            }

            var song = this.Data.Songs
                .All()
                .Where(s => s.SongId == id)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.SongInvalidIdErrorMessage);
            }

            song.Title = string.IsNullOrEmpty(songModel.Title) ? song.Title : songModel.Title;
            song.Genre = string.IsNullOrEmpty(songModel.Genre) ? song.Genre : songModel.Genre;
            song.Year = songModel.Year;

            this.Data.Songs.Update(song);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.SongInvalidIdErrorMessage);
            }

            var song = this.Data.Songs
                .All()
                .Where(s => s.SongId == id)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.SongInvalidIdErrorMessage);
            }

            this.Data.Songs.Remove(song);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}