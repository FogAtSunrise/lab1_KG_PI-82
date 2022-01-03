using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_KG_PI_82
{
    class Object3d
    {
        //
        //матрица
        //
        MatrixFor3d matrix;
        //
        //список ребер
        //
        public List<Tuple<Point3d, Point3d>> edgeList;
        //
        //список точек
        //
        public List<Point3d> pointList;
        //
        //Копия списка
        //
        public List<Point3d> copyPointList;
        //
        //конструктор
        //
        public Object3d()
        {
            edgeList = new List<Tuple<Point3d, Point3d>>();
            pointList = new List<Point3d>();
            copyPointList = new List<Point3d>();
            matrix = new MatrixFor3d();
            makeObj();
        }

        //задание обхекта (заполняю список точек и ребер)
        void makeObj()
        {
            shiftPoints();
            copy(pointList, copyPointList);
            shiftEdges();
        }

        public void copy(List<Point3d> first, List<Point3d> second)
        {
            if (second != null)
                second.Clear();
            foreach (Point3d el in first)
            {
                second.Add(new Point3d(el));
            }
        }

        private void shiftPoints()
        {
            pointList.Clear();

            // Буква В
            for (float h = 0; h <= 10; h += 10)
            {
                pointList.Add(new Point3d(0, 0, h));
                pointList.Add(new Point3d(20, 0, h));
                pointList.Add(new Point3d(20, 20, h));
                pointList.Add(new Point3d(40, 0, h));
                pointList.Add(new Point3d(70, 0, h));
                pointList.Add(new Point3d(90, 20, h));
                pointList.Add(new Point3d(90, 60, h));
                pointList.Add(new Point3d(60, 80, h));
                pointList.Add(new Point3d(80, 100, h));
                pointList.Add(new Point3d(80, 120, h));
                pointList.Add(new Point3d(60, 140, h));
                pointList.Add(new Point3d(40, 140, h));
                pointList.Add(new Point3d(20, 120, h));
                pointList.Add(new Point3d(20, 140, h));
                pointList.Add(new Point3d(0, 140, h));
                pointList.Add(new Point3d(0, 0, h));

            }

            for (float h = 0; h <= 10; h += 10)
            {

                pointList.Add(new Point3d(20, 40, h));
                pointList.Add(new Point3d(40, 20, h));
                pointList.Add(new Point3d(70, 20, h));
                pointList.Add(new Point3d(70, 50, h));
                pointList.Add(new Point3d(60, 60, h));
                pointList.Add(new Point3d(20, 60, h));
                pointList.Add(new Point3d(20, 40, h));

            }

            for (float h = 0; h <= 10; h += 10)
            {

                pointList.Add(new Point3d(20, 80, h));
                pointList.Add(new Point3d(20, 100, h));
                pointList.Add(new Point3d(40, 120, h));
                pointList.Add(new Point3d(60, 120, h));
                pointList.Add(new Point3d(60, 100, h));
                pointList.Add(new Point3d(40, 80, h));
                pointList.Add(new Point3d(20, 80, h));

            }
        }

        public void shiftEdges()
        {
            edgeList.Clear();
            int countHalf = pointList.Count() / 2;
            countHalf = 16;
            for (int i = 0; i < countHalf; i++)
            {
                edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i], pointList[i + countHalf]));
                if (i > 0)
                {
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i + countHalf - 1], pointList[i + countHalf]));
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i - 1], pointList[i]));
                }
            }
            countHalf = 7;
            for (int i = 32; i < 39; i++)
            {
                edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i], pointList[i + countHalf]));
                if (i > 32)
                {
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i + countHalf - 1], pointList[i + countHalf]));
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i - 1], pointList[i]));
                }
            }

            countHalf = 7;
            for (int i = 46; i < 53; i++)
            {
                edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i], pointList[i + countHalf]));
                if (i > 46)
                {
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i + countHalf - 1], pointList[i + countHalf]));
                    edgeList.Add(new Tuple<Point3d, Point3d>(pointList[i - 1], pointList[i]));
                }
            }
        }
        private void changeCoords()
        {
            float[] vct = new float[4];
            float[] res = new float[4];
            for (int i = 0; i < pointList.Count; i++)
            {
                Point3d p1 = pointList[i];
                vct[0] = p1.X; vct[1] = p1.Y; vct[2] = p1.Z; vct[3] = 1.0F;
                res = matrix.multOnVect(vct);
                p1.X = res[0];
                p1.Y = res[1];
                p1.Z = res[2];
            }

            shiftEdges();

        }


        public void moving(float toX, float toY, float toZ)
        {
            matrix.matrixZero();
            matrix.value[0][0] = 1.0F;
            matrix.value[1][1] = 1.0F;
            matrix.value[2][2] = 1.0F;
            matrix.value[3][0] = toX;
            matrix.value[3][1] = toY;
            matrix.value[3][2] = toZ;
            matrix.value[3][3] = 1.0F;
            changeCoords();

        }

        public void rotate(float[][] matr, float[] mov)
        {
            moving(-mov[0], -mov[1], -mov[2]);
            matrix.value = matr;
            changeCoords();
            moving(mov[0], mov[1], mov[2]);
        }

        public void rotateX(float mean, float[] mov)
        {
            float cosA = (float)Math.Cos(mean);
            float sinA = (float)Math.Sin(mean);

            float[][] matr = new float[][]
        {
            new float[] {1, 0, 0, 0},
            new float[] {0, cosA, sinA, 0},
            new float[] {0, -sinA, cosA, 0},
            new float[] {0, 0, 0, 1}
        };
            rotate(matr, mov);
        }

        public void rotateY(float mean, float[] mov)
        {
            float cosA = (float)Math.Cos(mean);
            float sinA = (float)Math.Sin(mean);

            float[][] matr = new float[][]
        {
                    new float[] {cosA, 0, -sinA, 0},
                    new float[] {0, 1, 0 , 0},
                    new float[] {sinA, 0, cosA, 0},
                    new float[] {0, 0, 0, 1}
        };
            rotate(matr, mov);
        }

        public void rotateZ(float mean, float[] mov)
        {
            float cosA = (float)Math.Cos(mean);
            float sinA = (float)Math.Sin(mean);

            float[][] matr = new float[][]
        {
                    new float[] {cosA, sinA, 0, 0},
                    new float[] {-sinA, cosA, 0 , 0},
                    new float[] {0, 0, 1, 0},
                    new float[] {0, 0, 0, 1}
        };
            rotate(matr, mov);
        }


        public void scale(float[] siz)
        {
            // moving(-mov[0], -mov[1], -mov[2]);
            matrix.value = new float[][]
        {
                    new float[] { siz[0], 0, 0, 0},
                    new float[] {0, siz[1], 0 , 0},
                    new float[] {0, 0, siz[2], 0},
                    new float[] {0, 0, 0, 1}
        };
            changeCoords();
            //moving(mov[0], mov[1], mov[2]);
        }
        public void chaneObj(int numb, float[] step)
        {
            if (numb >= pointList.Count || numb < 0)
            { return; }

            pointList[numb].X += step[0];
            pointList[numb].Y += step[1];
            pointList[numb].Z += step[2];
            shiftEdges();

        }
    }

   
}
