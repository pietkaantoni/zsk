// See https://aka.ms/new-console-template for more information

/*                                                              Funkcja zwracająca true/false
 * 1 warstwa poza kodem, poza main-em:
 * 
 * static bool IsTriangle(double a, double b, double c)
 * {
 *      return a+b>c && a+c>b && b+c>a;
 * }
 * static double calculateTriangleArea(double a, double b, double c)
 * {
 *      double p = (a+b+c) / 2;
 *      return Math.Sqrt((p-a)*(p-b)*(p-c));
 * }
 * 
 * W kodzie:
 * IsTriangle(a,b,c)
*/
/*                                      Program się wykrzaczył
Console.WriteLine("Podaj krok a:");
double a;
a = double.Parse(Console.ReadLine());
*/

/*                                      Nie wykrtzaczył
Console.WriteLine("Podaj krok a:");
double a;
double.TryParse(Console.ReadLine(), out a);
*/

/*
Console.WriteLine("Podaj krok a:");
double a;
if (double.TryParse(Console.ReadLine(), out a))
{
    Console.WriteLine(a);
}
*/

//                                                              Program wypytuje o boki a,b,c dopóki użytkownik nie wprowadzi ich poprawnie
bool isCorrect = false;
do 
{
    Console.Write("Podaj bok a: ");
    double a;
    while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
    {
        Console.Write("Podaj poprawnie bok a: ");
    }

    Console.Write("Podaj bok b: ");
    double b;
    while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
    {
        Console.Write("Podaj poprawnie bok b: ");
    }

    Console.Write("Podaj bok c: ");
    double c;
    while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
    {
        Console.Write("Podaj poprawnie bok c: ");
    }

    if (a + b > c && a + c > b && b + c > a)
    {
        isCorrect = true;
        double p = (a + b + c) / 2;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Pole trójkąta o bokach {0}, {1}, {2}, wynosi: {3}cm\u00B2", a, b, c, Math.Sqrt((p - a) * (p - b) * (p - c)));
        Console.OutputEncoding = System.Text.Encoding.Default;
    }
    else
    {
        Console.WriteLine("Z podanych boków nie da się utworzyć trójkąta.");
        Thread.Sleep(1000);
        Console.Clear();
    }
}while (!isCorrect);





