using System;

namespace MGANN
{
    public static class VARIABLES
    {
        public enum GENRES_ENUM
        {
            Блюз,
            Классическсая,
            Кантри,
            Диско,
            ХипХоп,
            Джаз,
            Метал,
            Поп,
            Рэгги,
            Рок
        }

        public static readonly int XSIZE = 51;
        public static readonly int YSIZE = 362;
        public static readonly int SIZE = 200;
        public static readonly string RESOURCE_PATH = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + $"\\MGANN\\resources";
        public static readonly string MUSIC_PATH;
        public static readonly string SPECTROGRAMS_PATH;
        public static readonly string NETWORK_DATA_PATH = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + $"\\MGANN\\networkData";
        public static readonly string[] GENRES = {"", "", "", "", "", "", "", "", "", ""};
        public static readonly int EnoughAccuracy = 50;

        static VARIABLES()
        {
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
