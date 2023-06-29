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

        public void EditContact(string firstName, string lastName)
        {

            Contacts contactToEdit = contacts.Find(contact => contact.FirstName == firstName && contact.LastName == lastName);

            if (contactToEdit == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine("Enter new contact information:");

            Console.Write("First Name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string newLastName = Console.ReadLine();

            Console.Write("Address: ");
            string newAddress = Console.ReadLine();

            Console.Write("City: ");
            string newCity = Console.ReadLine();

            Console.Write("State: ");
            string newState = Console.ReadLine();

            Console.Write("Zip: ");
            string newZip = Console.ReadLine();

            Console.Write("Phone Number: ");
            string newPhoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            string newEmail = Console.ReadLine();

            contactToEdit.FirstName = newFirstName;
            contactToEdit.LastName = newLastName;
            contactToEdit.Address = newAddress;
            contactToEdit.City = newCity;
            contactToEdit.State = newState;
            contactToEdit.Zipcode = newZip;
            contactToEdit.PhoneNumber = newPhoneNumber;
            contactToEdit.Email = newEmail;

            Console.WriteLine("Contact updated.");
        }

        public void DeleteContact(string firstName, string lastName)
        {
            Contacts contactToDelete = contacts.Find(contact => contact.FirstName == firstName && contact.LastName == lastName);

            if (contactToDelete == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.Remove(contactToDelete);
            Console.WriteLine("Contact deleted.");
        }
    }
}
