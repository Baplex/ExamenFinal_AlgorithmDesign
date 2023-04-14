using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DIseñoDeAlgoritmos_ExamenFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 0, y = 0, z = 0;


        private void DrawRectangle()
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 4);
            System.Drawing.Graphics formGraphics;

            formGraphics = this.CreateGraphics();
            formGraphics.DrawRectangle(myPen, new Rectangle(700, 75, x, y));
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void DrawSquare()
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Blue, 4);
            System.Drawing.Graphics formGraphics;

            formGraphics = this.CreateGraphics();
            formGraphics.DrawRectangle(myPen, new Rectangle(700, 75, x, y));
            myPen.Dispose();
            formGraphics.Dispose();
        }
        private void DrawTriangle()
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Green, 4);
            System.Drawing.Graphics formGraphics;
            Point TopV = new Point(700, 75);
            Point BottomRV = new Point(TopV.X + x, TopV.Y + (int)(Math.Sqrt(3) / 2 * x));
            Point BottomLV = new Point(TopV.X - x, TopV.Y + (int)(Math.Sqrt(3) / 2 * x));

            Point[] trianglePoints = new Point[]
            {TopV, BottomRV, BottomLV};

            formGraphics = this.CreateGraphics();
            formGraphics.DrawPolygon(myPen, trianglePoints);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void DrawRhomboid()
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Yellow, 4);
            System.Drawing.Graphics formGraphics;
            Point topLeftVertex = new Point(700, 75);
            Point topRightVertex = new Point(topLeftVertex.X + x, topLeftVertex.Y);
            Point bottomRightVertex = new Point(topRightVertex.X - (int)(y * Math.Cos(Math.PI / 4)), topRightVertex.Y + (int)(y * Math.Sin(Math.PI / 4)));
            Point bottomLeftVertex = new Point(topLeftVertex.X - (int)(y * Math.Cos(Math.PI / 4)), topLeftVertex.Y + (int)(y * Math.Sin(Math.PI / 4)));


            Point[] rhomboidPoints = new Point[] { topLeftVertex, topRightVertex, bottomRightVertex, bottomLeftVertex };
            formGraphics = this.CreateGraphics();
            formGraphics.DrawPolygon(myPen, rhomboidPoints);
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void DrawCircle()
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red, 4);
            System.Drawing.Graphics formGraphics;

            formGraphics = this.CreateGraphics();
            formGraphics.DrawEllipse(myPen, new Rectangle(700, 75, x, y));
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);

            double squareSide = 0;
            double circleRadius = 0;

            x = Convert.ToInt32(a);
            y = Convert.ToInt32(b);
            z = Convert.ToInt32(c);

            if (a == b && b == c)
            {
                // Square and Circle
                squareSide = a;
                circleRadius = a / 2;
                DrawSquare();
                DrawCircle();
            }

            else if (a == b || a == c || b == c)
            {
                //Rhomboid and Rectangle
                DrawRhomboid();
                DrawRectangle();
            }

            else if (a != b && a != c && b != c)
            {
                // Triangle 
                DrawTriangle();
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);

            double area, perimeter;
            area = a * 10;
            perimeter = b * 10;

            if (a == b && b == c)
            {
                // Square case
                area = Math.Pow(a, 2);
                perimeter = a * 4;
                MessageBox.Show("Detalles del cuadrado");
                MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
                double circleRadius = a / 2;
                double circArea = (circleRadius*circleRadius) * 3.14;
                MessageBox.Show("Detalles del círculo");
                MessageBox.Show($"Area: {circArea} pixeles, Radio {circleRadius} pixeles");

            }
            else if (a == b || a == c || b == c)
            {
                // es un rectángulo o un rombo
                if (a == b && a != c || a == c && a != b || b == c && b != a)
                {
                    // es un rombo
                    area = (a * c) / 2;
                    perimeter = a * 2 + b * 2;
                    MessageBox.Show("Detalles del rombo");
                    MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
                }
                // es un rectángulo
                if (a == b)
                {
                    area = a * c;
                    perimeter = a * 2 + b * 2;
                    MessageBox.Show("Detalles del rectángulo");
                    MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
                }
                else if (a == c)
                {
                    area = a * b;
                    perimeter = a * 2 + c * 2;
                    MessageBox.Show("Detalles del rectángulo");
                    MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
                }
                else if (b == c)
                {
                    area = b * a;
                    perimeter = b * 2 + c * 2;
                    MessageBox.Show("Detalles del rectángulo");
                    MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
                }
            }
            else if (a != b && a != c && b != c)
            {
                // Triangulo
                Console.WriteLine("Se ha detectado un triángulo escaleno con lados {0}, {1} y {2}", a, b, c);
                double s = (a + b + c) / 2;
                area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                perimeter = a + b + c;
                MessageBox.Show("Detalles del triángulo");
                MessageBox.Show($"Area: {area} pixeles, Perimetro: {perimeter} pixeles");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}