using FluentAssertions.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Braille.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {



            // Web API configuration and services
            var enableCorsAttribute = new EnableCorsAttribute("*",
                                         "Origin, Content-Type, Accept",
                                         "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);





            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);




            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling =
             NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Formatting.Indented;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            /********************************************/




            //config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling =
            //NullValueHandling.Ignore;
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
            //ReferenceLoopHandling.Ignore;

            //config.Formatters.JsonFormatter.SerializerSettings =
            //     new JsonSerializerSettings
            //     {
            //         NullValueHandling = NullValueHandling.Ignore,
            //         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //     };


            //var jsonformatter = new JsonMediaTypeFormatter
            //{
            //    SerializerSettings =
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    ReferenceLoopHandling=ReferenceLoopHandling.Ignore

            //}
            //};

            //config.Formatters.RemoveAt(0);
            //config.Formatters.Insert(0, jsonformatter);



        }

    }
}

