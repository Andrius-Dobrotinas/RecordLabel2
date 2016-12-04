using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class SettingsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                ItemsPerPage = Settings.ItemsPerPage
            });
        }
    }
}