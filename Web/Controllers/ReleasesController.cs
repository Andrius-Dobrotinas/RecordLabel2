﻿using AndrewD.RecordLabel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class ReleasesController : ApiController
    {
        private IReleaseService repository;

        // TODO: make this DI'able
        private Validators.ICustomModelValidator<ReleaseSlim> _modelValidator;
        private Validators.ICustomModelValidator<ReleaseSlim> modelValidator
        {
            get
            {
                return _modelValidator ?? (_modelValidator = new Validators.CustomModelValidator());
            }
        }

        public ReleasesController()
        {
            // TODO: DI
            repository = new Data.EF.Access.ReleaseService();
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

        public IHttpActionResult GetBatch(int number)
        {
            return GetBatch(number, 0);
        }

        public IHttpActionResult GetBatch(int number, int size)
        {
            if (size == 0) size = Settings.ItemsPerPage;
            var model = repository.GetReleases(number, size);
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

        public IHttpActionResult GetTemplate()
        {
            return Ok(new ReleaseSlim {
                Date = (short)DateTime.Now.Year
            });
        }
        
        public IHttpActionResult Post(ReleaseSlim model)
        {
            RemoveEmptyItems(model);// TODO

            foreach (var item in modelValidator.Validate(model))
            {
                ModelState.AddModelError(item.Key, item.Value);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // TODO: try/catch and log
                repository.Save(model);
                return Ok();
            }
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