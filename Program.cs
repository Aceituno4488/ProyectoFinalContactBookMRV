// Codigo iniciado por Mariana Rivera Vazquez

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
            // TODO: mejorar pantalla de bienvenida
            Console.WriteLine("Contact Manager");
            Console.ReadLine();
        }

        static void MainMenu()
        {
            // TODO: implementar menú principal
        }

        class Contact
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            // TODO: añadir validaciones y más campos si es necesario
        }

        static void LoadContacts()
        {
            // TODO
        }

        static void ShowContacts()
        {
            // TODO
        }

        static void AddContact()
        {
            // TODO
        }

        static void EditContact()
        {
            // TODO
        }

        static void DeleteContact()
        {
            // TODO
        }

        static void MergeDuplicates()
        {
            // TODO
        }

        static void SaveContacts()
        {
            // TODO
        }

        static void ExitApplication()
        {
            // TODO: confirmar salida si hay cambios
        }
    }
}
