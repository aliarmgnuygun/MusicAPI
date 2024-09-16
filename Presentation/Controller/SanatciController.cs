using Entities.Models;
using Entities.Request;
using Entities.Response;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanatciController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public SanatciController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllSanatcilar()
        {
            var sanatcilar = _manager.SanatciService.GetAllSanatcilar(trackChanges: false);

            if(sanatcilar is null)
            {
                return NotFound();
            }
            return Ok(sanatcilar);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetSanatciById([FromRoute(Name = "id")] int id)
        {
            var sanatci = _manager.SanatciService.GetSanatciById(id, false);
            return Ok(sanatci);
        }

        [HttpPost]
        public IActionResult CreateOneSanatci([FromBody] CreateSanatciRequest request)
        {
            if (request is null)
            {
                return BadRequest(new { message = "Geçersiz sanatçı verisi." });
            }

            var sanatci = new Sanatci
            {
                AlbumSayisi = request.AlbumSayisi
            };

            _manager.SanatciService.CreateOneSanatci(sanatci);

            var response = new SanatciResponse
            {
                Id = sanatci.Id,
                Ad = sanatci.Ad,
                KurulusTarihi = sanatci.KurulusTarihi
            };

            return CreatedAtAction(nameof(GetSanatciById), new { id = sanatci.Id }, response);
        }
    }
}
