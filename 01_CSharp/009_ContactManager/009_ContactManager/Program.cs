List<Contact> contacts = new List<Contact>();
bool isRunning = true;
Console.WriteLine("Welcome to the Contact Manager!");
Console.WriteLine();
while (isRunning)
{
    Console.WriteLine("1. Add contact");
    Console.WriteLine("2. Show contacts");
    Console.WriteLine("3. Update contact");
    Console.WriteLine("4. Remove contact");
    Console.WriteLine("5. Exit");
    Console.WriteLine();
    Console.WriteLine("Select option:");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            AddContact(contacts);
            break;

        case "2":
            ShowContacts(contacts);
            break;

        case "3":
            UpdateContact(contacts);
            break;

        case "4":
            RemoveContact(contacts);
            break;

        case "5":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
    if (isRunning)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
Console.WriteLine("Goodbye!");

void AddContact(List<Contact> contacts)
{
    Console.WriteLine("Enter the contact name:");
    string name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Contact name cannot be empty.");
        return;
    }

    Console.WriteLine("Enter the telephone number:");
    string phoneNumber = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(phoneNumber))
    {
        Console.WriteLine("Contact number cannot be empty.");
        return;
    }

    Console.WriteLine("Enter the e-mail address:");
    string email = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("Contact e-mail cannot be empty.");
        return;
    }

    Contact newContact = new Contact(name, phoneNumber, email);
    contacts.Add(newContact);

    Console.WriteLine("Contact added successfully.");
}

void ShowContacts(List<Contact> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("Your contact list is empty.");
        return;
    }

    Console.WriteLine("Your contacts: ");
    for (int i = 0; i < contacts.Count; i++)
    {
        Console.WriteLine(
                          $"{i + 1}. {contacts[i].Name} | " +
                          $"Phone: {contacts[i].PhoneNumber} | " +
                          $"E-mail: {contacts[i].Email}");
    }
}

void UpdateContact(List<Contact> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("Your contact list is empty!");
        return;
    }
    ShowContacts(contacts);
    Console.WriteLine();

    Console.WriteLine("Enter the number of the contact you want to update: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int contactNumber))
    {
        Console.WriteLine("Invalid Contact Number");
        return;
    }

    int index = contactNumber - 1;

    if (index < 0 || index >= contacts.Count)
    {
        Console.WriteLine("Contact number does not exist.");
        return;
    }

    Contact contactToUpdate = contacts[index];
    string oldName = contactToUpdate.Name;


    Console.WriteLine("Enter the contact name:");
    string newName = Console.ReadLine();

    Console.WriteLine("Enter the e-mail address:");
    string newEmail = Console.ReadLine();

    Console.WriteLine("Enter the telephone number:");
    string newNumber = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(newName) ||
        string.IsNullOrWhiteSpace(newEmail) ||
        string.IsNullOrWhiteSpace(newNumber))
    {
        Console.WriteLine("Contact details cannot be empty.");
        return;
    }

    contactToUpdate.Name = newName;
    contactToUpdate.Email = newEmail;
    contactToUpdate.PhoneNumber = newNumber;

    Console.WriteLine($"Contact \"{oldName}\" updated to \"{newName}\" successfully.");
}

void RemoveContact(List<Contact> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("Your contact list is empty!");
        return;
    }
    ShowContacts(contacts);
    Console.WriteLine();

    Console.WriteLine("Enter the number of contact to remove: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int contactNumber))
    {
        Console.WriteLine("Invalid contact number.");
        return;
    }
    int index = contactNumber - 1;

    if (index < 0 || index >= contacts.Count )
    {
        Console.WriteLine("Contact number does not exist.");
        return;
    }

    Contact removedContact = contacts[index];
    contacts.RemoveAt(index);

    Console.WriteLine($"Contact \"{removedContact.Name}\" removed successfully.");
}
