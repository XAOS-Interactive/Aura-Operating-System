﻿/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Desktop
* PROGRAMMER(S):    Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using System;
using System.Collections.Generic;
using System.Text;
using Aura_OS.System.GUI;
using Aura_OS.System.GUI.Graphics;
using Aura_OS.System.GUI.Imaging;

using Cosmos.HAL;

namespace Aura_OS.System.GUI.UI
{
    class Desktop
    {

        public static VbeScreen Screen = new VbeScreen();
        public static Canvas Canvas = new Canvas(800, 600);
        public static SdfFont terminus;

        static int _frames = 0;
        static int _fps = 0;
        static int _deltaT = 0;

        private static bool flag = false;

        public static int Main()
        {
            Initialize();

            while(true)
            {
                int ret = Update();
                if (ret == 1)
                {
                    break;
                }
                Render();
            }

            Final();

            return 0;
        }

        static ConsoleKeyInfo c;

        public static int Update()
        {
            c = Console.ReadKey(true);

            if (c.Key == ConsoleKey.Escape)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static void Render()
        {
        
        }

        public static void Initialize()
        {
            Console.Clear();
            Screen.SetMode(VbeScreen.ScreenSize.Size800X600, VbeScreen.Bpp.Bpp32);
            Screen.Clear(Colors.Blue);


            _deltaT = RTC.Second;

            var g = new Graphics.Graphics(Canvas);
            g.Clear(Colors.White);


            Canvas.WriteToScreen();

            terminus = new SdfFont(Fonts.Terminus.Terminus_fnt,
            Image.FromBytes(Fonts.Terminus.Terminus_ppm, "ppm"));


            g.DrawString(10, 10, "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 14f, terminus, Colors.Black);
            Canvas.WriteToScreen();
            g.DrawString(10, 25, "abcdefghijklmnopqrstuvwxyz", 14f, terminus, Colors.Black);
            Canvas.WriteToScreen();
            g.DrawString(10, 44, "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 30f, terminus, Colors.Black);
            Canvas.WriteToScreen();
            g.DrawString(10, 74, "abcdefghijklmnopqrstuvwxyz", 30f, terminus, Colors.Black);
            Canvas.WriteToScreen();
        }

        public static void Final()
        {
            Cosmos.System.Power.Reboot();
        }
    }
}
