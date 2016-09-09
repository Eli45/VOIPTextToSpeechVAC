using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VOIPTextToSpeechVAC.Base.HotKey;
using VOIPTextToSpeechVAC.Base.Helper;
using VOIPTextToSpeechVAC.Base.Constants;

namespace VOIPTextToSpeechVAC.Base.ConfigWriter
{
    //TODO
    //Config structure
    /*[VOIPTextToSpeechVAC Config Data]
     *Hotkey: {MOD, KEY}
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */



    class ConfigWriter
    {
        public void WriteConfig(List<HotKey.HotKey> HotKeys)
        {
            string programExePathFolder = HelperFunc.GetExeDirectory();

            StreamWriter sw = new StreamWriter(programExePathFolder + Constants.Constants.APP_CONFIG_LOCATION);
            try
            {
               

                if (HotKeys != null)
                    foreach (HotKey.HotKey entry in HotKeys)
                    {
                        //TODO:
                        //sw.Write("Hotkey{ ");
                        //sw.Write(entry.Key.id + " " + entry.Key.keyModifier + " " + entry.Key.key);
                        //sw.Write(" " + entry.Value.ToAbsoluteString());
                        //sw.Write(" }\n");
                    }
            }
            catch (Exception e)
            {
                //if (e is IOException)
                //    FileLogger.Log("Could not read CFG file: " + e.Message, LogOptions.DISPLAY_ERROR);
                //else
                //    FileLogger.Log("Unknown exception caught while reading config file: " + e.Message, LogOptions.SHOULD_THROW);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
