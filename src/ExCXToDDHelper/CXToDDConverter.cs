using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace RKSoftware.ExCXToDDHelper
{
    public static class CXToDDConverter
    {
        public static void Convert(string filename)
        {
            using (var archive = ZipFile.Open(filename, ZipArchiveMode.Update))
                ZipArchiveConverter.ConvertZipArchive(archive);
        }

        public static void Convert(Stream stream)
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Update, true))
            {
                ZipArchiveConverter.ConvertZipArchive(archive);
            }
            stream.Position = 0;
        }
    }
}
