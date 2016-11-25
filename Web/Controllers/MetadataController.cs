using AndrewD.RecordLabel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class MetadataController : ApiController
    {
        private IRepositoryProxy repository;
        private Data.EF.Access.EntityToModelTransformer transformer;

        public MetadataController()
        {
            // TODO: DI
            repository = new Data.EF.Access.RepositoryProxy();
            transformer = new Data.EF.Access.EntityToModelTransformer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        public IHttpActionResult Get()
        {
            var model = repository.GetMetadataList();
            return Ok(model);
        }
    }
}