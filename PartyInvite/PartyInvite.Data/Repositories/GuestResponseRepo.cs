﻿using PartyInvite.Data.Interfaces;
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

        public void DeleteGuestRepo(GuestResponse guestResponse)
        {
            _context.GuestResponses.Remove(guestResponse);
        }

        public IList<GuestResponse> GetAllGuestsRepo()
        {
            return _context.GuestResponses.Where(x => x.WillAttend == true).ToList();
        }

        public GuestResponse GetGuestRepo(int id)
        {
            return _context.GuestResponses.Where(
                x => x.Id == id).FirstOrDefault();
        }

        public void UpdateGuestRepo(GuestResponse guestResponse)
        {
            _context.GuestResponses
                .Update(guestResponse);
        }
    }
}
