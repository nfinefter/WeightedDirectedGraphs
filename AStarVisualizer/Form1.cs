using Heap_Tree;

using Microsoft.VisualBasic.Devices;
using System.Transactions;
using WeightedDirectedGraphs;

namespace AStarVisualizer
{
    public partial class Form1 : Form
    {
        static Vertex<Point> ChonkyVert;

        Bitmap bitmap;
        Graphics gfx;
        Graph<Point> graph = new Graph<Point>();
        VertexType selectedType;
        int startCount = 0;
        int endCount = 0;
        int size = 19;
        Vertex<Point> Start;
        Vertex<Point> End;
        List<Vertex<Point>> path = new List<Vertex<Point>>();
        List<AStarInfo> data;
        int TraversalCount = 0;
        int graphWidth = 20;
        int graphHeight = 20;
        int Count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        enum VertexType
        {
            Start,
            End,
            Heavy,
            Wall
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Ignores the whole right and bottom row/column
            HeuristicDropDown.SelectedIndex = 0;
            graphWidth += GraphVisual.Width;
            graphHeight += GraphVisual.Height;

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
            startButton.Enabled = false;

            gfx.Clear(Color.WhiteSmoke);

            for (int i = 0; i < graphWidth; i += size+1)
            {
                gfx.DrawLine(Pens.Black, new Point(i, 0), new Point(i, graphHeight));
            }

            for (int i = 0; i < graphHeight; i += size+1)
            {
                gfx.DrawLine(Pens.Black, new Point(0, i), new Point(graphWidth, i));
            }

            //4 Connections
            for (int X = 0; X < graphWidth - size *2; X += size)
            {
                for (int Y = 0; Y < graphHeight - size *2; Y += size)
                {
                    graph.AddVertex(new Vertex<Point>(new Point(X, Y)));
                    AddEdges(new Point(X, Y), size);
                }
            }

            GraphVisual.Image = bitmap;
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            if (Count < data.Count)
            {
                Brush brush = Brushes.Wheat;

                Point pos = data[Count].pos;

                pos = new Point(pos.X * 20 / 19, pos.Y * 20 / 19);

               // DataToPoint(ref pos);

                switch (data[Count].color)
                {
                    case ColorToBrush.Queued:
                        {
                            brush = Brushes.Green;
                            break;
                        }
                    case ColorToBrush.Visited:
                        {
                            brush = Brushes.Blue;
                            break;
                        }
                    case ColorToBrush.FinalPath:
                        {
                            brush = Brushes.Yellow;
                            break;
                        }

                }

                gfx.FillRectangle(brush, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                Count++;
            }

            GraphVisual.Image = bitmap;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (e.Button == MouseButtons.Left)
            {
                Point pos = new Point(x, y);
                DataToPoint(ref pos);

                Color color = bitmap.GetPixel(pos.X + 1, pos.Y + 1);

                if (color.ToArgb() == Color.WhiteSmoke.ToArgb())
                {

                    if (selectedType == VertexType.Wall)
                    {
                        gfx.FillRectangle(Brushes.Gray, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                        PointToData(ref pos);
                        RemoveEdges(pos);

                        Vertex<Point> vertex = new Vertex<Point>(pos);

                        //graph.RemoveVertex(vertex);
                    }
                    if (selectedType == VertexType.Start && startCount == 0)
                    {
                        gfx.FillRectangle(Brushes.Green, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                        PointToData(ref pos);

                        Start = new Vertex<Point>(new Point(pos.X, pos.Y));
                        startCount++;
                    }
                    if (selectedType == VertexType.End && endCount == 0)
                    {
                        gfx.FillRectangle(Brushes.Red, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                        PointToData(ref pos);

                        End = new Vertex<Point>(new Point(pos.X, pos.Y));
                        endCount++;
                    }
                    if (selectedType == VertexType.Heavy)
                    {
                        gfx.FillRectangle(Brushes.Orange, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

                        PointToData(ref pos);
                        RemoveEdges(pos);
                        AddEdges(pos, (size * 20));
                        ChonkyVert = graph.Search(pos);
                    }
                }

                GraphVisual.Image = bitmap;
            }

            if (e.Button == MouseButtons.Right)
            {

                Point pos = new Point(x, y);
                
                DataToPoint(ref pos);

                Color color = bitmap.GetPixel(pos.X + 1, pos.Y + 1);

                gfx.FillRectangle(Brushes.WhiteSmoke, new Rectangle(new Point(pos.X + 1, pos.Y + 1), new Size(size, size)));

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
                    PointToData(ref pos);
                    RemoveEdges(pos);
                    AddEdges(pos, size);
                }
                if (color.ToArgb() == Color.Gray.ToArgb())
                {
                    PointToData(ref pos);
                    RemoveEdges(pos);
                    AddEdges(pos, size);

                    Vertex<Point> vertex = new Vertex<Point>(pos);

                    graph.AddVertex(vertex);
                }

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
            if (Start == null || End == null) return;

            Heap<Vertex<Point>> queue = new Heap<Vertex<Point>>(0);
            Vertex<Point> vertex = new Vertex<Point>(new Point(0, 0));

            int heuristicsChoice = HeuristicDropDown.SelectedIndex;


            PathFinding.Result result = PathFinding.AStar(out data, out path, graph, Start.Value, End.Value, PathFinding.Heuristics((HeuristicsChoices)heuristicsChoice));

            if (result == PathFinding.Result.Found)
            {
                Updater.Enabled = true;
            }
        }
        private void PointToData(ref Point pos)
        {
            if (pos.X <= 380)
            {
                pos.X = pos.X - (pos.X % (size));
            }
            else
            {
                pos.X = pos.X - (pos.X % (size)) + size;
            }
            if (pos.Y <= 380)
            {
                pos.Y = pos.Y - (pos.Y % (size));
            }
            else
            {
                pos.Y = pos.Y - (pos.Y % (size)) + size;
            }



        }
        private void DataToPoint(ref Point pos)
        {
            int operation = pos.X % (size + 1);

            if (operation != 0)
            {
                pos.X -= operation;
            }

            operation = pos.Y % (size + 1);

            if (operation != 0)
            {
                pos.Y -= operation;
            }
        }

    }
}