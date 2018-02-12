using PastebinMVC.DAL.Entities;
using System.Collections.Generic;

namespace PastebinMVC.Services
{
    public static class Facade
    {
        private static BusinessLogic BusinessLogicInstance
        {
            get { return BusinessLogic.Instance; }
        }

        public static IList<User> GetUsers()
        {
            return BusinessLogicInstance.GetUsers();
        }

        internal static IList<Text> GetTexts()
        {
            return BusinessLogicInstance.GetTexts();
        }

        internal static Text GetTextById(long id)
        {
            return BusinessLogicInstance.GetTextById(id);
        }

        internal static void RemovePaste(long id)
        {
            BusinessLogicInstance.RemoveText(id);
        }

        internal static IList<Text> GetTextByUserId(long userId)
        {
            return BusinessLogicInstance.GetTextByUserId(userId);
        }

        internal static  User GetUserByUsernameAndPassword(string username, string password)
        {
            return BusinessLogicInstance.GetUserByUsernameAndPassword(username, password);
        }

        internal static IList<Text> GetAllTextByUserId(long userId)
        {
            return BusinessLogicInstance.GetAllTextByUserId(userId);
        }

        internal static void AddText(string content, long userId, out long? id)
        {
            BusinessLogicInstance.AddText(content, userId, out id);
        }
    }
}