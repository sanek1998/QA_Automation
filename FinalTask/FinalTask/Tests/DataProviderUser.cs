using System.Collections;
using FinalTask.Model;

namespace FinalTask.Tests
{
    public class DataProviderUser
    {
        public static IEnumerable ValidUsers
        {
            get
            {
                yield return new User()
                {
                    Email = "test@mail.ru",
                    Password = "12345678"
                };
            }
        }

    }
}