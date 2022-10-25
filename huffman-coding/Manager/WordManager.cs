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
    public String _file =String.Empty;
    private FileManager _fileManager = new FileManager();
    private HuffmanTree _huffmanTree = new HuffmanTree();
    private Informations _informations = new Informations();
    private string _output = "test2";
    private string decompressed = "test2.docx";
    public WordManager(string file)
    {
        this._file = file;
    }

    public string GetWordContent(string file)
    {
        StringBuilder processed = new StringBuilder();
        using (Stream source = File.Open("Lisa.docx", FileMode.Open))
        {
            //Opens the Word template document
            using (WordDocument document = new WordDocument())
            {
                document.Open(source,FormatType.Docx);
                //Gets the Word document text
                string text = document.GetText();
                //Display Word document's text content.
                processed.Append(text);
            }
        }

      
        return processed.ToString().Substring(61);
    }
    public void CompressWord(string data)
    {
        _huffmanTree.Build(data);
        BitArray encoded = _huffmanTree.Encode(GetWordContent(_file));
        byte[] bytes = _informations.ConvertToByte(encoded);
        _fileManager.WriteCompressedFile(bytes,_output);
    }   

    public void DecompressWord()
    {
        byte[] bytes2 = File.ReadAllBytes(_output);
        var bitarray=new BitArray (bytes2);
        string decoded = _huffmanTree.Decode(bitarray);
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        
        
        var document = new DocumentModel();
        
        // Add new section with two paragraphs, containing some text and symbols.
        document.Sections.Add(
            new GemBox.Document.Section(document,
                new GemBox.Document.Paragraph(document,decoded)));

        // Save Word document to file's path.
        document.Save(decompressed);
        
    }
}