using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romanov_Rustam_ISEbd_21
{
    public abstract class Vehicle : ITransport
    {
        protected int _startPosX;

        protected int _startPosY;

        protected int _pictureWidth;
        ///Высота окна отрисовки
        protected int _pictureHeight;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { protected set; get; }
        /// <summary>
        /// Вес самолёта
        /// </summary>
        public int Weight { protected set; get; }
        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color MainColor { protected set; get; }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void SetMainColor(Color color)
        {
            MainColor = color;
        }
        public abstract void DrawAirplane(Graphics g);
        public abstract void MoveAirplane(Direction direction);
    }
}
