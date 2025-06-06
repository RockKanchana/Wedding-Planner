using Microsoft.AspNetCore.Identity;
using Wedding_Planner.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services.Impl
{
    public class GuestService : IGuestService
    {
        private readonly WeddingPlannerDbContext _context;


        public GuestService(WeddingPlannerDbContext context)
        {
            _context = context;
        }

        public void AddGuest(GuestModel guest)
        {
            var entity = new Guest
            {
                WeddingId = guest.WeddingId,
                FullName = guest.FullName,
                Email = guest.Email,
                TableNumber = guest.TableNumber
            };

            _context.Guests.Add(entity);
            _context.SaveChanges();
        }

        //public void DeleteGuest(int guestId)
        //{
        //    var guest = _context.Guests.FirstOrDefault(g => g.Id == guestId);
        //    if (guest != null)
        //    {
        //        _context.Guests.Remove(guest);
        //        _context.SaveChanges();
        //    }
        //}

        public GuestModel GetGuestById(int id)
        {
            var guest = _context.Guests.FirstOrDefault(g => g.Id == id);
            if (guest == null) return null;

            return new GuestModel
            {
                Id = guest.Id,
                WeddingId = guest.WeddingId,
                FullName = guest.FullName,
                Email = guest.Email,
                TableNumber = guest.TableNumber
            };
        }


        public void UpdateGuest(GuestModel guest)
        {
            var existing = _context.Guests.FirstOrDefault(g => g.Id == guest.Id);
            if (existing != null)
            {
                existing.FullName = guest.FullName;
                existing.Email = guest.Email;
                existing.TableNumber = guest.TableNumber;
                _context.SaveChanges();
            }
        }

        public void DeleteGuest(int id)
        {
            var guest = _context.Guests.FirstOrDefault(g => g.Id == id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }
        }

        public List<GuestModel> GetGuestsByWeddingId(int weddingId)
        {
            return _context.Guests
                .Where(g => g.WeddingId == weddingId)
                .Select(g => new GuestModel
                {
                    Id = g.Id,
                    WeddingId = g.WeddingId,
                    FullName = g.FullName,
                    Email = g.Email,
                    TableNumber = g.TableNumber
                })
                .ToList();
        }

    }
}