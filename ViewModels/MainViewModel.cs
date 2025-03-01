using MVVM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        // 속성 관리를 위한 ObservableObject
        private readonly ObservableObject<MainViewModel> _obs;

        /// <summary>
        /// MainViewModel 생성자. 초기값을 설정하고 명령을 등록함.
        /// </summary>
        public MainViewModel()
        {
            _obs = new ObservableObject<MainViewModel>(this);
            ClickCommand = new RelayCommand(_ => ClickAction());
        }

        /// <summary>
        /// 사용자 이름 속성
        /// </summary>
        public string Name
        {
            get => _obs.Get(vm => vm.Name);
            set => _obs.Set(vm => vm.Name, value);
        }

        /// <summary>
        /// 사용자 나이 속성.
        /// </summary>
        public int Age
        {
            get => _obs.Get(vm => vm.Age);
            set => _obs.Set(vm => vm.Age, value);
        }

        /// <summary>
        /// 버튼 클릭 시 실행할 명령
        /// </summary>
        public ICommand ClickCommand { get; }

        private void ClickAction()
        {
            Name = "Clicked";
            Age++;
        }
    }
}
