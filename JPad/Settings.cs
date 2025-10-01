/*======================================================================================================================================================*\
|               .%#@+                                                                       *#%.                     ..    ..                     -*--@: |
|              -##+@.                                      +##.                             @##                    -###*  *#@                   -+:   *+ |
|             -###*                                      .##%*             +##%##+   -##*   =#=                   %#++%  :##%               -%=::.   .=+=|
|            :##:                                       :#@%+          -%#*   %##.  -##%   -##.                 .##.=%  .###.             .@%+@ -+. .. -+|
|       . -=###-                                       :###*         +##.    @##.  *##@.   @#-                 :#% #=   @##.             *@#=####:  ..=* |
|      %#=--##:                        **          :*--###-         .*:     %##. .@###.   %#.                 *#+*#:   +#%            +#@=+=%%@#%:*- *+  |
|         -##*           -@####=    -####*      :###%@##%                  %##. +#%##*   @#.  .%#+   .@#+.   -#@##.  .##%           =@+##@=:=#.  -@+.@.  |
|        +##*         .%###=  ##*.%#=.-##*   . @#=  *###.  :#.            @##.:##-*##. .#%  =####=  @###@. ..###+  .@##@  :@@.        %#@*.*=%#+--=+:@   |
|       =##@%%%%%+:-. --##-   @#-..  *#%  .%#:@#: -#*:#@ +#=             *##@##*  .##%##-    -##:.##.:##.:#%:#=   %#+##-@#*          =% +%++.+@:%@ :.@-  |
|  -+%@###:      .+###*.##  +#@.     @#=##@- -#@*#=   :@@:               %###-      .-       -####-  +###*  .#@*##::###+          .:##=:=%=#@.:@..%+=#+. |
|.%@=@##+            -.  *@=-         :+-     .+:                         ..                   ..     ..      ..   @#+#%          .*###+*%#:.##%*-=@*%:  |
|                   /\                                                                                            %#% :#*      .--=###-  ..#:.#+-%#-%#:  |
|                    \\ _____________________________________________________________________                    +#@ -#%    +#%. :..  *@@.  +=:*##:+@=-  |
|      (O)[\\\\\\\\\\(O)#####################################################################>                  -##..#+    . :@=-     .  :=-.+=+%**%#@   |
|                    //                                                                                         @#:+#.      .  .      ..-*+:.. -.*@.-..  |
|                   \/                                                                                         *##@-                ..      ..::.###:    |
\*======================================================================================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace JPad
{
    public class Settings
    {
        public Settings()
        {
            ConfigFile = configFile;
        }
        public Settings(string file)
        {
            ConfigFile = file;
        }

        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        private string configFile = Path.Combine(Application.StartupPath, "JPad.conf");

        [JsonIgnore]
        public string ConfigFile
        {
            get { return configFile; }
            set
            {
                configFile = value;

                if (!File.Exists(configFile))
                {
                    File.WriteAllText(configFile, JsonSerializer.Serialize(this, jsonOptions));
                }
            }
        }


        #region Font Color
        //private string fontColorHex = "#000000";

        //public string FontColorHex
        //{
        //    get { return fontColorHex; }
        //    set
        //    {
        //        if (value.Length != 7 || !value.StartsWith('#'))
        //        {
        //            throw new Exception("Invalid color - must be hexadecimal with leading '#'");
        //        }
        //        fontColorHex = value;
        //        int r = Convert.ToInt32(value.Substring(1, 2), 16);
        //        int g = Convert.ToInt32(value.Substring(3, 2), 16);
        //        int b = Convert.ToInt32(value.Substring(5, 2), 16);
        //        fontColor = Color.FromArgb(255, r, g, b);
        //    }
        //}


        //private Color fontColor = Color.White;
        //[JsonIgnore]
        //public Color FontColor
        //{
        //    get { return fontColor; }
        //    set
        //    {
        //        fontColor = value;
        //        fontColorHex = $"#{value.R:X2}{value.G:X2}{value.B:X2}";
        //    }
        //}
        #endregion

        #region Font
        public string FontName { get; set; } = "Lucida Console";
        public float FontSize { get; set; } = 9.75f;
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;

        [JsonIgnore]
        public Font Font
        {
            get { return new Font(FontName, FontSize, FontStyle); }
            set
            {
                FontName = value.Name;
                FontSize = value.Size;
                FontStyle = value.Style;
            }
        }
        #endregion

        public bool WordWrap { get; set; } = true;
        public bool DarkMode { get; set; } = false;




        public static Settings Load(string path)
        {
            using var fs = File.OpenRead(path);
            return JsonSerializer.Deserialize<Settings>(fs, jsonOptions) ?? new Settings();
        }

        public static Settings LoadOrCreate(string path)
        {
            if (!File.Exists(path))
            {
                var s = new Settings { ConfigFile = path };
                s.Save(); // writes using jsonOptions
                return s;
            }

            try
            {
                var s = Load(path);
                s.ConfigFile = path; // keep file path tracked
                return s;
            }
            catch
            {
                //preserve the bad file and regen defaults
                try
                {
                    File.Move(path, path + ".bad", overwrite: true);
                }
                catch
                {
                    throw new Exception($"Bad configuration file - delete {path} and try again.");
                }
                var s = new Settings { ConfigFile = path };
                s.Save();
                return s;
            }
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(this, jsonOptions);
            File.WriteAllText(ConfigFile, json);
        }

        public void Reload()
        {
            CopyFrom(Load(ConfigFile));
        }

        public void CopyFrom(Settings s)
        {

            //FontColorHex = s.FontColorHex;
            WordWrap = s.WordWrap;
            DarkMode = s.DarkMode;
            FontName = s.FontName;
            FontSize = s.FontSize;
            FontStyle = s.FontStyle;
        }
    }
}
