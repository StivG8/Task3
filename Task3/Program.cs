using System.Security.Cryptography;

namespace Task3
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (!Check(args))
            {
                return;
            }

            KeyGenerator key = new();
            bool Status = false;

            while (!Status)
            {
                var rand = RandomNumberGenerator.GetInt32(args.Length);

                Console.WriteLine("HMAC: " + key.HMAC(key.Key(), args[rand]) + "\nAvailable Moves:");

                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(i + 1 + " - " + args[i]);
                }

                Console.Write("0 - Exit\n? - Help\nEnter your move: ");
                var option = Console.ReadLine();

                if (option == "?")
                {
                    new Table(args).Print();
                    continue;
                }

                if (option == "0")
                {
                    Status = true;
                    continue;
                }

                int player = 0;

                if (!int.TryParse(option, out player) || player <= 0 || player > args.Length)
                {
                    Console.WriteLine("\n\n");
                    continue;
                }

                Console.WriteLine("Your move: " + args[player - 1] + "\nComputer move: " + args[rand]);

                switch (new Rules(args.Length).Calculate(rand, player - 1))
                {
                    case Result.Victory: Console.WriteLine("You won!");
                        break;

                    case Result.Defeat: Console.WriteLine("You lost!");
                        break;

                    default: Console.WriteLine("Draw!");
                        break;
                }

                Console.WriteLine("HMAC key: " + key.Key() + "\n\n");
            }
        }
        static bool Check(string[] args)
        {
            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Wrong input\nCases have not to be the same.");
                return false;
            }

            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Wrong input\nCases of move must be odd number (minimum is 3).");
                return false;
            }

            return true;
        }
    }
}