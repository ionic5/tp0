using System;
using System.Numerics;

namespace Portal301.TP0.Client.Core.View
{
    public class MouseButtonDownEventArgs : EventArgs
    {
        public readonly Vector2 Position;

        public MouseButtonDownEventArgs(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}