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
using VOIPTextToSpeechVAC.Base.UserActivityHook;
using VOIPTextToSpeechVAC.Base.Helper;

namespace VOIPTextToSpeechVAC
{
    public partial class BaseGUI : Form
    {
        //TODO: DISABLE ON RELEASE VERS.
        private static bool IS_DEBUG = true;


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

        UserActivityHook actHook;

        public void GlobalKeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            this.KL.AddKey(k);
        }


        private List<HotKey> HotKeys = new List<HotKey>();
        private KeyLogger    KL = new KeyLogger();

        public BaseGUI()
        {
            InitializeComponent();
        }


        private void BaseGUI_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook(); // crate an instance
            // hang on events
            actHook.KeyDown += new KeyEventHandler(GlobalKeyDown);

            if (!IS_DEBUG)
            {
                //Instantiate ConfigReader and read hotkeys.
                ConfigReader c = new ConfigReader();
                this.HotKeys = c.ReadHotKeys();


                if (HotKeys != null)
                    foreach (HotKey entry in HotKeys)
                        RegisterHotKey(Handle, entry.Id, entry.KeyModifier, entry.KeyHashCode);
            }
            else 
            {
                //todo: make sure 0 is the KeyModifier code for nothing.
                HotKey p = new HotKey(0, 0, Keys.P);    //P will be used as our debug hotkey
                RegisterHotKey(Handle, p.Id, p.KeyModifier, p.KeyHashCode);
            }
        }

        private void BaseGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IS_DEBUG)
            {
                //Instantiate ConfigWriter and write saved hotkeys.
                ConfigWriter c = new ConfigWriter();
                c.WriteConfig(this.HotKeys);

                if (HotKeys != null)
                    foreach (HotKey entry in HotKeys)
                        UnregisterHotKey(Handle, entry.Id);
            }
            else
            {
                HotKey p = new HotKey(0, 0, Keys.P);
                UnregisterHotKey(Handle, p.Id);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //HOTKEY DOWN
            if (m.Msg == Constants.WIN_MSG_HOTKEY_DOWN)
            {
                if (KL.IsListening) 
                {
                    KL.StopListening();
                    this.lblIsListening.Text = "IsListening: False";
                    this.lblIsListening.ForeColor = Color.Red;
                    this.TransmitAudio(KL.KeysPressed);
                }
                else 
                {
                    KL.StartListening();
                    this.lblIsListening.Text = "IsListening: True";
                    this.lblIsListening.ForeColor = Color.Green;
                }
                
            }
        }

        public void TransmitAudio(List<Keys> k)
        {
            //todo: transmit audio.
            if (IS_DEBUG)
            {
                this.txtDetectedKeys.Text = HelperFunc.GenerateStringFromKeys(this.KL.KeysPressed);
            }
        }



    }
}
