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
                return $"{Name} {LastName}, Phone: {PhoneNumber}, Email: {Email}";
            }
        }

        static void LoadContacts()
        {
            if (File.Exists("contacts.txt"))
            {
                contacts.Clear();
                string[] lines = File.ReadAllLines("contacts.txt");

                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        contacts.Add(new Contact
                        {
                            Name = parts[0],
                            LastName = parts[1],
                            PhoneNumber = parts[2],
                            Email = parts[3]
                        });
                    }
                }

                Console.WriteLine("Contacts loaded successfully. Press ENTER to continue.");
            }
            else
            {
                Console.WriteLine("No contacts file found. Press ENTER to continue.");
            }
            Console.ReadLine();
        }

        static void SaveContacts()
        {
            using (StreamWriter writer = new StreamWriter("contacts.txt"))
            {
                foreach (var contact in contacts)
                {
                    writer.WriteLine($"{contact.Name}|{contact.LastName}|{contact.PhoneNumber}|{contact.Email}");
                }
            }

            changesMade = false;
            Console.WriteLine("Contacts saved successfully. Press ENTER to continue.");
            Console.ReadLine();
        }

        static void ShowContacts()
        {
            Console.Clear();
            Console.WriteLine("=== Contact List ===");

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts to display.");
            }
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contacts[i]}");
                }
            }

            Console.WriteLine("\nPress ENTER to return to the menu.");
            Console.ReadLine();
        }

        static void AddContact()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Contact ===");

            Console.Write("First Name: ");
            string name = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Name and Last Name are required. Press ENTER to return.");
                Console.ReadLine();
                return;
            }

            contacts.Add(new Contact
            {
                Name = name,
                LastName = lastName,
                PhoneNumber = phone,
                Email = email
            });

            changesMade = true;

            Console.WriteLine("Contact added successfully! Press ENTER to continue.");
            Console.ReadLine();
        }

        static void EditContact()
        {
            ShowContacts();

            Console.Write("Enter the number of the contact to edit: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= contacts.Count)
            {
                Contact c = contacts[index - 1];

                Console.Write($"New First Name ({c.Name}): ");
                string name = Console.ReadLine();
                Console.Write($"New Last Name ({c.LastName}): ");
                string lastName = Console.ReadLine();
                Console.Write($"New Phone Number ({c.PhoneNumber}): ");
                string phone = Console.ReadLine();
                Console.Write($"New Email ({c.Email}): ");
                string email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name)) c.Name = name;
                if (!string.IsNullOrWhiteSpace(lastName)) c.LastName = lastName;
                if (!string.IsNullOrWhiteSpace(phone)) c.PhoneNumber = phone;
                if (!string.IsNullOrWhiteSpace(email)) c.Email = email;

                changesMade = true;
                Console.WriteLine("Contact updated. Press ENTER to continue.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Press ENTER to return.");
            }

            Console.ReadLine();
        }

        static void DeleteContact()
        {
            ShowContacts();

            Console.Write("Enter the number of the contact to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= contacts.Count)
            {
                contacts.RemoveAt(index - 1);
                changesMade = true;
                Console.WriteLine("Contact deleted. Press ENTER to continue.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Press ENTER to return.");
            }

            Console.ReadLine();
        }

        static void MergeDuplicates()
        {
            var uniqueContacts = contacts
                .GroupBy(c => $"{c.Name.ToLower()}|{c.LastName.ToLower()}")
                .Select(g => g.First()) // keep the first of each duplicate group
                .ToList();

            if (uniqueContacts.Count < contacts.Count)
            {
                contacts = uniqueContacts;
                changesMade = true;
                Console.WriteLine("Duplicates merged. Press ENTER to continue.");
            }
            else
            {
                Console.WriteLine("No duplicates found. Press ENTER to continue.");
            }

            Console.ReadLine();
        }

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
