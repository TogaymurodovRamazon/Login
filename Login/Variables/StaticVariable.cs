using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Variables
{
    public static class StaticVariable
    {
        public static string DatabaseName { get; set; } = "robotics_posdb.db";
        public static string CurrentUserName { get; set; } = "";
    }
}
