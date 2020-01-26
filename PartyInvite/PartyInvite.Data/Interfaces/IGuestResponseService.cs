using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Interfaces
{
    public interface IGuestResponseService
    {
        public GuestResponse GetGuestResponseService(int id);
        public void AddGuestService(GuestResponse guestResponse);
        public IList<GuestResponse> GetAllGuestsService();
        public IList<GuestResponse> SearchGuestsService(string text);
        public void UpdateGuestService(GuestResponse guestResponse);
        public void DeleteGuestService(int id);
        public IList<GuestResponse> PaginateService(int pagenum, int pagesize);
    }
}
