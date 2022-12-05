using ApiControlUsers.Models;
using ApiControlUsers.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ApiControlUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IUnitOfWork _ofWork;

        public SocialMediaController(IUnitOfWork contex)
        {
            _ofWork = contex;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAsync()
        {
            var medias = await _ofWork.SocialMediaRepository.Get().ToListAsync();
            if (medias.Count == 0)
            {
                return NoContent();
            }
            return Ok(medias);
        }

        [HttpPost]
        public async Task<ActionResult<SocialMedia>> PostAsync(SocialMedia media)
        {
            _ofWork.SocialMediaRepository.Add(media);
            await _ofWork.Commit();

            return StatusCode(StatusCodes.Status201Created, media);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SocialMedia>> PutAsync(int id, SocialMedia media)
        {
            if (id != media.SocialMediaId)
            {
                return BadRequest();
            }
            _ofWork.SocialMediaRepository.Update(media);
            await _ofWork.Commit();

            return Ok(media);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var media = await _ofWork.SocialMediaRepository.GetById(p => p.SocialMediaId == id);
            if (media == null)
            {
                return NotFound();
            }
            _ofWork.SocialMediaRepository.Delete(media);
            await _ofWork.Commit();

            return Ok();
        }
    }
}
