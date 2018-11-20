using System;
using System.Collections.Generic;

//Check out https://github.com/samuwyat989/3DProjection for a cool use of these classes
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
        /// Creates vector with components
        /// </summary>
        /// <param name="compenents">In the order x then y</param>
        public R2Vector(List<float> compenents)
        {
            x = compenents[0];
            y = compenents[1];
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

        public void scalarMult(float mult)
        {
            x *= mult;
            y *= mult;
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
        /// Creates vector with components
        /// </summary>
        /// <param name="compenents">In the order x then y then z</param>
        public R3Vector(List<float> compenents)
        {
            x = compenents[0];
            y = compenents[1];
            z = compenents[2];
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

    public class RNVector
    {
        public List<float> components = new List<float>();

        public RNVector(List<float> _components)
        {
            components = _components;
        }

        public float magnetude()
        {
            float compSum = 0;
            foreach (float c in components)
            {
                compSum += (float)Math.Pow(c, 2);
            }

            return (float)Math.Sqrt(compSum);
        }

        public Matrix ToMatrix()
        {
            return new Matrix(components, 1);
        }

        public void scalarMult(float mult)
        {
            for(int i = 0; i < components.Count; i++)
            {
                components[i] *= mult;
            }
        }

        public void noramlize()
        {
            float mag = magnetude();
            for (int i = 0; i < components.Count; i++)
            {
                components[i] /= mag;
            }
        }

        public float dot(RNVector vec)
        {
            float dotSum = 0;

            for(int i = 0; i < components.Count; i++)
            {
                dotSum += components[i] * vec.components[i];
            }
            return dotSum;
        }
    }

    public class Matrix
    {
        public List<List<float>> MRows = new List<List<float>>();

        /// <summary>
        /// Takes in a list of enteries and makes a nxm Matrix
        /// </summary>
        /// <param name="orderedEntries">Enteries of the matrix ie.
        /// row 1 : [1 2 3]
        /// row 2 : [2 5 7]
        /// would be put in a list in the order {1,2,3,2,5,7}
        /// </param>
        /// <param name="cols">numbers of cols of the matrix</param>
        public Matrix(List<float> orderedEntries, int cols)
        {
            List<float> row = new List<float>();
            for (int i = 0; i < orderedEntries.Count; i++)
            {
                row.Add(orderedEntries[i]);

                if (row.Count == cols)
                {
                    MRows.Add(row);
                    row = new List<float>();
                }
            }

            if(MRows.Count == 0)
            {
                MRows.Add(row);
            }
        }

        public Matrix()
        {

        }

        public RNVector ToVec()
        {
            List<float> comps = new List<float>();
            for(int i = 0; i < MRows.Count; i++)
            {
                comps.Add(MRows[i][0]);
            }

            return new RNVector(comps);
        }

        public void add(Matrix m2)
        {
            if (MRows.Count == m2.MRows.Count && MRows[0].Count == m2.MRows[0].Count)
            {
                for (int i = 0; i < MRows.Count; i++)
                {
                    for (int j = 0; j < MRows[i].Count; i++)
                    {
                        MRows[i][j] += m2.MRows[i][j];
                    }
                }
            }
        }

        public Matrix mult(Matrix m2)
        {
            List<RNVector> rowVectors = new List<RNVector>();
            List<RNVector> rowVectors2 = new List<RNVector>();

            //get rows of first matrix 
            for (int i = 0; i < MRows.Count; i++)
            {
                RNVector rN = new RNVector(MRows[i]);
                rowVectors.Add(rN);             
            }

            //get cols of second matrix 
            for (int x = 0; x < m2.MRows[0].Count; x++)
            {
                List<float> colComps = new List<float>();
                for (int y = 0; y < m2.MRows.Count; y++)
                {
                    colComps.Add(m2.MRows[y][x]);
                }

                RNVector rN = new RNVector(colComps);
                rowVectors2.Add(rN);
            }

            //same number of cols as second matrix
            int cols = m2.MRows[0].Count;

            List<float> orderedEntries = new List<float>();

            //same number of rows as first matrix
            for(int i = 0; i < MRows.Count; i++)
            {
                for (int c = 0; c < cols; c++)
                {
                    orderedEntries.Add(rowVectors[i].dot(rowVectors2[c]));
                }              
            }

            return new Matrix(orderedEntries, cols);
        }
    }

    public class AugMatrix
    {
        List<List<float>> MRows = new List<List<float>>();
        //List<float> MConstants = new List<float>();
       
        public AugMatrix(List<float> coeffs, List<float> consts, int cols)
        {
            List<float> row = new List<float>();
            //MConstants = consts;
            int rCount = 0;

            for (int i = 0; i < coeffs.Count; i++)
            {
                row.Add(coeffs[i]);

                if (row.Count == cols)
                {
                    row.Add(consts[rCount]);
                    rCount++;
                    MRows.Add(row);
                    row = new List<float>();
                }
            }
        }

        public List<float> solve()
        {
            int workingCol = 0;
            for (int i = 0; i < MRows.Count; i++)
            {
                if (MRows[i][workingCol] == 0)
                {
                    int next = 0;

                    for(int x = 0; x < MRows.Count; x++)
                    {
                        if(MRows[x][workingCol] != 0)
                        {
                            next = x;
                            break;
                        }
                    }

                    R1(i, next);
                }

                if (MRows[i][workingCol] != 1 && MRows[i][workingCol] != 0)
                {
                    R2(i, 1 / MRows[i][workingCol]);
                }

                for (int j = 0; j < MRows.Count; j++)
                {
                    if (j != i)
                    {

                        R3(i, j, -MRows[j][workingCol]/ MRows[i][workingCol]);
                    }
                }

                workingCol++;
            }


            List<float> solutions = new List<float>();
            foreach(List<float> row in MRows)
            {
               solutions.Add(row[row.Count - 1]);
            }

            return solutions;
        }   
        
        /// <summary>
        /// Interchages Rows
        /// </summary>
        public void R1(int r1Index, int r2Index)
        {
            List<float> r1 = new List<float>();                
            r1.AddRange(MRows[r1Index]);
            List<float> r2 = new List<float>();
            r2.AddRange(MRows[r2Index]);

            for(int i = 0; i < r1.Count; i++)
            {
                MRows[r1Index][i] = r2[i];
                MRows[r2Index][i] = r1[i];
            }
        }

        public void R2(int rowIndex, float mult)
        {
            for(int i = 0; i < MRows[rowIndex].Count; i++)
            {
                MRows[rowIndex][i] *= mult;
            }
        }

        /// <summary>
        /// adds scalar multiple of one row to another
        /// </summary>
        /// <param name="r1Index">row that will be added</param>
        /// <param name="r2Index">row that will be changed due to the addition</param>
        /// <param name="mult">the scalar multiplier</param>
        public void R3(int r1Index, int r2Index, float mult)
        {
            for (int i = 0; i < MRows[r2Index].Count; i++)
            {
                MRows[r2Index][i] += mult * MRows[r1Index][i];
            }
        }

    }
}
