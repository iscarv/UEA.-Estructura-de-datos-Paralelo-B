using System;
using System.Collections.Generic;

// Clase que representa un nodo en el árbol binario
class Nodo
{
    public int Valor; // Valor almacenado en el nodo
    public Nodo Izq, Der; // Punteros a los nodos izquierdo y derecho

    public Nodo(int valor)
    {
        Valor = valor;
        Izq = Der = null;
    }
}

// Clase que representa el árbol binario y sus operaciones
class ArbolBinario
{
    public Nodo Raiz; // Raíz del árbol

    // --- MÉTODO PARA INSERTAR UN VALOR EN EL ÁRBOL ---
    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null) // Si el nodo está vacío, lo creamos
            return new Nodo(valor);

        // Insertamos recursivamente en el subárbol izquierdo o derecho
        if (valor < nodo.Valor)
            nodo.Izq = InsertarRec(nodo.Izq, valor);
        else
            nodo.Der = InsertarRec(nodo.Der, valor);

        return nodo;
    }

    // --- MÉTODO PARA ELIMINAR UN NODO DEL ÁRBOL ---
    public void Eliminar(int valor)
    {
        Raiz = EliminarRec(Raiz, valor);
    }

    private Nodo EliminarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        // Buscamos el nodo a eliminar
        if (valor < nodo.Valor)
            nodo.Izq = EliminarRec(nodo.Izq, valor);
        else if (valor > nodo.Valor)
            nodo.Der = EliminarRec(nodo.Der, valor);
        else
        {
            // Caso 1: Nodo con un solo hijo o sin hijos
            if (nodo.Izq == null) return nodo.Der;
            if (nodo.Der == null) return nodo.Izq;

            // Caso 2: Nodo con dos hijos (se reemplaza con el menor de la derecha)
            Nodo temp = MinimoNodo(nodo.Der);
            nodo.Valor = temp.Valor;
            nodo.Der = EliminarRec(nodo.Der, temp.Valor);
        }
        return nodo;
    }

    // Método para encontrar el nodo con el menor valor en un subárbol
    private Nodo MinimoNodo(Nodo nodo)
    {
        while (nodo.Izq != null)
            nodo = nodo.Izq;
        return nodo;
    }

    // --- MÉTODO PARA BUSCAR UN VALOR EN EL ÁRBOL ---
    public bool Buscar(int valor)
    {
        return BuscarRec(Raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (nodo.Valor == valor) return true;

        return valor < nodo.Valor ? BuscarRec(nodo.Izq, valor) : BuscarRec(nodo.Der, valor);
    }

    // --- MÍNIMO Y MÁXIMO ---
    public int Minimo()
    {
        if (Raiz == null) return -1;
        return MinimoNodo(Raiz).Valor;
    }

    public int Maximo()
    {
        Nodo nodo = Raiz;
        while (nodo.Der != null)
            nodo = nodo.Der;
        return nodo.Valor;
    }

    // --- CALCULAR LA ALTURA DEL ÁRBOL ---
    public int Altura()
    {
        return AlturaRec(Raiz);
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null) return -1;
        return 1 + Math.Max(AlturaRec(nodo.Izq), AlturaRec(nodo.Der));
    }

    // --- CONTAR NODOS Y HOJAS ---
    public int ContarNodos()
    {
        return ContarNodosRec(Raiz);
    }

    private int ContarNodosRec(Nodo nodo)
    {
        if (nodo == null) return 0;
        return 1 + ContarNodosRec(nodo.Izq) + ContarNodosRec(nodo.Der);
    }

    public int ContarHojas()
    {
        return ContarHojasRec(Raiz);
    }

    private int ContarHojasRec(Nodo nodo)
    {
        if (nodo == null) return 0;
        if (nodo.Izq == null && nodo.Der == null) return 1;
        return ContarHojasRec(nodo.Izq) + ContarHojasRec(nodo.Der);
    }

    // --- INVERSIÓN DEL ÁRBOL ---
    public void Invertir()
    {
        Raiz = InvertirRec(Raiz);
    }

    private Nodo InvertirRec(Nodo nodo)
    {
        if (nodo == null) return null;
        Nodo temp = nodo.Izq;
        nodo.Izq = InvertirRec(nodo.Der);
        nodo.Der = InvertirRec(temp);
        return nodo;
    }

    // --- VERIFICAR SI EL ÁRBOL ES UN BST ---
    public bool EsBST()
    {
        return EsBSTRec(Raiz, int.MinValue, int.MaxValue);
    }

    private bool EsBSTRec(Nodo nodo, int min, int max)
    {
        if (nodo == null) return true;
        if (nodo.Valor <= min || nodo.Valor >= max) return false;
        return EsBSTRec(nodo.Izq, min, nodo.Valor) && EsBSTRec(nodo.Der, nodo.Valor, max);
    }

    // --- VERIFICAR SI EL ÁRBOL ESTÁ BALANCEADO ---
    public bool EsBalanceado()
    {
        return VerificarBalanceo(Raiz) != -1;
    }

    private int VerificarBalanceo(Nodo nodo)
    {
        if (nodo == null) return 0;

        int alturaIzq = VerificarBalanceo(nodo.Izq);
        if (alturaIzq == -1) return -1; // No está balanceado

        int alturaDer = VerificarBalanceo(nodo.Der);
        if (alturaDer == -1) return -1; // No está balanceado

        if (Math.Abs(alturaIzq - alturaDer) > 1)
            return -1; // Desbalanceado

        return Math.Max(alturaIzq, alturaDer) + 1; // Retorna la altura
    }

    // --- MÉTODO PARA ENCONTRAR EL NIVEL MÁS PROFUNDO CON HOJAS ---
    public int NivelMasProfundo()
    {
        if (Raiz == null) return -1;

        Queue<(Nodo, int)> cola = new Queue<(Nodo, int)>();
        cola.Enqueue((Raiz, 0));

        int nivelMasProfundo = 0;

        while (cola.Count > 0)
        {
            var (nodo, nivel) = cola.Dequeue();
            nivelMasProfundo = nivel;

            if (nodo.Izq != null)
                cola.Enqueue((nodo.Izq, nivel + 1));
            if (nodo.Der != null)
                cola.Enqueue((nodo.Der, nivel + 1));
        }

        return nivelMasProfundo;
    }

    // --- IMPRESIÓN DEL ÁRBOL EN DIFERENTES RECORRIDOS ---
    public void Imprimir(string tipo)
    {
        if (tipo == "preorden") Preorden(Raiz);
        else if (tipo == "inorden") Inorden(Raiz);
        else if (tipo == "postorden") Postorden(Raiz);
        Console.WriteLine();
    }

    private void Preorden(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Valor + " ");
        Preorden(nodo.Izq);
        Preorden(nodo.Der);
    }

    private void Inorden(Nodo nodo)
    {
        if (nodo == null) return;
        Inorden(nodo.Izq);
        Console.Write(nodo.Valor + " ");
        Inorden(nodo.Der);
    }

    private void Postorden(Nodo nodo)
    {
        if (nodo == null) return;
        Postorden(nodo.Izq);
        Postorden(nodo.Der);
        Console.Write(nodo.Valor + " ");
    }
}

// Clase principal con menú interactivo
class Programa
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.WriteLine("\n1. Insertar");
            Console.WriteLine("2. Eliminar");
            Console.WriteLine("3. Buscar");
            Console.WriteLine("4. Imprimir (Preorden, Inorden, Postorden)");
            Console.WriteLine("5. Mínimo y Máximo");
            Console.WriteLine("6. Altura del árbol");
            Console.WriteLine("7. Contar nodos y hojas");
            Console.WriteLine("8. Invertir árbol");
            Console.WriteLine("9. Verificar si es BST");
            Console.WriteLine("10. Verificar si está balanceado");
            Console.WriteLine("11. Nivel más profundo con hojas");
            Console.WriteLine("12. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa el valor a insertar: ");
                    int insertar = int.Parse(Console.ReadLine());
                    arbol.Insertar(insertar);
                    break;
                case "2":
                    Console.Write("Ingresa el valor a eliminar: ");
                    int eliminar = int.Parse(Console.ReadLine());
                    arbol.Eliminar(eliminar);
                    break;
                case "3":
                    Console.Write("Ingresa el valor a buscar: ");
                    int buscar = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(buscar) ? "Encontrado" : "No encontrado");
                    break;
                case "4":
                    Console.WriteLine("Impresión en preorden: ");
                    arbol.Imprimir("preorden");
                    Console.WriteLine("Impresión en inorden: ");
                    arbol.Imprimir("inorden");
                    Console.WriteLine("Impresión en postorden: ");
                    arbol.Imprimir("postorden");
                    break;
                case "5":
                    Console.WriteLine($"Mínimo: {arbol.Minimo()}");
                    Console.WriteLine($"Máximo: {arbol.Maximo()}");
                    break;
                case "6":
                    Console.WriteLine($"Altura: {arbol.Altura()}");
                    break;
                case "7":
                    Console.WriteLine($"Nodos: {arbol.ContarNodos()}");
                    Console.WriteLine($"Hojas: {arbol.ContarHojas()}");
                    break;
                case "8":
                    arbol.Invertir();
                    Console.WriteLine("Árbol invertido.");
                    break;
                case "9":
                    Console.WriteLine(arbol.EsBST() ? "Es un BST" : "No es un BST");
                    break;
                case "10":
                    Console.WriteLine(arbol.EsBalanceado() ? "Está balanceado" : "No está balanceado");
                    break;
                case "11":
                    Console.WriteLine($"Nivel más profundo: {arbol.NivelMasProfundo()}");
                    break;
                case "12":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
