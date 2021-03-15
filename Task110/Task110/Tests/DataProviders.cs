using System.Collections;
using Task110.Model;

namespace Task110.Tests
{
    public class DataProviders
    {
        public static IEnumerable ValidUsers
        {
            get
            {
                yield return new User
                {
                    Login = "seleniumtests@tut.by",
                    Password = "123456789zxcvbn"
                };
            }
        }
    }
}