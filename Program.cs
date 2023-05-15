using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of cities: ");
        int numberOfCities = int.Parse(Console.ReadLine());

        string[] cityNames = new string[numberOfCities];
        int[] contactCities = new int[numberOfCities];
        int[] diseaseLevels = new int[numberOfCities];

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.Write("Enter the name of city " + i + ": ");
            cityNames[i] = Console.ReadLine();

            Console.Write("Enter the number of cities connected to city " + i + ": ");
            contactCities[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the IDs of the cities connected to city " + i + ":");
            for (int j = 0; j < contactCities[i]; j++)
            {
                int id = int.Parse(Console.ReadLine());

                if (id == i || id >= numberOfCities)
                {
                    Console.WriteLine("Invalid ID");
                    j--;
                }
                else
                {
                    contactCities[id]++;
                }
            }
        }

        for (int i = 0; i < numberOfCities; i++)
        {
            Console.WriteLine(i + " " + cityNames[i] + " " + diseaseLevels[i]);
        }

        while (true)
        {
            Console.Write("Enter an event (Outbreak, Vaccinate, Lockdown, Spread, Exit): ");
            string eventName = Console.ReadLine();

            if (eventName == "Exit")
            {
                break;
            }

            Console.Write("Enter the ID of the city for the event: ");
            int eventCity = int.Parse(Console.ReadLine());

            switch (eventName)
            {
                case "Outbreak":
                    diseaseLevels[eventCity] += 2;
                    for (int i = 0; i < numberOfCities; i++)
                    {
                        if (contactCities[i] > 0 && diseaseLevels[i] < diseaseLevels[eventCity])
                        {
                            diseaseLevels[i]++;
                        }
                    }
                    break;

                case "Vaccinate":
                    diseaseLevels[eventCity] = 0;
                    break;

                case "Lockdown":
                    if (diseaseLevels[eventCity] > 0)
                    {
                        diseaseLevels[eventCity]--;
                    }
                    for (int i = 0; i < numberOfCities; i++)
                    {
                        if (contactCities[i] > 0 && diseaseLevels[i] > 0 && diseaseLevels[i] > diseaseLevels[eventCity])
                        {
                            diseaseLevels[i]--;
                        }
                    }
                    break;

                case "Spread":
                    for (int i = 0; i < numberOfCities; i++)
                    {
                        if (contactCities[i] > 0 && diseaseLevels[i] > 0)
                        {
                            diseaseLevels[i]++;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid");
                    continue;
            }

            for (int i = 0; i < numberOfCities; i++)
            {
                Console.WriteLine(i + " " + cityNames[i] + " " + diseaseLevels[i]);
            }
        }
    }
}
