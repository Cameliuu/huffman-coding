using System.Collections;
using ShellProgressBar;
using Syncfusion.Drawing;

namespace huffman_coding.Manager;

public class TextManager
{
    private static WordManager _wordManager;
    private static string _fileContent = String.Empty;
    private static string txtFile= "text.txt";
    private static string output = "test1";
    private static string decompressed = "test1.txt";

    public void CompressTxtFile()
    {
        HuffmanTree.Build(_fileContent);
        BitArray encoded = HuffmanTree.Encode(_fileContent);
        byte[] bytes = ConvertToByte(encoded);
        FileManager.WriteCompressedFile(bytes, "test1");
        Console.WriteLine("File encoded successfully!");
        Console.WriteLine();
    }

    public void DecompressTxtFile()
    {
        byte[] bytes2 = File.ReadAllBytes("test1");
        var bitarray=new BitArray (bytes2);
        string decoded = HuffmanTree.Decode(bitarray);
        File.WriteAllText("test1.txt", decoded);
        Console.WriteLine("Text File Decoded Successfuly\n");
    }

    public void Run()
    {
        Console.WriteLine("[ + ] RUNNING HUFFMAN ALGORITM FOR TXT FILE", Color.Green);
        _fileContent = FileManager.GetFileContent(txtFile);
        CompressTxtFile();
        DecompressTxtFile();
    }

    public void DisplayProgressBar()
    {
        const int totalTicks = 10;
        var options = new ProgressBarOptions
        {
            ProgressCharacter = '#',
            ForegroundColorError = ConsoleColor.Red,
            ShowEstimatedDuration = false,
            ProgressBarOnBottom = true,
            DisplayTimeInRealTime = false
        };
        using (var pbar = new ProgressBar(totalTicks, "Encoding in progress", options))
        {
            for(int i=1;i<=10;i++)
            {
                pbar.Tick();
                System.Threading.Thread.Sleep(50);
            }
            pbar.Message = "Encoding Complete!";
        }
    }

    static byte[] ConvertToByte(BitArray bits) {
        byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
        bits.CopyTo(bytes, 0);;
        return bytes;
    }

    
    public void GetFile()
    {
        
        Console.WriteLine($"Continutul fisierului este:{_fileContent}\nAcesta ocupa {_fileContent.Length*8} biti");
    }
}