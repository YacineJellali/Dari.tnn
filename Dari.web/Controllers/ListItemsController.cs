using Dari.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Dari.web.Controllers
{
    public class ListItemsController : ApiController
    {

        private static List<ClientVM> Clientvms { get; set; } = new List<ClientVM>();

        // GET api/<controller>
        public IEnumerable<ClientVM> Get()
        {
            return Clientvms;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var item = Clientvms.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]ClientVM model)
        {
            if (string.IsNullOrEmpty(model?.Nom))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if (Clientvms.Count > 0)
            {
                maxId = Clientvms.Max(x => x.Id);
            }
            model.Id = maxId + 1;
            Clientvms.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]ClientVM model)
        {
            if (string.IsNullOrEmpty(model?.Nom))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var item = Clientvms.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                // Update *all* of the item's properties
                item.Nom = model.Nom;

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }


        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var item = Clientvms.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Clientvms.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}