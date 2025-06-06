using System.Numerics;
using Wedding_Planner.Models.DTO;
using Wedding_Planner.Models.Entity;

namespace Wedding_Planner.Services.Impl
{
    public class VendorsService : IVendorsService
    {

        private readonly WeddingPlannerDbContext _context;


        public VendorsService(WeddingPlannerDbContext context)
        {
            _context = context;
        }


        public void AddVendor(VendorsModel vendor)
        {
            var entity = new Vendor
            {
                VendorName = vendor.VendorName,
                ContactPerson = vendor.ContactPerson,
                Email = vendor.Email,
                Phone = vendor.Phone,
                Website = vendor.Website,
                Address = vendor.Address,
                Description = vendor.Description,
                HourlyRate = vendor.HourlyRate,
                IsActive = true
            };

            _context.Vendors.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteVendor(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(g => g.Id == id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }

        public VendorsModel GetVendorById(int id)
        {
            var vendor = _context.Vendors.FirstOrDefault(g => g.Id == id);
            if (vendor == null) return null;

            return new VendorsModel
            {
                Id = vendor.Id,
                VendorName = vendor.VendorName,
                ContactPerson = vendor.ContactPerson,
                Email = vendor.Email,
                Phone = vendor.Phone,
                Website = vendor.Website,
                Address = vendor.Address,
                Description = vendor.Description,
                HourlyRate = vendor.HourlyRate,
                IsActive = vendor.IsActive
            };
        }

        public List<VendorsModel> GetVendors()
        {
            return _context.Vendors
                .Select(vendor => new VendorsModel
                {
                    Id = vendor.Id,
                    VendorName = vendor.VendorName,
                    ContactPerson = vendor.ContactPerson,
                    Email = vendor.Email,
                    Phone = vendor.Phone,
                    Website = vendor.Website,
                    Address = vendor.Address,
                    Description = vendor.Description,
                    HourlyRate = vendor.HourlyRate,
                    IsActive = vendor.IsActive
                })
                .ToList();
        }

        public void UpdateVendor(VendorsModel guest)
        {
            throw new NotImplementedException();
        }
    }
}
