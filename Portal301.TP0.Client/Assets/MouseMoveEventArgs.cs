using System;
using System.Numerics;

public class MouseMoveEventArgs : EventArgs
{
    public readonly Vector2 Position;

    public MouseMoveEventArgs(Vector2 position)
    {
        Position = position;
    }
}