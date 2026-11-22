public class CoffeeLog
{
    public string CoffeeName { get; }
    public int Rating { get; }
    public CoffeeLog(string coffeeName, int rating)
    {
        CoffeeName = coffeeName;
        Rating = rating;
    }
}