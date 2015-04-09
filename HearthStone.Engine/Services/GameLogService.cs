using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HearthStone.Engine.Services
{
    public static class GameLogService
    {
        public delegate void LogHandler(string text);

        public static event LogHandler Log;

        public static void AddLog(string text)
        {
            if (Log != null)
            {
                Log(text);
            }
        }
    }
}
