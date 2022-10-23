using System.Collections;

namespace huffman_coding;

public class HuffmanTree
{
    private List<HuffmanNode> nodes = new List<HuffmanNode>();
    public Dictionary<char, int> dict = new Dictionary<char, int>(){};
    public HuffmanNode root { get; set; }
            

    public void Build(string text)
    {
        foreach (var c in text)
        {
            if (!dict.ContainsKey(c))
                dict.Add(c, 1);
            else
                dict[c]++;
        }

        foreach (var s in dict)
        {
            nodes.Add( new HuffmanNode()
            {
                c=s.Key,
                value= s.Value
            });
            
        }

        while (nodes.Count > 1)
        {
           
            List<HuffmanNode> orderedNodes = nodes.OrderBy(node => node.value).ToList();
            if (orderedNodes.Count >= 2)
            {
                List<HuffmanNode> taken = orderedNodes.Take(2).ToList<HuffmanNode>();
                
                HuffmanNode parent = new HuffmanNode()
                {
                    c = '*',
                    value = taken[0].value + taken[1].value,
                    LeftN = taken[0],
                    RightN = taken[1]
                };
                
                nodes.Remove(taken[0]);
                nodes.Remove(taken[1]);
                nodes.Add(parent);
                
            }

            this.root = nodes.FirstOrDefault();
        }
    }

    public BitArray Encode(string input)
    {
        List<bool> encodedText = new List<bool>();
        foreach (var c in input)
        {
            List<bool> encodedChar = this.root.Traverse(c, new List<bool>());
            encodedText.AddRange(encodedChar);
        }

        return new BitArray(encodedText.ToArray());
    }
    public string Decode(BitArray bits)
    {
        HuffmanNode current = this.root;
        string decoded = "";

        foreach (bool bit in bits)
        {
            if (bit)
            {
                if (current.RightN != null)
                {
                    current = current.RightN;
                }
            }
            else
            {
                if (current.LeftN != null)
                {
                    current = current.LeftN;
                }
            }

            if (IsLeaf(current))
            {
                decoded += current.c;
                current = this.root;
            }
        }

        return decoded;
    }

    public bool IsLeaf(HuffmanNode node)
    {
        return (node.LeftN == null && node.RightN == null);
    }
    
}
