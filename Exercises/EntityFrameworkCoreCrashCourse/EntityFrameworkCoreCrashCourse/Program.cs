using EntityFrameworkCoreCrashCourse.Data;
using EntityFrameworkCoreCrashCourse.Enums;
using EntityFrameworkCoreCrashCourse.Models;

public class Program
{
    public static void Main(string[] args)
    {
        using TankAppContext context = new();

        Console.WriteLine($"Provider: {context.Database.ProviderName}");

        /*Commander commander = new()
        {
            Name = "Sixten Peterson",
            Age = 21,
            Gender = Gender.Male,
        };

        context.Add(commander);

        Tank tank = new Tank(){
            CommanderId = 0,
            Name = "Strv fm/21",
            Nation = Nation.Sweden,
            BattlesFought = 12,
        };

        context.Tanks.Add(tank);

        context.SaveChanges();*/

        var tanks = context.Tanks
            .Where(t => t.Nation == Nation.Sweden)
            .OrderBy(t => t.Name);

        foreach (Tank t in tanks)
        {
            Console.WriteLine(t.Name);
            Console.WriteLine(t.CommanderId);
            Console.WriteLine(t.Name);
            Console.WriteLine(t.Nation);
            Console.WriteLine(t.BattlesFought);
        }
    }
}