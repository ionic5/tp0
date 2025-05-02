using System;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld
{
    public class ReadCsvAction
    {
        public void Invoke(string path, Action<CsvHelper.IReader> callback)
        {
            TextAsset csvFile = Resources.Load<TextAsset>(path);
            using var reader = new StringReader(csvFile.text);
            using var csvReader = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Read();
            csvReader.ReadHeader();
            while (csvReader.Read())
                callback(csvReader);
        }
    }
}
