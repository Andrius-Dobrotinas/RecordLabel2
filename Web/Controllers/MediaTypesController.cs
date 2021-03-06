﻿using AndrewD.RecordLabel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class MediaTypesController : ApiController
    {
        private IReleaseService repository;

        public MediaTypesController()
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
            return Ok(repository.GetMediaTypeList());
        }
    }
}
