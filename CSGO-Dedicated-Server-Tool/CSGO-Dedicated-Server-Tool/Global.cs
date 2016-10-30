using System.Collections.Generic;
using System.Diagnostics;

namespace CSGO_Dedicated_Server_Tool
{
    static class Global
    {
        public static string _SERVER_NAME = "srcds.exe";

        // Directories
        public static string _SERVER_INSTALL_DIR = "";
        public static string _SERVER_LOG_DIR = "";
        public static string _SERVER_CRASH_LOG_DIR = "";
        public static string _SERVER_SAVED_LOG_DIR = "";

        // Version
        public static string _APPLICATION_VERSION = "1.0";

        // Server
        public static int _CURRENT_SERVER_INDEX = 0;
        public static List<string> _SERVER_LIST = new List<string>();


        // Process
        public static bool _isProcNotRunningAllowed = true;             // This is used to see if the program crashed or if it was shut down manually
        public static Process _proc = null;                             // SRCDS Process
        public static List<string> _procArgs = new List<string>();      // SRCDS Arguments
        public static string[] _defaultProcArgs = { "-game csgo", "-console", "-condebug", "-usercon", "+net_port_try 1", "+exec server.cfg", "-stringtables" };

        // Forms
        public static CommandLineArgs cmdLineForm;
        public static Settings _settingsForm;

        // Classes
        public static Config _cfg;
    }
}
