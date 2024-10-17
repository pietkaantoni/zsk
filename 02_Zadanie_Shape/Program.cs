using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Zadanie_Shape
{
    /*
    Zadanie: Obliczanie Pola i Obwodu Figur Geometrycznych
   Cel:
   Stwórz aplikację konsolową w języku C#, która oblicza pola i obwody różnych figur geometrycznych, takich jak koło, kwadrat, prostokąt i trójkąt. Aplikacja powinna korzystać z abstrakcji, dziedziczenia i kompozycji.

   Wymagania:
   Klasa abstrakcyjna Shape:

   Utwórz abstrakcyjną klasę Shape, która będzie zawierać abstrakcyjne metody CalculateArea() i CalculatePerimeter().

   Dziedziczenie:

   Utwórz klasy Circle, Square, Rectangle i Triangle, które dziedziczą po klasie Shape i implementują abstrakcyjne metody CalculateArea() i CalculatePerimeter().

   Kompozycja:

   Utwórz klasę Geometry, która będzie zawierać listę obiektów Shape i metody do dodawania figur oraz obliczania całkowitego pola i obwodu wszystkich figur.


   Testowanie:

   Utwórz instancje różnych figur, dodaj je do listy w klasie Geometry i wyświetl obliczenia pola i obwodu każdej figury.

                         geometry.AddShape(new Circle(5));
               geometry.AddShape(new Square(4));
               geometry.AddShape(new Rectangle(3, 7));
               geometry.AddShape(new Triangle(3, 4, 3, 4, 5));    
    */
    internal class Program
    {
        public abstract class Shape
        {
            public abstract double CalculeteArea();
            public abstract double CalculatePerimeter();
        }
        public class Square : Shape
        {
            public double Side { get; set; }
            public Square(double side)
            {
                Side = side;
            }
            public override double CalculeteArea()
            {
                return Math.Pow(Side,2);
            }
            public override double CalculatePerimeter()
            {
                return 4*Side;
            }
        }
        public class Rectangle : Shape
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Rectangle(double x, double y)
            {
                X = x;
                Y = y;
            }
            public override double CalculeteArea()
            {
                return X*Y;
            }
            public override double CalculatePerimeter()
            {
                return 2*(X+Y);
            }
        }
        public class Geometry
        {
            public List<Shape> Shapes { get; set; }
            public Geometry()
            {
                Shapes = new List<Shape>();
            }
            public void AddShape(Shape shape)
            {
                Shapes.Add(shape);
            }
            public double CalculateTotalArea()
            {
                double totalArea = 0;
                foreach (var shape in Shapes)
                {
                    totalArea += shape.CalculeteArea();
                }
                return totalArea;
            }
            public double CalculateTotalPerimeter()
            {
                double totalPerimeter = 0;
                foreach (var shape in Shapes)
                {
                    totalPerimeter += shape.CalculatePerimeter();
                }
                return totalPerimeter;
            }
        }
        static void Main(string[] args)
        {
            Geometry geometry = new Geometry();
            geometry.AddShape(new Square(4));
            geometry.AddShape(new Rectangle(4, 2));

            Console.WriteLine($"Całkowite pole: {geometry.CalculateTotalArea()}");
            
            
            Console.ReadKey();
        }
    }
}
