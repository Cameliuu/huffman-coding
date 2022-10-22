namespace huffman_coding;

public class HuffmanNode
{
    public int value { get; set; }
    public char c { get; set; }
    public HuffmanNode LeftN { get; set; }
    public HuffmanNode RightN { get; set; }

    public List<bool> Traverse(char c, List<bool> data)
    {
        if (LeftN == null && RightN == null)
        {
            return (c.Equals(this.c)) ? data : null;
        }

        List<bool> leftD = new List<bool>();
        List<bool> rightD = new List<bool>();
        if (LeftN != null)
        {
            List<bool> leftPath = new List<bool>();
            leftPath.AddRange(data);
            leftPath.Add(false);
            leftD = LeftN.Traverse(c, leftPath);
        }

        if (RightN != null)
        {
            List<bool> rightPath = new List<bool>();
            rightPath.AddRange(data);
            rightPath.Add(true);
            rightD = RightN.Traverse(c, rightPath); 
        }

        return (leftD != null) ? leftD : rightD;
    }
}