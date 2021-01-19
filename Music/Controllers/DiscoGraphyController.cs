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
    public class DiscoGraphyController : ControllerBase
    {
        private readonly MusicReport musicReport;

        public DiscoGraphyController(MusicReport musicReport)
        {
            this.musicReport = musicReport;
        }
        

        [HttpGet]
        public Discography GetDisc([FromQuery] string ArtistName)
        {
            return musicReport.GetAlbum(ArtistName);
        }

    }
}
