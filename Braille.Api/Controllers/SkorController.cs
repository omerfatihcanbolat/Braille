using Braille.Api.Attributes;
using Braille.DAL.EntitiyFramework;
using Braille.DAL.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
namespace Braille.Api.Controllers
{
   
    [ApiException]
    public class SkorController : ApiController
    {
        SkorDAL SkorDAL = new SkorDAL();

        [ResponseType(typeof(IEnumerable<Skor>))]
        public IHttpActionResult Get()
        {
            var skorlar = SkorDAL.GetSkorlar();


            return Ok(skorlar);

        }

        [ResponseType(typeof(Skor))]
        public IHttpActionResult Get(int id)
        {
            var skor = SkorDAL.GeSkorById(id);
            if (skor == null)
            {
                return NotFound();
            }
            return Ok(skor);
        }

        [ResponseType(typeof(Skor))]
        public HttpResponseMessage Post(Skor skor)
        {
            var createdSkor = SkorDAL.InsertSkor(skor);
            return Request.CreateResponse(HttpStatusCode.Created, createdSkor);
        }

        [ResponseType(typeof(Skor))]
        public HttpResponseMessage Put(int id, Skor skor)
        {
            if (SkorDAL.IsThereAnySkor(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı.");

            }
            else if (ModelState.IsValid == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, SkorDAL.UpdateSkor(id, skor));

            }

        }

        public HttpResponseMessage Delete(int id)
        {
            if (SkorDAL.IsThereAnySkor(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı.");
            }
            else
            {
                SkorDAL.DeleteSkor(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
    }
}

