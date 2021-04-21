using System;
using FinalTask.Model;

namespace FinalTask.Helper
{
    public static class GenerateNewUser
    {
        public static User GenerateUser(this User user)
        {
            var guidString = Guid.NewGuid().ToString();

            user.IsMan = true;
            user.FirstName = "FirstName";
            user.LastName = "FirstName";
            user.Email = guidString + "@mail.com";
            user.Password = "12345678";
            user.BirthDate = new DateTime(1998, 7, 9);
            user.IsNewsletter = false;
            user.IsSpecialOffers = false;
            user.Company = "Company";
            user.Address1 = "Address1";
            user.Address2 = "Address2";
            user.City = "City";
            user.State = "Florida";
            user.Zip = "00000";
            user.Country = "United States";
            user.AdditionalInformation = "AdditionalInformation";
            user.HomePhone = "123456789012";
            user.MobilePhone = "123456789013";
            user.Alias = "Alias";
            return user;
        }
    }
}