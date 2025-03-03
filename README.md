# SahibindenProductTableParser

[![.NET](https://img.shields.io/badge/.NET-9.0-%23512bd4)](https://dotnet.microsoft.com)
[![GPLv3 License](https://img.shields.io/badge/License-GPLv3-blue.svg)](LICENSE)

Bu araç, sahibinden'den alınan ürün tablosunu ayrıştırır.
HTML formatındaki ürün tablosu içerisinden ürün adları, fiyat bilgileri gibi verileri çekerek, okunabilir bir çıktı sunar.

### Örnek Input

Alt alta birden fazla "searchResultsTable" eklenebilir.

```html
<table id="searchResultsTable" class="">
    ...
</table>
<table id="searchResultsTable" class="">
    ...
</table>
```

### Örnek Output

```html
[SAYFA 1]
Ryzen 3 1300X İşlemci Sorunsuz Sıkıntısız-750 TL
RYZEN 5 5600X-3.900 TL
Ryzen 5 1500X Amd İşlemci Sorunsuz Sıkıntısız-1.050 TL
```

## Hızlı Başlangıç

```bash
git clone https://github.com/bayrakhasancan/SahibindenProductTableParser.git
cd SahibindenProductTableParser
dotnet run -- samples/input.txt
```