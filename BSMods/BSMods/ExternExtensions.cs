﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSMods
{
    static class ExternExtensions
    {
            public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
            {
                if (!overwrite)
                {
                    archive.ExtractToDirectory(destinationDirectoryName);
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
                string destinationDirectoryFullPath = di.FullName;

                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                    if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new IOException("Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");
                    }

                    if (file.Name == "")
                    {// Assuming Empty for Directory
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                        continue;
                    }

                    if (!Directory.Exists(completeFileName))
                    {
                        var splitted = completeFileName.Split('\\');
                        var path = completeFileName.Replace(splitted[splitted.Length - 1], "");
                        Directory.CreateDirectory(path);
                    }

                file.ExtractToFile(completeFileName, true);
                   
                }
            }
        
    }
}
