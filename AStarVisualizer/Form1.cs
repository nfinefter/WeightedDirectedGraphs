namespace AStarVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            button1.Location = new Point(button1.Location.X + 100, button1.Location.Y);        
        }

        public void DoStuff(object? joe, EventArgs idc)
        {
            Location = new Point(1000, -50);
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
        }
    }
}