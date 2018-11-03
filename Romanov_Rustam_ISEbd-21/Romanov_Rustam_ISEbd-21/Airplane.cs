using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{

    class Airplane : Plane
    {
        public bool Radar { private set; get; }
        public Color DopColor { private set; get; }

        public Airplane(int maxSpeed, int weight, Color mainColor, Color secondColor, bool radar) : base(maxSpeed, weight, mainColor)
        {
            Radar = radar;
            DopColor = secondColor;
        }

        public override void DrawAirplane(Graphics G)
        {
            base.DrawAirplane(G);
            if (Radar)
            {
                Brush B_S_Gray = new SolidBrush(Color.Gray);
                Brush Color_Radar = new SolidBrush(DopColor);
                G.FillRectangle(Color_Radar, _startPosX + 50, _startPosY - 10, 10, 10);
                Pen P = new Pen(Color.Black, 2);
                G.DrawLine(P, _startPosX + 40, _startPosY - 10, _startPosX + 70, _startPosY - 10);
            }
        }
    }
}
