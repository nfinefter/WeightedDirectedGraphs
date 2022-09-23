using Microsoft.VisualBasic.Devices;

using WeightedDirectedGraphs;

namespace AStarVisualizer
{
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        Graphics gfx;
        Graph<Point> graph = new Graph<Point>();
        ButtonType button;
        int startCount = 0;
        int endCount = 0;

        public Form1()
        {
            InitializeComponent();
        }
        //TO DO:
        //Redo my graph connection logic

        enum ButtonType
        {
            Start,
            End,
            Heavy,
            Wall
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(GraphVisual.Width, GraphVisual.Height);
            gfx = Graphics.FromImage(bitmap);
        }

        private void artButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GraphVisual.Width; i += 10)
            {
                for (int j = 0; j < GraphVisual.Height; j += 10)
                {
                    gfx.DrawLine(Pens.Black, new Point(i, j), new Point(GraphVisual.Width - i, GraphVisual.Height - j));
                }
            }
            GraphVisual.Image = bitmap;
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            Updater.Enabled = true;


            for (int i = 0; i < GraphVisual.Width; i += 20)
            {
                gfx.DrawLine(Pens.Black, new Point(i, 0), new Point(i, GraphVisual.Height));
            }

            for (int i = 0; i < GraphVisual.Height; i += 20)
            {
                gfx.DrawLine(Pens.Black, new Point(0, i), new Point(GraphVisual.Width, i));
            }

            GraphVisual.Image = bitmap;
        }

        private void Updater_Tick(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            int size = 19;

            if (e.Button == MouseButtons.Left)
            {
                int operation = x % (size + 1);

                if (operation != 0)
                {
                    x -= operation;
                }

                operation = y % (size + 1);

                if (operation != 0)
                {
                    y -= operation;
                }

                Point pos = new Point(x, y);


                if (button == ButtonType.Wall)
                {
                    gfx.FillRectangle(Brushes.Gray, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                }
                if (button == ButtonType.Start && startCount == 0)
                {
                    gfx.FillRectangle(Brushes.Green, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                    startCount++;
                }
                if (button == ButtonType.End && endCount == 0)
                {
                    gfx.FillRectangle(Brushes.Red, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                    endCount++;
                }
                if (button == ButtonType.Heavy)
                {
                    gfx.FillRectangle(Brushes.Orange, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                }

                GraphVisual.Image = bitmap;
            }
            if (e.Button == MouseButtons.Right)
            {
                int operation = x % (size + 1);

                if (operation != 0)
                {
                    x -= operation;
                }

                operation = y % (size + 1);

                if (operation != 0)
                {
                    y -= operation;
                }

                Point pos = new Point(x, y);

                Color color = bitmap.GetPixel(pos.X + 1, pos.Y + 1);

                if (color.G == 128)
                {
                    startCount--;
                }
                if (color.R == 255)
                {
                    endCount--;
                }

                gfx.FillRectangle(Brushes.WhiteSmoke, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                GraphVisual.Image = bitmap;
            }
            for (int X = 0; X < GraphVisual.Width; X += size)
            {
                for (int Y = 0; Y < GraphVisual.Height; Y += size)
                {
                    Vertex<Point> temp = new Vertex<Point>(new Point(x, y));
                    graph.AddVertex(temp);

                    if (x >= 0 && y >= 0)
                    {
                        Vertex<Point> prevX = graph.Search(new Point(x - size, y));
                        graph.AddEdge(prevX, temp, 1);
                        graph.AddEdge(temp, prevX, 1);

                        Vertex<Point> prevY = graph.Search(new Point(x, y - size));
                        graph.AddEdge(prevY, temp, 1);
                        graph.AddEdge(temp, prevY, 1);
                    }
                }
            }
        }

        private void StartVertexButton_Click(object sender, EventArgs e)
        {
            button = ButtonType.Start;
        }

        private void EndVertexButton_Click(object sender, EventArgs e)
        {
            button = ButtonType.End;
        }

        private void WallButton_Click(object sender, EventArgs e)
        {
            button = ButtonType.Wall;
        }

        private void HeavyVertexButton_Click(object sender, EventArgs e)
        {
            button = ButtonType.Heavy;
        }


    }
}