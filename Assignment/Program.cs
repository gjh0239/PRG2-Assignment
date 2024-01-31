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
    return;
}

bool RegisterCustomer()
{
    return true;
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