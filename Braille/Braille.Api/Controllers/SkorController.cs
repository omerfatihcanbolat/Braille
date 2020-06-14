using Braille.Api.Attributes;
using Braille.DAL.EntitiyFramework;
using Braille.DAL.Models;
using Braille.DAL.Models.ViewModel;
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
    public class SkorController : ApiController
    {
        SkorDAL SkorDAL = new SkorDAL();

        /*[ResponseType(typeof(IEnumerable<Skor>))]

        public IHttpActionResult Get()
        {
            var skorlar = SkorDAL.GetSkorlar();


            return Ok(skorlar);

        }*/
/*
        [ResponseType(typeof(Skor))]
        public IHttpActionResult Get(int id)
        {
            var skor = SkorDAL.GeSkorById(id);
            if (skor == null)
            {
                return NotFound();
            }
            return Ok(skor);
        }*/
        /*
        [ResponseType(typeof(Skor))]
        public HttpResponseMessage Post(Skor skor)
        {
            var createdSkor = SkorDAL.InsertSkor(skor);
            return Request.CreateResponse(HttpStatusCode.Created, createdSkor);
        }*/

        [HttpPost]
        [ResponseType(typeof(IEnumerable<Kelimeler>))]
        public HttpResponseMessage SaveSkorList(List<Skor> skorList)
        {
            SkorDAL.InsertSkorList(skorList);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Kelimeler>))]
        public IHttpActionResult GetUserScores(string phone)
        {
            IQueryable<Skor> queryable = SkorDAL.GetUserScores(phone);
            var newList = queryable.ToList();

            List<UserSkor> userSkors = new List<UserSkor>();
            foreach (var item in newList)
            {
                var userSkor = new UserSkor
                {
                    kelimeAdi = item.Kelimeler.Kelime,
                    siraNo = SkorDAL.GetKelimeSiralama(phone, item.KelimeId),
                    sure = item.Sure
                };
                userSkors.Add(userSkor);
            }

            userSkors = userSkors.OrderBy(a => a.siraNo).ToList();


            return Ok(userSkors);
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

