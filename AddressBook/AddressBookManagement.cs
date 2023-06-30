using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookManagement
    {
        public Dictionary<string, List<Contacts>> addressBooks;
        public Dictionary<string, List<Contacts>> contactsByCity;
        public Dictionary<string, List<Contacts>> contactsByState;
        public AddressBookManagement()
        {
            addressBooks = new Dictionary<string, List<Contacts>>();
            contactsByCity = new Dictionary<string, List<Contacts>>();
            contactsByState = new Dictionary<string, List<Contacts>>();
        }
        public void AddAddressBook(string addressBookName)
        {
            if (!addressBooks.ContainsKey(addressBookName))
            {
                addressBooks[addressBookName] = new List<Contacts>();
                Console.WriteLine("Address Book added successfully.");
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("Address Book with the same name already exists!");
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void AddContact(string addressBookName, Contacts contact)
        {
            if (addressBooks.ContainsKey(addressBookName))
            {
                List<Contacts> addressBook = addressBooks[addressBookName];

                bool isDuplicate = addressBook.Any(c => string.Equals(c.FirstName, contact.FirstName, StringComparison.OrdinalIgnoreCase) &&
                                                        string.Equals(c.LastName, contact.LastName, StringComparison.OrdinalIgnoreCase));
                if (!isDuplicate)
                {
                    addressBook.Add(contact);
                    Console.WriteLine("Contact added successfully!");
                    if (!contactsByCity.ContainsKey(contact.City))
                    {
                        contactsByCity[contact.City] = new List<Contacts>();
                    }
                    contactsByCity[contact.City].Add(contact);

                    if (!contactsByState.ContainsKey(contact.State))
                    {
                        contactsByState[contact.State] = new List<Contacts>();
                    }
                    contactsByState[contact.State].Add(contact);

                    Console.WriteLine("-----------------------------------------");
                }
                else
                {
                    Console.WriteLine("Duplicate entry ,contact with same name already exist");
                    Console.WriteLine("-----------------------------------------");
                }

            }
            else
            {
                Console.WriteLine("Address Book not found!");
            }
        }

        public void ViewContactsByCity(string city)
        {
            if (contactsByCity.ContainsKey(city))
            {
                List<Contacts> contacts = contactsByCity[city];
                Console.WriteLine("Contacts in: " + city);
                PrintContacts(contacts);
            }
            else
            {
                Console.WriteLine("No cntacts found in " + city);
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void ViewContactsByState(string state)
        {
            if (contactsByState.ContainsKey(state))
            {
                List<Contacts> contacts = contactsByState[state];
                Console.WriteLine("Contacts in: " + state);
                PrintContacts(contacts);
            }
            else
            {
                Console.WriteLine("No cntacts found in " + state);
                Console.WriteLine("No cntacts found in " + state);
                Console.WriteLine("No cntacts found in " + state);
                Console.WriteLine("No cntacts found in " + state);
                Console.WriteLine("-----------------------------------------");
            }
        }

        public void PrintContacts(List<Contacts> contacts)
        {
            foreach (Contacts contact in contacts)
            {
                Console.WriteLine("FirstName   = " + contact.FirstName);
                Console.WriteLine("LastName    = " + contact.LastName);
                Console.WriteLine("Address     = " + contact.Address);
                Console.WriteLine("City        = " + contact.City);
                Console.WriteLine("State       = " + contact.State);
                Console.WriteLine("Zip         = " + contact.Zipcode);
                Console.WriteLine("PhoneNumber = " + contact.PhoneNumber);
                Console.WriteLine("Email       = " + contact.Email);
                Console.WriteLine("-----------------------------------------");
            }
        }

        public void PrintContacts(string addressBookName)
        {
            if (addressBooks.ContainsKey(addressBookName))
            {
                List<Contacts> addressBook = addressBooks[addressBookName];
                Console.WriteLine("Contacts in Address Book : " + addressBookName);

                foreach (Contacts contact in addressBook)
                {
                    Console.WriteLine("FirstName   = " + contact.FirstName);
                    Console.WriteLine("LastName    = " + contact.LastName);
                    Console.WriteLine("Address     = " + contact.Address);
                    Console.WriteLine("City        = " + contact.City);
                    Console.WriteLine("State       = " + contact.State);
                    Console.WriteLine("Zip         = " + contact.Zipcode);
                    Console.WriteLine("PhoneNumber = " + contact.PhoneNumber);
                    Console.WriteLine("Email       = " + contact.Email);
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Address Book Not found...");
                Console.WriteLine("-----------------------------------------");
            }
        }

        public Contacts FindContact(List<Contacts> addressBook, string firstName, string lastName)
        {
            return addressBook.Find(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                                         c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public void EditContact(string addressBookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(addressBookName))
            {
                List<Contacts> addressBook = addressBooks[addressBookName];
                Contacts contact = FindContact(addressBook, firstName, lastName);
                if (contact != null)
                {
                    Console.WriteLine("Enter new details for the contact:");
                    Console.Write("FirstName: ");
                    contact.FirstName = Console.ReadLine();
                    Console.Write("LastName: ");
                    contact.LastName = Console.ReadLine();
                    Console.Write("Address: ");
                    contact.Address = Console.ReadLine();
                    Console.Write("City: ");
                    contact.City = Console.ReadLine();
                    Console.Write("State: ");
                    contact.State = Console.ReadLine();
                    Console.Write("Zip: ");
                    contact.Zipcode = Console.ReadLine();
                    Console.Write("Phone Number: ");
                    contact.PhoneNumber = Console.ReadLine();
                    Console.Write("Email: ");
                    contact.Email = Console.ReadLine();
                    Console.WriteLine("Contact updated successfully!");
                    Console.WriteLine("-----------------------------------------");
                }
                else
                {
                    Console.WriteLine("Contact not found!");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Address Book not found!");
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void DeleteContact(string addressBookName, string firstName, string lastName)
        {
            if (addressBooks.ContainsKey(addressBookName))
            {
                List<Contacts> addressBook = addressBooks[addressBookName];
                Contacts contact = FindContact(addressBook, firstName, lastName);
                if (contact != null)
                {
                    addressBook.Remove(contact);
                    Console.WriteLine("Contact deleted successfully!");
                    Console.WriteLine("-----------------------------------------");
                }
                else
                {
                    Console.WriteLine("Contact not found!");
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Address Book not found!");
                Console.WriteLine("-----------------------------------------");
            }
        }
        public void SearchContactsByCityOrState(string cityOrState)
        {
            List<Contacts> searchResults = new List<Contacts>();

            foreach (var addressBook in addressBooks.Values)
            {
                foreach (var contact in addressBook)
                {
                    if (contact.City.Equals(cityOrState, StringComparison.OrdinalIgnoreCase) ||
                        contact.State.Equals(cityOrState, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(contact);
                    }
                }
            }
            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search Results: ");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine("FirstName   = " + contact.FirstName);
                    Console.WriteLine("LastName    = " + contact.LastName);
                    Console.WriteLine("Address     = " + contact.Address);
                    Console.WriteLine("City        = " + contact.City);
                    Console.WriteLine("State       = " + contact.State);
                    Console.WriteLine("Zip         = " + contact.Zipcode);
                    Console.WriteLine("PhoneNumber = " + contact.PhoneNumber);
                    Console.WriteLine("Email       = " + contact.Email);
                    Console.WriteLine("-----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No contacts found in the specified city or state");
                Console.WriteLine("-----------------------------------------");
            }
        }
        public int CountByCity(string city)
        {
            if (contactsByCity.ContainsKey(city))
            {
                List<Contacts> contacts = contactsByCity[city];
                return contacts.Count;
            }
            else
            {
                return 0;
            }
        }
        public int CountByState(string state)
        {
            if (contactsByState.ContainsKey(state))
            {
                List<Contacts> contacts = contactsByState[state];
                return contacts.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}

