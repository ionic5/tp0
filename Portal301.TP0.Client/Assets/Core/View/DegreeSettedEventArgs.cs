using System;

namespace Portal301.TP0.Client.Core.View
{
    public class AngleSettedEventArgs : EventArgs
    {
        public readonly float Angle;

        public AngleSettedEventArgs(float angle)
        {
            Angle = angle;
        }
    }
}
