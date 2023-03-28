namespace APD.Algorithms;

public class MergeSort
{
    public static void Sort(int[] array)
    {
        if (array.Length <= 1) return;

        int mid = array.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            left[i] = array[i];
        }

        for (int i = mid; i < array.Length; i++)
        {
            right[i - mid] = array[i];
        }

        Sort(left);
        Sort(right);
        Merge(left, right, array);
    }

    private static void Merge(int[] left, int[] right, int[] array)
    {
        int leftIndex = 0, rightIndex = 0, arrayIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] < right[rightIndex])
            {
                array[arrayIndex++] = left[leftIndex++];
            }
            else
            {
                array[arrayIndex++] = right[rightIndex++];
            }
        }

        while (leftIndex < left.Length)
        {
            array[arrayIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            array[arrayIndex++] = right[rightIndex++];
        }
    }
}
