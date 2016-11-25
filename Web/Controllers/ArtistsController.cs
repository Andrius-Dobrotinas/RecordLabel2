using AndrewD.RecordLabel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class ArtistsController : ApiController
    {
        private IRepositoryProxy repository;

        public ArtistsController()
        {
            // TODO: DI
            repository = new Data.EF.Access.RepositoryProxy();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Returns a list of artists with essential data only
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetList()
        {
            return Ok(repository.GetArtistBarebonesList());
        }
    }
}
