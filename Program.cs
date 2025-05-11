//Codigo Hecho por Mariana Rivera Vazquez

using System;
using System.Collections.Generic;

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

        // Clase Contact en construccion
        class Contact
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            // Falta agregar validaciones o formato mas detallado
            public override string ToString()
            {
                return $"{Name} {LastName}, {PhoneNumber}, {Email}";
            }
        }

        // Métodos aún no implementados (en construccion)
        static void LoadContacts()
        {
            Console.WriteLine("Cargar contactos aún no implementado...");
            Console.ReadLine();
        }

        static void ShowContacts()
        {
            Console.WriteLine("Mostrar contactos aún no implementado...");
            Console.ReadLine();
        }

        static void AddContact()
        {
            Console.WriteLine("Agregar contacto aún no implementado...");
            Console.ReadLine();
        }

        static void EditContact()
        {
            Console.WriteLine("Editar contacto aún no implementado...");
            Console.ReadLine();
        }

        static void DeleteContact()
        {
            Console.WriteLine("Eliminar contacto aún no implementado...");
            Console.ReadLine();
        }

        static void MergeDuplicates()
        {
            Console.WriteLine("Fusionar duplicados aún no implementado...");
            Console.ReadLine();
        }

        static void SaveContacts()
        {
            Console.WriteLine("Guardar contactos aún no implementado...");
            Console.ReadLine();
        }

        static void ExitApplication()
        {
            if (changesMade)
            {
                Console.WriteLine("Hay cambios no guardados. ¿Salir sin guardar? (s/n)");
                if (Console.ReadLine().ToLower() != "s") return;
            }
            Console.WriteLine("Saliendo del programa...");
            Console.ReadLine();
        }
    }
}
