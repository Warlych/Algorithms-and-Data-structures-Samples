namespace Huffman_Algorithm;

public static class HuffmanCodec
{
    public static string EncodeString(string input, Dictionary<char, string> huffmanCodes)
    {
        var encodeStr = String.Empty;
        
        foreach (var ch in input)
        {
            encodeStr += huffmanCodes.First(c => c.Key.Equals(ch)).Value;
        }
        
        return encodeStr;
    }

    private static HuffmanTree.HuffmanNode BuildHuffmanTree(Dictionary<char, string> huffmanCodes)
    {
        HuffmanTree.HuffmanNode root = new HuffmanTree.HuffmanNode(null, 0);

        foreach (var entry in huffmanCodes)
        {
            var current = root;
            foreach (char bit in entry.Value)
            {
                if (bit == '0')
                {
                    if (current.Left == null)
                        current.Left = new HuffmanTree.HuffmanNode(null, 0);
                    
                    current = current.Left;
                }
                else if (bit == '1')
                {
                    if (current.Right == null)
                        current.Right = new HuffmanTree.HuffmanNode(null, 0);
                    
                    current = current.Right;
                }
                else
                    throw new InvalidOperationException("Неверный код Хаффмана.");
            }

            current.Ch = entry.Key;
        }

        return root;
    }

    public static string DecodeString(string encodedStr, Dictionary<char, string> huffmanCodes)
    {
        var decodeStr = String.Empty;

        var root = BuildHuffmanTree(huffmanCodes);
        var current = root;
        
        foreach (var bit in encodedStr)
        {
            if (bit == '0')
                current = current.Left;
            else if (bit == '1')
                current = current.Right;
            else
                throw new InvalidOperationException("Неверный бит в кодированной строке.");


            if (current.Ch != null)
            {
                decodeStr += current.Ch;
                current = root;
            }
        }

        return decodeStr;
    }
}