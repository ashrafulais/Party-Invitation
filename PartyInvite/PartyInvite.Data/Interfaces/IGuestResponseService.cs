using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Interfaces
{
    public interface IGuestResponseService
    {
        public void AddGuestService(GuestResponse guestResponse);
        public IList<GuestResponse> GetAllGuestsService();
    }
}
