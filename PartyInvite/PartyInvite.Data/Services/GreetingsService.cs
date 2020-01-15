using PartyInvite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Services
{
    public class GreetingsService : IGreetingsService
    {
        public Dictionary<string, string> GetStatus()
        {
            var result = new Dictionary<string, string>();
            DateTime timenow = DateTime.Now;

            int hour = DateTime.Now.Hour;
            string status = "শুভ দিন";

            if (hour > 4 && hour <= 12)
            {
                status = "শুভ সকাল";
            }
            else if (hour > 12 && hour <= 14)
            {
                status = "শুভ দুপুর";
            }
            else if (hour > 14 && hour <= 18)
            {
                status = "শুভ অপরাহ্ণ";
            }
            else
            {
                status = "শুভ রাত্রি";
            }
            result.Add("TimeNow", timenow.ToString());
            result.Add("GreetingsMessage", status);

            return result;
        }
    }
}
