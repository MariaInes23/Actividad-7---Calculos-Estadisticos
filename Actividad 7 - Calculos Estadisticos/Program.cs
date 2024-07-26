
// Diagrama de Clases: https://drive.google.com/file/d/14fRsGnk5bl-Raooz8smgSOUzaIs9Wa9s/view?usp=sharing

using System;

    List<double> numeros = new List<double>();

    while (true)
    {
        Console.Clear();
        MostrarMenu();
        int opcion = Convert.ToInt32(Console.ReadLine());
        try
        { 
            switch (opcion)
            {
                case 1:
                    numeros = ListaNumeros();
                    break;
                case 2:
                    Media(numeros);
                    break;
                case 3:
                    Mediana(numeros);
                    break;
                case 4:
                    Moda(numeros);
                    break;
                case 5:
                    DesviacionEstandar(numeros);
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
        }
        catch (FormatException)
        {
        Console.WriteLine("Entrada no válida. Asegúrese de ingresar un número entero.");
        }
        catch (Exception ex)
        {
        Console.WriteLine($"Error inesperado: {ex.Message}");
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

    static List<double> ListaNumeros()
    {
        List<double> numeros = new List<double>();

        Console.Write("Ingrese la cantidad de números que desea introducir: ");
        int cantidad;
        while (true)
        {
            try
            {
                cantidad = Convert.ToInt32(Console.ReadLine());
                if (cantidad <= 0)
                {
                    Console.Write("La cantidad debe ser un número entero positivo. Inténtelo de nuevo: ");
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.Write("Entrada no válida. Ingrese un número entero positivo: ");
            }
        }

        for (int i = 0; i < cantidad; i++)
        {
            double numero;
            while (true)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                try
                {
                    numero = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("Entrada no válida. Ingrese un número válido: ");
                }
            }
            numeros.Add(numero);
        }

        return numeros;
    }

    static void Media(List<double> numeros)
    {
        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números ingresados.");
            return;
        }

        double suma = 0;
        foreach (var numero in numeros)
        {
            suma += numero;
        }
        double media = suma / numeros.Count;

        Console.WriteLine($"La media es: {media}");
    }

    static void Mediana(List<double> numeros)
    {
        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números ingresados.");
            return;
        }

        for (int i = 0; i < numeros.Count - 1; i++)
        {
            for (int j = 0; j < numeros.Count - 1 - i; j++)
            {
                if (numeros[j] > numeros[j + 1])
                {
                    // Intercambiar numeros[j] y numeros[j + 1]
                    double temp = numeros[j];
                    numeros[j] = numeros[j + 1];
                    numeros[j + 1] = temp;
                }
            }
        }

        int cantidadNumeros = numeros.Count;
        double mediana;

        if (cantidadNumeros % 2 == 1)
        {
            mediana = numeros[cantidadNumeros / 2];
        }
        else
        {
            mediana = (numeros[cantidadNumeros / 2 - 1] + numeros[cantidadNumeros / 2]) / 2;
        }

        Console.WriteLine($"La mediana es: {mediana}");
    }

    static void Moda(List<double> numeros)
    {
        Dictionary<int, int> frecuencia = new Dictionary<int, int>();

        foreach (int repetido in numeros)
        {
            try
            {
                frecuencia[repetido]++;
            }
            catch (KeyNotFoundException)
            {
                frecuencia[repetido] = 1;
            }
        }

        double moda = numeros[0];
        int contador = 0;

        foreach (var encontrar in frecuencia)
        {
            if (encontrar.Value > contador)
            {
                contador = encontrar.Value;
                moda = encontrar.Key;
            }
        }

        Console.WriteLine($"La moda es: {moda}");
    }

    static void DesviacionEstandar(List<double> numeros)
    {
    if (numeros.Count == 0)
    {
        Console.WriteLine("No hay números ingresados.");
        return;
    }

    double media = 0;
    double suma = 0;
    foreach (var numero in numeros)
    {
        suma += numero;
    }
    media = suma / numeros.Count;

    double formulaDesviacion = 0;
    foreach (var numero in numeros)
    {
        formulaDesviacion += Math.Abs(numero - media);
    }
    double desviacionEstandar = formulaDesviacion / numeros.Count;

    Console.WriteLine($"La desviación estándar es: {desviacionEstandar}");
}

