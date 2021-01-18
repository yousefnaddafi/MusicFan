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
    public class MVideoController : ControllerBase
    {
        private readonly MusicReport musicReport;

        public MVideoController(MusicReport musicReport)
        {
            this.musicReport = musicReport;
        }
        [HttpGet]
        public MVideocs GetAlbum([FromQuery] int i)
        {
            return musicReport.GetMusic(i);
        }
    }
}
