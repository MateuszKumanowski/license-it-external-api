using licenseItExternal.Models.AppModel;
using licenseItExternal.Repositories;
using licenseItExternal.Repositories.Interfaces;

namespace licenseItExternal.Classes
{
    public class LicenseClass
    {
        private readonly ILicenseRepository _licenseRepository = new LicenseRepository(new DataBaseContext());

        public LicenseModel GetLicense(string licenseInputLicenseNumber, string licenseInputIdentityNumber, string licenseInputApplicationHash)
        {
            var getLicense = _licenseRepository.GetByNumber(licenseInputLicenseNumber, licenseInputIdentityNumber, licenseInputApplicationHash);
            if (getLicense != null)
            {
                return new LicenseModel
                {
                    Expiration = getLicense.Expiration,
                    IsActive = getLicense.IsActive,
                    AssignedVersion = getLicense.AssignedVersion,
                    Description = "License active"
                };
            }

            return new LicenseModel();
        }
    }
}
