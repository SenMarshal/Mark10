using Mark10.Project.Website.Models;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mark10.Project.Website.Controllers
{
    public class CarousalController : Controller
    {
        // GET: Carousal
        public ActionResult Index()
        {
            var model = new CarousalModel();
            List<Slide> slides = new List<Slide>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["Slides"];

            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();

                foreach (var slide in slideItems)
                {
                    //var description = new MvcHtmlString(FieldRenderer.Render(RenderingContext.Current?.Rendering.Item, "Description"));
                    //var image = new MvcHtmlString(FieldRenderer.Render(RenderingContext.Current?.Rendering.Item, "Image"));
                    //var cta = new MvcHtmlString(FieldRenderer.Render(RenderingContext.Current?.Rendering.Item, "CTA", "class=btn"));

                    var titleField = slide.Fields["Title"];
                    var descriptionField = slide.Fields["Description"];
                    Sitecore.Data.Fields.ImageField imageField = slide.Fields["Image"];
                    var ctaField = slide.Fields["CTA"];

                    slides.Add(new Slide
                    {
                        Title = titleField?.Value,
                        Description = descriptionField?.Value,
                        ImageUrl = GetMediaImageUrl(imageField),
                        CTA = ctaField?.Value
                    });
                }

                model.Slides = slides;
            }
            return View(model);
        }

        private string GetMediaImageUrl(ImageField imageField)
        {
            string imageURL = string.Empty;
            if (imageField != null && imageField.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
            }
            return imageURL;
        }
    }
}