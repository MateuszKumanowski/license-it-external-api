using System;
using licenseItExternal.Classes;
using licenseItExternal.Models;
using licenseItExternal.Models.AppModel;
using licenseItExternal.Models.DataBaseModel;
using licenseItExternal.Repositories;
using licenseItExternal.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace licenseItExternal.Controllers
{
    [Produces("application/json")]
    public class LicenseController : Controller
    {
        private readonly ILicenseRepository _licenseRepository = new LicenseRepository(new DataBaseContext());

        // POST: api/License/Get
        [HttpPost]
        [Route("api/License/Get")]
        public LicenseModel GetById([FromBody] LicenseInput licenseInput)
        {
            if (string.IsNullOrEmpty(licenseInput?.IdentityNumber) || string.IsNullOrEmpty(licenseInput.ApplicationHash) || string.IsNullOrEmpty(licenseInput.LicenseNumber))
                throw new Exception("invalid data");

            var resp = new LicenseModel();

            try
            {
                var res = _licenseRepository.GetByNumber(licenseInput.LicenseNumber, licenseInput.IdentityNumber, licenseInput.ApplicationHash);

                if (res != null)
                {
                    resp = new LicenseModel
                    {
                        Expiration = res.Expiration,
                        IsActive = res.IsActive,
                        AssignedVersion = res.AssignedVersion,
                        Description = "License active"
                    };
                }
                else
                {
                    resp = new LicenseModel
                    {
                        IsActive = false,
                        Description = "No active license"
                    };
                }
                
            }
            catch (Exception ex)
            {
                resp.Description = $"Error: {ex.Message}";
            }

            //SetLogs
            new LogsClass(new Logs
            {
                Description = resp.Description,
                Date = DateTime.Now,
                LicenseNumber = licenseInput.LicenseNumber
            }).SetLogs();

            return resp;
        }

        // POST: api/License/Active
        [HttpPost]
        [Route("api/License/Active")]
        public LicenseModel Active([FromBody] LicenseInput licenseInput)
        {
            var resp = new LicenseModel();

            try
            {
                if(string.IsNullOrEmpty(licenseInput?.IdentityNumber) || string.IsNullOrEmpty(licenseInput.ApplicationHash) || string.IsNullOrEmpty(licenseInput.LicenseNumber))
                    throw new Exception("invalid data");

             
                var res = _licenseRepository.ActiveLicense(licenseInput.LicenseNumber, licenseInput.IdentityNumber, licenseInput.ApplicationHash);
                
                switch (res)
                {
                    case LicenseStatusEnum.Incorrect:
                        resp.Description = "License is incorrect";
                        break;
                    case LicenseStatusEnum.InActive:
                        resp.Description = "License is not active";
                        break;
                    case LicenseStatusEnum.HasExpired:
                        resp.Description = "License has expired";
                        break;
                    case LicenseStatusEnum.NotEnabled:
                        resp.Description = "License is not enabled";
                        break;
                    case LicenseStatusEnum.NoIdentityNumber:
                        resp.Description = "No identity number";
                        break;
                    case LicenseStatusEnum.AlreadyActivated:
                        resp.Description = "License already activated";
                        break;
                    case LicenseStatusEnum.Active:
                    case LicenseStatusEnum.Activated:
                        resp.Description = "License active";
                        var licenseClass = new LicenseClass();
                        resp = licenseClass.GetLicense(licenseInput.LicenseNumber, licenseInput.IdentityNumber, licenseInput.ApplicationHash);
                        break;
                    case LicenseStatusEnum.Error:
                        resp.Description = "Error";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
            }
            catch (Exception ex)
            {
                resp.Description = $"Error: {ex.Message}";
            }

            //SetLogs
            new LogsClass(new Logs
            {
                Description = resp.Description,
                Date = DateTime.Now,
                LicenseNumber = licenseInput?.LicenseNumber??""
            }).SetLogs();

            return resp;
        }

    }
}
