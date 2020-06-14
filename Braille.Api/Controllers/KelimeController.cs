using Braille.Api.Attributes;

using Braille.DAL.EntitiyFramework;
using Braille.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
namespace Braille.Api.Controllers
{
    [ApiException]
    public class KelimeController : ApiController
    {
        KelimeDAL KelimeDAL = new KelimeDAL();

        [ResponseType(typeof(IEnumerable<Kelimeler>))]
        public IHttpActionResult Get()
        {
            var kelimeler = KelimeDAL.GetKelimeler();

            return Ok(kelimeler);
        }

        [ResponseType(typeof(Kelimeler))]
        public IHttpActionResult Get(int id)
        {
            var kelime = KelimeDAL.GetKelimeById(id);
            if (kelime == null)
            {
                return NotFound();

            }
            return Ok(kelime);
        }

        [ResponseType(typeof(Kelimeler))]
        public HttpResponseMessage Post(Kelimeler kelime)
        {
            var createdKelime = KelimeDAL.InsertKelime(kelime);
            return Request.CreateResponse(HttpStatusCode.Created, createdKelime);
        }


        [ResponseType(typeof(Kelimeler))]
        public HttpResponseMessage Put(int id, Kelimeler kelime)
        {
            if (KelimeDAL.IsThereAnyKelime(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı.");

            }
            else if (ModelState.IsValid == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, KelimeDAL.UpdateKelime(id, kelime));

            }
        }

        public HttpResponseMessage Delete(int id)
        {
            if (KelimeDAL.IsThereAnyKelime(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayır bulunamadı.");
            }
            else
            {
                KelimeDAL.DeleteKelime(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

        }
    }
}
