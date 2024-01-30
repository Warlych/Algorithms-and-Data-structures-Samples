namespace Knuth_Morris_Pratt_Algorithm;

public static class KnuthMorrisPrattAlgorithm
{
    private static int[] CalculatePrefix(string pattern)
    {
        int length = pattern.Length;
        int[] prefix = new int[length];

        for (int i = 0, q = 1; q < length; q++)
        {
            while (i > 0 && pattern[i] != pattern[q])
                i = prefix[i - 1];
            
            if (pattern[i] == pattern[q])
                i++;
            
            prefix[q] = i;
        }

        return prefix;
    }

    public static ICollection<int> Search(string input, string pattern)
    {
        ICollection<int> result = new List<int>();
        
        int n = input.Length;
        int m = pattern.Length;
        int[] prefix = CalculatePrefix(pattern);
        
        int q = 0;
        for (int i = 0; i < n; i++)
        {
            while (q > 0 && pattern[q] != input[i])
                q = prefix[q - 1];
            
            if (pattern[q] == input[i])
                q++;
            
            if (q == m)
            {
                result.Add(i - m + 1);
                q = prefix[q - 1];
            }
        }

        return result;
    }
}