using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

class Class1
{
    public static Item[] items = new Item[5];

    static void Main(string[] arg)
    {
        int randomCount = 200000;

        items[0] = new Item("A", 1000);
        items[1] = new Item("B", 200);
        items[2] = new Item("C", 50);
        items[3] = new Item("D", 10);
        items[4] = new Item("E", 1);

        float maxCount = 0; // 1261

        for(int i = 0; i < items.Length; i++)
        {
            maxCount += items[i].weight;
        }

        // 디버그
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{items[i].name} : {items[i].weight / maxCount * 100} %");
            items[i].randomRate = items[i].weight / maxCount;
        }

        Random random = new Random();

        for (int i = 0; i < randomCount; i++)
        {
            double f = random.NextDouble();

            for (int j = 0; j < items.Length; j++)
            {
                f -= items[j].randomRate;

                if (f <= 0)
                {
                    items[j].pickCount++;
                    break;
                }
            }
        }

        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("");
        //Console.WriteLine($"{items[0].randomRate}");
        Console.WriteLine($"random count : {randomCount}\n");

        // 디버그
        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{items[i].name} pick count : {items[i].pickCount} \t {items[i].pickCount / randomCount * 100} %");
        }
    }

    public class Item
    {
        public string name;
        public float weight;

        public float randomRate;
        public float pickCount = 0;

        public Item(string _name, float _weight)
        {
            name = _name;
            weight = _weight;
        }
    }
}

