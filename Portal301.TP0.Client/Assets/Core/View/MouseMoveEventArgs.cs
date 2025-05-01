using System;
using System.Numerics;

namespace Portal301.TP0.Client.Core.View
{
    public class MouseMoveEventArgs : EventArgs
    {
        public readonly Vector2 Position;

        public MouseMoveEventArgs(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}