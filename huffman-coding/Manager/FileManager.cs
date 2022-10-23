using System.Collections;

namespace huffman_coding.Manager;

public class FileManager
{
    
    public string GetFileContent(string path)
    {
        if (path.Equals(String.Empty))
        {
            Console.WriteLine("Introduceti va rog numele fisierului!");
            return null;    
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("Fisierul nu a putut fi gasit!");
            return null;
        }

        return File.ReadAllText(path);
    }

    public byte[] GetFileBytes(string path)
    {
        return File.ReadAllBytes(path);
    }

    public void WriteCompressedFile(byte[] data)
    {
        string name = "test1";
        if (!File.Exists(name))
            File.Create(name);
        
            File.WriteAllBytes(name,data);
        
    }
}