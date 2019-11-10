using System.Windows;
using System.Windows.Input;
using FDTDWPF.Commands;
using FDTDWPF.ViewModels.Base;

namespace FDTDWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Главное окно";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        public ICommand CloseApplicationCommand { get; }

        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }

        private static void OnCloseApplicationCommandExecuted(object Obj) => Application.Current.Shutdown();

        private static bool CanCloseApplicationCommandExecute(object Arg) => true;
    }
}
