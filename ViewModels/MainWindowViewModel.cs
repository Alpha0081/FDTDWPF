using System.Windows;
using System.Windows.Input;
using FDTDWPF.Commands;
using FDTDWPF.ViewModels.Base;

namespace FDTDWPF.ViewModels
{
    /// <summary>Модель-представления главного окна</summary>
    public class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Главное окно";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        /// <summary>Команда закрытия приложения</summary>
        public ICommand CloseApplicationCommand { get; }

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }

        /// <summary>Метод действия команды закрытия приложения</summary>
        /// <param name="Obj">Параметр команды</param>
        private static void OnCloseApplicationCommandExecuted(object Obj) => Application.Current.Shutdown();

        /// <summary>Метод, вызываемый для проверки возможности выполнения команды закрытия приложения</summary>
        /// <param name="Obj">Параметр команды</param>
        private static bool CanCloseApplicationCommandExecute(object Arg) => true;
    }
}
