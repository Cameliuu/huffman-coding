// See https://aka.ms/new-console-template for more information

using huffman_coding.Manager;

FileManager fileManager = new FileManager();
string p=String.Empty;
string path = String.Empty;
do
{
    Console.WriteLine("Introduceti numele fisierului");
     p = Console.ReadLine();
     path = fileManager.GetFileContent(p);
} while (path == null);
Console.WriteLine(path);