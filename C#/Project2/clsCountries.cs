using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountries
    {

        public enum enMode { AddMode, UpdateMode};
        public enMode Mode = enMode.AddMode;

        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }



        public clsCountries()
        {
             this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";


            Mode = enMode.AddMode;
        }

        clsCountries(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.UpdateMode;
        }
        public static clsCountries Find(int ID)
        {
            string CountryName = "", Code = "", PhoneCode = "";
            if(clsCountriesDataAccess.GetCountriesInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountries(ID, CountryName, Code, PhoneCode);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);

            return (CountryID != -1);
        }
        
        private bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);
        }
        
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddMode:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
               case enMode.UpdateMode:
                    return _UpdateCountry();

                default:
                    return false;
            }
        }

        public static bool DeleteCountry(int ID)
        {
            return clsCountriesDataAccess.DeleteCountry(ID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

        public static bool IsCountryExist(int ID)
        {
            return clsCountriesDataAccess.IsCountryExist(ID);
        }
    }
}
