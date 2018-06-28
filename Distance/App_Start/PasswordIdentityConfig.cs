using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Distance.App_Start
{
    public class PasswordIdentityConfig
    {   
        //settings for UI
        public static int REQUIREDLENGTH { get; } = 6;
        public static bool REQUIREDIGIT { get; } = true;
        public static bool REQUIRELOWERCASE { get; } = true;
        public static bool REQUIREUPPERCASE { get; } = true;
        public static bool REQUIRENONLETTERORDIGIT { get; } = true;

        //settings for IdentityConfig
        public static bool REQUIREDIGITIDENTITY { get; } = false;
        public static bool REQUIRELOWERCASEIDENTITY { get; } = false;
        public static bool REQUIREUPPERCASEIDENTITY { get; } = false;
        public static bool REQUIRENONLETTERORDIGITIDENTITY { get; } = false;
    }
}