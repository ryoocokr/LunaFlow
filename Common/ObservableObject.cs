using System.ComponentModel;
using System.Linq.Expressions;

namespace MVVM.Common
{
    /// <summary>
    /// ViewModel의 속성을 쉽게 관리하기 위한 유틸리티 클래스.
    /// 속성 값을 저장하고 변경 시 자동으로 PropertyChanged 이벤트를 발생시킴.
    /// </summary>
    /// <typeparam name="T">BaseViewModel을 상속받은 ViewModel 타입</typeparam>
    internal class ObservableObject<T> where T: BaseViewModel
    {
        private readonly T _viewModel; // 연결된 ViewModel
        private readonly Dictionary<string, object> _values = new(); // 속성값 저장소 

        /// <summary>
        /// ObservableObject 생성자. ViewModel을 참조함.
        /// </summary>
        /// <param name="viewModel"></param>
        public ObservableObject(T viewModel) => _viewModel = viewModel;

        /// <summary>
        /// 속성 값을 가져옴.
        /// </summary>
        /// <typeparam name="U">속성 타입</typeparam>
        /// <param name="property">속성 표현식 (예: vm=>vm.PropertyName)</param>
        /// <returns>저장된 속성 값</returns>
        public U Get<U>(Expression<Func<T, U>> property)
        {
            var name = GetPropertyName(property);
            return _values.TryGetValue(name, out var value) ? (U)value : default;
        }

        /// <summary>
        /// 속성 값을 설정하고 변경을 감지하여 UI에 알림을 보냄.
        /// </summary>
        /// <typeparam name="U">속성 타입</typeparam>
        /// <param name="property">속성 표현식 (예: vm => vm.PropertyName)</param>
        /// <param name="value">새로운 값</param>
        public void Set<U>(Expression<Func<T, U>> property, U value)
        {
            var name = GetPropertyName(property);
            if (_values.TryGetValue(name, out var existing) && EqualityComparer<U>.Default.Equals((U)existing, value))
                return; // 기존 값과 동일하면 변경하지 않음.

            _values[name] = value;
            _viewModel.OnPropertyChanged(name); // UI에 알림.
        }

        /// <summary>
        /// 람다식에서 속성 이름을 추출
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetPropertyName<U>(Expression<Func<T, U>> property) =>
            (property.Body as MemberExpression)?.Member.Name ?? throw new ArgumentException("Invalid Property");
    }
}
