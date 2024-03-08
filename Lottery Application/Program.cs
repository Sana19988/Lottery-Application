using Lottery_Application.Data;
using Lottery_Application.Models;

namespace Lottery_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LotteryDbContext())
            {
                db.Database.EnsureCreated();
                
                Console.WriteLine("Commands: Run | History | Exit");
                while (true)
                {
                    Console.Write("> ");
                    string command = Console.ReadLine()?.Trim().ToLower();

                    switch (command)
                    {
                        case "run":
                            RunLotteryDraw(db);
                            break;
                        case "history":
                            ShowDrawHistory(db);
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            break;
                    }
                }
            }
        }

        static void RunLotteryDraw(LotteryDbContext db)
        {
            var random = new Random();
            var numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int randomNumber;
                do
                {
                    randomNumber = random.Next(1, 51);
                } while (numbers.Contains(randomNumber));

                numbers[i] = randomNumber;
            }

            Array.Sort(numbers);
            string drawResult = string.Join(", ", numbers);
            Console.WriteLine($"Lottery draw result: {drawResult}");

            var draw = new LotteryDraw
            {
                Numbers = drawResult,
                DrawDate = DateTime.Now
            };

            db.DrawHistory.Add(draw);
            db.SaveChanges();
        }

        static void ShowDrawHistory(LotteryDbContext db)
        {
            var draws = db.DrawHistory.OrderByDescending(d => d.DrawDate).ToList();

            Console.WriteLine("Lottery Draw History:");
            foreach (var draw in draws)
            {
                Console.WriteLine($"ID: {draw.Id} | Numbers: {draw.Numbers} | Date: {draw.DrawDate}");
            }
        }
    }
}
