
// Diagrama de Clases: https://drive.google.com/file/d/14fRsGnk5bl-Raooz8smgSOUzaIs9Wa9s/view?usp=sharing

using System;


while (true)
    {
    List<int> numeros = new List<int>();
    Console.Clear();
        MostrarMenu();
        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:

            numeros = ListaNumeros();
                break;
            case 2:
            Console.WriteLine($"Media: {Media(numeros)}");
            break;
            case 3:
            Console.WriteLine($"Mediana: {Mediana(numeros)}");
            break;
            case 4:
            Console.WriteLine($"Moda: {Moda(numeros)}");
            break;
            case 5:
            Console.WriteLine($"Desviación Estándar: {DesviacionEstandar(numeros)}");
                break;
            case 6:
                ListaNumeros();
            break;
            case 7:
                Console.WriteLine("Saliendo...");
                return;
            default:
                Console.WriteLine("Opción no válida, intenta de nuevo.");
                break;
        }

        Console.WriteLine("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }


static void MostrarMenu()
{
    Console.WriteLine("Menú Cálculos Estadísticos:");
    Console.WriteLine("1. Ingresar Lista de Números");
    Console.WriteLine("2. Calcular y Mostrar Media");
    Console.WriteLine("3. Calcular y Mostrar Mediana");
    Console.WriteLine("4. Calcular y Mostrar Moda");
    Console.WriteLine("5. Calcular y Mostrar Desviación Estandar");
    Console.WriteLine("6. Volver a Ingresar números");
    Console.WriteLine("7. Salir");
    Console.Write("Selecciona una opción: ");
}

static List<int> ListaNumeros()
{
    List<int> numeros = new List<int>();
    Console.Write("¿Cuántos números desea ingresar? ");
    int cantidad = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < cantidad; i++)
    {
        Console.Write($"Ingrese el número {i + 1}: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        numeros.Add(numero);
    }
    return numeros;
}

static double Media(List<int> numeros)
{
 double suma = 0;
            for (int i = 0; i < numeros.Count; i++)
            {
                suma += numeros[i];
            }

         double media = suma / numeros.Count;

    return media;
}

static double Mediana(List<int> numeros)
{
    numeros.Sort();
    if (numeros.Count % 2 != 0)
    {
        return numeros[numeros.Count / 2];
    }
    else
    {
        int midIndex = numeros.Count / 2;
        return (numeros[midIndex - 1] + numeros[midIndex]) / 2.0;
    }
}

static int Moda(List<int> numeros)
{
    return numeros.GroupBy(v => v)
                  .OrderByDescending(g => g.Count())
                  .First()
                  .Key;
}

static double DesviacionEstandar(List<int> numeros)
{
    double media = Media(numeros);
    double sumaDesviacion = numeros.Sum(num => Math.Pow(num - media, 2));
    return Math.Sqrt(sumaDesviacion / numeros.Count);
}