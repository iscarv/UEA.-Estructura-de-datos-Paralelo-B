//1.	Tomando en cuenta la teoría de la clase sobre pilas, resuelva el código en C# 
//la verificación de una operación matemática se encuentran balanceados: Ej: {7+(8*5)-[(9-7)+(4+1)]} resultado => formula balanceada.
using System;
using System.Collections.Generic;

class FormulaBalanceada
{
    /// <summary>
    /// Método principal que verifica si una fórmula matemática está balanceada.
    /// </summary>
    /// <param name="formula">La fórmula matemática a verificar.</param>
    /// <returns>True si la fórmula está balanceada; de lo contrario, False.</returns>
    static bool VerificarBalanceo(string formula)
    {
        // Pila para almacenar los caracteres de apertura
        Stack<char> pila = new Stack<char>();

        // Recorrer cada carácter en la fórmula
        foreach (char c in formula)
        {
            // Si el carácter es un símbolo de apertura, se agrega a la pila
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // Si el carácter es un símbolo de cierre, verificar con el tope de la pila
            else if (c == ')' || c == ']' || c == '}')
            {
                // Si la pila está vacía, significa que hay un símbolo de cierre sin apertura previa
                if (pila.Count == 0) return false;

                // Obtener el símbolo de apertura en el tope de la pila
                char top = pila.Pop();

                // Verificar si el símbolo de apertura coincide con el de cierre
                if (!EsParCoincidente(top, c)) return false;
            }
        }

        // Si la pila está vacía al final, todos los símbolos están balanceados
        return pila.Count == 0;
    }

    /// <summary>
    /// Método auxiliar para verificar si un par de símbolos coincide.
    /// </summary>
    /// <param name="apertura">El símbolo de apertura.</param>
    /// <param name="cierre">El símbolo de cierre.</param>
    /// <returns>True si los símbolos coinciden; de lo contrario, False.</returns>
    static bool EsParCoincidente(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }

    /// <summary>
    /// Punto de entrada principal del programa.
    /// </summary>
    static void Main()
    {
        // Ejemplo de fórmula a verificar
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";

        // Llamar al método para verificar el balanceo
        bool resultado = VerificarBalanceo(formula);

        // Mostrar el resultado al usuario
        if (resultado)
        {
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            Console.WriteLine("La fórmula no está balanceada.");
        }
    }
}