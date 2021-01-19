using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.HttpService;
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
        public MVideo GetAlbum([FromQuery] string ArtistId)
        {
            return musicReport.GetMusicVideo(ArtistId);
        }
    }
}
