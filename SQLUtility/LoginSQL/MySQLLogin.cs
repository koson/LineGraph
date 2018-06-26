using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LineGraph.SQLUtility
{
    public partial class MySQLLogin : Form
    {
        private const string SERVER = "127.0.0.1";
        private string DATABASE = "GuGong";

        public MySQLLogin()
        {
            InitializeComponent();
        }

        public void ConnectMySQL()
        {
            userIdTextBox.Text = "root";
            passwordTextBox.Text = "123456";
            MySQLDB.GetMySQLDB().connect(SERVER, DATABASE, userIdTextBox.Text, passwordTextBox.Text);    
        }

        //private void commandButton_Click(object sender, EventArgs e)
        //{
        //    if (m_MySQLDatabase == null) return;
        //    result_richText.Text += "\n-------------------------------------------------------------------";
        //    MySqlCommand cmd = m_MySQLDatabase.giveCommand(commandTextBox.Text);
        //    MySqlDataReader reader = null;
        //    try
        //    {
        //        reader = cmd.ExecuteReader();
        //    }
        //    catch (Exception eq)
        //    {
        //        MessageBox.Show("Error : " + eq.StackTrace);
        //    }

        //    int fieldNum = reader.FieldCount;
        //    if (commandTextBox.Text.Contains("select"))
        //        printData(fieldNum, reader);
        //    else if (commandTextBox.Text.Contains("update"))
        //    {
        //        //TODO : Set up getting updated strings.                
        //        //string updated = result_richText.Text.Substring(result_richText.Text.IndexOf("set ", 4));
        //        result_richText.Text += "\n\tTable Updated";
        //    }
        //    reader.Close();
        //}

        //void printData(int fieldNum, MySqlDataReader reader)
        // {
        ////Add the column names
        //result_richText.Text += "\n";
        //for (int i = 0; i < fieldNum; i++)
        //{
        //    columnName.Add(reader.GetName(i));
        //    result_richText.Text += "\t" + reader.GetName(i);
        //}
        ////Add all the values of all rows
        //result_richText.Text += "\n";
        //while (reader.Read())
        //{
        //    result_richText.Text += "\n";
        //    for (int i = 0; i < fieldNum; i++)
        //    {
        //        values.Add(reader[i].ToString());
        //        result_richText.Text += "\t" + reader[i].ToString();
        //    }
        //}

        //int[] initOffset = new int[fieldNum];
        //for (int i = 0; i < fieldNum; i++)
        //    initOffset[i] = i;
        ////Gets all the values of a particular field each
        //for (int j = 0; j < fieldNum; j++)
        //{
        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        if (initOffset[j] == i)
        //        {
        //            initOffset[j] += fieldNum;
        //        }
        //    }
        //}

        //}

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MySQLDB.GetMySQLDB().closeConnection();
            }
            catch { }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (userIdTextBox.Text != String.Empty && passwordTextBox.Text != String.Empty /*&& textBoxDatabase.Text != String.Empty*/)
            {
                DATABASE = textBoxDatabase.Text;
                MySQLDB.GetMySQLDB().connect(SERVER, DATABASE, userIdTextBox.Text, passwordTextBox.Text);
            }
        }

        private void OnClick_RemoveText(object sender, EventArgs e)
        {
            if (sender.Equals(userIdTextBox))
                userIdTextBox.Text = "";
            if (sender.Equals(passwordTextBox))
                passwordTextBox.Text = "";
            if (sender.Equals(textBoxDatabase))
                textBoxDatabase.Text = "";
        }
    }
}
