using MVVM.Common;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_LunaFlow.Models
{
    public class CyCleEntry:BaseViewModel
    {
        private ObservableObject<CyCleEntry> _obs;

        public CyCleEntry()
        {
            _obs = new ObservableObject<CyCleEntry>(this);
        }

        public DateTime Date
        {
            get => _obs.Get(vm=>vm.Date); set=>_obs.Set(vm=>vm.Date, value);    
        }

        public string Note
        {
            get=> _obs.Get(vm=>vm.Note); set=> _obs.Set(vm=>vm.Note, value);
        }

        public bool IsPeriod
        {
            get=>_obs.Get(vm=>vm.IsPeriod); set=> _obs.Set(vm=>vm.IsPeriod, value);
        }

        public bool IsOvulation
        {
            get => _obs.Get(vm => vm.IsOvulation); set=>_obs.Set(vm=>vm.IsOvulation, value);
        }
    }
}
