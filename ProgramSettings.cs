using System;
using System.IO;
using System.Xml.Linq;

namespace TicTacToe
{
    internal static class ProgramSettings
    {
        internal static bool UseSoundManager { get; set; }
        internal static bool UseSessionManager { get; set; }
        internal static AI AI { get; set; }
        internal static bool RandomStartChoiceIsEnabled { get; set; }

        internal static void SetDefaultSettings()
        {
            AI = new AI()
            {
                IsEnabled = false,
                Difficult = 0,
                UsingSymbol = ""
            };

            RandomStartChoiceIsEnabled = false;
        }

        internal static string settingsFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Tic Tac Toe";
        internal static string settingsFilePath = $@"{settingsFolderPath}\Settings.xml";

        private static readonly string _root = "settings";

        private static void Initialization()
        {
            if (!Directory.Exists(settingsFolderPath))
            {
                Directory.CreateDirectory(settingsFolderPath);
            }

            if (!File.Exists(settingsFilePath))
            {
                CreateSettingsFile();
            }
        }

        private static void CreateSettingsFile(bool save = false)
        {
            XDocument XD = new XDocument();
            XElement root = new XElement(_root);

            root.Add(new XElement("setting",
                new XAttribute("name", $"AI"),
                new XElement("isEnabled", save == false ? false : AI.IsEnabled),
                new XElement("difficult", save == false ? 0 : AI.Difficult),
                new XElement("usingSymbol", save == false ? null : AI.UsingSymbol)));

            root.Add(new XElement("setting",
                new XAttribute("name", $"RandomStart"),
                new XElement("isEnabled", save == false ? false : RandomStartChoiceIsEnabled)));

            root.Add(new XElement("setting",
                new XAttribute("name", $"SessionManager"),
                new XElement("isEnabled", save == false ? false : UseSessionManager)));

            root.Add(new XElement("setting",
                new XAttribute("name", $"SoundManager"),
                new XElement("isEnabled", save == false ? true : UseSoundManager)));

            XD.Add(root);

            XD.Save(settingsFilePath);
        }

        internal static void Save()
        {
            CreateSettingsFile(true);
        }

        internal static void Load()
        {
            Initialization();

            XDocument XD = XDocument.Load(settingsFilePath);

            foreach (var item in XD.Elements("settings").Elements("setting"))
            {
                switch (item.Attribute("name").Value)
                {
                    case "AI":
                        AI = new AI()
                        {
                            IsEnabled = bool.Parse(item.Element("isEnabled").Value),
                            Difficult = byte.Parse(item.Element("difficult").Value),
                            UsingSymbol = item.Element("usingSymbol").Value
                        };

                        break;
                    case "RandomStart":
                        RandomStartChoiceIsEnabled = bool.Parse(item.Element("isEnabled").Value);
                        break;
                    case "SessionManager":
                        UseSessionManager = bool.Parse(item.Element("isEnabled").Value);
                        break;
                    case "SoundManager":
                        UseSoundManager = bool.Parse(item.Element("isEnabled").Value);
                        break;
                }
            }

            //UseSessionManager = XD.Root.Element("setting").Element("isEnabled").
        }
    }
}
