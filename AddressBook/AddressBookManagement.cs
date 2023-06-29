using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookManagement
    {
        public List<Contacts> contacts = new List<Contacts>();
        public void AddContact(Contacts contact)
        {
            contacts.Add(contact);
        }

        public void PrintContacts()
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
            }
        }
    }
}
