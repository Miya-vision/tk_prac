using System.Data;
using ToDoApp.ViewModel;

namespace ToDoApp.Model
{
    public class MainModel
    {
        private object DbAccess;

        //コンストラクタ
        public MainModel()
        {
            LoginPageViewModel lpvm = new LoginPageViewModel();
            //TaskPageViewModel tpvml = new TaskPageViewModel();
        }

        public string LoginId { get; set; } = "";
        public string Password { get; set; } = "";

        //DB接続
        public string SetDataFromPostgresServer(string username, string password)
        {
            DbAccess dba = new DbAccess();

            string checkUsername = username;

            string checkPassword = password;

            //DbAccessで取得したデータを格納
            string pw = dba.GetDataFromPostgresServer(checkUsername, checkPassword);

            return pw;
        }
    }
}