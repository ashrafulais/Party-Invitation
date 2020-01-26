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
        public IList<GuestResponse> SearchGuestsRepo(string text);
        public GuestResponse GetGuestRepo(int id);
        public void UpdateGuestRepo(GuestResponse guestResponse);
        public void DeleteGuestRepo(GuestResponse guestResponse);
        public IList<GuestResponse> PaginateRepo(int skipnum, int pagesize);
    }
}
