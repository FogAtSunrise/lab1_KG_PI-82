using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_KG_PI_82
{
    public partial class MainWin : Form
    {
        private const float orientation = 200;
        Object3d myObj;
        float offset = 5F;

        float []allMoving = new float[3]{0,0,0};
        public MainWin()
        {
            InitializeComponent();
            myObj = new Object3d();

            pictureBox1.Refresh();
            timer1.Start();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //оси 
            //1 0 0 0
            //0 -1 0 0 
            //-0.5* cos(PI / 4)  0.5* cos(PI / 4)  0  0
            // 0 0 0 1
            e.Graphics.TranslateTransform(pictureBox1.ClientSize.Width / 2, ClientSize.Height / 2);
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), orientation, 0, 0, 0);
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), 0, -orientation, 0, 0);
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), float.Parse((-(orientation /2) * Math.Cos(Math.PI / 4)).ToString()),
                                float.Parse(((orientation/2) * Math.Cos(Math.PI / 4)).ToString()), 0, 0);

            //если объект задан, выводим
            if (myObj != null)
            drawObject(sender, e, myObj);
        }

    //вывод объекта
        private void drawObject(object sender, PaintEventArgs e, Object3d obj)
        {
            float a, b, c, d;
          
            foreach (var edge in obj.edgeList)
            {
                a = edge.Item1.X - float.Parse((edge.Item1.Z * 0.5 * Math.Cos(Math.PI / 4)).ToString());
                b = -edge.Item1.Y + float.Parse((edge.Item1.Z * 0.5 * Math.Cos(Math.PI / 4)).ToString());
                c = edge.Item2.X - float.Parse((edge.Item2.Z * 0.5 * Math.Cos(Math.PI / 4)).ToString());
                d = -edge.Item2.Y + float.Parse((edge.Item2.Z * 0.5 * Math.Cos(Math.PI / 4)).ToString());
               
                e.Graphics.DrawLine(new Pen(Color.Black, 1), a, b, c, d);
       
            }
        }

       float continuousMovementX = 0, continuousMovementY = 0, continuousMovementZ = 0;
        private void buttonXper0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementX = offset;
            
        }

        private void buttonXper0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementX = 0;
        }

    
        private void buttonXper1_MouseDown_1(object sender, MouseEventArgs e)
        {
            continuousMovementX = -offset;
   
        }
        private void buttonXper1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementX = 0;
        }

        private void buttonYper0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementY = offset;
           
        }

        private void buttonYper0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementY = 0;
        }
        private void buttonYper1_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementY = -offset;
            
        }

        private void buttonYper1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementY = 0;
        }
        private void buttonZper0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementZ = offset;
  
        }

        private void buttonZper0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementZ = 0;
        }

        private void buttonZper1_MouseDown(object sender, MouseEventArgs e)
        {
            continuousMovementZ = -offset;
           
        }

        private void buttonZper1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousMovementZ = 0;
        }

       float rotSpeed = (float)(Math.PI / 180);


        float continuousRotationX = 0, continuousRotationY = 0, continuousRotationZ = 0;

    
  private void buttonXvr0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationX = rotSpeed;
        }
        private void buttonXvr0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationX = 0;
        }

        private void buttonXvr1_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationX = -rotSpeed;
        }

        private void buttonYvr0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationY = rotSpeed;
        }

        private void buttonYvr0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationY = 0;
        }

        private void buttonYvr1_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationY = -rotSpeed;
        }

        private void buttonYvr1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationY = 0;
        }

       

        private void buttonXvr1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationX = 0;
        }

        private void buttonZvr0_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationZ = 0;
        }

 

        private void buttonZvr1_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationZ = -rotSpeed;
        }

     

        private void buttonZvr1_MouseUp(object sender, MouseEventArgs e)
        {
            continuousRotationZ = 0;

        }

        private void buttonZvr0_MouseDown(object sender, MouseEventArgs e)
        {
            continuousRotationZ = rotSpeed;
        }

     

        float scalonX = 1, scalonY = 1, scalonZ = 1, sizeScal=1.05F;

        private void buttonYmas1_MouseDown(object sender, MouseEventArgs e)
        {
            scalonY = sizeScal - 0.1F;
        }

        private void buttonYmas1_MouseUp(object sender, MouseEventArgs e)
        {
            scalonY = 1;
        }

        private void buttonZmas0_MouseDown(object sender, MouseEventArgs e)
        {
            scalonZ = sizeScal;

        }

        private void buttonZmas0_MouseUp(object sender, MouseEventArgs e)
        {
            scalonZ = 1;

        }

        private void buttonZmas1_MouseDown(object sender, MouseEventArgs e)
        {
            scalonZ = sizeScal - 0.1F;
        }

        private void buttonZmas1_MouseUp(object sender, MouseEventArgs e)
        {
            scalonZ = 1;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            myObj.copy(myObj.pointList, myObj.copyPointList);
            timer2.Start();
            buttonStart.Enabled=false;
            buttonZmas1.Enabled = false;
            buttonZmas0.Enabled = false;
            buttonYmas1.Enabled = false;
            buttonYmas0.Enabled = false;
            buttonXmas1.Enabled = false;
            buttonXmas0.Enabled = false;

            buttonZper1.Enabled = false;
            buttonZper0.Enabled = false;
            buttonYper1.Enabled = false;
            buttonYper0.Enabled = false;
            buttonXper1.Enabled = false;
            buttonXper0.Enabled = false;

            buttonZvr1.Enabled = false;
            buttonZvr0.Enabled = false;
            buttonYvr1.Enabled = false;
            buttonYvr0.Enabled = false;
            buttonXvr1.Enabled = false;
            buttonXvr0.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            buttonStart.Enabled = true;
            buttonZmas1.Enabled = true;
            buttonZmas0.Enabled = true;
            buttonYmas1.Enabled = true;
            buttonYmas0.Enabled = true;
            buttonXmas1.Enabled = true;
            buttonXmas0.Enabled = true;

            buttonZper1.Enabled = true;
            buttonZper0.Enabled = true;
            buttonYper1.Enabled = true;
            buttonYper0.Enabled = true;
            buttonXper1.Enabled = true;
            buttonXper0.Enabled = true;

            buttonZvr1.Enabled = true;
            buttonZvr0.Enabled = true;
            buttonYvr1.Enabled = true;
            buttonYvr0.Enabled = true;
            buttonXvr1.Enabled = true;
            buttonXvr0.Enabled = true;

            myObj.copy(myObj.copyPointList, myObj.pointList);
            myObj.shiftEdges();
            pictureBox1.Refresh();

        }

        float maxSpeedOfAnime = 1.1F;
        float minSpeedOfAnime = 0.98F;
        
        float one = 1.0F;
        float sp = 0F;
        float speedChangeOfSpeedOfAnime = 0.01F;
        float x1=0, y1=0, z1=0, del=20;
        
        bool flag = false;
        float x12 = 0;

     

        float ch = -10f;


        bool startMove = true;
        bool dirMov = false;
        float line = 0F;
        
       
        float speedChange = 20;
        int countStep = 10;
        float maxLine = 0;
        float minLine = 0;
        float x=0, y=0, z=0;
        int num=0;
        Point3d copy;
        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if (startMove == true)
            {
                if (copy != null)
                {
                    myObj.pointList[num] = new Point3d(copy);
                    myObj.shiftEdges();
                }
                Random rnd = new Random();
                //Получить случайное число (в диапазоне от -200 до 200)
                num = rnd.Next(0, myObj.pointList.Count-1);
                startMove = false;
                copy = new Point3d(myObj.pointList[num]);
                x = rnd.Next(-200, 200);
                y = rnd.Next(-200, 200);
                z = rnd.Next(-200, 200);
                maxLine = speedChange * countStep;

            }
           
            if (Math.Abs(line) >= maxLine)
            {
                speedChange *= -1;
            }
            else if (Math.Abs(line) <= 10 && speedChange<0)
            {
                startMove = true;
                speedChange *= -1;
                return;
            }
            line += speedChange;
           myObj.moving(-x, -y, -z);
            myObj.chaneObj(num, new float[] {x/speedChange, y/speedChange, z/speedChange});
            myObj.moving(x, y, z);

        }

        private void buttonYmas0_MouseUp(object sender, MouseEventArgs e)
        {
            scalonY = 1;
        }

        private void buttonYmas0_MouseDown(object sender, MouseEventArgs e)
        {
            scalonY = sizeScal;

        }

        private void buttonXmas0_MouseDown(object sender, MouseEventArgs e)
        {
            scalonX = sizeScal;
        }

        private void buttonXmas0_MouseUp(object sender, MouseEventArgs e)
        {
            scalonX = 1;
        }
        private void buttonXmas1_MouseDown(object sender, MouseEventArgs e)
        {
            scalonX = sizeScal-0.1F;
        }

        private void buttonXmas1_MouseUp(object sender, MouseEventArgs e)
        {
            scalonX = 1;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // движение при зажатой клавише

            myObj.moving(continuousMovementX, continuousMovementY, continuousMovementZ);
            allMoving[0] += continuousMovementX;
            allMoving[1] += continuousMovementY;
            allMoving[2] += continuousMovementZ;
            myObj.scale(new float[] { scalonX, scalonY, scalonZ });
           myObj.rotateX(continuousRotationX, allMoving);
            myObj.rotateY(continuousRotationY, allMoving);
            myObj.rotateZ(continuousRotationZ, allMoving);
 
            pictureBox1.Refresh();
          
        }
    }
}
