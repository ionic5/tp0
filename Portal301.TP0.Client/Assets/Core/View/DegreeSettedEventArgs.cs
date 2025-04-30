using System;

namespace Portal301.TP0.Client.Core.View
{
    public class DegreeSettedEventArgs : EventArgs
    {
        public readonly int Degree;

        public DegreeSettedEventArgs(int degree)
        {
            Degree = degree;
        }
    }
}
