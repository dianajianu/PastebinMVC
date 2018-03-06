using PastebinMVC.DAL.Entities;
using PastebinMVC.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PastebinMVC.Services
{
    internal class BusinessLogic : Singleton<BusinessLogic>
    {
        private UnitOfWork _uow = new UnitOfWork();

        internal IList<User> GetUsers()
        {
            using (var repo = _uow.UserRepository)
            {
                return repo.LoadAllEntities();
            }
        }

        internal IList<Text> GetTexts()
        {
            using (var repo = _uow.TextRepository)
            {
                return repo.LoadAllEntities();
            }
        }

        internal Text GetTextById(long id)
        {
            using (var repo = _uow.TextRepository)
            {
                return repo.LoadEntityById(id);
            }
        }

        internal void RemoveText(long id)
        {
            using (var repo = _uow.TextRepository)
            {
                repo.Delete(id);
                repo.Save();
            }
        }

        internal IList<Text> GetTextByUserId(long userId)
        {
            using (var repo = _uow.TextRepository)
            {
                return repo.LoadEntitiesById(e => e.UserId == userId);
            }
        }

        internal SyntaxFormatter GetSyntaxFormatterByCode(string syntaxFormatterCode)
        {
            using (var repo = _uow.SyntaxFormatterRepository)
            {
                return repo.LoadAllEntities()
                    .Where(e => e.FormatterCode == syntaxFormatterCode)
                    .FirstOrDefault();
            }
        }

        internal SyntaxFormatter GetSyntaxFormatterById(long syntaxFormatterId)
        {
            using (var repo = _uow.SyntaxFormatterRepository)
            {
                return repo.LoadEntityById(syntaxFormatterId);
            }
        }

        internal User GetUserByUsernameAndPassword(string username, string password)
        {
            using (var repo = _uow.UserRepository)
            {
                return repo.LoadEntitiesById(e => e.Username == username && e.Password == password).FirstOrDefault();
            }
        }

        internal IList<Text> GetAllTextByUserId(long userId)
        {
            using (var repo = _uow.TextRepository)
            {
                return repo.LoadEntitiesById(e => e.UserId == userId);
            }
        }

        internal void AddText(string content, long userId, long? syntaxFormatterId, out long id)
        {
            using (var repo = _uow.TextRepository)
            {
                var text = new Text { Content = content, UserId = userId, SyntaxFormatterId = syntaxFormatterId };

                repo.Add(text);
                repo.Save();

                id = text.Id;
            }
        }
    }
}