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
            List<float> vComps = new List<float>();

            char[] vectorChars = vectorString.ToCharArray();

            float nComp = 0;
            bool und1 = false;
            int decPlace = 0;

            for (int i = 0; i < vectorChars.Length; i++)
            {
                if (Char.IsNumber(vectorChars[i]))
                {
                    if(und1)
                    {
                        nComp = nComp + (float)Math.Pow(10, -decPlace) * (float)Convert.ToDouble(vectorChars[i].ToString());
                        decPlace++;
                    }
                    else
                    {
                        nComp = nComp * 10 + (float)Convert.ToDouble(vectorChars[i].ToString());
                    }
                }
                else if (vectorChars[i].ToString() == ".")
                {
                    und1 = true;
                    decPlace++;
                }
                else
                {
                    und1 = false;
                    decPlace = 0;
                    try
                    {
                        if (Char.IsNumber(vectorChars[i - 1]))
                        {
                            vComps.Add(nComp);
                            nComp = 0;
                        }
                    }
                    catch { };
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
            List<float> vComps = new List<float>();

            char[] vectorChars = vectorString.ToCharArray();

            float nComp = 0;
            bool und1 = false;
            int decPlace = 0;

            for (int i = 0; i < vectorChars.Length; i++)
            {
                if (Char.IsNumber(vectorChars[i]))
                {
                    if (und1)
                    {
                        nComp = nComp + (float)Math.Pow(10, -decPlace) * (float)Convert.ToDouble(vectorChars[i].ToString());
                        decPlace++;
                    }
                    else
                    {
                        nComp = nComp * 10 + (float)Convert.ToDouble(vectorChars[i].ToString());
                    }
                }
                else if (vectorChars[i].ToString() == ".")
                {
                    und1 = true;
                    decPlace++;
                }
                else
                {
                    und1 = false;
                    decPlace = 0;
                    try
                    {
                        if (Char.IsNumber(vectorChars[i - 1]))
                        {
                            vComps.Add(nComp);
                            nComp = 0;
                        }
                    }
                    catch { };
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
