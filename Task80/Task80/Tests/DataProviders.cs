using System.Collections;
using Task80.Model;

namespace Task80.Tests
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