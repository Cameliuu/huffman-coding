using System.Collections;

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

        // write the decoded file in txt file
        File.WriteAllText("test3.txt", decoded);
        Console.WriteLine("Text File Decoded Successfuly\n");
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