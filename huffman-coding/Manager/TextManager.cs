using System.Collections;
using ShellProgressBar;

namespace huffman_coding.Manager;

public class TextManager
{
    private static string _fileContent=String.Empty;
    private static FileManager _fileManager = new FileManager();
    private static HuffmanTree _huffmanTree = new HuffmanTree();
    public void Run()
    {
        GetFile();
        _huffmanTree.Build(_fileContent);
        BitArray encoded = _huffmanTree.Encode(_fileContent);
        byte[] bytes = ConvertToByte(encoded);
        _fileManager.WriteCompressedFile(bytes);
        Console.WriteLine("File encoded successfully!");
        Console.WriteLine();
        
        byte[] bytes2 = File.ReadAllBytes("test1");
        var bitarray=new BitArray (bytes2);
        string decoded = _huffmanTree.Decode(bitarray);
            
        File.WriteAllText("test3.txt", decoded);
        Console.WriteLine("Text File Decoded Successfuly\n");
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
        do
        {
            Console.WriteLine("Introduceti numele fisierului!: ");
            string path=Console.ReadLine();
            _fileContent = _fileManager.GetFileContent(path);
        } while (_fileContent == null);

        Console.WriteLine($"Continutul fisierului este:{_fileContent}\nAcesta ocupa {_fileContent.Length*8} biti");
    }
}