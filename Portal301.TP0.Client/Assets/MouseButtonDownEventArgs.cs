using System;
using System.Numerics;

public class MouseButtonDownEventArgs : EventArgs
{
    public readonly Vector2 Position;

    public MouseButtonDownEventArgs(Vector2 position)
    {
        Position = position;
    }
}