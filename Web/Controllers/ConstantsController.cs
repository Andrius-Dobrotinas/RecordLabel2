using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndrewD.RecordLabel.Web
{
    public class ConstantsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                PrintStatuses = GetEnumArray<PrintStatus>(),
                ReferenceTypes = GetEnumArray<ReferenceType>(),

                DefaultReference = new Reference(),
                DefaultTrack = new Track(),

                MinDate = 1950, // TODO: Get this value from somewhere else,
                MaxDate = DateTime.Today.Year
            });
        }
        
        private object[] GetEnumArray<TEnum>()
        {
            return (from object item in typeof(TEnum).GetEnumValues()
                    select new { Id = (int)item, Text = item.ToString() })
                .ToArray();
        }
    }
}
