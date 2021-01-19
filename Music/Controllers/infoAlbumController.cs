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
    public class infoAlbumController : ControllerBase
    {
        private readonly MusicReport musicReport;
        public infoAlbumController(MusicReport musicReport)
        {
            this.musicReport = musicReport;
        }

        [HttpGet]
        public Mode2 GetAlbumDetail([FromQuery] string ArtistName)
        {
            return musicReport.GetAlbumInfo(ArtistName);
        }
    }
}
