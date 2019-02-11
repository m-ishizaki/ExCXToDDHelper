using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RKSoftware.ExCXToDDHelper
{
    static class ZipArchiveConverter
    {
        internal static void ConvertZipArchive(ZipArchive archive)
        {
            var sharedFileNames = new[] { "xl/_rels/workbook.xml.rels", "xl/styles.xml", "xl/sharedStrings.xml" };
            var sheetNames = SheetNames(archive);
            var fileNames = sharedFileNames.Union(sheetNames);
            foreach (var fileName in fileNames) ConvertZipEntry(archive, fileName);
        }

        static IEnumerable<string> SheetNames(ZipArchive archive)
        {
            var regex = new Regex("^xl/worksheets/sheet\\d+\\.xml$");
            var names = archive.Entries.Select(entry => entry.FullName).Where(filename => regex.IsMatch(filename)).ToArray();
            return names;
        }

        static string ConverText(string oldText)
            => oldText
            .Replace("Target=\"/xl/", "Target=\"")
            .Replace("<x:", "<").Replace("</x:", "</").Replace("xmlns:x=", "xmlns=")
            .Replace("orientation=\"default\"", "");


        static void ConvertZipEntry(ZipArchive archive, string filename)
        {
            var oldEntry = archive.GetEntry(filename);
            if (oldEntry == null) return;
            var oldText =  ZipArchiveEntryHelper.ReadToEnd(oldEntry) ?? string.Empty;
            var newText = ConverText(oldText);
            oldEntry.Delete();
            var newEntry = archive.CreateEntry(filename);
            ZipArchiveEntryHelper.Write(newEntry, newText);
        }
    }
}
