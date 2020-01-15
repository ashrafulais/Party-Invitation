using System;
using System.Collections.Generic;
using System.Text;
using PartyInvite.Data.Interfaces;
using PartyInvite.Data.Repositories;
using PartyInvite.Data.Services;

namespace PartyInvite.Data
{
    public class Unitofwork : IUnitofwork
    {
        public IGuestResponseRepo _guestResponseRepo { get; set; }
        public PartyContext _partyContext;

        public Unitofwork(string conn, string migration)
        {
            _partyContext = new PartyContext(conn, migration);
            _guestResponseRepo = new GuestResponseRepo(_partyContext);
        }

        public void Save()
        {
            _partyContext.SaveChanges();
        }
    }
}
