using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ToDoApp.Model;
using ToDoApp.ViewModel;

namespace ToDoApp.Commands
{
    class LoginBtnCommand : ICommand
    {
        private LoginPageViewModel _view { get; set; }

        /// <summary>
        /// コンストラクタ
        /// 　対応するViewModelを引数に設定しておく
        /// </summary>
        /// <param name="view"></param>
        public LoginBtnCommand(LoginPageViewModel view)
        {
            _view = view;
        }

        /// <summary>
        /// 必ず実装しておくメソッド
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 必ず実装しておくメソッド
        /// /// コマンドの有効／無効を判定するメソッド
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 必ず実装しておくメソッド
        /// コマンドの動作を定義するメソッド
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //テキストボックスとパスワードボックスから直接ユーザーネームとパスワードの受け取りを行う
            //をしたいけれどどうしたらいいかなぁ
            //入れ物は用意済↓
            string username = String.Empty;
            string password = String.Empty;

            //MainModelのSetDataFromPostgresServerメソッドを使うためにインスタンス化
            MainModel mm = new MainModel();

            // 空チェック
            if (string.IsNullOrEmpty(_view.LoginId))
            {
                MessageBox.Show("ログインIDを入力してください");
                return;
            }

            if (string.IsNullOrEmpty(_view.Password))
            {
                MessageBox.Show("パスワードを入力してください");
                return;
            }

            //ユーザーネームとパスワードの照合
            mm.SetDataFromPostgresServer(username, password);

            //照合完了の場合はタスク一覧画面へ遷移
            var navigationWindow = (NavigationWindow)Application.Current.MainWindow;
            var uri = new Uri("Views/MenuPage.xaml", UriKind.Relative);
            navigationWindow.Navigate(uri, parameter);

        }
    }
}
