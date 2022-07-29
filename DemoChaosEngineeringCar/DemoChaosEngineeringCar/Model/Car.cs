namespace DemoChaosEngineeringCar.Model
{
    public class Car
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Year { get; private set; }

        public Car() { }

        public Car(int id, string name, decimal price, int year)
        {
            Id = id;
            Name = name;
            Price = price;
            Year = year;
        }

        public void SetName(string name) => Name = name;
        public void SetPrice(decimal price) => Price = price;
        public void SetYear(int year) => Year = year;
    }
}
