using SahibindenProductTableParser.Services;
using System.Diagnostics;

namespace SahibindenProductTableParser;

public static class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var inputPath = FileService.GetInputFilePath(args);
            var htmlContent = await FileService.ReadFileAsync(inputPath);

            var products = ProductParserService.ParseProducts(htmlContent);

            var outputPath = Path.Combine(
                Path.GetDirectoryName(inputPath)!,
                $"{Path.GetFileNameWithoutExtension(inputPath)}_results.txt");

            await OutputService.WriteOutputAsync(products, outputPath);

            Console.WriteLine($"\nSonuçlar kaydedildi: {outputPath}");
            Process.Start(new ProcessStartInfo(outputPath) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}