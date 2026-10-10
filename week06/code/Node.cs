public void Insert(int value)
{
    if (value < Value)
    {
        // Insertar en el subárbol izquierdo
        if (Left is null)
        {
            Left = new Node(value);
        }
        else
        {
            Left.Insert(value);
        }
    }
    else if (value > Value)
    {
        // Insertar en el subárbol derecho
        if (Right is null)
        {
            Right = new Node(value);
        }
        else
        {
            Right.Insert(value);
        }
    }
    // Si value == Value, no se hace nada para evitar duplicados.
}
