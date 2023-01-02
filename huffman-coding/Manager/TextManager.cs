using System.Collections;
using ShellProgressBar;
using Syncfusion.Drawing;

namespace huffman_coding.Manager;

public class TextManager
{
    private static WordManager _wordManager;
    public static string _fileContent = String.Empty;
    public static string txtFile= "text.txt";
    public static string output = "test1";
    private static string decompressed = "test1.txt";


    public void CompressTxtFile()
    {
        HuffmanTree.Build(_fileContent);
        BitArray encoded = HuffmanTree.Encode(_fileContent);
        byte[] bytes = ConvertToByte(encoded);
        FileManager.WriteCompressedFile(bytes, "test1");
   
        Console.WriteLine();
    }

    public void DecompressTxtFile()
    {
        byte[] bytes2 = File.ReadAllBytes("test1");
        var bitarray=new BitArray (bytes2);
        string decoded = HuffmanTree.Decode(bitarray);
        File.WriteAllText("test1.txt", decoded);
     
    }

    public void Run()
    {
        
        _fileContent = FileManager.GetFileContent(txtFile);
        CompressTxtFile();
        DecompressTxtFile();
        Console.WriteLine("[ + ] RUNNING HUFFMAN ALGORITHM FOR TEXT FILE");
        Console.ForegroundColor =ConsoleColor.Green;
        
        Console.WriteLine("[ + ] HUFFMAN ALGORITHM EXECUTED SUCCESSFULLY FOR TEXT FILE");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

    }

  

    static byte[] ConvertToByte(BitArray bits) {
        byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
        bits.CopyTo(bytes, 0);;
        return bytes;
    }

    
}