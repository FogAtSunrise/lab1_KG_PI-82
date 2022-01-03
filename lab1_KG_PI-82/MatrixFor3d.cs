using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_KG_PI_82
{
    class MatrixFor3d
    {
        //
        //значение матрицы
        //
        public float[][] value;
        //
        //конструктор
        //
        public MatrixFor3d()
        {
            value = new float[4][];
            for (int i = 0; i < 4; i++)
            {
                value[i] = new float[4];
                for (int j = 0; j < 4; j++)
                    value[i][j] = 0.0F;
            }
           
        }

        //
        //обнуление
        //
        public void matrixZero()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    value[i][j] = 0.0F;
            }

        }
        //
        //умножение матрицы на вектор
        //
        public float[] multOnVect(float[] vect)
        {
            float[] res = new float[4];
            for (int i = 0; i < 4; i++)
            {
                res[i] = 0;
                for (int j = 0; j < 4; j++)
                    res[i] += vect[j] * value[j][i];
            }
            return res;
        }


    }
}
