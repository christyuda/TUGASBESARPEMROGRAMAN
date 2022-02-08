using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;


namespace AplikasiGudang
{
    class koneksidb
    {
        //private MySqlConnection Conn = new MySqlConnection("server=localhost;user id=root;database=gudang;sslMode=none");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        //public DataTable dt;
        int result;
        private string url = "server=localhost;userid=root;password=;database=gudang";
        public MySqlConnection GetConn()
        {
            MySqlConnection Conn = new MySqlConnection(url);
            return Conn;
        }
        //public void Execute_Query(string sql)
        //{
        //    try
        //    {
        //        Conn.Open();
        //        cmd = new MySqlCommand();
        //        cmd.Connection = Conn;
        //        cmd.CommandText = sql;
        //        result = cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //    }
        //}
        //public void update_Autonumber(string id)
        //{
        //    Execute_Query("UPDATE `tabel_autonumber` SET `END`=`END`+`INCREMENT` WHERE `DESCRIPTION`='" + id + "'");
        //}
        //public void Execute_CUD(string sql, string msg_false, string msg_true)
        //{
        //    try
        //    {
        //        Conn.Open();
        //        cmd = new MySqlCommand();
        //        cmd.Connection = Conn;
        //        cmd.CommandText = sql;
        //        result = cmd.ExecuteNonQuery();

        //        if (result > 0)
        //        {
        //            MessageBox.Show(msg_true);
        //        }
        //        else
        //        {
        //            MessageBox.Show(msg_false);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //    }
        //}

        //public void autonumber(string sql, TextBox txt)
        //{
        //    try
        //    {
        //        Conn.Open();
        //        cmd = new MySqlCommand();
        //        da = new MySqlDataAdapter();
        //        dt = new DataTable();


        //        cmd.Connection = Conn;
        //        cmd.CommandText = sql;
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);

        //        txt.Text = dt.Rows[0].Field<string>(0);


        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        da.Dispose();
        //        Conn.Close();
        //    }
        //}

        //private void UpdateDB(string cmd)
        //{
        //    try
        //    {
        //        MySqlConnection myconn = new MySqlConnection(url);
        //        myconn.Open();
        //        MySqlCommand command = new MySqlCommand();
        //        command.Connection = myconn;
        //        command.CommandText = cmd;
        //        command.ExecuteNonQuery();
        //        MessageBox.Show("Database has been Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}
    }
}
