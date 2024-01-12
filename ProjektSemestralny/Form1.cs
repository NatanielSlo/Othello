namespace ProjektSemestralny
{
    public partial class Form1 : Form
    {
        int currentuser = 1;

        Board board = new Board();
        Sztokryba ai = new Sztokryba();
        public Form1()
        {
            InitializeComponent();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            board.Draw(g);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (board.Move(e.X, e.Y) == true)
            {
                timer1.Start();
                pictureBox1.Invalidate();
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.WaitCursor;
            //movie ai
            board.moveai(ai.CalculateBasicMove(board.piony));
            System.Threading.Thread.Sleep(500);
            Cursor = Cursors.Default;
            pictureBox1.Invalidate();

        }
    }
}