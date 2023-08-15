
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpotify.Data.Interfaces;
using MySpotify.Models;
using MySpotify.Services.Interfaces;
using System.Security.Claims;

namespace MySpotify.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private IUserService userService;
        private IMusicService musicService;
        private IPlaylistService playlistService;
        private IRhythmService rhythmService;
        private ISingerService singerService;

        public BaseController(IServiceProvider sp)
        {

            musicService = (IMusicService)sp.GetService(typeof(IMusicService));
            playlistService = (IPlaylistService)sp.GetService(typeof(IPlaylistService));
            rhythmService = (IRhythmService)sp.GetService(typeof(IRhythmService));
            singerService = (ISingerService)sp.GetService(typeof(ISingerService));


            userService = (IUserService)sp.GetService(typeof(IUserService));
        }
        
        public BaseController(IUserService userService1)
        {
            userService = userService1;

        }

        public BaseController(
                             IMusicService musicService1,
                             IPlaylistService playlistService1
                             )
        {
            musicService = musicService1;
            playlistService = playlistService1;
        }

        public BaseController(IUserService userService1,
                             IMusicService musicService1,
                             IPlaylistService playlistService1,
                             IRhythmService rhythmService1,
                             ISingerService singerService1
                             )
        {
            userService = userService1;
            musicService = musicService1;
            playlistService = playlistService1;
            singerService = singerService1;
            rhythmService = rhythmService1;
        }

        protected User ReadToken()
        {
            var idUser = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(x => x.Value).FirstOrDefault();
            if (!string.IsNullOrEmpty(idUser))
            {
                var user = new User();
                user = userService.GetById(Guid.Parse(idUser));
                return user;
            }
            else
            {
                return null;
            }
            throw new UnauthorizedAccessException("Token invalid");
        }
    }
}
