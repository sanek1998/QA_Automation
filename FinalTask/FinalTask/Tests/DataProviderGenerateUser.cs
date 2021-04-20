using System.Collections;
using FinalTask.Helper;
using FinalTask.Model;

namespace FinalTask.Tests
{
    public class DataProviderGenerateUser
    {
        public static IEnumerable GenerateNewUser
        {
            get
            {
                yield return new User().GenerateUser();

            }
        }
    }
}