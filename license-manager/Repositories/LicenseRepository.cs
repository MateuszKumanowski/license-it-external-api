using System;
using System.Linq;
using licenseItExternal.Models;
using licenseItExternal.Models.DataBaseModel;
using licenseItExternal.Repositories.Interfaces;

namespace licenseItExternal.Repositories
{
   
    public class LicenseRepository : Repository<Licenses>, ILicenseRepository
    {
        private readonly DataBaseContext _context;

        public LicenseRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public Licenses GetByNumber(string licenseNumber, string identityNumber, string applicationHash)
        {
            var lic = _context.Licenses.FirstOrDefault(x => x.Number.Equals(licenseNumber) && x.IsActive && x.IsActivated && x.IdentityNumber == identityNumber && x.Application.Hash.Equals(applicationHash));

            if (lic?.Inclusion != null && (lic.Inclusion.Value.Date <= DateTime.Now.Date && (lic.Expiration.HasValue && lic.Expiration.Value.Date >= DateTime.Now.Date)))
            {
                return lic;
            }

            if (lic?.Inclusion != null && lic?.Expiration == null && lic.Inclusion.Value.Date <= DateTime.Now.Date)
            {
                return lic;
            }

            if (lic?.Inclusion == null && lic?.Expiration != null && lic.Expiration.Value.Date >= DateTime.Now.Date)
            {
                return lic;
            }

            if (lic != null && lic?.Expiration == null && lic?.Inclusion == null)
            {
                return lic;
            }

            return null;
        }

        public LicenseStatusEnum ActiveLicense(string licenseNumber, string identityNumber, string applicationHash)
        {

            var getActive = GetByNumber(licenseNumber, identityNumber, applicationHash);

            if (getActive != null)
            {
                return LicenseStatusEnum.Active;
            }

            var licenseObject = _context.Licenses.FirstOrDefault(x => x.Number.Equals(licenseNumber) && x.Application.Hash.Equals(applicationHash));

            if (licenseObject == null)
            {
                return LicenseStatusEnum.Incorrect;
            }

            if (!licenseObject.IsActive)
            {
                return LicenseStatusEnum.InActive;
            }

            if ((licenseObject.Expiration != null && licenseObject.Expiration.Value.Date < DateTime.Now.Date))
            {
                return LicenseStatusEnum.HasExpired;
            }
            if ((licenseObject.Inclusion != null && licenseObject.Inclusion.Value.Date > DateTime.Now.Date))
            {
                return LicenseStatusEnum.NotEnabled;
            }

            if (string.IsNullOrEmpty(identityNumber))
            {
                return LicenseStatusEnum.NoIdentityNumber;
            }

            if (licenseObject.IsActivated && licenseObject.IdentityNumber.Equals(identityNumber))
            {
                return LicenseStatusEnum.AlreadyActivated;
            }

            if (string.IsNullOrEmpty(licenseObject.IdentityNumber))
            {
                licenseObject.LastCheck = DateTime.Now;
                licenseObject.IdentityNumber = identityNumber;
                licenseObject.LastCheckIdentityNumber = identityNumber;
                licenseObject.IsActivated = true;
                _context.SaveChanges();
                
                return LicenseStatusEnum.Activated;
            }

            return LicenseStatusEnum.Error;
        }
    }
}
