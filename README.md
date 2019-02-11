# ExCXToDDHelper
This library converts xlsx file from CX to DD.
# Usage
#### File
```cs
const string filename = @"out\from.xlsx";
const string outfilename = @"out\to.xlsx";

{
    var book = new XLWorkbook();
    var sheet = book.AddWorksheet("New Sheet");
    book.SaveAs(filename);
}

RKSoftware.ExCXToDDHelper.CXToDDConverter.Convert(filename);

{
    var book = new Workbook();
    book.Open(filename);
    book.Save(outfilename);
}
```
#### Stream
```cs
const string outfilename = @"out\to.xlsx";

using (var stream = new MemoryStream())
{
    {
        var book = new XLWorkbook();
        var sheet = book.AddWorksheet("New Sheet");
        book.SaveAs(stream);
    }

    RKSoftware.ExCXToDDHelper.CXToDDConverter.Convert(stream);

    {
        var book = new Workbook();
        book.Open(stream);
        book.Save(outfilename);
    }
}
```