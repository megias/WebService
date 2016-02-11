using System.Collections.Generic;
using System.Web.Mvc;
using WebApiCristianMegias.Areas.Api.Models;

namespace WebApiCristianMegias.Areas.Api.Controllers
{
    public class VideoController : Controller
    {   
        private VideoManager videomanager;

        public VideoController()
        {
            videomanager = new VideoManager();
        }
        // GET /Api/Clientes
        [HttpGet]
        public JsonResult VideoPlayer()
        {
            return Json(videomanager.ObtenerVideos(),
                        JsonRequestBehavior.AllowGet);
        }

        // POST    /Api/Clientes/Cliente    { Nombre:"nombre", Telefono:123456789 }
        // PUT     /Api/Clientes/Cliente/3  { Id:3, Nombre:"nombre", Telefono:123456789 }
        // GET     /Api/Clientes/Cliente/3
        // DELETE  /Api/Clientes/Cliente/3
        public JsonResult Videos(int? id, VideoPlayer item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(videomanager.InsertarVideo(item));
                    /*
                case "PUT":
                    return Json(clientesManager.ActualizarCliente(item));*/
                case "GET":
                    return Json(videomanager.ObtenerVideo(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                    /*
                case "DELETE":
                    return Json(clientesManager.EliminarCliente(id.GetValueOrDefault()));*/
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
    }
}