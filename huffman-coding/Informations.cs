using System.Collections;
using huffman_coding.Manager;
using ShellProgressBar;

namespace huffman_coding;

public class Informations
{
    public static void DisplayProgressBar(string coding)
    {
        ProgressBarOptions? options;
        options = new ProgressBarOptions();
        const int totalTicks = 10;
        switch (coding)
        {
            case "ENCODING":


                    options.ProgressCharacter = '#';
                    options.ForegroundColorError = ConsoleColor.Red;
                    options.ForegroundColor = ConsoleColor.Green;
                    options.ShowEstimatedDuration = false;
                    options.ProgressBarOnBottom = true;
                    options.DisplayTimeInRealTime = false;
                
                break;
            case "DECODING":
                 {
                    options.ProgressCharacter = '#';
                    options.ForegroundColorError = ConsoleColor.Red;
                    options.ForegroundColor = ConsoleColor.DarkRed;
                        options.ShowEstimatedDuration = false;
                    options.ProgressBarOnBottom = true;
                    options.DisplayTimeInRealTime = false;
                };
                break;
        }
        
        using (var pbar = new ProgressBar(totalTicks, $"{coding} in progress", options))
        {
            for(int i=1;i<=10;i++)
            {
                pbar.Tick();
                System.Threading.Thread.Sleep(25);
            }
            pbar.Message = $"{coding} Complete!";
        }

        Console.WriteLine("\n");
    }

    

    public static void DisplayInfo(string file1, string file2)
    {
        FileInfo fi1 = new FileInfo(file1);
        FileInfo fi2 = new FileInfo(file2);
        
        Console.WriteLine($"\nMarimea fisierului inainte de compresie: {fi1.Length}\nMarimea fisierului in urma compresiei : {fi2.Length}");
        Console.WriteLine($"In urma procesului de compresie s-au economisit {fi1.Length - fi2.Length} bytes");
    }

    public static void Show()
    {
        Console.WriteLine("TEXT FILE INFO");
        DisplayInfo(TextManager.txtFile,TextManager.output);
        Console.WriteLine("WORD FILE INFO");
        DisplayInfo(WordManager.wordFile, WordManager.output);
        Console.WriteLine("PDF FILE INFO");
        DisplayInfo(PDFManager.pdfFile,PDFManager.output);
    }

    public static byte[] ConvertToByte(BitArray bits) {
        byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
        bits.CopyTo(bytes, 0);;
        return bytes;
    }

}