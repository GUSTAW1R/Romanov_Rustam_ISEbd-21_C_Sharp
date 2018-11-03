using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Romanov_Rustam_ISEbd_21
{
    public partial class FormPlane : Form
    {
        private ITransport plane;

        public FormPlane()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Graphics G = Graphics.FromImage(bmp);
            plane.DrawAirplane(G);
            pictureBoxAirplane.Image = bmp;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new Airplane(50, 10, Color.Gray, Color.Blue, true);
            plane.SetPosition(200, 200, pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Draw();
        }
        private void buttonCreatePlane_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            plane = new Plane(50, 10, Color.Gray);
            plane.SetPosition(200, 200, pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    plane.MoveAirplane(Direction.Up);
                    break;
                case "buttonDown":
                    plane.MoveAirplane(Direction.Down);
                    break;
                case "buttonLeft":
                    plane.MoveAirplane(Direction.Left);
                    break;
                case "buttonRight":
                    plane.MoveAirplane(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
