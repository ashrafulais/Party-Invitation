using PartyInvite.Data.Interfaces;
using PartyInvite.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyInvite.Data.Services
{
    public class GiftService : IGiftService
    {
        IGiftRepo _giftRepo;
        public GiftService(IGiftRepo giftRepo)
        {
            _giftRepo = giftRepo;
        }

        public List<Gift> GetGiftsService()
        {
            return _giftRepo.GetGiftsRepo();
        }
    }
}
