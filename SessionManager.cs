using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace TicTacToe
{
    internal static class SessionManager
    {
        internal static SessionType session = new SessionType() { Date = DateTime.Now.ToString() };

        internal static string sessionsFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Tic Tac Toe";
        internal static string sessionsFilePath = $@"{sessionsFolderPath}\Sessions.xml";

        private static readonly string _root = "sessions";

        private static void Initialization()
        {
            if (!Directory.Exists(sessionsFolderPath))
            {
                Directory.CreateDirectory(sessionsFolderPath);
            }

            if (!File.Exists(sessionsFilePath))
            {
                CreateXml();
            }
        }

        private static void CreateXml()
        {
            XDocument XD = new XDocument();
            XElement root = new XElement(_root);

            XD.Add(root);

            XD.Save(sessionsFilePath);
        }

        internal static void Add()
        {
            Initialization();

            XDocument XD = XDocument.Load(sessionsFilePath);

            XD.Root.Add(new XElement("session",
                new XAttribute("date", $"{DateTime.Now}"),
                new XElement("draw", session.DrawCount),
                new XElement("crossWins", session.CrossWins),
                new XElement("zeroWins", session.ZeroWins),
                new XElement("gamesPlayed", session.GamesPlayed)));

            XD.Save(sessionsFilePath);
        }

        internal static ObservableCollection<SessionType> ToList()
        {
            ObservableCollection<SessionType> sessions = new ObservableCollection<SessionType>();

            XDocument XD = XDocument.Load(sessionsFilePath);

            foreach (var xSession in XD.Elements("sessions").Elements("session"))
            {
                SessionType session = new SessionType()
                {
                    Date = xSession.Attribute("date").Value,
                    DrawCount = int.Parse(xSession.Element("draw").Value),
                    ZeroWins = int.Parse(xSession.Element("zeroWins").Value),
                    CrossWins = int.Parse(xSession.Element("crossWins").Value),
                    GamesPlayed = int.Parse(xSession.Element("gamesPlayed").Value),
                };

                sessions.Add(session);
            }

            return sessions;
        }
    }
}
