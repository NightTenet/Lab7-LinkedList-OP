using Lab7.LinkedListClasses;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList? list = new LinkedList();

            //
            Console.WriteLine("\nHow much elements do you want to add?");
            int elemAmount = int.Parse(Console.ReadLine());
            if (elemAmount < 0)
                return;

            for (int i = 0; i < elemAmount; i++)
            {
                Console.WriteLine($"Enter value for {i + 1} node: ");
                float value = float.Parse(Console.ReadLine());
                list.AddToEnd(value);
            }

            Console.WriteLine("\nYour current list:\n");
            foreach (var elem in list)
                Console.Write($"{elem}  ");


            // 
            Console.WriteLine("\n\nEnter a number to find the first bigger than it: ");
            float parameter = float.Parse(Console.ReadLine());
            Node? result = list.FindFirstElementThatGreaterThan(parameter);

            if (result == null)
                Console.WriteLine($"\nThere is no element that's bigger than {parameter}!");
            else
            {
                int index = 0;
                foreach (var elem in list)
                {
                    if (elem > parameter)
                        break;
                    index++;
                }
                Console.WriteLine($"\nThe first element that's bigger is {result.Value} at position {index + 1}");
            }


            // 
            float sum = list.FindSumOfLowerNumbers();
            Console.WriteLine($"\nThe sum of values that lower that the first negative value is: {sum}");


            //
            Console.WriteLine("\n\nEnter position to show element on that position: ");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nThe element on that position is {list[position - 1]}");


            // 
            Console.WriteLine("\nEnter a position on which delete a node: ");
            position = int.Parse(Console.ReadLine());

            Console.WriteLine("\nBefore:");
            foreach (var elem in list)
                Console.Write($"{elem}  ");
            
            list.RemoveAtIndex(position - 1);
            Console.WriteLine("\n\nAfter:");
            foreach (var elem in list)
                Console.Write($"{elem}  ");
            

            //
            Console.WriteLine("\n\nEnter a parameter to create a new list: ");
            parameter = float.Parse(Console.ReadLine());

            list = list.CreateNewList(parameter);
            if (list == null)
                Console.WriteLine("\nYour new list is empty!\n");
            else
            {
                Console.WriteLine("\nYour new list:\n");
                foreach (var elem in list)
                    Console.Write($"{elem}  ");
            }   
        }
    }
}