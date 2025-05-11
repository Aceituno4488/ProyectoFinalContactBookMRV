// Code written by Mariana Rivera Vázquez

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactManager
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();
        static bool changesMade = false;

        static void Main(string[] args)
        {
            ShowWelcomeScreen();
            MainMenu();
        }

        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Contact Manager\n");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== Contact Manager Main Menu ======");
                Console.WriteLine("1. Load Contacts from File");
                Console.WriteLine("2. Show All Contacts");
                Console.WriteLine("3. Add New Contact");
                Console.WriteLine("4. Edit Existing Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Merge Duplicate Contacts");
                Console.WriteLine("7. Save Contacts to File");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option (1-8): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": LoadContacts(); break;
                    case "2": ShowContacts(); break;
                    case "3": AddContact(); break;
                    case "4": EditContact(); break;
                    case "5": DeleteContact(); break;
                    case "6": MergeDuplicates(); break;
                    case "7": SaveContacts(); break;
                    case "8": ExitApplication(); return;
                    default: 
                        Console.WriteLine("Invalid option. Press ENTER to try again."); 
                        Console.ReadLine(); 
                        break;
                }
            }
        }

        // Class to represent a contact
        class Contact
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public override string ToString()
            {
                return $"{Name} {LastName}, {PhoneNumber}, {Email}";
            }
        }

        // Main contact manager methods
        static void LoadContacts() { /* Load from file */ }
        static void ShowContacts() { /* Display contact list */ }
        static void AddContact() { /* Add new contact */ }
        static void EditContact() { /* Edit existing contact */ }
        static void DeleteContact() { /* Delete contact */ }
        static void MergeDuplicates() { /* Merge duplicate contacts */ }
        static void SaveContacts() { /* Save to file */ }

        static void ExitApplication()
        {
            if (changesMade)
            {
                Console.WriteLine("Changes have been made. Are you sure you want to exit without saving? (y/n)");
                if (Console.ReadLine().ToLower() != "y") return;
            }
            Console.WriteLine("Thank you for using Contact Manager. Goodbye!");
            Console.ReadLine();
        }
    }
}
