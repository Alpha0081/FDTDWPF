using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FDTDWPF.Commands.Base
{
    /// <summary>Команда</summary>
    public abstract class Command : ICommand
    {
        /// <summary>Событие возникает в момент времени, когда команда меняет своё состояние можно/нельзя выполнить</summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>Метод проверки возможности выполнения команды</summary>
        /// <param name="parameter">Параметр, передаваемый для проверки</param>
        /// <returns>Истина, если команда в её текущем состоянии и при переданном значении параметра может быть выполнена</returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>Метод, реализующий основное действие команды</summary>
        /// <param name="parameter">Объект-параметр, передаваемый для выполнения в основной метод команды</param>
        public abstract void Execute(object parameter);
    }
}
