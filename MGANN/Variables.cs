using System;

namespace MGANN
{
    // Какими буквами будет правильным тоном ?)
    internal static class VARIABLES
    {
        public static readonly int XSIZE = 51;
        public static readonly int YSIZE = 362;
        public static readonly string RESOURCE_PATH = Environment.CurrentDirectory;
        public static readonly string MUSIC_PATH;
        public static readonly string SPECTROGRAMS_PATH;
        public static readonly string[]? GENRES = {"", "", "", "", "", "", "", "", "", ""};

        static VARIABLES()
        {
            RESOURCE_PATH = RESOURCE_PATH.Substring(0, RESOURCE_PATH.Length - "bin\\Debug\\net6.0".Length) + "resources";
            MUSIC_PATH = RESOURCE_PATH + "\\music";
            SPECTROGRAMS_PATH = RESOURCE_PATH + "\\spectrograms";
            GENRES[0] = "\\blues\\";
            GENRES[1] = "\\classical\\";
            GENRES[2] = "\\country\\";
            GENRES[3] = "\\disco\\";
            GENRES[4] = "\\hiphop\\";
            GENRES[5] = "\\jazz\\";
            GENRES[6] = "\\metal\\";
            GENRES[7] = "\\pop\\";
            GENRES[8] = "\\reggae\\";
            GENRES[9] = "\\rock\\";
        } 
    }
}
