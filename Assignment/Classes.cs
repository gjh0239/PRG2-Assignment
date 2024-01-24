namespace Assignment
{
	internal class IceCream
	{
		internal string Option { get; set; }
		internal int Scoops { get; set; }
		internal List<Flavour> Flavours { get; set; }
		internal List<Topping> Toppings { get; set; }

		internal IceCream()
		{
			Option = "";
			Scoops = 0;
			Flavours = new List<Flavour>();
			Toppings = new List<Topping>();
		}

		internal IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
		{
			Option = option;
			Scoops = scoops;
			Flavours = flavours;
			Toppings = toppings;
		}

	}

	internal class Cup: IceCream
	{
		internal Cup(): base() {}

		internal Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings):
				base(option, scoops, flavours, toppings) {}
		
		internal double CalculatePrice()
		{
			double price = 0;

			price += toppings.Count * 0.5;

			foreach (Flavour flavour in Flavours)
			{
				// TODO: Implement price calculation 
			}

		}

		
	}
}