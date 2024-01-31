﻿//==========================================================
// Student Number : S10258107
// Student Name : Gan Jun Hang
// Partner Name : Ivan Ng Keyang
//==========================================================

using Assignment;

Queue<Order> OrdinaryQueue = new Queue<Order>();
Queue<Order> GoldQueue = new Queue<Order>();

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

object? CreateIceCreamMenu() 
{
    //  Menu details
    int MenuOption;
    object NewIceCream;
        //creating ice cream order:
        Console.WriteLine($"===============================\nIce Cream Menu\n===============================\n[1] Cup\n[2] Cone\n[3] Waffle\n[0] Exit Program\n===============================\n");
        Console.Write("Enter your option: ");
        MenuOption = int.Parse(Console.ReadLine()??"0");
        switch (MenuOption)
        {
            case 1:
                NewIceCream = CreateCup();
                return NewIceCream;

            case 2:
                NewIceCream = CreateCone();
                return NewIceCream;

            case 3:
                NewIceCream = CreateWaffle();
                return NewIceCream;

            case 0:
                Console.WriteLine("Thank you for using I.C. Treats!");
                return null;
            default:
                return null; 
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
    object NewIceCream;

    ListCustomers(); //Write values from "Customer.csv"
    Console.WriteLine("Enter Member ID: ");
    int memberid = int.Parse(Console.ReadLine()??"0");
    Customer? c = CustomerList.Find(x => x.Memberid == memberid);//  chosen customer

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
            NewIceCream = CreateIceCreamMenu();
            Neworder.AddIceCream((IceCream)NewIceCream);
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
        
        if (c.Rewards.Tier == "gold")   
        {
            GoldQueue.Enqueue(Neworder);
        }
        else
        {
            OrdinaryQueue.Enqueue(Neworder);
        }
    }
    return true;

    
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

Object? ModifyOrderDetails()
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
            return null;
        }

        Console.WriteLine($"{c.CurrentOrder}");
        if (c.CurrentOrder.IceCreamList.Count == 0)
        {
            Console.WriteLine("No ice creams in the order.");
            return null;
        }

        Console.WriteLine("Ice Creams in the Order:");
        for (int i = 0; i < c.CurrentOrder.IceCreamList.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {c.CurrentOrder.IceCreamList[i]}");
        }
        Console.WriteLine("[1] Modify an existing ice cream\n[2] Add a new ice cream\n[3] Delete an existing ice cream");
        Console.Write("Enter your option: ");
        string option = Console.ReadLine() ?? "-1";
        switch (option) // Choose to either modify, add or delete an ice cream
        {
            case "1": // Modify an existing ice cream
                Console.Write("Enter the index of the ice cream to modify: ");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                if (index < 0 || index >= c.CurrentOrder.IceCreamList.Count)
                {
                    Console.WriteLine("Invalid ice cream index.");
                    return null;
                }
                var IC = c.CurrentOrder.IceCreamList[index]; // var since there are 3 types of ice cream

                string ICtype = IC.Option; // get the type of ice cream

                // Explicitly cast the ice cream object to its respective type
                switch (ICtype)
                {
                    case "Cone": IC = (Cone)IC; break;
                    case "Waffle": IC = (Waffles)IC; break;
                    case "Cup": IC = (Cup)IC; break;
                }

                // Display the ice cream object
                Console.WriteLine($"Selected ice cream: {IC}");
                Console.WriteLine("What do you wish to modify:");
                // switch(ICtype) // Display the options available to modify based on the type of ice cream
                // {
                // 	case "Cone":
                // 		Console.WriteLine("[1] Ice Cream Type\n[2] Scoops\n[3] Flavours\n[4] Toppings\n[5] Dipped Cone");
                // 		break;
                // 	case "Waffle":
                // 		Console.WriteLine("[1] Ice Cream Type\n[2] Scoops\n[3] Flavours\n[4] Toppings\n[5] Waffle Flavour");
                // 		break;
                // 	case "Cup":
                // 		Console.WriteLine("[1] Ice Cream Type\n[2] Scoops\n[3] Flavours\n[4] Toppings");
                // 		break;
                // }

                Console.WriteLine("[1] Ice Cream Type\n[2] Scoops\n[3] Flavours\n[4] Toppings");

                Console.Write("\nEnter your option: ");
                string modifyOption = Console.ReadLine() ?? "-1";
                switch (modifyOption) // Choose what to modify
                {
                    case "1": // Modify the ice cream type

                        Console.WriteLine("Available ice cream types:");
                        // Display the available ice cream types based on the current ice cream type
                        if (ICtype == "Cone") Console.WriteLine("[1] Waffle\n[2] Cup");
                        else if (ICtype == "Waffle") Console.WriteLine("[1] Cone\n[2] Cup");
                        else Console.WriteLine("[1] Cone\n[2] Waffle");

                        // Prompt the user for the modifications they wish to make to the ice cream
                        Console.Write("Enter the index of the ice cream type to change to: ");
                        int ICtypeIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (ICtypeIndex < 0 || ICtypeIndex > 3)
                        {
                            Console.WriteLine("Invalid ice cream type index.");
                            return null;
                        }

                        // Modify the ice cream type
                        if (ICtype == "Cone")
                        {
                            switch (ICtypeIndex)
                            {
                                case 1: ICtype = "Waffle"; c.CurrentOrder.IceCreamList[index] = (Waffles)IC; break;
                                case 2: ICtype = "Cup"; c.CurrentOrder.IceCreamList[index] = (Cup)IC; break;
                            }
                        }
                        else if (ICtype == "Waffle")
                        {
                            switch (ICtypeIndex)
                            {
                                case 1: ICtype = "Cone"; c.CurrentOrder.IceCreamList[index] = (Cone)IC; break;
                                case 2: ICtype = "Cup"; c.CurrentOrder.IceCreamList[index] = (Cup)IC; break;
                            }
                        }
                        else if (ICtype == "Cup")
                        {
                            switch (ICtypeIndex)
                            {
                                case 1: ICtype = "Cone"; c.CurrentOrder.IceCreamList[index] = (Cone)IC; break;
                                case 2: ICtype = "Waffle"; c.CurrentOrder.IceCreamList[index] = (Waffles)IC; break;
                            }
                        }
                        break;

                    case "2": // Modify the number of scoops
                        Console.Write("Enter the number of scoops: ");
                        int scoops = Convert.ToInt32(Console.ReadLine());
                        if (scoops < 1 || scoops > 3)
                        {
                            Console.WriteLine("Invalid number of scoops.");
                            return null;
                        }
                        IC.Scoops = scoops;
                        break;
                    case "3": // Modify the flavours
                        Console.WriteLine("Available flavours to change:");
                        int count = 1;
                        foreach (Flavour f in IC.Flavours)
                        {
                            Console.WriteLine($"[{count}] {f}");
                            count++;
                        }

                        // Ask user what flavour to change
                        Console.Write("Enter the index of the flavour to add: ");
                        int flavourIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (flavourIndex < 0 || flavourIndex >= IC.Flavours.Count)
                        {
                            Console.WriteLine("Invalid flavour index.");
                            return null;
                        }

                        // Modify that flavour
                        List<string> FList = new List<string>() { "Vanilla", "Chocolate", "Strawberry", "Durian", "Ube", "Sea Salt" };
                        Console.WriteLine("Available Flavours to change to:");
                        Console.WriteLine("Regular Flavours\n[1] Vanilla\n[2] Chocolate\n[3] Strawberry\n\nPremium Flavours\n[4] Durian\n[5] Ube\n[6] Sea Salt");
                        Console.Write("Enter the index of the flavour to change to: ");

                        int fChangeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (fChangeIndex < 0 || fChangeIndex >= 5)
                        {
                            Console.WriteLine("Invalid flavour index.");
                            return null;
                        }

                        // filters premium
                        if (fChangeIndex <= 2) IC.Flavours[flavourIndex] = new Flavour(FList[fChangeIndex], false, 1);
                        else IC.Flavours[flavourIndex] = new Flavour(FList[fChangeIndex], true, 1);

                        break;
                    case "4": // Modify the toppings
                        Console.WriteLine("Available toppings:");
                        int count2 = 1;
                        foreach (Topping t in IC.Toppings)
                        {
                            Console.WriteLine($"[{count2}] {t}");
                            count2++;
                        }

                        // Ask user what topping to modify
                        Console.Write("Enter the index of the topping to modify: ");
                        int toppingIndex2 = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (toppingIndex2 < 0 || toppingIndex2 >= IC.Toppings.Count)
                        {
                            Console.WriteLine("Invalid topping index.");
                            return null;
                        }

                        Console.Write("Enter the index of the topping to add: ");
                        int toppingIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (toppingIndex < 0 || toppingIndex >= IC.Toppings.Count)
                        {
                            Console.WriteLine("Invalid topping index.");
                            return null;
                        }
                        IC.Toppings.Add(IC.Toppings[toppingIndex]);
                        break;
                        /*case "5": // Modify the dipped cone or waffle flavour (only applicable to cone and waffle)
                            switch (ICtype)
                            {
                                case "Cone":
                                    c.CurrentOrder.IceCreamList[index] = (Cone) IC; // Explicitly cast the ice cream object to its respective type
                                    Console.WriteLine((Cone)IC.Dipped);

                                    break;
                                case "Waffle":
                                    Console.WriteLine("Available waffle flavours:");
                                    List<string> WList = new List<string>() {"Red Velvet", "Charcoal", "Pandan"};
                                    int count3 = 1;
                                    foreach (string s in WList)
                                    {
                                        Console.WriteLine($"[{count3}] {s}");
                                        count3++;
                                    }
                                    Console.Write("Enter the index of the waffle flavour to add: ");
                                    int waffleFlavourIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                                    if (waffleFlavourIndex < 0 || waffleFlavourIndex >= IC.Count)
                                    {
                                        Console.WriteLine("Invalid waffle flavour index.");
                                        return null;
                                    }
                                default:
                                    Console.WriteLine("Invalid option.");
                                    return null;
                            }*/
                }
                break;
            case "2": // Add a new ice cream
                c.CurrentOrder.AddIceCream((IceCream)CreateIceCreamMenu());
                break;
            case "3": // Delete an existing ice cream
                Console.Write("Enter the index of the ice cream to delete: ");
                int deleteIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                if (deleteIndex < 0 || deleteIndex >= c.CurrentOrder.IceCreamList.Count)
                {
                    Console.WriteLine("Invalid ice cream index.");
                    return null;
                }
                c.CurrentOrder.IceCreamList.RemoveAt(deleteIndex);
                Console.WriteLine("Ice cream deleted from the order.");
                break;
            default:
                Console.WriteLine("Invalid option.");
                return null;
        }
        Console.WriteLine("Updated Order:");
        Console.WriteLine($"{c.CurrentOrder}");
        return null;
    }
    catch (FormatException)
    {
        Console.WriteLine("\nInvalid member ID!");
        return null;
    }
}

// Extra functions
// Main loop
CustomerList = ReadCustomers(CustomerList);
Console.WriteLine(CustomerList);

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