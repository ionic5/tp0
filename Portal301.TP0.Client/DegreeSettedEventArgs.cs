using System;

public class AngleSettedEventArgs : EventArgs
{
    public readonly int Angle;

    public AngleSettedEventArgs(int angle)
    {
        Angle = angle;
    }
}