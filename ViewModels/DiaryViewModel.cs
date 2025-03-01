using MVVM.Common;
using MVVM_LunaFlow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_LunaFlow.ViewModels
{
    public class DiaryViewModel:BaseViewModel
    {
        private readonly PeriodRecordService _recordService;
        public ObservableCollection<PeriodRecord> PeriodRecords { get; set; }
        public ObservableCollection<GeneralRecord> GeneralRecords { get; set; }
        private readonly ObservableObject<DiaryViewModel> _obs;
        public DiaryViewModel()
        {
            _obs = new ObservableObject<DiaryViewModel>(this);
            _recordService = new PeriodRecordService();
            PeriodRecords = new ObservableCollection<PeriodRecord>(_recordService.LoadRecords());
            GeneralRecords = new ObservableCollection<GeneralRecord>(_recordService.LoadGeneralRecords());
            AddRecordCommand = new RelayCommand(_ => AddRecord());
        }

        private void AddRecord()
        {
            // 일반적인 기록
            var newGeneralRecord = new GeneralRecord
            {
                OvulationStartDate = OvulationStartDate,
                OvulationEndDate = OvulationEndDate,
                OvulationMemo = OvulationMemo,
                PeriodStartDate = PeriodStartDate,
                PeriodEndDate = PeriodEndDate,
                PeriodMemo = PeriodMemo
            };

            // 날짜별 기록
            var newDailyRecord = new DailyRecord
            {
                Date = SelectedDate ?? DateTime.Now, // 선택된 날짜 사용, 없으면 오늘 날짜
                BodyCondition = BodyCondition,
                Mood = Mood,
                Temperature = Temperature
            };

            // 새 기록을 추가
            PeriodRecords.Add(newGeneralRecord); // 일반 기록 추가
            PeriodRecords.Add(newDailyRecord); // 날짜별 기록 추가

            GeneralRecords.Add(newGeneralRecord);

            // 기록을 JSON 파일에 저장
            _recordService.SaveRecords(PeriodRecords.ToList());
            _recordService.SaveGeneralRecords(GeneralRecords.ToList());

            // UI 필드 초기화
            ClearInputFields();
        }

        // 입력 필드 초기화
        private void ClearInputFields()
        {
            OvulationStartDate = DateTime.Now;
            OvulationEndDate = DateTime.Now.AddDays(5);
            PeriodStartDate = DateTime.Now;
            PeriodEndDate = DateTime.Now.AddDays(5);
            OvulationMemo = string.Empty;
            PeriodMemo = string.Empty;
            BodyCondition = string.Empty;
            Mood = string.Empty;
            Temperature = 36.5;
            SelectedDate = null; // 날짜 초기화
        }

        public ICommand AddRecordCommand { get; }

        #region properties
        public DateTime? OvulationStartDate
        {
            get=>_obs.Get(vm=>vm.OvulationStartDate); set=>_obs.Set(vm=>vm.OvulationStartDate, value);
        }
        public DateTime? OvulationEndDate
        {
            get => _obs.Get(vm => vm.OvulationEndDate); set => _obs.Set(vm => vm.OvulationEndDate, value);
        }
        public string OvulationMemo { get; set; }

        public DateTime? PeriodStartDate
        {
            get => _obs.Get(vm => vm.PeriodStartDate); set => _obs.Set(vm => vm.PeriodStartDate, value);
        }
        public DateTime? PeriodEndDate
        {
            get => _obs.Get(vm => vm.PeriodEndDate); set => _obs.Set(vm => vm.PeriodEndDate, value);
        }
        public string PeriodMemo { get; set; }

        public DateTime? SelectedDate
        {
            get => _obs.Get(vm => vm.SelectedDate); set => _obs.Set(vm => vm.SelectedDate, value);
        }

        public string BodyCondition
        {
            get => _obs.Get(vm => vm.BodyCondition); set=>_obs.Set(vm=>vm.BodyCondition, value);
        }
        public string Mood
        {
            get => _obs.Get(vm => vm.Mood); set => _obs.Set(vm => vm.Mood, value);
        }
        public double Temperature
        {
            get => _obs.Get(vm => vm.Temperature); set => _obs.Set(vm => vm.Temperature, value);
        }
        #endregion
    }
}
