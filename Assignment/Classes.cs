namespace Assignment
{
	internal class IceCream
	{
		public string Option { get; set; }
		public int Scoops { get; set; }
		public List<Flavour> Flavours { get; set; }
		public List<Topping> Toppings { get; set; }

		public IceCream()
		{
			Option = "";
			Scoops = 0;
			Flavours = new List<Flavour>();
			Toppings = new List<Topping>();
		}

		public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
		{
			Option = option;
			Scoops = scoops;
			Flavours = flavours;
			Toppings = toppings;
		}

	}

	internal class Flavour
	{
		public string Type { get; set; }
		public bool Premium { get; set; }
		public int Quantitiy { get; set; }

		public Flavour()
		{
			Type = "";
			Premium = false;
			Quantitiy = 0;
		}

		public Flavour(string type, bool premium, int quantitiy)
		{
			Type = type;
			Premium = premium;
			Quantitiy = quantitiy;
		}

		public override string ToString()
		{
			return $"{Type}: {Quantitiy}";
		}
	}

	internal class Topping
	{
		public string Type { get; set; }

		public Topping()
		{
			Type = "";
		}

		public Topping(string type, int quantitiy)
		{
			Type = type;
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
}