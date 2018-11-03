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
        private Airplane airplane;

        public FormPlane()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Graphics G = Graphics.FromImage(bmp);
            airplane.DrawAirplane(G);
            pictureBoxAirplane.Image = bmp;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            airplane = new Airplane(50, 10, Color.Gray, Color.Black);
            airplane.SetPosition(200, 200, pictureBoxAirplane.Width, pictureBoxAirplane.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    airplane.MoveAirplane(Direction.Up);
                    break;
                case "buttonDown":
                    airplane.MoveAirplane(Direction.Down);
                    break;
                case "buttonLeft":
                    airplane.MoveAirplane(Direction.Left);
                    break;
                case "buttonRight":
                    airplane.MoveAirplane(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
