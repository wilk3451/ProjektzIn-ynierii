using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        /*
        public Vector2(double x, double y)
        {
            X = Zero().X;
            Y = Zero().Y;
        }*/

        public Vector2(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

        public Vector2 Add(Vector2 A, Vector2 B)
        {
            Vector2 C = new Vector2(A.X + B.X, A.Y + B.Y);
            return C;
        }

        public double Distance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

    }
}
