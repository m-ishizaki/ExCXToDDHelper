using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace RKSoftware.ExCXToDDHelper
{
    static class ZipArchiveEntryHelper
    {
        internal static string ReadToEnd(ZipArchiveEntry entry)
        {
            using (var sr = new System.IO.StreamReader(entry.Open()))
                return sr.ReadToEnd();
        }

        internal static void Write(ZipArchiveEntry entry, string text)
        {
            using (var sw = new System.IO.StreamWriter(entry.Open()))
                sw.Write(text);
        }
    }
}
