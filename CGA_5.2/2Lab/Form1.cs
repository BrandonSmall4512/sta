using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.Platform.Windows;
using Tao.FreeGlut;
using Tao.DevIl;

namespace _2Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Scene.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки glut
            Glut.glutInit();
            // инициализация режима экрана
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            // установка цвета очистки экрана (RGBA)
            //Gl.glClearColor(255, 255, 255, 1);
            Gl.glClearColor(255, 255, 255, 255);
            // установка порта вывода
            Gl.glViewport(0, 0, Scene.Width, Scene.Height);
            // активация проекционной матрицы
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы
            Gl.glLoadIdentity();
            // установка перспективы
            Glu.gluPerspective(45, (float)Scene.Width / (float)Scene.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // начальная настройка параметров openGL (тест глубины, освещение и первый источник света)
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //Gl.glClearColor(255, 255, 255, 1);
            Gl.glClearColor(255, 255, 255, 255);
            // очищение текущей матрицы
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            // возвращаем состояние матрицы
            Gl.glPopMatrix();
            // завершаем рисование
            Gl.glFlush();
            // обновляем элемент AnT
            Scene.Invalidate();

            Il.ilInit();
            // создаем изображение с индификатором imageId
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим
            Il.ilBindImage(imageId);
            if (Il.ilLoadImage($"apple.png"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject1 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject1 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"vetka.png"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject2 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject2 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"list.png"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject3 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject3 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"snake.jpg"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject4 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject4 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"grass.jpg"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject5 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject5 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"snake.jpg"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject6 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject6 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"snake.jpg"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject7 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject7 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            if (Il.ilLoadImage($"eye.jpg"))
            {
                // если загрузка прошла успешно
                // сохраняем размеры изображения
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp) // в зависимости оп полученного результата
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA
                    case 24:
                        mGlTextureObject8 = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject8 = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            position[0].X = 1;
            position[0].Y = 0;
            direction[0] = 3;
            position[1].X = 0;
            position[1].Y = 0;
            direction[1] = 3;
            nextDirection[0] = 3;
            nextDirection[1] = 3;
            a = zoomtrackBar.Value;
            seconds.Interval = 50;
            seconds.Tick += new EventHandler(update);
        }

        private int size = 8;
        private Timer seconds = new Timer();
        public struct dPoint
        {
            public double X;
            public double Y;
        }

        // текстурный объект
        public uint mGlTextureObject1 = 0;
        public uint mGlTextureObject2 = 0;
        public uint mGlTextureObject3 = 0;
        public uint mGlTextureObject4 = 0;
        public uint mGlTextureObject5 = 0;
        public uint mGlTextureObject6 = 0;
        public uint mGlTextureObject7 = 0;
        public uint mGlTextureObject8 = 0;

        // имя текстуры
        public string texture_name = "";
        // индефекатор текстуры
        public int imageId = 0;

        private dPoint[] position = new dPoint[64];
        private dPoint tailPos;
        private int tailDireciton;
        private int tailnextDirection;
        private int[] direction = new int[64];
        private int[] nextDirection = new int[64];
        private int count = 0;
        private int score = -1;
        private bool lose = false;
        private int length = 2;
        private bool newApple = true;
        private dPoint applePosition;
        private int a = 120;

        public void update(object o, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //Gl.glClearColor(0, 255, 255, 1);
            Gl.glClearColor(255, 255, 255, 255);
            // очищение текущей матрицы
            Gl.glLoadIdentity();
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта
            Gl.glPushMatrix();
            Gl.glTranslated(-size/2+0.5,-size/2+0.45, -size-4);
            Gl.glRotated(a, 1, 0, 0);
            build_walls();
            if(size * size != length)
            {
                build_apple();
            }
            build_snake();
            Gl.glPopMatrix();
            label2.Text = $"{score}";
            // завершаем рисование
            Gl.glFlush();
            // обновляем элемент AnT
            Scene.Invalidate();
        }

        public void build_walls()
        {
            Glu.GLUquadric quadr1;
            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject5);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Gl.glBegin(Gl.GL_POLYGON);
                    // указываем поочередно вершины и текстурные координаты
                    //Gl.glVertex3d(-0.5, -0.5, 1);
                    //Gl.glTexCoord2f(0.0f, 0.0f);
                    Gl.glVertex3d(-0.5, 0.5, 1);
                    Gl.glTexCoord2f(0.0f, 1.0f);
                    Gl.glVertex3d(0.5, 0.5, 1);
                    Gl.glTexCoord2f(1.0f, 1.0f);
                    Gl.glVertex3d(0.5, -0.5, 1);
                    Gl.glTexCoord2f(1.0f, 0.0f);
                    Gl.glVertex3d(-0.5, -0.5, 1);
                    Gl.glTexCoord2f(0.0f, 0.0f);
                    Gl.glEnd();
                    //Glut.glutSolidCube(1);
                    Gl.glTranslated(1, 0, 0);
                }
                Gl.glTranslated(-size, 0, 0);
                Gl.glTranslated(0, 1, 0);
            }
            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glTranslated(0, 0, 0.5f);
        }
        
        public void build_apple()
        {
            Glu.GLUquadric quadr1, quadr2, quadr3;
            int d = 1;

            if (newApple)
            {
                score++;
                Random rnd = new Random();
                while (newApple)
                {
                    applePosition.X = rnd.Next(0, size);
                    applePosition.Y = rnd.Next(0, size);
                    newApple = false;
                    for (int i = 0; i < length; i++)
                    {
                        if (applePosition.X < position[i].X+0.3 && applePosition.X > position[i].X-0.3)
                        {
                            if (applePosition.Y < position[i].Y + 0.3 && applePosition.Y > position[i].Y - 0.3)
                            {
                                newApple = true;
                                break;
                            }
                        }
                    }
                }

            }
            // change apple for my figure!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            //Отрисовка сферы с текстурой:
            //quadr1 = Glu.gluNewQuadric();
            //Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glTranslated(applePosition.X, -size+applePosition.Y, 1);
            // включаем режим текстурирования
            double R = 0.5f;
            Glut.glutSolidSphere(R, 16, 16); // полигональная сфера 
            Gl.glTranslated(0, 0, R * 1.33f);
            Glut.glutSolidSphere(R * 0.666f, 16, 16);
            Gl.glTranslated(0, 0, R);
            Glut.glutSolidSphere(R * 0.444f, 16, 16);

            Gl.glTranslated(0, 0, R * 0.296f);
            Glut.glutSolidCylinder(R * 0.666f, R * 0.037f, 16, 16);

            Glut.glutSolidCylinder(R * 0.331f, R * 0.8f, 16, 16);


            Gl.glTranslated(0, 0, -0.74f * R);
            Gl.glRotated(90, 1, 1, 0);
            Glut.glutSolidCylinder(R * 0.111f, -1.5f * R, 16, 16);
            Glut.glutSolidCylinder(R * 0.111f, 1.5f * R, 16, 16);

            Gl.glRotated(-90, 1, 1, 0);
            Gl.glTranslated(R * 0.3f, R * 0.3f, 0.55f * R);
            Glut.glutSolidSphere(R * 0.1f, 16, 16);

            Gl.glTranslated(0, -R * 0.6f, 0);
            Glut.glutSolidSphere(R * 0.1f, 16, 16);

            Gl.glTranslated(0, R * 0.3f, -R * 0.1);
            Gl.glRotated(90, 1, 1, 1);
            Glut.glutSolidCone(R * 0.1f, R * 0.5f, 16, 16);
            Gl.glRotated(-90, 1, 1, 1);
            Gl.glTranslated(-R * 0.3f,0, -R * 2.336f);
            
            /*
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject1);


            Glu.gluSphere(quadr1, 0.3, 32, 32);


            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            /*
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject2);
            
            quadr2 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr2, Gl.GL_TRUE);
            Glu.gluCylinder(quadr2, (double)(0.1), (double)(0.06), (double)(0.8), 8, 8);
            Glu.gluDeleteQuadric(quadr2);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            //Gl.glTranslated(d * 0.1, -d * 0.1, d * 0.3);

            //// включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject3);

            Gl.glTranslated(0, -0.2, 0.4);
            // отрисовываем полигон
            Gl.glBegin(Gl.GL_POLYGON);
            // указываем поочередно вершины и текстурные координаты
            Gl.glVertex3d((double)(0.7), (double)(0.7), 0);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d((double)(0.7), (double)(0.4), 0);
            Gl.glTexCoord2f(0.7f, 0.0f);
            Gl.glVertex3d((double)(-0.2), (double)(0.0), 0);
            Gl.glTexCoord2f(0.5f, 0.5f);
            Gl.glVertex3d((double)(-0.1), (double)(0.4), 0);
            Gl.glTexCoord2f(0.0f, 0.5f);
            // завершаем отрисовку
            Gl.glEnd();
            */
            //отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glTranslated(-applePosition.X, size-applePosition.Y+0.2, -0.4);
        }
        
        public void build_snake()
        {
            if (count == 10)
            {
                for (int i = length-1; i > -1; i--)
                {
                    if(i != 0)
                    direction[i] = nextDirection[i];
                    position[i].X = Math.Round(position[i].X);
                    position[i].Y = Math.Round(position[i].Y);
                }

                if (((int)applePosition.X == (int)position[0].X) && ((int)applePosition.Y == (int)position[0].Y))
                {
                    newApple = true;
                    position[length] = tailPos;
                    direction[length] = tailDireciton;
                    nextDirection[length] = tailnextDirection;
                    length += 1;
                }

                if ((nextDirection[0] ==0 && direction[0]!=1) || (nextDirection[0]==1 && direction[0]!=0) || (nextDirection[0]==2 && direction[0]!=3) || (nextDirection[0]==3 && direction[0]!=2))
                {
                    direction[0] = nextDirection[0];
                    direction[0] = nextDirection[0];
                    for (int i = length-1; i > 0; i--)
                        nextDirection[i] = direction[i-1];
                }

                for(int i = 1; i < length; i++)
                {
                    if(position[i].X == position[0].X)
                    {
                        if(position[i].Y == position[0].Y)
                        {
                            lose = true;
                            break;
                        }
                    }
                }
                if(count == 10)
                    count = 0;
                
                tailPos = position[length-1];
                tailDireciton = direction[length-1];
                tailnextDirection = nextDirection[length-1];
            }

            for (int i = 0; i < length; i++)
            {
                if (direction[i] == 0)
                {
                    if (position[i].Y <= size-1) position[i].Y += 0.1;
                    else lose = true;
                }
                if (direction[i] == 1)
                {
                    if (position[i].Y >= 0) position[i].Y -= 0.1;
                    else lose = true;
                }
                if (direction[i] == 2)
                {
                    if (position[i].X >= 0) position[i].X -= 0.1;
                    else lose = true;
                }
                if (direction[i] == 3)
                {
                    if (position[i].X <= size - 1) position[i].X += 0.1;
                    else lose = true;
                }
            }

            count += 1;

            if (lose)
            {
                score = 0;
                button1.Visible = true;
                lose = false;
                count = 0;
                length = 2;
                direction[0] = 3;
                direction[1] = 3;
                position[0].X = 1;
                position[0].Y = 0;
                position[1].X = 0;
                position[1].Y = 0;
                nextDirection[0] = 3;
                nextDirection[1] = 3;
                seconds.Stop();
                return;
            }

            Glu.GLUquadric quadr1;
            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject6); // текстура шариков//////////////////////////////////////////
            
            for (int i = 1; i < length-1; i++)
            {
                Gl.glTranslated(position[i].X, -size + position[i].Y, 0);
                Glu.gluSphere(quadr1, 0.5, 32, 32);
                Gl.glTranslated(-position[i].X, -(-size + position[i].Y), 0);
            }
            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            /////////////////////////////////////////////////////.................................
            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject3);

            //голова...............................................................................................................................................///////
            Gl.glTranslated(position[0].X, -size + position[0].Y, 0);

            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);


            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject4); //тектура головы

            int angle = 180;
            if (direction[0] == 1) angle = 0;
            else if (direction[0] == 2) angle = -90;
            else if (direction[0] == 3) angle = 90;
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(angle, 0, 1, 0);

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(-0.35f, 0, -0.5f);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(-0.1f, 0, 0.5f);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 0.5f);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0, 0, -0.5f);
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(0.35f, 0, -0.5f);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.1f, 0, 0.5f);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 0.5f);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0, 0, -0.5f);
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();


            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject8); //тектура глаз


            Gl.glTranslated(-0.1f, 0, -0.2f);
            Gl.glRotated(180, 1, 0, 0);

            Gl.glBegin(Gl.GL_POLYGON);
            Glu.gluSphere(quadr1, 0.04f, 32, 32);
            Gl.glTranslated(0.2f, 0, 0);
            Glu.gluSphere(quadr1, 0.04f, 32, 32);


            Gl.glRotated(180, 1, 0, 0);
            Gl.glTranslated(-0.1f, 0, 0.2f);
            Gl.glEnd();



            Gl.glRotated(-angle, 0, 1, 0);
            Gl.glRotated(-90, 1, 0, 0);
            Gl.glTranslated(-position[0].X, size - position[0].Y,0);

            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            quadr1 = Glu.gluNewQuadric();
            Glu.gluQuadricTexture(quadr1, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования , указывая индификатор mGlTextureObject
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject7); //текстура хвоста
            //хвост
            Gl.glTranslated(position[length - 1].X, -size + position[length - 1].Y, 0);
            angle = 0;
            if (direction[length-1] == 1) angle = 180;
            else if (direction[length-1] == 2) angle = 90;
            else if (direction[length-1] == 3) angle = -90;
            Gl.glRotated(angle, 0, 0, 1);
            Gl.glRotated(90, 1, 0, 0);

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(-0.25f, 0, -0.5f);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(-0.1f, 0, 0.5f);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 0.5f);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0, 0, -0.5f);
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3d(0.25f, 0, -0.5f);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(0.01f, 0, 0.5f);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 0, 0.5f);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(0, 0, -0.5f);
            Gl.glTexCoord2f(0, 0);
            Gl.glEnd();
            Gl.glRotated(-90, 1, 0, 0);
            Gl.glRotated(-angle, 0, 0, 1);
            Gl.glTranslated(-position[length - 1].X, size - position[length - 1].Y, 0);

            Glu.gluDeleteQuadric(quadr1);
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            if (length == size*size && count < 11)
            {
                count = 11;
            }
        }

        private void Scene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                nextDirection[0] = 0;
            if (e.KeyCode == Keys.S)
                nextDirection[0] = 1;
            if (e.KeyCode == Keys.A)
                nextDirection[0] = 2;
            if (e.KeyCode == Keys.D)
                nextDirection[0] = 3;
        }

        // создание текстуры в памяти openGL static 
        private uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // индетефекатор текстурного объекта
            uint texObject;

            // генерируем текстурный объект
            Gl.glGenTextures(1, out texObject);

            // устанавливаем режим упаковки пикселей
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);

            // создаем привязку к только что созданной текстуре
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);

            // устанавливаем режим фильтрации и повторения текстуры
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);

            // создаем RGB или RGBA текстуру
            switch (Format)
            {
                case Gl.GL_RGB:
                    {
                        Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                        break;
                    }

                case Gl.GL_RGBA:
                    {
                        Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                        break;
                    }
            }

            // возвращаем индетефекатор текстурного объекта

            return texObject;
        }

        private void zoomtrackBar_Scroll(object sender, EventArgs e)
        {
            a = zoomtrackBar.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seconds.Start();
            button1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
