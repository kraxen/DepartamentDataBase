﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Install-Package Newtonsoft.Json -Version 10.0.3
using System.IO;

namespace Seriolization
{
    public class ToJSON
    {
        /// <summary>
        /// Метод сериализации List<Worker >
        /// </summary>
        /// <param name="СoncreteWorker">Коллекция для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        public static void SerializeToJsonList<T>(T СoncreteWorkerList, string Path)
        {
            string json = JsonConvert.SerializeObject(СoncreteWorkerList);

            json = JsonConvert.SerializeObject(СoncreteWorkerList);
            File.WriteAllText(Path, json);
        }
        /// <summary>
        /// Метод десериализации Worker
        /// </summary>
        /// <param name="СoncreteWorker">Экземпляр для сериализации</param>
        /// <param name="Path">Путь к файлу</param>
        public static T DeserializeToJson<T>(string Path)
        {
            string json = File.ReadAllText(Path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
