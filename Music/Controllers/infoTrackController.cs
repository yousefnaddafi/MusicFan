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
    public class infoTrackController : ControllerBase
    {
        private readonly MusicReport musicReport;

        public infoTrackController(MusicReport musicReport)
        {
            this.musicReport = musicReport;
        }

        [HttpGet]
        public TrackDetail GetTrackInfo([FromQuery] string TrackId)
        {
            return musicReport.GetTrackInf(TrackId);
        }

    }
}
