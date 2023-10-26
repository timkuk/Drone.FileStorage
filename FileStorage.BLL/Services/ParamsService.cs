﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using FileStorage.BLL.Interfaces;
using FileStorage.DAL.Interfaces;
using System.Text.RegularExpressions;

namespace FileStorage.BLL.Services
{
    public class ParamsService : IParamsService
    {
        private readonly IDirectoryRepository _directoryRepository;


        public ParamsService(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }


        public FileInfo[] GetFilesWithConditions(Dictionary<string, string> commandsMap, DirectoryInfo directoryInfo)
        {
            var parseMaxFileSize = commandsMap.SingleOrDefault(c => c is { Key: "s" }).Value;
            var maxFileSize = ConvertSizeToBytes(parseMaxFileSize);

            var parseMaxFilesCount = commandsMap.SingleOrDefault(c => c .Key == "c").Value;
            var maxFilesCount = int.Parse(parseMaxFilesCount);

            var files = _directoryRepository.GetInformationAboutAllFilesInDirectory(directoryInfo);

            var filteredFiles = FilterFiles(files, maxFileSize, maxFilesCount);

            return filteredFiles;
        }


        private static long ConvertSizeToBytes(string input)
        {
            var match = Regex.Match(input, @"(\d+)\s*(GB|MB|KB)", RegexOptions.IgnoreCase);

            if (!long.TryParse(match.Groups[1].Value, out var size))
            {
                throw new ArgumentException("Invalid format string.");
            }

            var units = match.Groups[2].Value.ToUpper();

            return units switch
            {
                "GB" => size * 1024 * 1024 * 1024,
                "MB" => size * 1024 * 1024,
                "KB" => size * 1024,
                "B" => size,
                _ => throw new ArgumentException("Invalid format units of measurement")
            };
        }

        private static FileInfo[] FilterFiles(FileInfo[] files, long? maxFileSize, int? maxFileCount)
        {
            var filteredFiles = files;

            if (maxFileSize.HasValue)
            {
                filteredFiles = files.Where(file => file.Length <= maxFileSize.Value).ToArray();
            }

            if (maxFileCount.HasValue)
            {
                filteredFiles = files.Take(maxFileCount.Value).ToArray();
            }

            return filteredFiles;
        }
    }
}
