using MVVM.Common;
using MVVM_LunaFlow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_LunaFlow.ViewModels
{
    public class CalendarViewModel:BaseViewModel
    {
        private ObservableObject<CalendarViewModel> _obs;

        public CalendarViewModel()
        {
            _obs = new ObservableObject<CalendarViewModel>(this);
            Entries = new ObservableCollection<CyCleEntry>();
            AddEntryCommand = new RelayCommand(_ => AddEntry());
        }

        public DateTime SelectedDate
        {
            get=>_obs.Get(vm=>vm.SelectedDate); set=>_obs.Set(vm=>vm.SelectedDate, value);
        }

        public string Note
        {
            get => _obs.Get(vm => vm.Note); set=>_obs.Set(vm=>vm.Note, value);
        }
        public bool IsPeriod
        {
            get => _obs.Get(vm => vm.IsPeriod); set=>_obs.Set(vm=>vm.IsPeriod, value);
        }
        public bool IsOvulation
        {
            get => _obs.Get(vm => vm.IsOvulation); set=>_obs.Set(vm=>vm.IsOvulation, value);
        }

        public ObservableCollection<CyCleEntry> Entries { get; set; }
        public ICommand AddEntryCommand { get; }

        public void AddEntry()
        {
            Entries.Add(new CyCleEntry { Date = SelectedDate, Note = Note, IsPeriod = IsPeriod, IsOvulation = IsOvulation });
        }        
    }
}
