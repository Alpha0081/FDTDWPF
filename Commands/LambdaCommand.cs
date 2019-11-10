using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDTDWPF.Commands.Base;

namespace FDTDWPF.Commands
{
    /// <summary>Универсальная команда на основе делегатов</summary>
    public class LambdaCommand : Command
    {
        /// <summary>Делегат действия, которое должно быть выполнено при выполнении команды</summary>
        private readonly Action<object> _Execute;

        /// <summary>Функция, осуществляющая проверку возможности выполнения команды с указанным значением параметра</summary>
        private readonly Func<object, bool> _CanExecute;

        /// <summary>Инициализация новой универсальной команды на основе делегатов</summary>
        /// <param name="Execute">Метод, выполняемый командой</param>
        /// <param name="CanExecute">Метод, позволяющий определить возможность выполнения команды</param>
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);
    }
}
