﻿using System;
using System.Collections.Generic;
using System.Text;
using Foster.Framework;

namespace Foster.GuiSystem
{
    public class GuiPanel
    {

        public readonly Gui Gui;
        public readonly int ID = Guid.NewGuid().GetHashCode();

        public string Title = "";
        public Action<Imgui>? OnRefresh;

        internal GuiDockNode? Node;

        public GuiPanel(Gui gui, string title)
        {
            Gui = gui;
            Title = title;
        }

        public void Popout()
        {
            Node?.PopoutPanel(this);
        }

        public void Close()
        {
            Node?.RemovePanel(this);
        }

        public void DockWith(GuiPanel? panel) => Dock(panel, GuiDockNode.Placings.Center);
        public void DockLeftOf(GuiPanel? panel) => Dock(panel, GuiDockNode.Placings.Left);
        public void DockRightOf(GuiPanel? panel) => Dock(panel, GuiDockNode.Placings.Right);
        public void DockBottomOf(GuiPanel? panel) => Dock(panel, GuiDockNode.Placings.Bottom);
        public void DockTopOf(GuiPanel? panel) => Dock(panel, GuiDockNode.Placings.Top);

        private void Dock(GuiPanel? panel, GuiDockNode.Placings placing)
        {
            Node?.RemovePanel(this);

            var node = panel?.Node;
            if (node == null)
                node = Gui.Manager.Root;

            node.InsertPanel(placing, this);
        }

    }
}
