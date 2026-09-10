using System;

namespace emp
{
    internal class Designation
    {
        public static implicit operator designation(Designation v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Designation(int v)
        {
            throw new NotImplementedException();
        }
    }
}