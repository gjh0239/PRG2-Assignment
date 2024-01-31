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

void CreateIceCreamMenu() 
{
    //  Menu details
    int MenuOption;
    IceCream NewIceCream;
        //creating ice cream order:
        Console.WriteLine($"===============================\nIce Cream Menu\n===============================\n[1] Cup\n[2] Cone\n[3] Waffle\n[0] Exit Program\n===============================\n");
        Console.Write("Enter your option: ");
        MenuOption = int.Parse(Console.ReadLine()??"0");
        switch (MenuOption)
        {
            case 1:
                NewIceCream = CreateCup();
                break;

            case 2:
                NewIceCream = CreateCone();
                break;

            case 3:
                NewIceCream = CreateWaffle();
                break;

            case 0:
                Console.WriteLine("Thank you for using I.C. Treats!");
                return;
            default:
                throw new InvalidOptionException();
        }
}

Cup CreateCup()
{
    Cup x;
    string option = "cup";
    int scoops;

    Flavour f;
    //flavour list
    string type;
    bool premium;
    int quantity;
    Topping t;
    //topping list
    string ToppingType;
    int ToppingQuantity;

    Console.Write("Enter number of scoops: ");
    scoops = int.Parse(Console.ReadLine()??"0");
    //flavour list
    Console.WriteLine($"===============================\nFlavour Menu\n===============================\n[1] Vanilla\n[2] Chocolate\n[3] Strawberry\n===============================\n");
    Console.Write("Enter Type of Ice Cream: ");
    type = Console.ReadLine()??"";
    Console.Write("Would you like premium flavours? (Y/N): ");
    if (Console.ReadLine().ToLower() == "y") 
    {
        premium = true;
    } 
    else 
    {
        premium = false;
    }
    Console.Write("Enter quantity: ");
    quantity = int.Parse(Console.ReadLine()??"0");
    f = new Flavour(type, premium, quantity);//  Flavour object

    //topping list
    Console.WriteLine($"===============================\nTopping Menu\n===============================\n[1] Sprinkles\n[2] Mochi\n[3] Sago\n[4] Oreos\n===============================\n");
    Console.Write("Enter Type of Topping: ");
    ToppingType = Console.ReadLine()??"";// Topping type
    Console.Write("Enter quantity: ");
    ToppingQuantity = int.Parse(Console.ReadLine()??"0");// Topping quantity
    t = new Topping(ToppingType, ToppingQuantity);//  Topping object
    
    //  create cup object
    x = new Cup(option, scoops, new List<Flavour>(), new List<Topping>());
    return x;
}

Cone CreateCone()
{
    
    Cone x;
    string option = "cone";
    int scoops;
    bool dipped;

    Flavour f;
    //flavour list
    string type;
    bool premium;
    int quantity;
    Topping t;
    //topping list
    string ToppingType;
    int ToppingQuantity;

    Console.Write("Enter number of scoops: ");
    scoops = int.Parse(Console.ReadLine()??"0");
    //flavour list
    Console.WriteLine($"===============================\nFlavour Menu\n===============================\n[1] Vanilla\n[2] Chocolate\n[3] Strawberry\n===============================\n");
    Console.Write("Enter Type of Ice Cream: ");
    type = Console.ReadLine()??"";
    Console.Write("Would you like premium flavours? (Y/N): ");
    if (Console.ReadLine().ToLower() == "y") 
    {
        premium = true;
    } 
    else 
    {
        premium = false;
    }
    Console.Write("Enter quantity: ");
    quantity = int.Parse(Console.ReadLine()??"0");
    f = new Flavour(type, premium, quantity);//  Flavour object

    //topping list
    Console.WriteLine($"===============================\nTopping Menu\n===============================\n[1] Sprinkles\n[2] Mochi\n[3] Sago\n[4] Oreos\n===============================\n");
    Console.Write("Enter Type of Topping: ");
    ToppingType = Console.ReadLine()??"";// Topping type
    Console.Write("Enter quantity: ");
    ToppingQuantity = int.Parse(Console.ReadLine()??"0");// Topping quantity
    t = new Topping(ToppingType, ToppingQuantity);//  Topping object
    
    //dipped?
    Console.Write("Would you like your cone dipped? (Y/N): ");
    if (Console.ReadLine().ToLower() == "y") 
    {
        dipped = true;
    } 
    else 
    {
        dipped = false;
    }
    //  create cone object
    x = new Cone(option, scoops, new List<Flavour>(), new List<Topping>(), dipped);
    return x;
}

Waffles CreateWaffle() 
{
    
    Waffles x;
    string option = "Waffle";
    int scoops;
    string WaffleFlavour;

    Flavour f;
    //flavour list
    string type;
    bool premium;
    int quantity;
    Topping t;
    //topping list
    string ToppingType;
    int ToppingQuantity;

    Console.Write("Enter number of scoops: ");
    scoops = int.Parse(Console.ReadLine()??"0");
    //flavour list
    Console.WriteLine($"===============================\nFlavour Menu\n===============================\n[1] Vanilla\n[2] Chocolate\n[3] Strawberry\n===============================\n");
    Console.Write("Enter Type of Ice Cream: ");
    type = Console.ReadLine()??"";
    Console.Write("Would you like premium flavours? (Y/N): ");
    if (Console.ReadLine().ToLower() == "y") 
    {
        premium = true;
    } 
    else 
    {
        premium = false;
    }
    Console.Write("Enter quantity: ");
    quantity = int.Parse(Console.ReadLine()??"0");
    f = new Flavour(type, premium, quantity);//  Flavour object

    //topping list
    Console.WriteLine($"===============================\nTopping Menu\n===============================\n[1] Sprinkles\n[2] Mochi\n[3] Sago\n[4] Oreos\n===============================\n");
    Console.Write("Enter Type of Topping: ");
    ToppingType = Console.ReadLine()??"";// Topping type
    Console.Write("Enter quantity: ");
    ToppingQuantity = int.Parse(Console.ReadLine()??"0");// Topping quantity
    t = new Topping(ToppingType, ToppingQuantity);//  Topping object
    
    //new waffle flavour
    Console.WriteLine($"===============================\nWaffle Flavour Menu\n===============================\n[1] Red Velvet\n[2] Charcoal\n[3] Pandan\n===============================\n");
    Console.Write("Enter new waffle flavour: ");
    WaffleFlavour = Console.ReadLine()??"";

    //  create cup object
    x = new Waffles(option, scoops, new List<Flavour>(), new List<Topping>(), WaffleFlavour);
    return x;
}

void ListCustomers()
{
    Console.WriteLine($"Name\tMember ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
    foreach (Customer c in CustomerList)
    {
        Console.WriteLine($"{c.Name}\t{c.Memberid}\t{c.Dob}\t{c.Rewards.Tier}\t{c.Rewards.Points}\t{c.Rewards.PunchCard}");
    }
}

void ListCurrentOrders(Queue<Order> OrdinaryQueue, Queue<Order> GoldQueue)
{
    // Console.WriteLine($"{"Name", 16}Member ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
    Console.WriteLine("Gold Queue");
    Console.WriteLine($"{"Order ID}, 12"}{"Time Received",16}{"Time Fulfilled",16}{"Ice Cream List",16}");
    foreach (Order o in OrdinaryQueue) Console.WriteLine(o);

    Console.WriteLine("Ordinary Queue");
    Console.WriteLine($"{"Order ID}, 12"}{"Time Received",16}{"Time Fulfilled",16}{"Ice Cream List",16}");
    foreach (Order o in GoldQueue) Console.WriteLine(o);
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
    //  order details
    int Id;
    DateTime RecievedAt;

    ListCustomers(); //Write values from "Customer.csv"
    Console.WriteLine("Enter Member ID: ");
    int memberid = int.Parse(Console.ReadLine()??"0");
    Customer c = CustomerList.Find(x => x.Memberid == memberid);//  chosen customer

    if (c == null)//  Error message if member ID not found
    {
        Console.WriteLine("Member ID not found!");
        return false;
    }
    else
    {
        Id = c.CurrentOrder.Id;//  order id   
        RecievedAt = DateTime.Now;// time of order
        Order Neworder = new Order(Id, RecievedAt);//  creating new order

        //calling ice cream menu
        try
        {
            CreateIceCreamMenu();
        }
        catch(InvalidOptionException)
        {
            Console.WriteLine("Invalid option! Please try again.");
        }

        //loop
        string option;
        Console.Write($"Would you like to add another ice cream? (Y/N): ");
        option = Console.ReadLine()??"".ToLower();
        while (option == "y")
        {
            CreateIceCreamMenu();
            Console.Write($"Would you like to add another ice cream? (Y/N): ");
            option = Console.ReadLine()??"".ToLower();
        }
        return true;
    }

    
}


void DisplayOrderDetails(List<Customer> CustomerList)
{
    ListCustomers();
    Console.Write("Enter member ID: ");
    try
    {
        int memberid = Convert.ToInt32(Console.ReadLine());
        Customer? c = CustomerList.Find(x => x.Memberid == memberid);
        if (c == null)
        {
            Console.WriteLine("\nCustomer not found!");
            return;
        }
        Console.WriteLine($"{c.CurrentOrder}");
        foreach (Order o in c.OrderHistory)
        {
            Console.WriteLine($"{o}");
        }
    }
    catch (FormatException) { Console.WriteLine("\nInvalid member ID!"); return; }
}

bool ModifyOrderDetails()
{
    return true;
}

// Extra functions

// Main loop
CustomerList = ReadCustomers(CustomerList);
Console.WriteLine(CustomerList);

Queue<Order> OrdinaryQueue = new Queue<Order>();
Queue<Order> GoldQueue = new Queue<Order>();

while (true)
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
                ListCurrentOrders(OrdinaryQueue, GoldQueue);
                break;
            case "3":
                if (RegisterCustomer()) break;
                else throw new InvalidOptionException();
            case "4":
                if (CreateOrder()) 
                {
                    Console.WriteLine("Thank You for your order!");
                    break;
                }               
                else throw new InvalidOptionException();
            case "5":
                DisplayOrderDetails(CustomerList);
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
        // Thread.Sleep(1500); // wait 1.5s
        Console.Write("Press enter to continue...\n\n");
        Console.ReadLine();
        // Console.Clear();
    }
}