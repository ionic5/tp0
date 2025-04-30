using System;

public class DegreeSettedEventArgs : EventArgs
{
    public readonly int Degree;

    public DegreeSettedEventArgs(int degree)
    {
        Degree = degree;
    }
}
