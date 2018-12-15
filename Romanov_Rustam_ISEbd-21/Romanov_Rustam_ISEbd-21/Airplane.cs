using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{

    class Airplane : Plane, IComparable<Airplane>, IEquatable<Airplane>
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

        public int CompareTo(Airplane other)
        {
            var res = (this is Plane).CompareTo(other is Plane);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (Radar != other.Radar)
            {
                return Radar.CompareTo(other.Radar);
            }
            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Airplane other)
        {
            var res = (this as Plane).Equals(other as Plane);
            if (!res)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (Radar != other.Radar)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Airplane carObj = obj as Airplane;
            if (carObj == null)
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
