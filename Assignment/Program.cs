//==========================================================
// Student Number : S10258107
// Student Name : Gan Jun Hang
// Partner Name : Ivan Ng Keyang
//==========================================================

using Assignment;

List <Customer> CustomerList = new List<Customer>();
using (StreamReader sr = new StreamReader("customers.csv")) 
{
    sr.ReadLine();  //removing header
    string line;

    Console.WriteLine($"Name\tMember ID\tDate of Birth\tMembershipStatus\tMembershipPoints\tPunchCard");
    while ((line = sr.ReadLine()) != null)
    {
        string[] values = line.Split(',');
        Console.WriteLine($"{values[0]}\t{values[1]}\t{values[2]}\t{values[3]}\t{values[4]}\t{values[5]}");
    }

    
    sr.Close();
}
        