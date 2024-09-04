using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_dziedziczenie
{
    
    internal class Program
    {
        class Shape
        {
            public virtual float CalculateArea()
            {
                return 0;
            }
            public virtual float CalculatePerimeter()
            {
                return 0;
            }

        }
        class Rectangle : Shape
        {
            private float width;
            private float height;
            
            public void SetDimensions(float w, float h)
            {
                width = w;
                height = h;
            }
            public override float CalculateArea()
            {
                return width * height;
            }
            public override float CalculatePerimeter()
            {
                return 2*(width+height);
            }
        }
        class Circle : Shape
        {
            private float radius;

            public void SetRadius(float r)
            {
                radius = r;
            }
            public override float CalculateArea()
            {
                //return base.CalculateArea();
                return (float)(Math.PI * radius * radius);
            }

        }

        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();

            rect.SetDimensions(2.5f, 3f);

            Console.WriteLine("Pole prostokąta wynosi: {0}", rect.CalculateArea());
            
            Circle circ = new Circle();
            circ.SetRadius(2.4f);
            Console.WriteLine("Pole koła wynosi: {0}", circ.CalculateArea());
            
            Console.ReadKey();
        }
    }
}
