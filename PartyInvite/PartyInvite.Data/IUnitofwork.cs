using PartyInvite.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data
{
    public interface IUnitofwork
    {
        public IGuestResponseRepo _guestResponseRepo { get; set; }
        public void Save();
    }
}
