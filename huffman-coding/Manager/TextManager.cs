using System.Collections;
using ShellProgressBar;
using System;
using System.IO;
using System.Text;

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
        DisplayFileInfo("test3.txt");
        byte[] bytes2 = File.ReadAllBytes("test1");
        var bitarray=new BitArray (bytes2);
        string decoded = _huffmanTree.Decode(bitarray);
            
        File.WriteAllText("test3.txt", decoded);
    }

    public void DisplayProgressBar(string coding)
    {
        ProgressBarOptions? options;
        options = new ProgressBarOptions();
        const int totalTicks = 10;
        switch (coding)
        {
            case "Encoding":


                    options.ProgressCharacter = '#';
                    options.ForegroundColorError = ConsoleColor.Red;
                    options.ForegroundColor = ConsoleColor.Green;
                    options.ShowEstimatedDuration = false;
                    options.ProgressBarOnBottom = true;
                    options.DisplayTimeInRealTime = false;
                
                break;
            case "Decoding":
                 {
                    options.ProgressCharacter = '#';
                    options.ForegroundColorError = ConsoleColor.Red;
                    options.ForegroundColor = ConsoleColor.DarkRed;
                    options.ShowEstimatedDuration = false;
                    options.ProgressBarOnBottom = true;
                    options.DisplayTimeInRealTime = false;
                };
                break;
        }
        
        using (var pbar = new ProgressBar(totalTicks, $"{coding} in progress", options))
        {
            for(int i=1;i<=10;i++)
            {
                pbar.Tick();
                System.Threading.Thread.Sleep(25);
            }
            pbar.Message = $"{coding} Complete!";
        }

        Console.WriteLine("\n");
    }

    public void DisplayFileInfo(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        Console.WriteLine("--------------------------------------INFORMATII FISIER--------------------------------------");
        Console.WriteLine($"Marime:{path.Length}");
    }
    

    public long GetFileSize(string path)    
    {
        FileInfo fileInfo = new FileInfo(path);
        return path.Length;
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