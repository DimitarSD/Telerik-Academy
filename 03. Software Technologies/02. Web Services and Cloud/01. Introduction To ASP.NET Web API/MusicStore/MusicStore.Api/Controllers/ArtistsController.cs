namespace MusicStore.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Common.Constants;
    using Data;
    using Models;
    using MusicStore.Data.Contracts;

    public class ArtistsController : BaseController
    {
        public ArtistsController(IMusicStoreData data)
            : base(data)
        {
        }

        public ArtistsController() 
            : base(new MusicStoreData())
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.Data.Artists
                .All()
                .Select(ArtistDataModel.FromDataToModel));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.ArtistInvalidIdErrorMessage);
            }

            return this.Ok(this.Data.Artists
                .All()
                .Where(a => a.ArtistId == id)
                .Select(ArtistDataModel.FromDataToModel));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ArtistDataModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = ArtistDataModel.FromModelToData(artistModel);
            this.Data.Artists.Add(artist);
            this.Data.SaveChanges();

            return this.Created(this.Url.ToString(), artist);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] ArtistDataModel artistModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.ArtistInvalidIdErrorMessage);
            }

            var artist = this.Data.Artists
                .All()
                .Where(a => a.ArtistId == id)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.ArtistInvalidIdErrorMessage);
            }

            artist.Name = string.IsNullOrEmpty(artistModel.Name) ? artist.Name : artistModel.Name;
            artist.Country = string.IsNullOrEmpty(artistModel.Country) ? artist.Country : artistModel.Country;
            artist.DateOfBirth = artistModel.DateOfBirth;

            this.Data.Artists.Update(artist);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return this.BadRequest(ControllerErrorMessageConstants.ArtistInvalidIdErrorMessage);
            }

            var artist = this.Data.Artists
                .All()
                .Where(a => a.ArtistId == id)
                .FirstOrDefault();

            if (artist == null)
            {
                return this.BadRequest(ControllerErrorMessageConstants.ArtistInvalidIdErrorMessage);
            }

            this.Data.Artists.Remove(artist);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}