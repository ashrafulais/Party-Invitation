using PartyInvite.Data.Interfaces;
using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartyInvite.Data.Repositories
{
    public class GiftRepo : IGiftRepo
    {
        public PartyContext _context;
        public GiftRepo(PartyContext context)
        {
            _context = context;
        }

        public List<Gift> GetGiftsRepo()
        {
            return _context.Gifts
                .ToList();
        }
    }
}
