using Microsoft.VisualBasic.Devices;
using System.Transactions;
using WeightedDirectedGraphs;

namespace AStarVisualizer
{
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        Graphics gfx;
        Graph<Point> graph = new Graph<Point>();
        VertexType selectedType;
        int startCount = 0;
        int endCount = 0;
        int size = 19;
        Vertex<Point> Start;
        Vertex<Point> End;
        public Form1()
        {
            InitializeComponent();
        }

        //TO DO:
        //Do AStar with timer
        enum VertexType
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
            gfx.Clear(Color.WhiteSmoke);

            for (int i = 0; i < GraphVisual.Width; i += 20)
            {
                gfx.DrawLine(Pens.Black, new Point(i, 0), new Point(i, GraphVisual.Height));
            }

            for (int i = 0; i < GraphVisual.Height; i += 20)
            {
                gfx.DrawLine(Pens.Black, new Point(0, i), new Point(GraphVisual.Width, i));
            }

            for (int X = 0; X < GraphVisual.Width; X += size)
            {
                for (int Y = 0; Y < GraphVisual.Height; Y += size)
                {
                    AddEdges(new Point(X, Y), 1);
                }
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
             
                Color color = bitmap.GetPixel(pos.X + 1, pos.Y + 1);

                if (color.ToArgb() == Color.WhiteSmoke.ToArgb())
                {

                    if (selectedType == VertexType.Wall)
                    {
                        gfx.FillRectangle(Brushes.Gray, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                         RemoveEdges(pos);
                    }
                    if (selectedType == VertexType.Start && startCount == 0)
                    {
                        gfx.FillRectangle(Brushes.Green, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                        Start = new Vertex<Point>(pos);
                        startCount++;
                    }
                    if (selectedType == VertexType.End && endCount == 0)
                    {
                        gfx.FillRectangle(Brushes.Red, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
                        End = new Vertex<Point>(pos);
                        endCount++;
                    }
                    if (selectedType == VertexType.Heavy)
                    {
                        gfx.FillRectangle(Brushes.Orange, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));
              
                        RemoveEdges(pos);
                        AddEdges(pos, 5);
                    }
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

                if (color.ToArgb() == Color.Green.ToArgb())
                {
                    startCount--;
                }
                if (color.ToArgb() == Color.Red.ToArgb())
                {
                    endCount--;
                }
                if (color.ToArgb() == Color.Orange.ToArgb())
                {
                    RemoveEdges(pos);
                    AddEdges(pos, 1);
                }

                gfx.FillRectangle(Brushes.WhiteSmoke, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                GraphVisual.Image = bitmap;
            }
           
        }
        private void RemoveEdges(Point pos)
        {
            Vertex<Point> temp = graph.Search(pos);

             Vertex<Point> prevX = graph.Search(new Point(pos.X - size, pos.Y));
             graph.RemoveEdge(prevX, temp);
             graph.RemoveEdge(temp, prevX);

             prevX = graph.Search(new Point(pos.X + size, pos.Y));
             graph.RemoveEdge(prevX, temp);
             graph.RemoveEdge(temp, prevX);

             Vertex<Point> prevY = graph.Search(new Point(pos.X, pos.Y - size));
             graph.RemoveEdge(prevY, temp);
             graph.RemoveEdge(temp, prevY);

             prevY = graph.Search(new Point(pos.X, pos.Y + size));
             graph.RemoveEdge(prevY, temp);
             graph.RemoveEdge(temp, prevY);

        }
        private void AddEdges(Point pos, int weight)
        {
             Vertex<Point> temp = graph.Search(pos);

                    Vertex<Point> prevX = graph.Search(new Point(pos.X - size, pos.Y));
                    graph.AddEdge(prevX, temp, weight);
                    graph.AddEdge(temp, prevX, weight);

                    prevX = graph.Search(new Point(pos.X + size, pos.Y));
                    graph.AddEdge(prevX, temp, weight);
                    graph.AddEdge(temp, prevX, weight);

                    Vertex<Point> prevY = graph.Search(new Point(pos.X, pos.Y - size));
                    graph.AddEdge(prevY, temp, weight);
                    graph.AddEdge(temp, prevY, weight);

                    prevY = graph.Search(new Point(pos.X, pos.Y + size));
                    graph.AddEdge(prevY, temp, weight);
                    graph.AddEdge(temp, prevY, weight);
        }
        private void StartVertexButton_Click(object sender, EventArgs e)
        {
            selectedType = VertexType.Start;
        }
        private void EndVertexButton_Click(object sender, EventArgs e)
        {
            selectedType = VertexType.End;
        }
        private void WallButton_Click(object sender, EventArgs e)
        {
            selectedType = VertexType.Wall;
        }
        private void HeavyVertexButton_Click(object sender, EventArgs e)
        {
            selectedType = VertexType.Heavy;
        }
        private void BeginButton_Click(object sender, EventArgs e)
        {
            Updater.Enabled = true;

            if (Start == null || End == null) return;
            
            AStarInfo aStar = new AStarInfo(Start, End);
            
        }
    }
}