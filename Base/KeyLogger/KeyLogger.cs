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
        List<Keys> KeysPressed = new List<Keys>();

        public bool IsListening = false;
        public UInt64 ActivationTime;//TODO

        public KeyLogger() {

        }

        public void StartListening() {

        }

        public void StopListening() {

        }
    }
}
