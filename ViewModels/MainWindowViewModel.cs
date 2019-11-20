using System.Windows;
using System.Windows.Input;
using FDTDWPF.Commands;
using FDTDWPF.ViewModels.Base;
using FDTDWPF.Models;
using FDTDWPF.Commands.Base;

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

        private int _X;

        public int X
        {
            get => _X;
            set
            {
                // _X = value;
                // OnPropertyChanged();
                Set(ref _X, value * ds);
            }
        }

        private int _Y;
        public int Y
        {
            get => _Y;
            set { Set(ref _Y, value * ds); }
        }

        private int _Z;
        public int Z
        {
            get => _Z;
            set { Set(ref _Z, value); }
        }

        private Grid _G;
        public Grid G
        {
            get => _G;
            set { Set(ref _G, new Grid(X, Y, Z)); }
        }

        private int _ds = 1;

        public int ds
        {
            get => _ds;
            set { Set(ref _ds, (value != 0) ? value : value + 1); }
        }

        public ICommand RebuildGrid { get; }

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
