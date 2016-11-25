﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AndrewD.RecordLabel.SuperModels;

namespace AndrewD.RecordLabel.Web
{
    public class ReleaseViewModel
    {
        public Release Release { get; set; }
        public IList<Reference> YoutubeReferences { get; set; }
    }
}