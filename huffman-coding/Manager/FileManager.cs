using System.Collections;
using System.Net;
using Microsoft.VisualBasic;

namespace huffman_coding.Manager;

public class FileManager
{
    
    public static string GetFileContent(string path)
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

    public static void WriteCompressedFile(byte[] data,string file)
    {
        using (var stream = File.Create(file))
        {
        }


        File.WriteAllBytes(file,data);
       

    }
}