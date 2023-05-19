using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Linq;

namespace TicTacToe
{
    internal static class SessionManager
    {
        internal static SessionType session = new SessionType() { Date = DateTime.Now.ToString() };

<<<<<<< HEAD
        internal static readonly string sessionsFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Tic Tac Toe";
        internal static readonly string sessionsFilePath = $@"{sessionsFolderPath}\Sessions.xml";
=======
        internal static string sessionsFolderPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Tic Tac Toe";
        internal static string sessionsFilePath = $@"{sessionsFolderPath}\Sessions.xml";
>>>>>>> 1f22c8cf7b34d47147c2aefe5352579b05c74f33

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

        internal static void LoadOldSession(SessionType oldSession)
        {
            session = new SessionType
            {
                Date = DateTime.Now.ToString(),
                CrossWins = oldSession.CrossWins,
                ZeroWins = oldSession.ZeroWins,
                DrawCount = oldSession.DrawCount,
                GamesPlayed = oldSession.GamesPlayed
            };
        }

        internal static void Delete(SessionType session)
        {
            var sessionsList = ToList();

            sessionsList.Remove(sessionsList.Single(d => d.Date.Equals(session.Date)));

            CreateXml();

            XDocument XD = XDocument.Load(sessionsFilePath);

            foreach (var s in sessionsList)
            {
                XD.Root.Add(new XElement("session",
                    new XAttribute("date", $"{s.Date}"),
                    new XElement("draw", s.DrawCount),
                    new XElement("crossWins", s.CrossWins),
                    new XElement("zeroWins", s.ZeroWins),
                    new XElement("gamesPlayed", s.GamesPlayed)));
            }

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
<<<<<<< HEAD
            Initialization();

=======
>>>>>>> 1f22c8cf7b34d47147c2aefe5352579b05c74f33
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
