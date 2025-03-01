using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Common
{
    /// <summary>
    /// MVVM에서 명령(Command)을 쉽게 생성하기 위한 클래스
    /// </summary>
    internal class RelayCommand: ICommand
    {
        private readonly Action<object?> _execute; // 실행할 동작
        private readonly Func<object?, bool>? _canExecute; // 실행 가능 여부 판단

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => _execute(parameter);

        public event EventHandler? CanExecuteChanged;
    }
}
