using Npgsql;
using System.Data;

namespace ToDoApp.ViewModel
{
    public class DbAccess
    {
        //PostgreSQLの接続文字列作成
        private string connectionString = "Server=localhost; Port=5432; User Id=postgres; Password=pos2025; Database=postgres; SearchPath=public";

        //DBに接続してテーブルのデータを取得
        public String GetDataFromPostgresServer(string username, string password)
        {
            //NpgsqlConnectionのインスタンスを生成
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string un = username;
                string pw = password;

                //渡されたユーザーネームでパスワードを検索して値を取得する
                string query = "SELECT password FROM test_table WHERE NO = " + un;

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {
                    }
                }

                return pw;
            }
        }
    }
}