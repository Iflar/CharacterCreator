using CharacterCreator.Models;
using CharacterCreator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharacterCreator.WebAPI.Controllers
{
    [Authorize]
    public class CharacterController : ApiController
    {
        // GET: Character
        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }
        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCharacterService();

            if (!service.CreateCharacter(character))
                return InternalServerError();

            return Ok();
        }
        private CharacterService CreateCharacterService()
        {
            var characterId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(characterId);
            return characterService;
        }
        public IHttpActionResult Get(int id)
        {
            CharacterService characterService = CreateCharacterService();
            var character = characterService.GetCharacterById(id);
            return Ok(character);
        }
        public IHttpActionResult Put(CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCharacterService();

            if (!service.UpdateCharacter(character))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCharacterService();

            if (!service.DeleteCharacter(id))
                return InternalServerError();

            return Ok();
        }
    }
}