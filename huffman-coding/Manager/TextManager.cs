namespace huffman_coding.Manager;

public class TextManager
{
    private static string fileContent=String.Empty;
    private static FileManager fileManager = new FileManager();
    public void Run()
    {
        GetFile();
    }

    public void GetFile()
    {
        do
        {
            Console.WriteLine("Introduceti numele fisierului!");
            string path=Console.ReadLine();
            fileContent = fileManager.GetFileContent(path);
        } while (fileContent == null);
    }
}