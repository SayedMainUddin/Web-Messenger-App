using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using ConnectionState = Microsoft.AspNet.SignalR.Client.ConnectionState;

namespace WindowsChatClient
{
    public partial class Form1 : Form
    {
        private HubConnection hubConnection;
        private IHubProxy chatHub;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hubConnection = new HubConnection("http://localhost:15844/myhub");
            chatHub = hubConnection.CreateHubProxy("chatHub");
            hubConnection.Start();


            chatHub.On("message", (string msg) =>
            {
                txtDialog.Text += (msg + Environment.NewLine);
            });

            //chatHub.On("message", (string msg) =>
            //{
            //    txtDialog.Text += (msg + Environment.NewLine);
            //});
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (hubConnection.State == ConnectionState.Connected)
            {
                chatHub.Invoke("send", txtMesage.Text);

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
