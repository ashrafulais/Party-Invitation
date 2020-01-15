using PartyInvite.Data.Interfaces;
using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Services
{
    public class GuestResponseService : IGuestResponseService
    {
        IUnitofwork _unitofwork;
        public GuestResponseService(IUnitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public void AddGuestService(GuestResponse guestResponse)
        {
            _unitofwork._guestResponseRepo
                .AddGuestRepo(guestResponse);
            _unitofwork.Save();
        }

        public IList<GuestResponse> GetAllGuestsService()
        {
            return _unitofwork.
                _guestResponseRepo.GetAllGuestsRepo();
        }
    }
}
