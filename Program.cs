using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsoleApp
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact contact1 =  clsContact.Find(ID);
            
            if(contact1 != null )
            {
                Console.WriteLine($"First Name = {contact1.FirstName}");
                Console.WriteLine($"Last Name  = {contact1.LastName}");
                Console.WriteLine($"Email      = {contact1.Email}");
                Console.WriteLine($"Phone      = {contact1.Phone}");
                Console.WriteLine($"Address    = {contact1.Address}");
                Console.WriteLine($"Birth Date = {contact1.DateOfBirth}");
                Console.WriteLine($"Country Id = {contact1.CountryID}");
                Console.WriteLine($"Image Path = {contact1.ImagePath}");
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] not found...");
            }

        }

        static void testAddNewContact()
        {
            clsContact contact1 = new clsContact();

            contact1.FirstName = "Rami";
            contact1.LastName = "Mohamed";
            contact1.Email = "mog43@gil.com";
            contact1.Phone = "1234567";
            contact1.Address = "istanv";
            contact1.DateOfBirth = new DateTime(1999, 11, 5, 3, 5, 1);
            contact1.CountryID = 1;
            contact1.ImagePath = "";


            if(contact1.Save())
            {
                Console.WriteLine("Contact added successfully with id = " + contact1.ContactID);
            }
        }

        static void testUpdateContact(int ID)
        {

            clsContact contact1 = clsContact.Find(ID);

            if (contact1 != null)
            {

                contact1.FirstName = "Roaa";
                contact1.LastName = "Ahmed";
                contact1.Email = "mfh43@gil.com";
                contact1.Phone = "1234567";
                contact1.Address = "irbud";
                contact1.DateOfBirth = new DateTime(1998, 11, 5, 3, 5, 1);
                contact1.CountryID = 1;
                contact1.ImagePath = "";


                if (contact1.Save())
                {
                    Console.WriteLine("Contact updated successfully");
                }
            }
        }

        static void testDeleteContact(int ID)
        {
            if(clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact deleted successfully...");
            }
            else
            {
                Console.WriteLine("Deltion failed...");
            }
        }

        static void testSelectAllContacts()
        {
            DataTable dt = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach(DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ContactID"].ToString()}, {row["FirstName"]} {row["LastName"]}\n\n");
            }
        }

        static void testIsContactExist(int ID)
        {
            if(clsContact.IsContactExist(ID))
            {
                Console.WriteLine($"Yes, contact {ID} is found...");
            }
            else
            {
                Console.WriteLine($"No, contact {ID} is not found...");
            }
        }

        static void testFindCountryNameByID(int ID)
        {
            clsCountries country1 = clsCountries.Find(ID);

            if(country1 != null)
            {
                Console.WriteLine($"Country with {ID} is found...\n\n");
                Console.WriteLine($"{country1.CountryID}");
                Console.WriteLine($"{country1.CountryName}");
                Console.WriteLine($"{country1.Code}");
                Console.WriteLine($"{country1.PhoneCode}");
            }
            else
            {
                Console.WriteLine($"Country with {ID} is not found...");
            }
        }

        static void testAddNewCountry()
        {
            clsCountries country = new clsCountries();

            country.CountryName = "Romania";
            country.Code = "394";
            country.PhoneCode = "Rom";
            if(country.Save())
            {
                Console.WriteLine($"Added successfully with ID {country.CountryID}");
            }
        }

        static void testUpdateCountry(int ID)
        {
            clsCountries country = clsCountries.Find(ID);

            if (country != null)
            {
                country.CountryName = "Japan";
                country.Code = "425";
                country.PhoneCode = "Jap";
            }
            if (country.Save()) 
            {
                Console.WriteLine($"Country updated with ID {country.CountryID}");
            }
        }

        static void testDeleteCountry(int ID)
        {
            if(clsCountries.DeleteCountry(ID))
            {
                Console.WriteLine($"Country with ID {ID} is deleted...");
            }
            else
            {
                Console.WriteLine($"Country could not be deleted...");
            }
        }

        static void testSelectAllCountries()
        {
            DataTable dt = clsCountries.GetAllCountries();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row["CountryID"].ToString().PadRight(2)}," +
                        $" {row["CountryName"].ToString().PadRight(2)}," +
                        $"{row["Code"].ToString().PadRight(2)}," +
                        $"{row["PhoneCode"].ToString().PadRight(2)}");
                }
            }
            else
            {
                Console.WriteLine("No data available...");
            }
        }

        static void testIsCountryExist(int ID)
        {
            if(clsCountries.IsCountryExist(ID))
            {
                Console.WriteLine("Yes, country is available...");
            }
            else
            {
                Console.WriteLine("No, country is not available...");
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
