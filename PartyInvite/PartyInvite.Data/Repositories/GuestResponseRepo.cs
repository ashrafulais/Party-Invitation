using PartyInvite.Data.Interfaces;
using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartyInvite.Data.Repositories
{
    public class GuestResponseRepo : IGuestResponseRepo
    {
        PartyContext _context;
        public GuestResponseRepo(PartyContext context)
        {
            _context = context;
        }

        public void AddGuestRepo(GuestResponse guestResponse)
        {
            _context.GuestResponses.Add(guestResponse);
        }

        public IList<GuestResponse> GetAllGuestsRepo()
        {
            return _context.GuestResponses.Where(x => x.WillAttend == true).ToList();
        }
    }
}
