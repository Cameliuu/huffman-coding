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
}