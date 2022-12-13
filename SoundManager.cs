using System.Media;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class SoundManager
    {
        public static SoundPlayer Player { get; set; }

        public static async void Play(string soundName)
        {
            await Task.Run(() =>
            {
                if (ProgramSettings.UseSoundManager == false)
                {
                    return;
                }

                switch (soundName)
                {
                    case "╳":
                        Player = new SoundPlayer(Properties.Resources.Cross_Step_1);
                        break;
                    case "◯":
                        Player = new SoundPlayer(Properties.Resources.Zero_Step_1);
                        break;
                    case "end":
                        Player = new SoundPlayer(Properties.Resources.Game_End_1);
                        break;
                    case "button":
                        Player = new SoundPlayer(Properties.Resources.Button_Click_Sound_1);
                        break;
                }

                Player.Play();
            });
        }
    }
}
