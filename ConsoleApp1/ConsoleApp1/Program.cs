using System;
using ConsoleApp1;

class Program
{
    static void Main()
    {
        List<Container> containers = new();
        while (true)
        {
            Ship ship1 = new Ship("Titanic");
            Ship ship2 = new Ship("Britanic");

            Console.WriteLine("1. Create a container");
            Console.WriteLine("2. Load cargo");
            Console.WriteLine("3. Load a container onto a ship");
            Console.WriteLine("4. Load a list of containers onto a ship");
            Console.WriteLine("5. Remove a container from the ship");
            Console.WriteLine("6. Unload a container");
            Console.WriteLine("7.  Replace a container on the ship with a given number with another container ");
            Console.WriteLine("8. Transfer a container between two ships");
            Console.WriteLine("9. Print information about a given container");
            Console.WriteLine("10.  Print information about a given ship and its cargo");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.WriteLine("Enter a type [L, G, R]:");
                    char type = char.Parse(Console.ReadLine().ToUpper());
                    Container container;
                    switch (type)
                    {
                        case 'L':
                            container = new LiquidContainer();
                            break;
                        case 'G':
                            container = new GasContainer();
                            break;
                        case 'R':
                            container = new RefrigeratedContainer(5.0);
                            break;
                        default:
                            Console.WriteLine("Invalid container type.");
                            continue;
                    }
                    containers.Add(container);
                    Console.WriteLine($"Created container {container.SerialNumber}");
                    break;

                case 2:
                    Console.WriteLine("Enter container index to load cargo:");
                    int index = int.Parse(Console.ReadLine());
                    if (index < 0 || index >= containers.Count)
                    {
                        Console.WriteLine("Invalid index.");
                        break;
                    }
                    Console.WriteLine("Enter cargo mass:");
                    int mass = int.Parse(Console.ReadLine());
                    containers[index].Load(mass);
                    Console.WriteLine("Cargo loaded successfully.");
                    break;

                case 3:
                    Console.WriteLine("Enter container index to load onto ship:");
                    index = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choose ship (1) Titanic or (2) Britanic:");
                    int shipChoice = int.Parse(Console.ReadLine());
                    if (index >= 0 && index < containers.Count)
                    {
                        if (shipChoice == 1) ship1.containers.Add(containers[index]);
                        else if (shipChoice == 2) ship2.containers.Add(containers[index]);
                        Console.WriteLine("Container loaded onto ship.");
                    }
                    else
                        Console.WriteLine("Invalid container index.");
                    break;

                case 4:
                    Console.WriteLine("Loading all containers onto a ship.");
                    Console.WriteLine("Choose ship (1) Titanic or (2) Britanic:");
                    shipChoice = int.Parse(Console.ReadLine());
                    if (shipChoice == 1) ship1.addContainers(containers);
                    else if (shipChoice == 2) ship2.addContainers(containers);
                    Console.WriteLine("All containers loaded onto ship.");
                    break;

                case 5:
                    Console.WriteLine("Enter ship (1) Titanic or (2) Britanic:");
                    shipChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter container index to remove:");
                    index = int.Parse(Console.ReadLine());
                    if (shipChoice == 1 && index < ship1.containers.Count) ship1.containers.RemoveAt(index);
                    else if (shipChoice == 2 && index < ship2.containers.Count) ship2.containers.RemoveAt(index);
                    Console.WriteLine("Container removed from ship.");
                    break;

                case 6:
                    Console.WriteLine("Enter container index to unload:");
                    index = int.Parse(Console.ReadLine());
                    containers[index].EmptyCargo();
                    Console.WriteLine("Cargo unloaded.");
                    break;

                case 7:
                    Console.WriteLine("Enter ship (1) Titanic or (2) Britanic:");
                    shipChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter container index to replace:");
                    index = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new container type [L, G, R]:");
                    type = char.Parse(Console.ReadLine().ToUpper());
                    Container newContainer = type switch
                    {
                        'L' => new LiquidContainer(),
                        'G' => new GasContainer(),
                        'R' => new RefrigeratedContainer(5.0),
                        _ => null
                    };
                    if (newContainer != null)
                    {
                        if (shipChoice == 1) ship1.containers[index] = newContainer;
                        else if (shipChoice == 2) ship2.containers[index] = newContainer;
                        Console.WriteLine("Container replaced.");
                    }
                    break;

                case 8:
                    Console.WriteLine("Enter container index to transfer:");
                    index = int.Parse(Console.ReadLine());
                    Console.WriteLine("Transfer from (1) Titanic to (2) Britanic or vice versa?");
                    shipChoice = int.Parse(Console.ReadLine());
                    if (shipChoice == 1 && index < ship1.containers.Count)
                    {
                        ship2.containers.Add(ship1.containers[index]);
                        ship1.containers.RemoveAt(index);
                    }
                    else if (shipChoice == 2 && index < ship2.containers.Count)
                    {
                        ship1.containers.Add(ship2.containers[index]);
                        ship2.containers.RemoveAt(index);
                    }
                    Console.WriteLine("Container transferred.");
                    break;

                case 9:
                    Console.WriteLine("Enter container index to print info:");
                    index = int.Parse(Console.ReadLine());
                    containers[index].info();
                    break;

                case 10:
                    Console.WriteLine("Enter ship (1) Titanic or (2) Britanic to print info:");
                    shipChoice = int.Parse(Console.ReadLine());
                    Ship selectedShip = shipChoice == 1 ? ship1 : ship2;
                    selectedShip.info();
                    break;

                default:
                    Console.WriteLine("Wrong number! Choose one from 1-10");
                    break;
            }

        }
    }
}
