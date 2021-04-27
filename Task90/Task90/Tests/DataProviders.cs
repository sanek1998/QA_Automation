using System.Collections;
using Task90.Model;

namespace Task90.Tests
{
    public class DataProviders
    {
        public static IEnumerable ValidUsers
        {
            get
            {
                yield return new User()
                {
                    Login = "seleniumtests@tut.by",
                    Password = "123456789zxcvbn"
                };
            }
        }
    }
}