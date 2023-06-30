namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddressBookManagement addressBookManager = new AddressBookManagement();

            while (true)
            {
                Console.WriteLine("Select an Option: ");
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Add a Contact to an address book.");
                Console.WriteLine("3. Print all Contacts in Address book.");
                Console.WriteLine("4. Edit a contact in Address Book.");
                Console.WriteLine("5. Delete Contact from an Address book.");
                Console.WriteLine("6. Quit");
                Console.Write("Option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter address book name: ");
                        string addressBookName = Console.ReadLine();
                        addressBookManager.AddAddressBook(addressBookName);
                        break;
                    case "2":
                        Console.WriteLine("Enter address book name: ");
                        string bookNameToAddContact = Console.ReadLine();
                        Console.WriteLine("Enter contact details:");

                        Contacts contactToAdd = new Contacts();

                        Console.Write("First Name: ");
                        contactToAdd.FirstName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        contactToAdd.LastName = Console.ReadLine();

                        Console.Write("Address: ");
                        contactToAdd.Address = Console.ReadLine();

                        Console.Write("City: ");
                        contactToAdd.City = Console.ReadLine();

                        Console.Write("State: ");
                        contactToAdd.State = Console.ReadLine();

                        Console.Write("Zip: ");
                        contactToAdd.Zipcode = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        contactToAdd.PhoneNumber = Console.ReadLine();

                        Console.Write("Email: ");
                        contactToAdd.Email = Console.ReadLine();

                        addressBookManager.AddContact(bookNameToAddContact, contactToAdd);
                        break;
                    case "3":
                        Console.WriteLine("Enter Address Book name: ");
                        string bookNameToPrintContacts = Console.ReadLine();
                        addressBookManager.PrintContacts(bookNameToPrintContacts);
                        break;
                    case "4":
                        Console.WriteLine("Enter address book name : ");
                        string bookNameToEditContact = Console.ReadLine();

                        Console.Write("Enter First Name of the contact to edit: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Enter Last Name of the contact to edit: ");
                        string lastName = Console.ReadLine();

                        addressBookManager.EditContact(bookNameToEditContact,firstName, lastName);
                        break;
                    case "5":
                        Console.WriteLine("Enter Address Book name:");
                        string bookNameToDeleteContact = Console.ReadLine();

                        Console.Write("enter First Name of the contact to delete: ");
                        string deleteFirstName = Console.ReadLine();

                        Console.Write("Enter Last Name of the contact to delete: ");
                        string deleteLastName = Console.ReadLine();

                        addressBookManager.DeleteContact(bookNameToDeleteContact,deleteFirstName, deleteLastName);
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}