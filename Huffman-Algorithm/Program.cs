using Huffman_Algorithm;

string input = "hello world";

HuffmanTree huffmanTree = new HuffmanTree(input);
Dictionary<char, string> huffmanCodes = huffmanTree.BuildHuffmanCodes();

Console.WriteLine("Коды:");
foreach (var entry in huffmanCodes)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}

var str = HuffmanCodec.EncodeString(input, huffmanCodes);
Console.WriteLine($"Результат кодирования: {str}");
Console.WriteLine($"Результат декодирования: {HuffmanCodec.DecodeString(str, huffmanCodes)}");