using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Commands;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        // とにかくVIewModelに実装するもの
        public event PropertyChangedEventHandler PropertyChanged;

        //Modelのインスタンスを保持するプロパティ
        public MainModel mm { get; set; }

        // コマンド格納プロパティ
        public LoginBtnCommand LoginBtnCommand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public LoginPageViewModel()
        {
            // コマンドインスタンスの生成
            LoginBtnCommand = new LoginBtnCommand(this);
        }

        public string LoginId
        {
            get
            {
                // ログインIDを返す
                return mm.LoginId;
            }
            set
            {
                // ログインMainModelに格納 
                mm.LoginId = value;
            }
        }

        public string Password
        {
            get
            {
                // パスワードを返す
                return mm.Password;
            }
            set
            {
                // パスワードをMainModelに格納 
                mm.Password = value;
            }
        }
    }
}
