using licenseItExternal.Models;
using licenseItExternal.Models.DataBaseModel;

namespace licenseItExternal.Repositories.Interfaces
{
    public interface ILicenseRepository : IRepository<Licenses>
    {
        Licenses GetByNumber(string licenseNumber, string identityNumber, string applicationHash);
        LicenseStatusEnum ActiveLicense(string licenseNumber, string identityNumber, string applicationHash);
    }
}