namespace APD.Utilities;

public class GenerateDataSet
{
    public static int[] Generate(int length, string order)
    {
        int[] array = new int[length];
        Random random = new Random();

        switch (order.ToLower())
        {
            case "ascending":
                for (int i = 0; i < length; i++)
                {
                    array[i] = i;
                }
                break;

            case "descending":
                for (int i = length - 1; i >= 0; i--)
                {
                    array[i] = length - 1 - i;
                }
                break;

            default:
                for (int i = 0; i < length; i++)
                {
                    array[i] = random.Next(0, length);
                }
                break;
        }

        return array;
    }

    public static void GenerateToFile(int length, string order)
    {
        int[] array = Generate(length, order);
        string fileName = $"{length}-{order}.txt";

        FileOperations.WriteArrayToFile(fileName, length, array);
    }

    public static void GenerateAll(int[] dataSets)
    {
        Console.WriteLine("Generating Data Sets...");

        foreach(var set in dataSets)
        {
            GenerateDataSet.GenerateToFile(set, "ascending");
            GenerateDataSet.GenerateToFile(set, "descending");
            GenerateDataSet.GenerateToFile(set, "random");
        }
    }
}
