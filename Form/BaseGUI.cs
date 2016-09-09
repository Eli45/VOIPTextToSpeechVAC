using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Speech; //Todo: Narrow
using VOIPTextToSpeechVAC.Base.HotKey;
using VOIPTextToSpeechVAC.Base.ConfigReader;
using VOIPTextToSpeechVAC.Base.ConfigWriter;
using VOIPTextToSpeechVAC.Base.Constants;
using VOIPTextToSpeechVAC.Base.KeyLogger;

namespace VOIPTextToSpeechVAC
{
    public partial class BaseGUI : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            int fsModifiers,
            int vk
        );

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id
        );

        private List<HotKey> HotKeys = new List<HotKey>();
        private KeyLogger    KL = new KeyLogger();

        public BaseGUI()
        {
            InitializeComponent();
        }


        private void BaseGUI_Load(object sender, EventArgs e)
        {
            //Instantiate ConfigReader and read hotkeys.
            ConfigReader c = new ConfigReader();
            this.HotKeys = c.ReadHotKeys();


            if (HotKeys != null)
                foreach (HotKey entry in HotKeys)
                    RegisterHotKey(Handle, entry.Id, entry.KeyModifier, entry.KeyHashCode);
        }

        private void BaseGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Instantiate ConfigWriter and write saved hotkeys.
            ConfigWriter c = new ConfigWriter();
            c.WriteConfig(this.HotKeys);

            if (HotKeys != null)
                foreach (HotKey entry in HotKeys)
                    UnregisterHotKey(Handle, entry.Id);   
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == Constants.WIN_MSG_HOTKEY_DOWN)
            {
                if (KL.IsListening) {
                    KL.StopListening();
                    //todo: Transmit audio
                }
                else {
                    KL.StartListening();
                }
                
            }
        }



    }
}
