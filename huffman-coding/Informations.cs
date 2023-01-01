using System.Collections;
using ShellProgressBar;

namespace huffman_coding;

public class Informations
{
    public void DisplayProgressBar(string coding)
    {
        ProgressBarOptions? options;
        options = new ProgressBarOptions();
        const int totalTicks = 10;
        switch (coding)
        {
            case "Encoding":


                    options.ProgressCharacter = '#';
                    options.ForegroundColorError = ConsoleColor.Red;
                    options.ForegroundColor = ConsoleColor.Green;
                    options.ShowEstimatedDuration = false;
                    options.ProgressBarOnBottom = true;
                    options.DisplayTimeInRealTime = false;
                
                break;
            case "Decoding":
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

    public void DisplayFileInfo(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        Console.WriteLine("--------------------------------------INFORMATII FISIER--------------------------------------");
        Console.WriteLine($"Marime:{path.Length}");
    }
    

    public long GetFileSize(string path)    
    {
        FileInfo fileInfo = new FileInfo(path);
        return path.Length;
    }

    public static byte[] ConvertToByte(BitArray bits) {
        byte[] bytes = new byte[bits.Length / 8 + (bits.Length % 8 == 0 ? 0 : 1)];
        bits.CopyTo(bytes, 0);;
        return bytes;
    }

}