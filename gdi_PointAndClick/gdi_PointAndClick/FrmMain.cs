using System.Collections.Generic; // benötigt für Listen

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        Random rnd = new Random();


        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            // Hilfsvarablen
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            // Zeichenmittel


            for (int i = 0; i < rectangles.Count; i++)
            {
                Color rndFarbe = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Brush b = new SolidBrush(rndFarbe);

                g.FillRectangle(b, rectangles[i]);
            }

        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            bool klickaufrec = false;

            Point mausposition = e.Location;

            int recGroese = rnd.Next(100);

            Rectangle r = new Rectangle(mausposition.X - recGroese / 2, mausposition.Y - recGroese / 2, recGroese, recGroese);


            foreach (var rectangle in rectangles)
            {
                if (rectangle.Contains(mausposition))
                {
                    klickaufrec = true;
                    break;
                }
            }

            if (!klickaufrec)
            {
                Color rndFarbe = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                rectangles.Add(r);

                //using (Brush b = new SolidBrush(rndFarbe))
                //{
                //    using (Graphics g = CreateGraphics())
                //    {
                //        g.FillRectangle(b, r);
                //    }
                //}
            }

            Refresh();
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}