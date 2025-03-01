using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Common
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // 속성 값 변경 시 발생하는 이벤트
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 속성 값을 변경하고, 변경이 감지되면 UI에 알림을 보냄.
        /// </summary>
        /// <typeparam name="T">속성 데이터 타입</typeparam>
        /// <param name="storage">기존 저장된 값</param>
        /// <param name="value">새로운 값</param>
        /// <param name="propertyName">속성 이름 (자동 설정)</param>
        /// <returns>값이 변경되었으면 true, 변경되지 않았으면 false</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false; // 기존 값과 동일하면 변경하지 않음

            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        internal protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
