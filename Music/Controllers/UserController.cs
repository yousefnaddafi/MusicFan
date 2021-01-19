using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Models.froogh_asgari;
using Music.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            public static UserRepo repository;
            public UserController()
            {
                repository = new UserRepo();
            }
            [HttpPost]
            public User Register([FromBody] User Usera)
            {
                repository.Insert(Usera);
                return Usera;
            }

        }
    }
