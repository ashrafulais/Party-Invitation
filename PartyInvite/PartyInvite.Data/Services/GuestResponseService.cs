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
            try
            {
                _unitofwork._guestResponseRepo
                .AddGuestRepo(guestResponse);
                _unitofwork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: "+e.Message);
            }
        }

        public void DeleteGuestService(int id)
        {
            try
            {
                GuestResponse originalguest = _unitofwork
                ._guestResponseRepo
                .GetGuestRepo(id);
                _unitofwork._guestResponseRepo
                    .DeleteGuestRepo(originalguest);
                _unitofwork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public IList<GuestResponse> GetAllGuestsService()
        {
            try
            {
                return _unitofwork.
                _guestResponseRepo.GetAllGuestsRepo();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }

        public void UpdateGuestService(GuestResponse guestResponse)
        {
            try
            {
                GuestResponse originalguest = _unitofwork._guestResponseRepo
                .GetGuestRepo(guestResponse.Id);

                _unitofwork._guestResponseRepo
                    .UpdateGuestRepo(guestResponse);
                _unitofwork.Save();
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
