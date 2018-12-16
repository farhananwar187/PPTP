using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace myVPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
            "\\VPN");

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Data db = new Data();
            server sv = new server();
         var user=    db.GetUser(txtUsrname.Text, txtPassword.Text);
            if (user != null)
            {
                sv = db.GetServer("195.154.58.188");
            }
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var sb = new StringBuilder();
            sb.AppendLine("[VPN]");
            sb.AppendLine("MEDIA=rastapi");
            sb.AppendLine("Port=VPN2-0");
            sb.AppendLine("Device=WAN Miniport (IKEv2)");
            sb.AppendLine("DEVICE=vpn");
            sb.AppendLine("PhoneNumber=" + sv.Server1);

            File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());

            sb = new StringBuilder();
            sb.AppendLine("rasdial \"VPN\" " + sv.User_Name + " " + sv.Password + " /phonebook:\"" + FolderPath +
                          "\\VpnConnection.pbk\"");

            File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            var newProcess = new Process
            {
                StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };

            newProcess.Start();
            newProcess.WaitForExit();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data db = new Data();
            string remoteUri = "http://freevpn.it/accounts/";

            // Create a new WebClient instance.
           WebClient myWebClient = new WebClient();
            // Download home page data.

            // Download the Web resource and save it into a data buffer.
            byte[] myDataBuffer = myWebClient.DownloadData(remoteUri);

            // Display the downloaded data.
            string download = Encoding.ASCII.GetString(myDataBuffer);

            string IP = getBetween(download, "<b>IP:</b>", "</li>");
            string UserName = getBetween(download, "Username:</b>", "</li>");
            string Password = getBetween(download, "<b>Password:</b>", "<span");
            IP= Regex.Replace(IP, @"\s+", "");
            UserName = Regex.Replace(UserName, @"\s+", "");
            Password = Regex.Replace(Password, @"\s+", "");
            server srv = new server();
            srv.Server1 = IP;
            srv.User_Name = UserName;
            srv.Password = Password;

            db.AddServer(srv);
            MessageBox.Show("Server Added Successfully");
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}