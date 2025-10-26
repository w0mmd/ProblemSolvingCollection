using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode {AddMode, UpdateMode};
        public enMode Mode = enMode.AddMode;

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }


       public clsContact()
        {
            this.ContactID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";

            Mode = enMode.AddMode;
        }

        clsContact(int ID, string FirstName, string LastName, string Email,
            string Phone, string Address, DateTime DateOfBirth, int CountryID,
            string ImagePath)
        {
            this.ContactID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.UpdateMode;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "",
                ImagePath = ""; DateTime DateOfBirth = DateTime.Now; int CountryID = -1;

            if(clsContactsDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email,
                ref Phone, ref Address,ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName,  LastName, Email,
                Phone, Address, DateOfBirth, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewContact()
        {
            this.ContactID = clsContactsDataAccess.AddNewContact(this.FirstName, this.LastName,
              this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID,
              this.ImagePath);

            return (ContactID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactsDataAccess.UpdateContact(this.ContactID, this.FirstName, this.LastName,
                this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactsDataAccess.DeleteContact(ID);
        }

        public static DataTable GetAllContacts()
        {
            return clsContactsDataAccess.GetAllContacts(); 
        }

        public static bool IsContactExist(int ID)
        {
            return clsContactsDataAccess.IsContactExist(ID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddMode:
                    if (_AddNewContact())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;   
                    }
                case enMode.UpdateMode:
                    return _UpdateContact();

                default: 
                    return false;
            }
        }
    }
}
