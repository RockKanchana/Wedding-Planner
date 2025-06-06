using Wedding_Planner.Models.DTO;

namespace Wedding_Planner.Services
{
    public interface IVendorsService
    {
        void AddVendor(VendorsModel vendor);
        List<VendorsModel> GetVendors();
        VendorsModel GetVendorById(int id);
        void UpdateVendor(VendorsModel guest);
        void DeleteVendor(int id);
    }
}
