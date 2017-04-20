﻿namespace Parliament.Search.Api.Controllers
{
    using OpenSearch;
    using System;
    using System.Web;
    using System.Web.Http;

    public class DescriptionController : ApiController
    {
        public Description Get()
        {
            var description = new Description
            {
                ShortName = "parliament.uk",
                DescriptionText = "tUK Parliament website"
            };

            var route = this.Url.Route(
                "NamedController",
                new
                {
                    controller = "search",
                    q = "{searchTerms}",
                    start = "{startPage?}"
                });

            var templateUri = new Uri(this.Request.RequestUri, new Uri(HttpUtility.UrlDecode(route), UriKind.Relative));

            description.Urls.Add(new Url
            {
                TypeName = "application/atom+xml",
                Template = templateUri.ToString()
            });

            return description;
        }
    }
}