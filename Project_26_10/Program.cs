
Console.WriteLine("Podaj 2 liczby");
bool c;
/*
 * static void ErrorColorChange(string message)
 *  {
 *      Console.ForegroundColor = ConsoleColor.Red;
 *      Console.Writeline($"\nBlad: {message}\n");
 *      Console.ResetColor();
 *  }
 */
do
{
    try
    {
        Console.Write("Podaj x: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Podaj y: ");
        int y = int.Parse(Console.ReadLine());
        if (y != 0)
        {
            Console.Write($"Iloraz ");
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{x} / {y} = {x / y}");
        Console.ResetColor();

        c = false;
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Podaj liczbe calkowita");
        Console.ResetColor();
        c = true;
    }
    catch (OverflowException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Liczba poza zakresem <{int.MinValue} ; {int.MaxValue}>");
        Console.ResetColor();
        c = true;
    }
    catch (DivideByZeroException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Dzielenie przez 0");
        Console.ResetColor();
        c = true;
    }
    catch (Exception ex)
    {
        //Console.WriteLine(ex.ToString());
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ResetColor();
        c = true;
    }
    finally
    {
        Console.WriteLine("Dziekujemy za skorzystanie z programu");
    }
    
} while (c);