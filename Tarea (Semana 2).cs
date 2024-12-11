using System;

namespace FigurasGeometricas
{
    // Clase que representa un círculo
    public class Circulo
    {
        // Campo privado que almacena el radio del círculo
        private double radio;

        // Constructor que inicializa el radio del círculo
        // Requiere como argumento el valor del radio
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // CalcularArea es una función que devuelve un valor double.
        // Se utiliza para calcular el área de un círculo, empleando la fórmula π * r^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es una función que devuelve un valor double.
        // Se utiliza para calcular el perímetro de un círculo, empleando la fórmula 2 * π * r
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase que representa un rectángulo
    public class Rectangulo
    {
        // Campos privados que almacenan la base y la altura del rectángulo
        private double baseRectangulo;
        private double altura;

        // Constructor que inicializa la base y la altura del rectángulo
        // Requiere como argumentos los valores de la base y la altura
        public Rectangulo(double baseRectangulo, double altura)
        {
            this.baseRectangulo = baseRectangulo;
            this.altura = altura;
        }

        // CalcularArea es una función que devuelve un valor double.
        // Se utiliza para calcular el área de un rectángulo, empleando la fórmula base * altura
        public double CalcularArea()
        {
            return baseRectangulo * altura;
        }

        // CalcularPerimetro es una función que devuelve un valor double.
        // Se utiliza para calcular el perímetro de un rectángulo, empleando la fórmula 2 * (base + altura)
        public double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + altura);
        }
    }

    // Clase principal que contiene el punto de entrada del programa
    public class Program
    {
        // Main es el punto de entrada del programa.
        // Es un método estático que ejecuta las pruebas de las clases Circulo y Rectangulo
        static void Main(string[] args)
        {
            // Crear un círculo con un radio de 5 unidades
            Circulo circulo = new Circulo(5);
            // Mostrar el área y el perímetro del círculo
            Console.WriteLine($"Área del círculo: {circulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro():F2}");

            // Crear un rectángulo con base de 4 unidades y altura de 7 unidades
            Rectangulo rectangulo = new Rectangulo(4, 7);
            // Mostrar el área y el perímetro del rectángulo
            Console.WriteLine($"Área del rectángulo: {rectangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro():F2}");
        }
    }
}