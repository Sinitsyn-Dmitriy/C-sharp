using System;

namespace MECalculator
{

class Start
    {
        public static string nameUser()
        {

            string name;
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
            return name;
        }


        public static int getWidth()
        {
            int width = 0;
            string widthString;
            Console.WriteLine("Enter desk width in inches (only whole numbers):");
            widthString = Console.ReadLine();



            for (int i = 0; i < 1;)
            {

            try {
                    width = int.Parse(widthString);
                    return width;
                } catch
            { Console.WriteLine("Invalid data");

                    Console.WriteLine("Enter desk width in inches (only whole numbers):");
                    widthString = Console.ReadLine();
             }
            }

            return width;
        }


        public static int getLength()
        {
            int length = 0;
            string lengthString;
            Console.WriteLine("Enter desk length in inches (only whole numbers):");
            lengthString = Console.ReadLine();


            for (int i = 0; i < 1;)
            {

                try
                {
                    length = int.Parse(lengthString);
                    return length;
                }
                catch
                {
                    Console.WriteLine("Invalid data");

                    Console.WriteLine("Enter desk length in inches (only whole numbers):");
                    lengthString = Console.ReadLine();
                }
            }

            return length;
        }


        public static int drawers()
        {
            int drawers = 0;
            string drawersString;
            Console.WriteLine("Enter amount of drawers (0 min to 7 max):");
            drawersString = Console.ReadLine();


            for (int i = 0; i < 1;)
            {
                switch (drawersString)
                {
                    case "0": drawers = int.Parse(drawersString); return drawers;
                    case "1": drawers = int.Parse(drawersString); return drawers;
                    case "2": drawers = int.Parse(drawersString); return drawers;
                    case "3": drawers = int.Parse(drawersString); return drawers;
                    case "4": drawers = int.Parse(drawersString); return drawers;
                    case "5": drawers = int.Parse(drawersString); return drawers;
                    case "6": drawers = int.Parse(drawersString); return drawers;
                    case "7": drawers = int.Parse(drawersString); return drawers;

                    default:
                        Console.WriteLine("Invalid data. Enter amount of drawers (0 min to 7 max):");
                        drawersString = Console.ReadLine();
     
                        break;
                }
            }

            return drawers;
        }


        public static string materialDesk()
        {
            string surfaceMaterial;
            Console.WriteLine("Choose surface material: oak, pine or laminate");
            surfaceMaterial = Console.ReadLine();

            for(int i = 0; i < 1; )
            {
                switch (surfaceMaterial)
                {
                    case "oak": return surfaceMaterial;

                    case "laminate": return surfaceMaterial;

                    case "pine": return surfaceMaterial;

                    default:
                        Console.WriteLine("Invalid data. Enter only word for surface material: laminate, oak or pine but nothing else");
                        surfaceMaterial = Console.ReadLine();
                        break;
                }
            }
            
            return surfaceMaterial;
        }


        public static int getRush()
        {
            int rush = 0;
            string rushString;
            Console.WriteLine("The normal production time is 14 days. \n You can choose rush order options of 3, 5, or 7 days. \n Enter the order option:");
            rushString = Console.ReadLine();
    


            for (int i = 0; i < 1;)
            {
                switch (rushString)
                {

                    case "3": rush = int.Parse(rushString); return rush;
                    case "5": rush = int.Parse(rushString); return rush;
                    case "7": rush = int.Parse(rushString); return rush;
                    case "14": rush = int.Parse(rushString); return rush;

                    default:
                        Console.WriteLine("Enter only numbers 3, 5, 7 or 14");
                        rushString = Console.ReadLine(); 
                        break;
                }
            }

            return rush;
        }
    }


    class Desk
    {

        static void count(string name, int width, int length, int drawersCount, string surfaceMaterial, int rush)
        {

            int calcArea = width * length;
            int calcPrice = 0;


  

            if (calcArea <= 1000)
            {
                calcPrice = 200;

            }

            if (calcArea > 1000)
            {
                calcPrice = calcArea * 5;
            }





            if (drawersCount > 0)
            {
                calcPrice += drawersCount * 50;
            }

            if (drawersCount == 0)
            {
                calcPrice = 200;
            }


            switch (surfaceMaterial)
            {
                case "oak":
                    calcPrice += 200;
                    break;
                case "laminate":
                    calcPrice += 100;
                    break;
                case "pine":
                    calcPrice += 50;
                    break;
                default:
                    break;
            }
            


            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Dmitriy\Desktop\111.txt");

            int[,] board = new int[3, 3];
            board[0, 0] = int.Parse(lines[0]);
            board[0, 1] = int.Parse(lines[1]);
            board[0, 2] = int.Parse(lines[2]);
            board[1, 0] = int.Parse(lines[3]);
            board[1, 1] = int.Parse(lines[4]);
            board[1, 2] = int.Parse(lines[5]);
            board[2, 0] = int.Parse(lines[6]);
            board[2, 1] = int.Parse(lines[7]);
            board[2, 2] = int.Parse(lines[8]);




            if(calcArea < 1000)
            {
                switch (rush)
                {
                    case 3:
                        calcPrice += board[0, 0];
                        break;
                    case 5:
                        calcPrice += board[1, 0];
                        break;
                    case 7:
                        calcPrice += board[2, 0];
                        break;
                    default:
                        break;
                }

            }




            if (calcArea >= 1000 && calcArea < 2000)
            {
                switch (rush)
                {
                    case 3:
                        calcPrice += board[0, 1];
                        break;
                    case 5:
                        calcPrice += board[1, 1];
                        break;
                    case 7:
                        calcPrice += board[2, 1];
                        break;
                    default:
                        break;
                }

            }



            if (calcArea >= 2000)
            {
                switch (rush)
                {
                    case 3:
                        calcPrice += board[0, 2];
                        break;
                    case 5:
                        calcPrice += board[1, 2];
                        break;
                    case 7:
                        calcPrice += board[2, 2];
                        break;
                    default:
                        break;
                }

            }


            Console.WriteLine("*************************************");
            Console.WriteLine("\n {0}, here is your receipt: ", name);
            Console.WriteLine("Width of the desk: {0}", width);
            Console.WriteLine("Length of the desk: {0}", length);
            Console.WriteLine("Amount of drawers: {0}", drawersCount);
            Console.WriteLine("Surface material: {0}", surfaceMaterial);
            Console.WriteLine("Rush option (amount of days): {0}", rush);
            Console.WriteLine("\n Total: {0}", calcPrice);
            Console.WriteLine("*************************************");

        }

        static void Main(string[] args)
        {

            string name = Start.nameUser();
            int width = Start.getWidth();
            int length = Start.getLength();
            int drawersCount = Start.drawers();
            string surfaceMaterial = Start.materialDesk();
            int rush = Start.getRush();
            count(name, width, length, drawersCount, surfaceMaterial, rush);

            Console.ReadKey();
        }
    }
}
