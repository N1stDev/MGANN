using System;

namespace MGANN
{
    // Какими буквами будет правильным тоном ?)
    internal static class VARIABLES
    {
        public static readonly string RESOURCE_PATH = Environment.CurrentDirectory;
        public static readonly string MUSIC_PATH;
        public static readonly string SPECTROGRAMS_PATH;
        public static readonly string[]? GENRES = {"", "", "", "", "", "", "", "", ""};

        static VARIABLES()
        {
            RESOURCE_PATH = RESOURCE_PATH.Substring(0, RESOURCE_PATH.Length - "bin\\Debug\\net6.0".Length) + "resources";
            MUSIC_PATH = RESOURCE_PATH + "\\music";
            SPECTROGRAMS_PATH = RESOURCE_PATH + "\\spectrograms";
            GENRES[0] = "\\classical\\";
            GENRES[1] = "\\country\\";
            GENRES[2] = "\\disco\\";
            GENRES[3] = "\\hiphop\\";
            GENRES[4] = "\\jazz\\";
            GENRES[5] = "\\metal\\";
            GENRES[6] = "\\pop\\";
            GENRES[7] = "\\reggae\\";
            GENRES[8] = "\\rock\\";
        } 
    }
}
