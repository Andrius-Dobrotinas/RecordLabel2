using AndrewD.RecordLabel.Data;
using AndrewD.RecordLabel.SuperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class ReleaseController : ApiController
    {
        private IRepositoryProxy repository;

        public ReleaseController()
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

        public IHttpActionResult Get()
        {
            var model = repository.GetReleases();
            return Ok(model);
        }

        public IHttpActionResult Get(int id)
        {
            var model = repository.GetReleaseComplete(id);
            
            if (model != null)
            {
                var viewModel = new ReleaseViewModelTransformer().Transform(model);
                return Ok(viewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult GetForEdit(int id)
        {
            var model = repository.GetReleaseSlim(id);
                
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
        
        public void Post(ReleaseSlim model)
        {
            //TODO: if (model == null)
            RemoveEmptyItems(model);// TODO
            //TODO: validations

            repository.Save(model);
        }

        // TODO
        private void RemoveEmptyItems(ReleaseSlim model)
        {
            /*foreach(var item in model.References)
            {
                // check if values are default
            }*/
        }
        
        // TODO
        public void Delete(int id)
        {
        }
    }
}