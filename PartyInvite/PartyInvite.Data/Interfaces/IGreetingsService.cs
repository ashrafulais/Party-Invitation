using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Interfaces
{
    public interface IGreetingsService
    {
        public Dictionary<string, string> GetStatus();
    }
}
