using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodiumInterview.MortgageApi.Logic
{
    public static class EmailValidator
    {
        public static bool IsEmailValid(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return string.Compare(email, mailAddress.Address, true) == 0;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                return false;
            }
        }
    }
}
