namespace MusicStore.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Common.Constants;
    using Data;
    using Models;
    using MusicStore.Data.Contracts;

    public class AlbumsController : BaseController
    {
        public AlbumsController(IMusicStoreData data) 
            : base(data)
        {
        }

        public AlbumsController() 
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Albums
                .All()
                .Select(AlbumDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.AlbumInvalidIdErrorMessage);
            }

            return this.Ok(this.Data.Albums
                .All()
                .Where(a => a.AlbumId == id)
                .Select(AlbumDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] AlbumDataModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var album = AlbumDataModel.FromModelToData(albumModel);
            this.Data.Albums.Add(album);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), album);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] AlbumDataModel albumModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.AlbumInvalidIdErrorMessage);
            }

            var album = this.Data.Albums
                .All()
                .Where(a => a.AlbumId == id)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.AlbumInvalidIdErrorMessage);
            }

            album.Title = string.IsNullOrEmpty(albumModel.Title) ? album.Title : albumModel.Title;
            album.Producer = string.IsNullOrEmpty(albumModel.Producer) ? album.Producer : albumModel.Producer;
            album.Year = albumModel.Year;

            this.Data.Albums.Update(album);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.AlbumInvalidIdErrorMessage);
            }

            var album = this.Data.Albums
                .All()
                .Where(a => a.AlbumId == id)
                .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.AlbumInvalidIdErrorMessage);
            }

            this.Data.Albums.Remove(album);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}