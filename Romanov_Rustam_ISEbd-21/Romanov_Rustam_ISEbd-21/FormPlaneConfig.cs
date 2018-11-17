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
    public partial class FormPlaneConfig : Form
    {
        ITransport plane = null;

        private event planeDelegate eventAddPlane;

        public FormPlaneConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelFuchsia.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            panelFiolet.MouseDown += panelColor_MouseDown;
            panelCyan.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void DrawPlane()
        {
            if (plane != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
                Graphics gr = Graphics.FromImage(bmp);
                plane.SetPosition(35, 30, pictureBoxPlane.Width, pictureBoxPlane.Height);
                plane.DrawAirplane(gr);
                pictureBoxPlane.Image = bmp;
            }
        }

        public void AddEvent(planeDelegate ev)
        {
            if (eventAddPlane == null)
            {
                eventAddPlane = new planeDelegate(ev);
            }
            else
            {
                eventAddPlane += ev;
            }
        }

        private void labelPlane_MouseDown(object sender, MouseEventArgs e)
        {
            labelPlane.DoDragDrop(labelPlane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelRadar_Plane_MouseDown(object sender, MouseEventArgs e)
        {
            labelRadar_Plane.DoDragDrop(labelRadar_Plane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void panelPlane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (plane != null)
            {
                plane.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawPlane();
            }
        }
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (plane != null)
            {
                if (plane is Airplane)
                {
                    (plane as Airplane).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawPlane();
                }
            }
        }

        private void panelPlane_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Plane":
                    plane = new Plane(100, 500, Color.White);
                    break;
                case "Radar Plane":
                    plane = new Airplane(100, 500, Color.White, Color.Black, true);
                    break;
            }
            DrawPlane();
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddPlane?.Invoke(plane);
            Close();
        }
    }
}
