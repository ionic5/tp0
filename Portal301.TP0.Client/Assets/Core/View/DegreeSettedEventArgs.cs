using System;

namespace Portal301.TP0.Client.Core.View
{
    public class AngleSettedEventArgs : EventArgs
    {
        public readonly int Angle;

        public AngleSettedEventArgs(int angle)
        {
            Angle = angle;
        }
    }
}
