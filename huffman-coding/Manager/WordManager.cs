using System.Collections;
using System.Text;
using iText.Layout.Element;

using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using GemBox;
using GemBox.Document;

namespace huffman_coding.Manager;

public class WordManager
{
    public static String _file =String.Empty;

    public static string wordFile = "word.docx";
    public static string output = "test2";
    private static string decompressed = "test2.docx";
    
    
    public static string GetWordContent(string file)
    {
        StringBuilder processed = new StringBuilder();
        using (Stream source = File.Open(wordFile, FileMode.Open))
        {
            
            using (WordDocument document = new WordDocument())
            {
                document.Open(source,FormatType.Docx);
           
                string text = document.GetText();
            
                processed.Append(text);
            }
        }

      
        return processed.ToString().Substring(61);
    }
    public static void CompressWord(string data)
    {
        HuffmanTree.Build(data);
        BitArray encoded = HuffmanTree.Encode(GetWordContent(_file));
        byte[] bytes =Informations.ConvertToByte(encoded);
        FileManager.WriteCompressedFile(bytes,output);
    }

  

    public static void DecompressWord()
    {
        byte[] bytes2 = File.ReadAllBytes(output);
        var bitarray=new BitArray (bytes2);
        string decoded = HuffmanTree.Decode(bitarray);
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        
        
        var document = new DocumentModel();
        
        document.Sections.Add(
            new GemBox.Document.Section(document,
                new GemBox.Document.Paragraph(document,decoded)));
        
        document.Save(decompressed);
        
        
    }
    public static void Run()
    {
        Console.WriteLine("[ + ] RUNNING HUFFMAN ALGORITHM FOR WORD FILE");
        CompressWord(GetWordContent(wordFile));
        DecompressWord();
        Console.ForegroundColor =ConsoleColor.Green;
        Console.WriteLine("[ + ] HUFFMAN ALGORITHM EXECUTED SUCCESSFULLY FOR WORD FILE");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
}