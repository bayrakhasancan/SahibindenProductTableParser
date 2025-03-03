using HtmlAgilityPack;
using SahibindenProductTableParser.Models;

namespace SahibindenProductTableParser.Services;

public class ProductParserService
{
    public static List<ProductPage> ParseProducts(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var tables = doc.DocumentNode.SelectNodes("//table");
        if (tables == null) return [];

        var results = new List<ProductPage>();

        for (var i = 0; i < tables.Count; i++)
        {
            var products = tables[i]
                .SelectNodes(".//tr[@data-id]")?
                .Select(ParseProduct)
                .Where(p => p != null)
                .ToList() ?? [];

            results.Add(new ProductPage(i + 1, products!));
        }

        return results;
    }

    private static Product? ParseProduct(HtmlNode node)
    {
        var name = node.SelectSingleNode(".//a[contains(@class, 'classifiedTitle')]")?.InnerText.Trim();
        var price = node.SelectSingleNode(".//div[contains(@class, 'classified-price-container')]/span")?.InnerText.Trim();

        return string.IsNullOrEmpty(name) || string.IsNullOrEmpty(price)
            ? null
            : new Product(name, price);
    }
}
