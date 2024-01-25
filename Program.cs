using System;
namespace brickyard400
{
    class versionOne
    {
        //It's only 25 laps. . . so it's really the "Brickyard 62.5 at Indy" (presented by me).
        static void Main(string[] args)
        {
            int lives = 0
                , fuel = 0, lapChunk = 0, direction = 0, laps = 25;
            Random r = new Random();
            bool win = false;
            Console.Write("What is your name? (Example: Tony Stewart) ");
            string name = Console.ReadLine();
            initValues(ref lives, ref fuel, ref lapChunk, r);
            while (lives > 0 && fuel > 0 && lapChunk > 0 && win == false)
            {
                direction = chooseDirection();
                /* if they choose left, good
                 * if they choose right, bad, very bad */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref fuel, ref lapChunk, direction);
                else
                    actions(r.Next(10), ref lives, ref fuel, ref lapChunk, direction);
                checkResults(ref laps, ref lives, ref fuel, ref lapChunk, ref win);
            }
            if (win)
                Console.WriteLine(name + " wins the 2005 Brickyard 400 at Indianapolis!");
            else if (lives <= 0)
                Console.WriteLine("You crashed");
            else if (fuel <= 0)
                Console.WriteLine("You don't have any fuel left and cannot complete the race. Time to yell at your crew chief.");
            //else
                //Console.WriteLine("");

        }

        private static void checkResults(ref int laps, ref int lives, ref int fuel, ref int lapChunk, ref bool win)
        {
            //throw new NotImplementedException();
            if (lapChunk == 0) { laps--; lapChunk = 4;}
            Console.WriteLine("Laps remaining: " + laps);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("Fuel: " + fuel);
            //Console.WriteLine("lapChunk remaining: " + lapChunk);
            if (laps == 0) win = true;
        }

        private static void actions(int v, ref int lives, ref int fuel, ref int lapChunk, int direction)
        {
            //turning outcomes

            //throw new NotImplementedException();

            switch (v)
            {
                case 0:
                    Console.WriteLine("You turned left.");
                    Console.WriteLine("You burned 1 unit of fuel");
                    lapChunk -= 1;
                    fuel -= 1;
                    break;
                case 1:
                    Console.WriteLine("You turned left.");
                    Console.WriteLine("You burned 2 units of fuel");
                    lapChunk -= 1;
                    fuel -= 2;
                    break;
                case 2:
                    Console.WriteLine("You turned left and coasted.");
                    Console.WriteLine("You burned 0 units of fuel");
                    lapChunk -= 1;
                    break;
                case 3:
                    Console.WriteLine("You turned left and goosed the throttle.");
                    Console.WriteLine("You burned 3 units of fuel");
                    lapChunk -= 1;
                    fuel -= 3;
                    break;
                case 4:
                    Console.WriteLine("You turned left and coasted.");
                    Console.WriteLine("You burned 0 units of fuel");
                    lapChunk -= 1;
                    break;
                case 5:
                    Console.WriteLine("You turned right.");
                    Console.WriteLine("...");
                    Console.WriteLine("You crashed and had to retire your car...");
                    lives = 0;
                    break;
                case 6:
                    Console.WriteLine("You turned right.");
                    Console.WriteLine("...");
                    Console.WriteLine("Your front right tire hit the wall, breaking the bead and causing you to retire...");
                    lives = 0;
                    break;
                case 7:
                    Console.WriteLine("You turned right.");
                    Console.WriteLine("...");
                    Console.WriteLine("WHY?");
                    lives = 0;
                    break;
                case 8:
                    Console.WriteLine("Your cooling vest stopped working.");
                    Console.WriteLine("...");
                    Console.WriteLine("It's like a million degrees in here! I'm retiring my car...");
                    lives = 0;
                    break;
                case 9:
                    Console.WriteLine("Your spotter notifies you about debris on your grill.");
                    Console.WriteLine("...");
                    Console.WriteLine("Your engine overheated and you retired...");
                    lives = 0;
                    break;
                default:
                    Console.WriteLine("You did nothing.");
                    Console.WriteLine("...");
                    Console.WriteLine("You crashed... Maybe try turning left next time.");
                    lives = 0;
                    break;
            }
        }


       
        private static int chooseDirection()

            //you can either turn left or crash
        {
            Console.WriteLine("Turn left! (1 = turn left and 2 = turn right) \r\n\r\n");
            int direction;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out direction))
                {
                    if (direction == 1 || direction == 2)
                    {
                        break; // Valid input, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("You entered an invalid number, please enter 1 for left or 2 for right");
                    }
                }
                else
                {
                    Console.WriteLine("You entered an invalid input, please enter a valid integer.");
                }
            }
            return direction;
        }

        private static void initValues(ref int lives, ref int fuel
            , ref int lapChunk, Random r)
        {
            lives = 1;
            fuel = r.Next(50) + 130;
            lapChunk = 1;

        }
    }
}
