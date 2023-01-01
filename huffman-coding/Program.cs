// See https://aka.ms/new-console-tem       plate for more information

using huffman_coding.Manager;
using Figgle;
using huffman_coding;

TextManager textManager = new TextManager();
Console.WriteLine(FiggleFonts.Banner3.Render("Huffman Encoding"));
Informations.DisplayProgressBar("ENCODING");
textManager.Run();
WordManager.Run();
PDFManager.Run();
Console.WriteLine();
Informations.DisplayProgressBar("DECODING");
Informations.Show();