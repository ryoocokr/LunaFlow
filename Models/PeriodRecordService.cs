using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace MVVM_LunaFlow.Models
{
    public class PeriodRecordService
    {
        private readonly string _filePath = "records.json";

        // 기록 로드
        public List<PeriodRecord> LoadRecords()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<PeriodRecord>>(jsonData);
            }
            return new List<PeriodRecord>();
        }

        // 기록 저장
        public void SaveRecords(List<PeriodRecord> records)
        {
            var jsonData = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }

        private readonly string _generalFilePath = "records_general.json";

        // 기록 로드
        public List<GeneralRecord> LoadGeneralRecords()
        {
            if (File.Exists(_generalFilePath))
            {
                var jsonData = File.ReadAllText(_generalFilePath);
                return JsonConvert.DeserializeObject<List<GeneralRecord>>(jsonData);
            }
            return new List<GeneralRecord>();
        }

        // 기록 저장
        public void SaveGeneralRecords(List<GeneralRecord> records)
        {
            var jsonData = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText(_generalFilePath, jsonData);
        }
    }
}
