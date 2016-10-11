using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterceptClient
{
    [ServiceContract]
    public interface IInterceptService
    {
        [OperationContract]
        string StartKeyboard(string file);
        [OperationContract]
        string StartMouse(string file);
        [OperationContract]
        string StopKeyboard();
        [OperationContract]
        string StopMouse();
        [OperationContract]
        byte[] GetFile(string file, int position);
    }

    public partial class Form1 : Form
    {
        private IInterceptService IS;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gbKeyboard.Enabled = false;
            gbMouse.Enabled = false;
            tbEndPoint.Text = ConfigurationManager.AppSettings["EndPoint"].ToString();
        }       
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            EndpointAddress address = new EndpointAddress(tbEndPoint.Text);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IInterceptService> factory = new ChannelFactory<IInterceptService>(binding, address);

            IS = factory.CreateChannel();

            gbKeyboard.Enabled = true;
            gbMouse.Enabled = true;
        }
        private void btnSaveKeyboard_Click(object sender, EventArgs e)
        {
            if(SFD.ShowDialog(this) == DialogResult.OK)
            {
                int i = 0;
                byte[] buffer = null;

                do
                {
                    buffer = IS.GetFile(ConfigurationManager.AppSettings["KeyboardFile"].ToString(), i);
                    if (buffer != null)
                    {
                        i += 1024;

                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            using (FileStream fs = new FileStream(SFD.FileName, FileMode.Append))
                            {
                                ms.CopyTo(fs);
                            }
                        }
                    }
                } while (buffer != null);
            }
        }
        private void btnSaveMouse_Click(object sender, EventArgs e)
        {
            if (SFD.ShowDialog(this) == DialogResult.OK)
            {
                int i = 0;                
                byte[] buffer = null;

                do
                {
                    buffer = IS.GetFile(ConfigurationManager.AppSettings["MouseFile"].ToString(), i);
                    if (buffer != null)
                    {
                        i += 1024;

                        using (MemoryStream ms = new MemoryStream(buffer))
                        {
                            using (FileStream fs = new FileStream(SFD.FileName, FileMode.Append))
                            {
                                ms.CopyTo(fs);
                            }
                        }
                    }
                } while (buffer != null);
            }
        }
        private void rbKeyboard_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            switch (rb.Text)
            {
                case "Start":
                    MessageBox.Show(IS.StartKeyboard(ConfigurationManager.AppSettings["KeyboardFile"].ToString()));
                    break;
                case "Stop":
                    MessageBox.Show(IS.StopKeyboard());
                    break;
            }
        }
        private void rbMouse_Click(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            switch(rb.Text)
            {
                case "Start":
                    MessageBox.Show(IS.StartMouse(ConfigurationManager.AppSettings["MouseFile"].ToString()));
                    break;
                case "Stop":
                    MessageBox.Show(IS.StopMouse());
                    break;
            }
        }
    }
}
