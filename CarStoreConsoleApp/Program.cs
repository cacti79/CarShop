﻿using System;
using CarStoreCommonLibrary;
namespace CarStoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store();

            Console.WriteLine("Welcome to the car store. First you must create some car inventory. Then you may add some cars to the shopping cart. Finally you may checkout which will give you a total value of the shopping cart.");

            int action = ChooseAction();

            while (action != 0)
            {
                Console.WriteLine("You chose " + action);

                switch (action)
                {
                    //add item to inventory
                    case 1:
                        Console.WriteLine("You chose to add a new car to the inventory");

                        Console.WriteLine("What is the car make? Ford, GM, Nissan, etc. ");
                        string carMake = Console.ReadLine();

                        Console.WriteLine("What is the car model? Corvette, Focus, etc. ");
                        string carModel = Console.ReadLine();

                        Console.WriteLine("What is the car price? ");
                        try
                        {
                           decimal carPrice = decimal.Parse(Console.ReadLine());
                           Car newCar = new Car(carMake, carModel, carPrice);
                           s.CarList.Add(newCar);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("wrong input");
                        }
                        PrintInventory(s);
                        break;

                    //add to cart
                    case 2:
                        Console.WriteLine("You chose to add a car to the shopping cart");
                        PrintInventory(s);
                        Console.WriteLine("Which item would you like to buy? (number)");
                        int carChosen = int.Parse(Console.ReadLine());

                        s.ShoppingList.Add(s.CarList[carChosen]);

                        PrintShoppingCart(s);

                        break;

                    //checkout
                    case 3:
                        PrintShoppingCart(s);
                        Console.WriteLine("The total cost of your items is : " + s.CheckOut());

                        break;

                    default:
                        break;
                }

                action = ChooseAction();
            }


        }

        private static void PrintShoppingCart(Store s)
        {
            Console.WriteLine("Cars you have chosen to buy ");

            for (int i = 0; i < s.ShoppingList.Count; i++)
            {
                Console.WriteLine($"Car number : **{ i }** {s.ShoppingList[i]}");
            }
        }

        private static void PrintInventory(Store s)
        {
            for (int i = 0; i < s.CarList.Count; i++)
            {
                Console.WriteLine($"Car number: **{ i }** {s.CarList[i]}");
            }
        }

        public static int ChooseAction()
        {
            int choice = 0;
            Console.WriteLine("Choose an action (0) to quit (1) to add a enw car to inventory (2) add car to cart (3) checkout");

            choice = int.Parse(Console.ReadLine());

            return choice;
        }
    
    }
}
