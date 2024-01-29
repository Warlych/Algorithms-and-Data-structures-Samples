namespace Rabin_Karp_Algorithm;

public static class RabinFingerprint
{
    private static int _prime = 101;
    private static int _size = 256;

    public static long CalculateHash(string str, int length)
    {
        var hash = 0l;

        for (int i = 0; i < length; i++) hash = (hash * _size + (long)str[i]) % _prime;
        return hash;
    }

    public static long RecalculateHash(long oldHash, char oldChar, char newChar, int length)
    {
        long newHash = (oldHash - (long)oldChar * (long)Math.Pow(_size, length - 1)) % _prime;
        newHash = (newHash * _size + (long)newChar) % _prime;

        if (newHash < 0)
            newHash += _prime;

        return newHash;
    }
}