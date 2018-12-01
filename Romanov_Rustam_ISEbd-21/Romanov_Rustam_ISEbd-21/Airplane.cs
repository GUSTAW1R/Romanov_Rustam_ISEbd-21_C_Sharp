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
        public Airplane(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 5)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Radar = Convert.ToBoolean(strs[4]);
            }
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
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + Radar;
        }
    }
}
