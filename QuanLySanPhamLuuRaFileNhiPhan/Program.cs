class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>();
        string path = "";

        // Item item = new Item("001", "coca cola", "coca-cola corp", 60000f, "cola drink");
        // Item item2 = new Item("002", "pepsi", "PepsiCo", 55000f, "pepsi drink");
        // Item item3 = new Item("003", "heniken", "NAN", 45000f, "alcohol");

        // items.Add(item);
        // items.Add(item2);
        // items.Add(item3);

        // SaveFile(items);

        Console.Clear();

        do
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-Enter: 'stop' to exit");
            if (!string.IsNullOrWhiteSpace(path)) Console.WriteLine($"-Last opened: {path}");

            Console.WriteLine("0: Display current Data File");
            Console.WriteLine("1: Open Data File");
            Console.WriteLine("2: Add product to current data");
            Console.WriteLine("3: Save the current data");
            Console.WriteLine("4: search product with name");

            Console.Write("Enter option: ");
            var optionInput = Console.ReadLine();

            if (!int.TryParse(optionInput, out int option))
            {
                if (optionInput == "stop") return;
                continue;
            }

            Console.Clear();
            switch (option)
            {
                case 0:
                    if (items == null)
                    {
                        Console.WriteLine("No Data File opened!");
                        continue;
                    }
                    else if (items.Count < 1)
                    {
                        Console.WriteLine("Current Data File is empty!");
                        continue;
                    }
                    else
                    {
                        DisplayItems(items);
                    }
                    break;
                case 1:
                    Console.Write("Enter file path: ");
                    path = Console.ReadLine();
                    var tempList = ReadFile(path);
                    if (tempList == null)
                    {
                        path = "";
                        items = new List<Item>();
                        Console.Clear();
                        continue;
                    }
                    items = tempList;

                    Console.Clear();
                    DisplayItems(items);
                    break;

                case 2:
                    Console.Write("Enter number of products: ");
                    var numInput = Console.ReadLine();

                    if (!int.TryParse(numInput, out int numOfProduct))
                    {
                        continue;
                    }

                    Console.Clear();
                    items.AddRange(EnterListOfItem(numOfProduct));
                    break;

                case 3:
                    Console.Write("Enter file destination: ");
                    string p = Console.ReadLine();
                    Console.Clear();
                    SaveFile(items, p);
                    break;

                case 4:
                    if (items.Count < 1)
                    {
                        Console.WriteLine("Current Data File is empty!");
                        continue;
                    }

                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();

                    List<Item> searchList = items.Where(i => i.name.Contains(name)).ToList();

                    Console.Clear();
                    Console.WriteLine($"Found {searchList.Count} result(s)");
                    foreach (Item item in searchList)
                    {
                        Console.WriteLine(item);
                    }

                    break;
            }
        } while (true);
    }

    static List<Item> EnterListOfItem(int numOfProduct)
    {
        List<Item> tList = new List<Item>();

        for (int i = 0; i < numOfProduct; i++)
        {
            Console.Clear();
            Console.WriteLine($"Product {i + 1} of {numOfProduct} products to add");
            Item item = new Item();

            Console.Write("Enter ID: ");
            item.ID = Console.ReadLine();

            Console.Write("Enter product name: ");
            item.name = Console.ReadLine();

            Console.Write("Enter producer: ");
            item.producer = Console.ReadLine();

            Console.Write("Enter price: ");
            var priceInput = Console.ReadLine();
            if (!double.TryParse(priceInput, out double price))
            {
                Console.Clear();
                i--;
                continue;
            }
            item.price = price;

            Console.Write("Note: ");
            item.note = Console.ReadLine();

            tList.Add(item);
        }
        return tList;
    }

    static void SaveFile(List<Item> items, string path = "ItemDatas")
    {
        BinaryWriter writer = null;

        try
        {
            writer = new BinaryWriter(new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (Item item in items)
            {
                writer.Write(item.ID);
                writer.Write(item.name);
                writer.Write(item.producer);
                writer.Write(item.price);
                writer.Write(item.note);
            }

            Console.WriteLine($"File saved att {path}");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
                writer.Dispose();
            }
        }
    }

    static List<Item> ReadFile(string path)
    {

        BinaryReader reader = null;
        List<Item> items = new List<Item>(); ;

        try
        {
            reader = new BinaryReader(new FileStream(path, FileMode.Open));

            while (reader.PeekChar() != -1)
            {
                Item item = new Item();
                item.GetDataFormBinaryFile(reader);
                items.Add(item);
            }

            reader.Close();
            reader.Dispose();
        }
        catch (System.Exception e)
        {
            // Console.WriteLine(e.StackTrace);
            items = null;
            Console.WriteLine("Invalid path!");
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }

        return items;
    }

    static void DisplayItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            Console.WriteLine(item);
        }
    }
}