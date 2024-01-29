namespace Huffman_Algorithm;

public class HuffmanTree
{
    public class HuffmanNode
    {
        public char? Ch { get; set; }
        public int Freq { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }

        public HuffmanNode(char? ch, int freq)
            => (Ch, Freq) = (ch, freq);
    }

    private readonly string _input;
    
    private readonly Dictionary<char, int> _frequencyTable;
    public Dictionary<char, string> HuffmanCodes { get; set; }

    private HuffmanNode _root;
    
    public HuffmanTree(string input)
    {
        _input = input;
        
        _frequencyTable = input.GroupBy(c => c)
            .ToDictionary(c => c.Key, c => c.Count());
    }

    public HuffmanNode Build()
    {
        PriorityQueue<HuffmanNode, int> priorityQueue = new PriorityQueue<HuffmanNode, int>();

        foreach (var en in _frequencyTable)
        {
            priorityQueue.Enqueue(new HuffmanNode(en.Key, en.Value), en.Value);
        }
        
        while (priorityQueue.Count > 1)
        {
            HuffmanNode left = priorityQueue.Dequeue();
            HuffmanNode right = priorityQueue.Dequeue();

            HuffmanNode parent = new HuffmanNode(null, left.Freq + right.Freq)
            {
                Left = left,
                Right = right
            };

            priorityQueue.Enqueue(parent, parent.Freq);
        }

        return priorityQueue.Dequeue();
    }

    private void BuildCode(HuffmanNode node, string code, Dictionary<char, string> codes)
    {
        if (node.Ch != null)
        {
            codes[(char)node.Ch] = code;
        }
        else
        {
            BuildCode(node.Left, code + "0", codes);
            BuildCode(node.Right, code + "1", codes);
        }
    }

    public Dictionary<char, string> BuildHuffmanCodes()
    {
        if (HuffmanCodes != null)
            return HuffmanCodes;
        
        _root = Build();
        
        Dictionary<char, string> codes = new Dictionary<char, string>();
        BuildCode(_root, "", codes);

        HuffmanCodes = codes;
        return HuffmanCodes;
    }
}