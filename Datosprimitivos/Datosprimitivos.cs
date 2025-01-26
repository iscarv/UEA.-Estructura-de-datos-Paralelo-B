using System;

class Program
{
    // Clase que encapsula un tipo de dato primitivo (int)
    public class NumeroEntero
    {
        // Campo privado para almacenar el valor
        private int valor;

        // Constructor para inicializar el valor
        public NumeroEntero(int valorInicial)
        {
            valor = valorInicial;
        }

        // Propiedad para acceder y modificar el valor
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        // Método para sumar otro número al valor actual
        public void Sumar(int otroNumero)
        {
            valor += otroNumero;
        }

        // Método para mostrar el valor actual
        public void MostrarValor()
        {
            Console.WriteLine($"El valor actual es: {valor}");
        }
    }

    static void Main(string[] args)
    {
        // Crear una instancia de la clase NumeroEntero
        NumeroEntero miNumero = new NumeroEntero(10);

        // Mostrar el valor inicial
        miNumero.MostrarValor();

        // Sumar un número
        miNumero.Sumar(5);

        // Mostrar el valor después de la suma
        miNumero.MostrarValor();
    }
}