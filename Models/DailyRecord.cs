using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_LunaFlow.Models
{
    public class PeriodRecord
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BodyCondition { get; set; }
    }

    public class GeneralRecord : PeriodRecord
    {
        public DateTime? OvulationStartDate { get; set; }
        public DateTime? OvulationEndDate { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public string OvulationMemo { get; set; }
        public string PeriodMemo { get; set; }
    }

    public class DailyRecord : PeriodRecord
    {
        public DateTime Date { get; set; }
        public string Mood { get; set; }
        public double Temperature { get; set; }
    }
}
