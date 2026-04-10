namespace DotaParser52.Homeworks._4._04.CoffeeMachine.Drinks.Coffee;

public class Coffee
{
    public string Name { get; set; }
        public decimal Price { get; init; }
        public decimal Weight { get; init; }
        public decimal RequiredCoffeeBeansAmount { get; init; }
        public decimal RequiredMilkAmount { get; init; }
        public decimal RequiredWaterAmount { get; init; }
        public decimal RequiredCreamAmount { get; init; }
    
    public Coffee(string name, decimal price,decimal weight, decimal requiredCoffeeBeansAmount,
            decimal requiredMilkAmount, decimal requiredWaterAmount,
            decimal requiredCreamAmount)
        {
            if (Math.Abs(weight -
                         (requiredCoffeeBeansAmount + requiredMilkAmount + requiredWaterAmount + requiredCreamAmount))
                > (decimal)Double.Epsilon)
            {
                throw new ArgumentException("weight have to be equal to the sum of the ingredients fot it");
            }
            Name = name;
            Price = price;
            Weight = weight;
            RequiredCoffeeBeansAmount = requiredCoffeeBeansAmount;
            RequiredMilkAmount = requiredMilkAmount;
            RequiredWaterAmount = requiredWaterAmount;
            RequiredCreamAmount = requiredCreamAmount;
           
        }
}