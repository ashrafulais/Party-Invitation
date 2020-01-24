using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Interfaces
{
    public interface IGiftRepo
    {
        public List<Gift> GetGiftsRepo();
    }
}
