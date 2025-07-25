using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public class FairyWindow : GComponent
    {
        protected GButton btnHide;
        protected GButton btnBack;
        protected GObject cont;
        protected GObject bg;

        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            btnBack = GetChild("btnBack") as GButton;
            btnHide = GetChild("btnHide") as GButton;
            cont = GetChild("cont");
            bg = GetChild("bg");

            btnBack?.onClick.Add(Dispose);
            bg?.onClick.Add(Dispose);
            btnHide?.onClick.Add(Hide);
        }

        protected void Hide()
        {
            if (btnBack != null) btnBack.visible = !btnBack.visible;
            if (cont != null) cont!.visible = !cont.visible;
        }
    }
}
