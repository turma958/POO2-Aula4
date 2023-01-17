
using System.Collections;
using System.Collections.Generic;

var lista = new Lista<string>();
lista.Add("Davi");
lista.Add("Guilherme");
lista.Add("Andre");
lista.Add("Paulo");

//var primeiroElemento = lista[0];

foreach (var item in lista)
{
    Console.WriteLine(item);
}

Console.ReadLine();

static class metodosUteis
{
    public static void Teste<T>(T valor) where T : class
    {

    }
}

class Pessoa
{

}

interface ILista<T>
{
    void Add(T value);
}

class Lista<T> : ILista<T>, IEnumerable<T>, IEnumerator<T>
{
    private Elemento<T> _first;
    private Elemento<T> _last;

    private Elemento<T> _current;

    public T Current { get; private set; }

    object IEnumerator.Current => Current;

    public T this[int index]
    {
        get
        {
            var elementAux = _first;
            int contador = 0;
            while (contador < index)
            {
                elementAux = elementAux.Next;
                contador++;
            }
            return elementAux.Value;
        }
        set
        {
        }
    }

    public void Add(T value)
    {
        if (_first == null)
        {
            _first = new Elemento<T>
            {
                Value = value
            };
            _last = _first;
            return;
        }

        var newElement = new Elemento<T>
        {
            Value = value
        };
        _last.Next = newElement;
        _last = newElement;
    }

    public void Dispose()
    {
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        if (_current == null && _first != null)
        {
            _current = _first;
            Current = _current.Value;
            return true;
        }

        _current = _current.Next;
        Current = _current != null ? _current.Value : default(T);

        return _current != null;
    }

    public void Reset()
    {
        _current = null;
        Current = default(T);
    }
}

class Elemento<T>
{
    public T Value { get; set; }
    public Elemento<T> Next { get; set; }
}