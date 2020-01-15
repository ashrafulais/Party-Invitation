using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Interfaces
{
    public interface IGuestResponseRepo
    {
        public void AddGuestRepo(GuestResponse guestResponse);
        public IList<GuestResponse> GetAllGuestsRepo();
        //public GuestResponse GetGuestRepo(int id);
        //public Gift GetGift(int id);
    }
}
