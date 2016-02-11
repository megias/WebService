using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCristianMegias.Areas.Api.Models
{
    public class VideoPlayer
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string link { get; set; }
        public string tipus { get; set; }
    }
}