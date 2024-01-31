//==========================================================
// Student Number : S10258107
// Student Name : Gan Jun Hang
// Partner Name : Ivan Ng Keyang
//==========================================================

using Assignment;

List<Customer> CustomerList = new List<Customer>();

List<Customer> ReadCustomers( List<Customer> cList )
{
    using (StreamReader sr = new StreamReader("customers.csv")) 
    {
        sr.ReadLine();  //removing header
        string line;

        Console.WriteLine($"Name\tMember ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
        while ((line = sr.ReadLine()??"") != null)
        {
            string[] values = line.Split(',');
            Customer c = new Customer(values[0], int.Parse(values[1]), DateTime.Parse(values[2]), new PointCard(int.Parse(values[4]), int.Parse(values[5])));
            c.Rewards.Tier = values[3].ToLower();

            //c.Rewards.AddPoints(0);     // work around to assign membership tier since AddPoints() will also assign a tier.
            cList.Add(c);
        }
        sr.Close();
    }
    return cList;
}

void ListCustomers()
{
    Console.WriteLine($"Name\tMember ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
    foreach (Customer c in CustomerList)
    {
        Console.WriteLine($"{c.Name}\t{c.Memberid}\t{c.Dob}\t{c.Rewards.Tier}\t{c.Rewards.Points}\t{c.Rewards.PunchCard}");
    }
}

void ListCurrentOrders()
{
    // Console.WriteLine($"{"Name", 16}Member ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
    foreach (Customer c in CustomerList)
    {
        Console.WriteLine($"{c.CurrentOrder}");
    }
}

bool RegisterCustomer()
{
    Customer NewCustomer = new Customer(); //   create new customer object
    string name;//  name of customer
    int memberid;//  member id of customer
    DateTime dob;//  date of birth of customer

    // get customer details
    Console.Write("Enter name: ");
    name = Console.ReadLine()??"";
    Console.Write("Enter member ID: ");
    memberid = int.Parse(Console.ReadLine()??"0");
    Console.Write("Enter date of birth (dd/mm/yyyy): ");
    dob = DateTime.Parse(Console.ReadLine()??"01/01/1900");

    // create new customer object
    NewCustomer = new Customer(name, memberid, dob, new PointCard());

    // add customer to file
    using (StreamWriter sw = new StreamWriter("customers.csv", true))
    {
        try
        {
            sw.WriteLine($"{NewCustomer.Name},{NewCustomer.Memberid},{NewCustomer.Dob},{NewCustomer.Rewards.Tier},{NewCustomer.Rewards.Points},{NewCustomer.Rewards.PunchCard}");
            Console.WriteLine("Customer added successfully!");//  display success message
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Error writing to file!");// display error message
            return false;
        }
        finally
        {
            sw.Close();
        }
    }
}


bool CreateOrder()
{
    return true;
}

void DisplayOrderDetails()
{

}

bool ModifyOrderDetails()
{
    return true;
}

// Extra functions

// Main loop
while(true)
{
    Console.WriteLine("===============================\nWelcome to I.C. Treats!\n\nHow can we be of service today?\n===============================\n[1] List All Customers\n[2] List All Current Orders\n[3] Register A New Customer\n[4] Create A Customer's Order\n[5] Display Order Details Of A Customer\n[6] Modify Order Details\n[0] Exit Program");
    Console.Write("Enter your option: ");
    string option = Console.ReadLine()??"-1";
    Console.WriteLine();
    try
    {
        switch (option)
        {
            case "1":
                ListCustomers();
                break;
            case "2":
                ListCurrentOrders();
                break;
            case "3":
                if (RegisterCustomer()) break;
                else throw new InvalidOptionException();
            case "4":
                if (CreateOrder()) break;
                else throw new InvalidOptionException();
            case "5":
                DisplayOrderDetails();
                break;
            case "6":
                ModifyOrderDetails();
                break;
            case "0":
                Console.WriteLine("Thank you for using I.C. Treats!");
                return;
            default:
                throw new InvalidOptionException();
        }
    }
    catch(InvalidOptionException)
    {
        Console.WriteLine("Invalid option! Please try again.");
    }
    finally
    {
        Thread.Sleep(1500); // wait 1.5s
    }
}