using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mark10.Project.Website.Models
{
    public class CarousalModel
    {
        public List<Slide> Slides { get; set; }
    }

    public class Slide
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string CTA { get; set; }
    }
}