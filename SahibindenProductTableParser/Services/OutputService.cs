using SahibindenProductTableParser.Models;

namespace SahibindenProductTableParser.Services;

public class OutputService
{
    public static async Task WriteOutputAsync(List<ProductPage> pages, string outputPath)
    {
        await using var writer = new StreamWriter(outputPath);

        foreach (var page in pages)
        {
            var header = $"[SAYFA {page.PageNumber}]";
            Console.WriteLine(header);
            await writer.WriteLineAsync(header);

            if (page.Products.Count == 0)
            {
                var message = $"Sayfa {page.PageNumber} için ürün bulunamadı!";
                Console.WriteLine(message);
                await writer.WriteLineAsync(message);
            }
            else
            {
                foreach (var product in page.Products)
                {
                    var line = $"{product.Name}-{product.Price}";
                    Console.WriteLine(line);
                    await writer.WriteLineAsync(line);
                }
            }

            var separator = new string('=', 100);
            Console.WriteLine(separator);
            await writer.WriteLineAsync(separator);
        }
    }
}
