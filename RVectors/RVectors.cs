using System;
using System.Collections.Generic;

namespace RVectors
{
    public class R2Vector
    {
        public float x, y;

        public R2Vector(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public R2Vector(float p1X, float p1Y, float p2X, float p2Y)
        {
            x = p1X - p2X;
            y = p1Y - p2Y;
        }

        /// <summary>
        /// Takes a string and splits it up, then makes the a vector out of the pieces
        /// </summary>
        /// <param name="vectorString">A written vector ie "(1,2)"</param>
        public R2Vector(string vectorString)
        {
            List<int> indexes = new List<int>();

            char[] vectorChars = vectorString.ToCharArray();
            for (int i = 0; i < vectorChars.Length; i++)
            {
                if (Char.IsNumber(vectorChars[i]))
                {
                    indexes.Add(i);
                }
            }

            int vComponent = 0;
            List<int> vComps = new List<int>();
            for (int i = 0; i < indexes.Count; i++)
            {
                if (i == 0)
                {
                    vComponent = Convert.ToInt32(vectorChars[indexes[i]].ToString());
                }
                else if (indexes[i] - 1 == indexes[i - 1])
                {
                    vComponent = vComponent * 10 + Convert.ToInt32(vectorChars[indexes[i]].ToString());
                }
                else
                {
                    vComps.Add(vComponent);
                    vComponent = 0;

                    if (i == indexes.Count - 1)
                    {
                        vComponent += Convert.ToInt32(vectorChars[indexes[i]].ToString());
                        vComps.Add(vComponent);
                        break;
                    }
                    else
                    {
                        vComponent = Convert.ToInt32(vectorChars[indexes[i]].ToString());
                    }
                }

                if (i == indexes.Count - 1)
                {
                    vComps.Add(vComponent);
                }
            }

            x = vComps[0];
            y = vComps[1];
        }

        public R2Vector add(R2Vector v2)
        {
            return new R2Vector(x + v2.x, y + v2.y);
        }

        public float magnetude()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public float dot(R2Vector v)
        {
            return x * v.x + y * v.y;
        }

        /// <summary>
        /// Shortens the vector to a length of 1 unit
        /// </summary>
        public void noramlize()
        {
            x /= magnetude();
            y /= magnetude();
        }

        public void changeMag(float mag)
        {
            float old = magnetude();
            x = x / old * mag;
            y = y / old * mag;
        }
    }

    public class R3Vector
    {
        public float x, y, z;

        public R3Vector(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        /// <summary>
        /// Takes a string and splits it up, then makes the a vector out of the pieces
        /// </summary>
        /// <param name="vectorString">A written vector ie "(1,2,5)"</param>
        public R3Vector(string vectorString)
        {
            List<int> indexes = new List<int>();

            char[] vectorChars = vectorString.ToCharArray();
            for (int i = 0; i < vectorChars.Length; i++)
            {
                if (Char.IsNumber(vectorChars[i]))
                {
                    indexes.Add(i);
                }
            }

            int vComponent = 0;
            List<int> vComps = new List<int>();
            for (int i = 0; i < indexes.Count; i++)
            {
                if (i == 0)
                {
                    vComponent = Convert.ToInt32(vectorChars[indexes[i]].ToString());
                }
                else if (indexes[i] - 1 == indexes[i - 1])
                {
                    vComponent = vComponent * 10 + Convert.ToInt32(vectorChars[indexes[i]].ToString());
                }
                else
                {
                    vComps.Add(vComponent);
                    vComponent = 0;

                    if (i == indexes.Count - 1)
                    {
                        vComponent += Convert.ToInt32(vectorChars[indexes[i]].ToString());
                        vComps.Add(vComponent);
                        break;
                    }
                    else
                    {
                        vComponent = Convert.ToInt32(vectorChars[indexes[i]].ToString());
                    }
                }

                if (i == indexes.Count - 1)
                {
                    vComps.Add(vComponent);
                }
            }

            x = vComps[0];
            y = vComps[1];
            z = vComps[2];
        }

        public R3Vector add(R3Vector v)
        {
            return new R3Vector(x + v.x, y + v.y, z + v.z);
        }

        public float magnetude()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public float dot(R3Vector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        /// <summary>
        /// Produces a vector perpendicular to the current vector and the input vector
        /// </summary>
        /// <param name="v">The input vector</param>
        /// <returns>A new perpendicular R3Vector</returns>
        public R3Vector cross(R3Vector v)
        {
            return new R3Vector(
                y * v.z - z * v.y,
                z * v.x - x * v.z,
                x * v.y - y * v.x);
        }

        public void noramlize()
        {
            x /= magnetude();
            y /= magnetude();
            z /= magnetude();
        }
    }
}
