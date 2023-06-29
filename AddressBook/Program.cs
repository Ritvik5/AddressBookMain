namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddressBookManagement manager = new AddressBookManagement();

            while (true)
            {
                Console.WriteLine("Select an Option");
                Console.WriteLine("1. Add a new contact");
                Console.WriteLine("2. Print all contacts");
                Console.WriteLine("3. Quit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        while(true)
                        {
                            Console.WriteLine("Enter contact information:");

                            Contacts newContact = new Contacts();

                            Console.Write("First Name: ");
                            newContact.FirstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            newContact.LastName = Console.ReadLine();

                            Console.Write("Address: ");
                            newContact.Address = Console.ReadLine();

                            Console.Write("City: ");
                            newContact.City = Console.ReadLine();

                            Console.Write("State: ");
                            newContact.State = Console.ReadLine();

                            Console.Write("Zip: ");
                            newContact.Zipcode = Console.ReadLine();

                            Console.Write("Phone Number: ");
                            newContact.PhoneNumber = Console.ReadLine();

                            Console.Write("Email: ");
                            newContact.Email = Console.ReadLine();

                            manager.AddContact(newContact);

                            Console.Write("Do You want to add another contact? (Y/N) ");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "y")
                            {
                                break;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("\nAddress Book:");
                        manager.PrintContacts();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}