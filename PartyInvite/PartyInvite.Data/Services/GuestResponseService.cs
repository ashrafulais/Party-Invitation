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

        public GuestResponse GetGuestResponseService(int id)
        {
            GuestResponse guest = _unitofwork
                ._guestResponseRepo
                .GetGuestRepo(id);
            if (guest is null)
            {
                throw new Exception("Guest Not Found");
            }
            else
            {
                return guest;
            }
        }

        public IList<GuestResponse> PaginateService(int pagenum, int pagesize)
        {
            try
            {
                int skipnum = (pagenum-1) * pagesize;
                skipnum = skipnum < 0 ? 0 : skipnum;

                return _unitofwork._guestResponseRepo
                .PaginateRepo(skipnum, pagesize);
            }
            catch (Exception e)
            {
                throw new Exception("Error paginating: " + e.Message);
            }
        }

        public IList<GuestResponse> SearchGuestsService(string text)
        {
            try
            {
                return _unitofwork.
                _guestResponseRepo.SearchGuestsRepo(text);
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
                //GuestResponse originalguest = _unitofwork._guestResponseRepo
                //.GetGuestRepo(guestResponse.Id);

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
