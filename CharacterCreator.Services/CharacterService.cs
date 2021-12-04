using CharacterCreator.Data;
using CharacterCreator.Models;
using CharacterCreator.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Services
{
    public class CharacterService
    {
        private readonly Guid _characterId;

        public CharacterService(Guid characterId)
        {
            _characterId = characterId;
        }
        public bool CreateCharacer(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    CharacterId = _characterId,
                    Name = model.Name,
                    Height = model.Height,
                    Race = model.Race,
                    Age = model.Age
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.CharacterId == _characterId)
                        .Select(
                            e =>
                                new CharacterListItem
                                {
                                    CharacterId = e.CharacterId,
                                    Name = e.Name
                                }
                        );
                return query.ToArray();
            }
        }
        public CharacterDetail GetCharacterById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == id && e.CharacterId == _characterId);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        Name = entity.Name,
                        Height = entity.Height,
                        Race = entity.Race,
                        Age = entity.Age
                    };
            }
        }
        public bool UpdateCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == model.CharacterId && e.CharacterId == _characterId);

                entity.Name = model.Name;
                entity.Height = model.Height;
                entity.Race = model.Race;
                entity.Age = model.Age;
                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId && e.CharacterId == _characterId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
