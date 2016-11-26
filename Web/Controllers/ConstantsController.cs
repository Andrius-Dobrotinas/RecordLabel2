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
            // TODO: move this object to a global static variable because these objects don't change at runtime
            var ReferenceTypeEnum = (from object item in typeof(ReferenceType).GetEnumValues()
                                     select new { Id = (int)item, Text = item.ToString() })
                .ToArray().ToDictionary(x => x.Text, x => x.Id);
            
            return Ok(new
            {
                PrintStatuses = GetEnumArray<PrintStatus>(),
                ReferenceTypes = GetEnumArray<ReferenceType>(),
                ReferenceTypeEnum = ReferenceTypeEnum,

                DefaultReference = new Reference(),
                DefaultTrack = new Track(),

                MinDate = 1950,
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
