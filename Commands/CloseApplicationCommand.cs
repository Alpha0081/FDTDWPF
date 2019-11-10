using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FDTDWPF.Commands.Base;

namespace FDTDWPF.Commands
{
    /// <summary>Команда, закрывающая текущее приложение с указанным кодом выхода</summary>
    public class CloseApplicationCommand : Command
    {
        /// <summary>Код выхода из приложения</summary>
        public int ResultCode { get; set; }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown(ResultCode);
    }
}
