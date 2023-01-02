using System;
using System.Collections;
using System.IO;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Layout;
using iText.Layout.Element;
namespace huffman_coding.Manager;

public class PDFManager
{
    private String _file;
    public static string pdfFile = "pdf.pdf";
    public static string output = "test3";
    private static string decompressed = "test3.pdf";
    public static string content = String.Empty;
    public PDFManager(string file)
    {
        this._file = file;
    }

    public static string GetPDFContent(string file)
    {
        StringBuilder text = new StringBuilder();
        using (PdfReader reader = new PdfReader(pdfFile))
        {
            PdfDocument doc = new PdfDocument(reader);
            for (int i = 1; i <= doc.GetNumberOfPages(); i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(i)));
            }
        }

        content = text.ToString();
        return text.ToString();

    }

    public static void CompressPDF(string data)
    {
        HuffmanTree.Build(data);
        BitArray encoded = HuffmanTree.Encode(GetPDFContent(pdfFile));
        byte[] bytes = Informations.ConvertToByte(encoded);
        FileManager.WriteCompressedFile(bytes,output);
    }

    public static void DecompressPDF()
    {
        byte[] bytes2 = File.ReadAllBytes(output);
        var bitarray=new BitArray (bytes2);
        string decoded = HuffmanTree.Decode(bitarray);
        PdfWriter writer = new PdfWriter(decompressed);
        PdfDocument pdf = new PdfDocument(writer);
        Document doc = new Document(pdf);
        doc.Add(new Paragraph(decoded));
        doc.Close();
    }

    public static void Run()
    {
        Console.WriteLine("[ + ] RUNNING HUFFMAN ALGORITHM FOR PDF FILE");
        CompressPDF(GetPDFContent(pdfFile));
        DecompressPDF();
        Console.ForegroundColor =ConsoleColor.Green;
        Console.WriteLine("[ + ] HUFFMAN ALGORITHM EXECUTED SUCCESSFULLY FOR PDF FILE");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }
}