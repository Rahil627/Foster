﻿using Foster.Framework;
using Foster.GuiSystem;
using Foster.GLFW;
using Foster.SDL2;
using Foster.OpenGL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Test1
{
    internal class Program
    {
        
        private static void Main()
        {
            App.Modules.Register<GLFW_System>();
            App.Modules.Register<GLFW_Input>();
            App.Modules.Register<GL_Graphics>();

            App.Start(Ready);
        }

        private static void Ready()
        {
            var font = new SpriteFont(Path.Combine(App.System.AppDirectory, "SourceSansPro-SemiBold.ttf"), 64, Charsets.ASCII);
            var gui = App.Modules.Register(new Gui(font, "Gui", 1280, 720));

            var strs = new string[]
            {
                "Scene",
                "Inspector",
                "Assets",
                "Game",
                "Log"
            };

            for (int i = 0; i < 5; i++)
            {
                var n = i;
                var panel = gui.CreatePanel(strs[i], new Rect(32, 32, 400, 400));
                panel.OnRefresh = (imgui) =>
                {
                    imgui.Row(2);
                    if (imgui.WideButton("SIZE DOWN [-]"))
                        gui.ContentScale -= Vector2.One * 0.1f;
                    if (imgui.WideButton("SIZE UP [+]"))
                        gui.ContentScale += Vector2.One * 0.1f;

                    for (int k = 0; k < n + 1; k++)
                    {
                        imgui.Label($"a nice label #{k + 1}!");

                        for (int j = 0; j < 4; j++)
                            if (imgui.Button($"What {k * 4 + j}"))
                                Console.WriteLine("PRESSED " + j);
                    }
                };
            }
        }

    }
}
