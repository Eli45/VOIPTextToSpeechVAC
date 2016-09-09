using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOIPTextToSpeechVAC.Base.KeyLogger
{
    class KeyLogger
    {
        public List<Keys> KeysPressed = new List<Keys>();

        public bool IsListening = false;
        public UInt64 ActivationTime;//TODO

        public KeyLogger() 
        {

        }

        public void StartListening() 
        {
            this.IsListening = true;
        }

        public void StopListening()
        {
            this.IsListening = false;
        }

        public void AddKey(Keys k)
        {
            this.KeysPressed.Add(k);
        }

        public void ResetKeys()
        {
            this.KeysPressed = new List<Keys>();
        }
    }
}
