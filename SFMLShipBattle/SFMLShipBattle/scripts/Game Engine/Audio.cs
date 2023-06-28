using AgarIO.scripts.GameEngine;
using SFML.Audio;

namespace AgarIO.scripts.GameEngine
{
    public class Audio
    {
        private static Audio? _instance;
        public static Audio Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new();

                return _instance;
            }
        }

        private Dictionary<string, Sound> sounds = new();

        public void InnitFiles()
        {
            string path = Game.PathToProject + "/Audio";

            string[] fileNames = Directory.GetFiles(path);

            foreach (var fileName in fileNames)
            {
                Sound sound = new (new SoundBuffer(fileName));
                sounds.Add(fileName.Replace($"{path}/", ""), sound);
            }
        }

        public Sound? PlaySound(string soundName, float volume = 1f, float pitch = 1f, bool loop = false)
        {
            soundName += ".wav";

            if (!sounds.ContainsKey(soundName))
                return null;

            var sound = sounds[soundName];

            sound.Volume = volume;
            sound.Pitch = pitch;
            sound.Loop = loop;

            sound.Play();

            return sound;
        }
    }


}