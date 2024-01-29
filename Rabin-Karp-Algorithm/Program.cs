using Rabin_Karp_Algorithm;

var text = "cwawdahlpwdawdhplmalhlp";
var pattern = "hlp";

var patternL = pattern.Length;
var textL = text.Length;

var patternHash = RabinFingerprint.CalculateHash(pattern, patternL);
var currentHash = RabinFingerprint.CalculateHash(text, patternL);

for (int i = 0; i <= textL - patternL; i++)
{
    if (patternHash == currentHash && text.Substring(i, patternL) == pattern)
    {
        bool overlap;
        for (int j = 0; j < patternL; j++)
        {
            if (text[i + j] != pattern[j])
            {
                overlap = false;
                break;
            }
        }
        
        Console.WriteLine($"Подстрока: {i + 1} - {i + patternL + 1}");
    }

    if (i < textL - patternL)
    {
        currentHash = RabinFingerprint.RecalculateHash(currentHash, text[i], text[i + patternL], patternL);
    }
}