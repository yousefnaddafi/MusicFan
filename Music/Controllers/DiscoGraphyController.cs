using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Models.froogh_asgari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoGraphyController : ControllerBase
    {
        private readonly MusicReport musicReport;

        public DiscoGraphyController(MusicReport musicReport)
        {
            this.musicReport = musicReport;
        }
        [HttpGet]
        public AlbumDisco GetAlbum([FromQuery] int s)
        {
            return musicReport.GetDG(s);
        }
    }
}
