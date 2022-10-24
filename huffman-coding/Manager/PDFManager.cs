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
    private FileManager _fileManager = new FileManager();
    private HuffmanTree _huffmanTree = new HuffmanTree();
    private Informations _informations = new Informations();
    private string _output = "test3";
    private string decompressed = "test3.pdf";
    public PDFManager(string file)
    {
        this._file = file;
    }

    public string GetPDFContent(string file)
    {
        StringBuilder text = new StringBuilder();
        using (PdfReader reader = new PdfReader("lorem-ipsum.pdf"))
        {
            PdfDocument doc = new PdfDocument(reader);
            for (int i = 1; i <= doc.GetNumberOfPages(); i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(i)));
            }
        }

        return text.ToString();

    }

    public void CompressPDF(string data)
    {
        _huffmanTree.Build(data);
        BitArray encoded = _huffmanTree.Encode(GetPDFContent("lorem-ipsum.pdf"));
        Console.WriteLine(encoded);
        byte[] bytes = _informations.ConvertToByte(encoded);
        _fileManager.WriteCompressedFile(bytes,_output);
    }

    public void DecompressPDF()
    {
        byte[] bytes2 = File.ReadAllBytes(_output);
        var bitarray=new BitArray (bytes2);
        string decoded = _huffmanTree.Decode(bitarray);
        PdfWriter writer = new PdfWriter(decompressed);
        PdfDocument pdf = new PdfDocument(writer);
        Document doc = new Document(pdf);
        doc.Add(new Paragraph(decoded));
        doc.Close();
    }

}