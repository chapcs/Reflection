using Secret;
using System.Reflection;

internal class Program
{
    public static void Main(string[] args)
    {
        HasASecret keeper = new HasASecret();

        // The statement below causes a console error because the field is inaccessible due to being private
        //Console.WriteLine(keeper.secret);

        // You can still use reflection to get the value of the private field
        FieldInfo[] fields = keeper.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        // This loop will cause the string to be printed to console
        foreach (FieldInfo field in fields)
        {
            Console.WriteLine(field.GetValue(keeper));
        }
    }
}
