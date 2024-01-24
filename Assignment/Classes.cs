//==========================================================
// Student Number : S10258107
// Student Name : Gan Jun Hang
// Partner Name : Ivan Ng Keyang
//==========================================================

namespace Assignment
{
	internal class IceCream
	{
		private string option;
		private int scoops;
		private List<Flavour> flavours;
		private List<Topping> toppings;
		public string Option { get{ return option; } set{ option = value; } }
		public int Scoops { get{ return scoops; } set{ scoops = value; } }
		public List<Flavour> Flavours { get{ return flavours; } set{ flavours = value; } }
		public List<Topping> Toppings { get{ return toppings; } set{ toppings = value; } }

		public IceCream()
		{
			option = "";
			scoops = 0;
			flavours = new List<Flavour>();
			toppings = new List<Topping>();
		}

		public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
		{
			this.option = option;
			this.scoops = scoops;
			this.flavours = flavours;
			this.toppings = toppings;
		}

	}

	internal class Flavour
	{
		private string type;
		private bool premium;
		private int quantitiy;

		public string Type { get{ return type; } set{ type = value; } }
		public bool Premium { get{ return premium; } set{ premium = value; } }
		public int Quantitiy { get{ return quantitiy; } set{ quantitiy = value; } }

		public Flavour()
		{
			type = "";
			premium = false;
			quantitiy = 0;
		}

		public Flavour(string type, bool premium, int quantitiy)
		{
			this.type = type;
			this.premium = premium;
			this.quantitiy = quantitiy;
		}

		public override string ToString()
		{
			return $"{Type}: {Quantitiy}";
		}
	}

	internal class Topping
	{
		private string type;
		public string Type { get{ return type; } set{ type = value; } }

		public Topping()
		{
			type = "";
		}

		public Topping(string type, int quantitiy)
		{
			this.type = type;
		}

		public override string ToString()
		{
			return Type;
		}
	}

	internal class Cup : IceCream
	{
		public Cup() : base() { }

		public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) :
				base(option, scoops, flavours, toppings) {}

		public double CalculatePrice()
		{
			double price;

			switch (Scoops) // Scoop price implementation
			{
				default: price = 4.0; break;
				case 2: price = 5.5; break;
				case 3: price = 6.5; break;
			}

			// Add-ons price implementation
			price += Toppings.Count * 1; // $1/topping 

			foreach (Flavour flavour in Flavours) // Flavour price implementation
			{
				if (flavour.Premium) // Premium flavour +$2/scoop
				{
					price += 2*Scoops;
				}
			}

			return price;
		}
	}

	internal class Customer
	{
		private string name;
		private int memberid;
		private DateTime dob;
		private Order currentOrder;
		private List<Order> orderHistory;
		private PointCard rewards;

		public string Name { get{ return name; } set{ name = value; } }
		public int Memberid { get{ return memberid; } set{ memberid = value; } }
		public DateTime Dob { get{ return dob; } set{ dob = value; } }
		public Order CurrentOrder { get{ return currentOrder; } set{ currentOrder = value; } }
		public List<Order> OrderHistory { get{ return orderHistory; } set{ orderHistory = value; } }
		public PointCard Rewards { get{ return rewards; } set{ rewards = value; } }

		public Customer()
		{
			name = "";
			memberid = 0;
			dob = DateTime.Now;
			currentOrder = new Order();
			orderHistory = new List<Order>();
			rewards = new PointCard();
		}

		public Customer(string name, int memberid, DateTime dob, Order currentOrder, List<Order> orderHistory, PointCard rewards)
		{
			this.name = name;
			this.memberid = memberid;
			this.dob = dob;
			this.currentOrder = currentOrder;
			this.orderHistory = orderHistory;
			this.rewards = rewards;
		}

		// TODO: Implement MakeOrder()
		// public Order MakeOrder()
		// {

		// }

		public bool IsBirthday()
		{
			return DateTime.Now.Day == Dob.Day && DateTime.Now.Month == Dob.Month;
		}

		public override string ToString()
		{
			return $"{Name}, {Memberid}, {Dob}, {CurrentOrder}, {OrderHistory}, {Rewards}";
		}
	}

	internal class PointCard
	{
		private int points;
		private int punchCard;
		private string tier;

		public int Points { get{ return points; } set{ points = value; } }
		public int PunchCard { get{ return punchCard; } set{ punchCard = value; } }
		public string Tier { get{ return tier; } set{ tier = value; } }

		public PointCard()
		{
			points = 0;
			punchCard = 0;
			tier = "ordinary";
		}

		public PointCard(int points, int punchCard)
		{
			this.points = points;
			this.punchCard = punchCard;
			tier = "ordinary";
		}

		public void AddPoints(int points)
		{
			Points += points;
			
			switch (tier) // one-way membership tier upgrade
			{
				case "ordinary": if (Points >= 50) { Tier = "silver"; } break;
				case "silver": if (Points >= 100) { Tier = "gold"; } break;
			}

		}

		public void RedeemPoints(int points)
		{
			Points -= points;
		}

		public void punch()
		{
			PunchCard++;
		}

		public override string ToString()
		{
			return $"{Points}, {PunchCard}, {Tier}";
		}
	}
}