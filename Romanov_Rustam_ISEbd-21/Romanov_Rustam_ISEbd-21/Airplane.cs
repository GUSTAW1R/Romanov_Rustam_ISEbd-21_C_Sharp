using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{
    
    class Airplane
    {
        private int _startPosX;
        private int _startPosY;
        private int _pictureWidth;
        private int _pictureHeight;
        private const int AirplaneWidth = 100;
        private const int AirplaneHeight = 60;
        public int MaxSpeed { private set; get; }
        public float MaxWeight { private set; get; }
        public Color MainColor { private set; get; }
        public Color SecondColor { private set; get; }
        private int P1, P2, P3, P4, P5, P6;

        public Airplane(int maxSpeed, float weight, Color mainColor, Color secondColor)
        {
            MaxSpeed = maxSpeed;
            MaxWeight = weight;
            MainColor = MainColor;
            SecondColor = secondColor;
        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public void MoveAirplane(Direction direction)
        {
            int step = MaxSpeed;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - AirplaneWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - AirplaneHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public void DrawAirplane(Graphics G)
        {
            Brush B_fon = new SolidBrush(Color.AliceBlue);
            G.FillRectangle(B_fon, 0, 0, 1920, 1080);
            Pen P = new Pen(Color.Black, 2);
            Brush B_T_Gray = new SolidBrush(Color.SlateGray);
            Brush B_S_Gray = new SolidBrush(Color.Gray);
            Brush B_Black = new SolidBrush(Color.Black);
            Brush B_blue = new SolidBrush(Color.Blue);
            Point point1 = new Point(_startPosX, _startPosY);
            Point point2 = new Point(_startPosX - 30, _startPosY + 10);
            Point point3 = new Point(_startPosX + 10, _startPosY + 40);
            Point point4 = new Point(_startPosX + 120, _startPosY + 40);
            Point point5 = new Point(_startPosX + 130, _startPosY + 30);
            Point point6 = new Point(_startPosX + 130, _startPosY + 10);
            Point point7 = new Point(_startPosX + 120, _startPosY);
            Point point8 = new Point(_startPosX - 20, _startPosY - 30);
            Point point9 = new Point(_startPosX, _startPosY - 30);
            Point point10 = new Point(_startPosX + 20, _startPosY);
            Point point11 = new Point(_startPosX + 40, _startPosY);
            Point point12 = new Point(_startPosX + 20, _startPosY + 30);
            Point point13 = new Point(_startPosX + 50, _startPosY + 30);
            Point point14 = new Point(_startPosX + 90, _startPosY);
            Point point15 = new Point(_startPosX + 100, _startPosY);
            Point point16 = new Point(_startPosX + 100, _startPosY + 10);

            Point[] Nabor1 = { point1, point2, point3, point4, point5, point6, point7 };
            Point[] Nabor2 = { point1, point8, point9, point10 };
            Point[] Nabor3 = { point11, point12, point13, point14 };
            Point[] Nabor4 = { point15, point16, point6, point7 };
            Point[] Obshii_nabor = { point1, point2, point3, point4, point5, point6, point7, point1, point8, point9, point10, point11, point12, point13, point14, point15, point16 };
            G.FillPolygon(B_S_Gray, Nabor1);
            G.FillRectangle(B_Black, _startPosX + 60, _startPosY + 10, 20, 10);
            G.FillRectangle(B_Black, _startPosX + 40, _startPosY + 20, 20, 10);
            G.FillRectangle(B_S_Gray, _startPosX + 50, _startPosY - 10, 10, 10);
            G.FillEllipse(B_Black, _startPosX + 20, _startPosY + 40, 10, 10);
            G.FillEllipse(B_Black, _startPosX + 30, _startPosY + 40, 10, 10);
            G.FillEllipse(B_Black, _startPosX + 40, _startPosY + 40, 10, 10);
            G.FillEllipse(B_Black, _startPosX + 50, _startPosY + 40, 10, 10);
            G.FillEllipse(B_Black, _startPosX + 90, _startPosY + 40, 10, 10);
            G.FillPolygon(B_T_Gray, Nabor2);
            G.FillPolygon(B_T_Gray, Nabor3);
            G.FillPolygon(B_blue, Nabor4);
            G.DrawLines(P, Obshii_nabor);
            G.DrawLine(P, _startPosX + 40, _startPosY - 10, _startPosX + 70, _startPosY - 10);
            G.DrawLine(P, _startPosX - 30, _startPosY - 30, _startPosX + 10, _startPosY - 30);

        }
    }
}
