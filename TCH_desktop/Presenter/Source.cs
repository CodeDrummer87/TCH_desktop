﻿using System.Drawing.Text;

namespace TCH_desktop.Presenter
{
    public static class Source
    {
        public static string dockerFont = @".\source\fonts\docker.ttf";
        public static string zektonFont = @".\source\fonts\zekton.ttf";

        public static Font LoadFont(string path, int size, bool isBold)
        {
            PrivateFontCollection customFont = new();
            customFont.AddFontFile(@path);

            return new Font(customFont.Families[0], size, isBold ? FontStyle.Bold : FontStyle.Regular);
        }
    }
}
