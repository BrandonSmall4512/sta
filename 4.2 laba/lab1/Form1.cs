using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;


namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        // вспомогательные переменные - в них будут храниться обработанные значения, 
        // полученные при перетаскивании ползунков пользователем 
        double a = 0, b = 0, c = -5, d = 0, zoom = 1; // выбранные оси 
        int os_x = 1, os_y = 0, os_z = 0;
        double R = 2;

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат 
            d = (double)trackBar4.Value;
            // подписываем это значение в label элементе под данным ползунком 
            label3.Text = d.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат 
            b = (double)trackBar2.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком 
            label5.Text = b.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат 
            c = (double)trackBar3.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком 
            label6.Text = c.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат 
            zoom = (double)trackBar5.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком 
            label7.Text = zoom.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // если отмечен 
            if (checkBox1.Checked)
            {
                // устанавливаем сеточный режим визуализации 
                Wire = true;
            }
            else
            {
                // иначе - полигональная визуализация 
                Wire = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // в зависимости от выбранного режима 
            switch (comboBox1.SelectedIndex)
            {
                // устанавливаем необходимую ось (будет использована в функции glRotate**) 
                case 0:
                    {
                        os_x = 1;
                        os_y = 0;
                        os_z = 0;
                        break;
                    }
                case 1:
                    {
                        os_x = 0;
                        os_y = 1;
                        os_z = 0;
                        break;
                    }
                case 2:
                    {
                        os_x = 0;
                        os_y = 0;
                        os_z = 1;
                        break;
                    }
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат 
            a = (double)trackBar1.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком 
            label4.Text = a.ToString();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            // вызываем функцию отрисовки сцены 
            Draw();
        }

        // режим сеточной визуализации 
        bool Wire = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();
            // установка перспективы 
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // начальная настройка параметров openGL (тест глубины, освещение и первый источник света) 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            // установка первых элементов в списках combobox 
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            // активация таймера, вызывающего функцию для визуализации 
            RenderTimer.Start();

        }

        // функция отрисовки 
        private void Draw()
        {
            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы 
            Gl.glLoadIdentity();
            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта 
            Gl.glPushMatrix();
            // производим перемещение в зависимости от значений, полученных при перемещении ползунков 
            Gl.glTranslated(a, b, c);
            // поворот по установленной оси 
            Gl.glRotated(d, os_x, os_y, os_z);
            // и масштабирование объекта 
            Gl.glScaled(zoom, zoom, zoom);
            // в зависимости от установленного типа объекта 
            switch (comboBox2.SelectedIndex)
            {
                // рисуем нужный объект, используя функции библиотеки GLUT 
                case 0:
                    {
                        if (Wire) // если установлен сеточный режим визуализации 
                            Glut.glutWireSphere(2, 16, 16); // сеточная сфера 
                        else
                            Glut.glutSolidSphere(2, 16, 16); // полигональная сфера 
                        break;
                    }
                case 1:
                    {
                        if (Wire) // если установлен сеточный режим визуализации 
                            Glut.glutWireCylinder(1, 2, 32, 32); // цилиндр 
                        else
                            Glut.glutSolidCylinder(1, 2, 32, 32);
                        break;
                    }
                case 2:
                    {
                        if (Wire) // если установлен сеточный режим визуализации 
                            Glut.glutWireCube(2); // куб 
                        else
                            Glut.glutSolidCube(2);
                        break;
                    }
                case 3:
                    {
                        if (Wire) // если установлен сеточный режим визуализации 
                            Glut.glutWireCone(2, 3, 32, 32); // конус 
                        else
                            Glut.glutSolidCone(2, 3, 32, 32);
                        break;
                    }
                case 4:
                    {
                        if (Wire) // если установлен сеточный режим визуализации 
                            Glut.glutWireTorus(0.2, 2.2, 32, 32); // тор 
                        else
                            Glut.glutSolidTorus(0.2, 2.2, 32, 32);
                        break;
                    }
                case 5:
                    {
                        draw_snowman();
                        break;
                    }
                case 6:
                    {
                        draw_sth();
                        break;
                    }
            }
            // возвращаем состояние матрицы 
            Gl.glPopMatrix();
            // завершаем рисование 
            Gl.glFlush();
            // обновляем элемент AnT 
            AnT.Invalidate();
        }
        private void draw_sth()
        {
            Gl.glRotated(90, 1, 0, 0);
            if (Wire)
            {
                Glut.glutWireCylinder(R, R * 0.1f, 16, 16);
                Gl.glRotated(-90, 1, 0, 0);
                draw_rifle(0, 0, R * 0.2f, R * 0.1f);
                Gl.glRotated(-90, 0, 1, 0);
                Gl.glRotated(90, 1, 0, 0);
                draw_rifle(R * 0.2f,R*0.7f, -0.2*R, R * 0.06f);
            }
            else
            {
                Glut.glutSolidCylinder(R, R * 0.1f, 16, 16);
                Gl.glRotated(-90, 1, 0, 0);
                draw_rifle(0, 0, R * 0.2f, R * 0.1f);
                Gl.glRotated(-90, 0, 1, 0);
                Gl.glRotated(90, 1, 0, 0);
                draw_rifle(R * 0.2f, R * 0.7f, -0.2 * R, R * 0.06f);
            }
        }
        private void draw_rifle(double x, double y, double z, double k)
        {
            Gl.glRotated(-90, 1, 0, 0);
            Gl.glTranslated(x, y, z);
            if (Wire)
            {
                Gl.glTranslated(-8*k, 0, 2 * k);
                Glut.glutWireCube(k);
                Gl.glRotated(90, 0, 1, 0);
                Glut.glutWireCylinder(k * 0.4f, 17 * k, 16, 16);
                Gl.glTranslated(0, 0, 6 * k);
                Glut.glutWireCylinder(k * 0.8f, 7*k, 16, 16);
                
                Gl.glTranslated(0, 0, 4.5f * k);     // draw a paralellepiped
                Gl.glRotated(120, 0, 1, 0);
                Glut.glutWireCylinder(k * 0.6f, 3 * k, 4, 4);

                Gl.glRotated(-45, 0, 1, 0);
                Gl.glTranslated(-2*k, 0, 0);
                Glut.glutWireCylinder(k * 0.4f, 3 * k, 4, 4);

                Gl.glRotated(45, 0, 1, 0);
                Gl.glRotated(-120, 0, 1, 0);

                Gl.glTranslated(0.3f*k, 0, 4 * k);
                Gl.glRotated(90, 0, 1, 0);
                Glut.glutWireCylinder(0.4f * k, 2 * k, 4, 4);
                Gl.glRotated(-90, 0, 1, 0);

                Gl.glTranslated(k, 0, -4.5f * k);
                Gl.glRotated(90, 1, 0, 0);
                Glut.glutWireTorus(k * 0.1f, k * 0.5f, 16, 16);

                Gl.glRotated(-90, 1, 0, 0);
                Gl.glTranslated(-1.7f * k, 0, -5.8f * k);
                Glut.glutWireTorus(k * 0.1f, k*0.3, 16, 16);

            }
            else
            {
                Gl.glTranslated(-8 * k, 0, 2 * k);
                Glut.glutSolidCube(k);
                Gl.glRotated(90, 0, 1, 0);
                Glut.glutSolidCylinder(k * 0.4f, 17 * k, 16, 16);
                Gl.glTranslated(0, 0, 6 * k);
                Glut.glutSolidCylinder(k * 0.8f, 7 * k, 16, 16);

                Gl.glTranslated(0, 0, 4.5f * k);     // draw a paralellepiped
                Gl.glRotated(120, 0, 1, 0);
                Glut.glutSolidCylinder(k * 0.6f, 3 * k, 4, 4);

                Gl.glRotated(-45, 0, 1, 0);
                Gl.glTranslated(-2 * k, 0, 0);
                Glut.glutSolidCylinder(k * 0.4f, 3 * k, 4, 4);

                Gl.glRotated(45, 0, 1, 0);
                Gl.glRotated(-120, 0, 1, 0);

                Gl.glTranslated(0.3f * k, 0, 4 * k);
                Gl.glRotated(90, 0, 1, 0);
                Glut.glutSolidCylinder(0.4f * k, 2 * k, 4, 4);
                Gl.glRotated(-90, 0, 1, 0);

                Gl.glTranslated(k, 0, -4.5f * k);
                Gl.glRotated(90, 1, 0, 0);
                Glut.glutSolidTorus(k * 0.1f, k * 0.5f, 16, 16);

                Gl.glRotated(-90, 1, 0, 0);
                Gl.glTranslated(-1.7f * k, 0, -5.8f * k);
                Glut.glutSolidTorus(k * 0.1f, k * 0.3, 16, 16);

           
            }
        }
        private void draw_snowman()
        {
            Gl.glRotated(45, 0, 0, 1);
            Gl.glRotated(180, 1, 0, 0);
            if (Wire)
            {  // если установлен сеточный режим визуализации 
                
                Glut.glutWireSphere(R, 16, 16); // сеточная сфера 
                Gl.glTranslated(0, 0, R * 1.33f);
                Glut.glutWireSphere(R*0.666f , 16, 16);
                Gl.glTranslated(0, 0, R);
                Glut.glutWireSphere(R * 0.444f, 16, 16);

                Gl.glTranslated(0, 0, R*0.296f);
                Glut.glutWireCylinder(R * 0.666f, R * 0.037f, 16, 16);

                Glut.glutWireCylinder(R * 0.331f, R * 0.8f, 16, 16);

                Gl.glTranslated(0, 0, -0.74f * R);
                Gl.glRotated(90, 1, 1, 0);
                Glut.glutWireCylinder(R * 0.111f, -1.5f * R, 16, 16);
                Glut.glutWireCylinder(R * 0.111f, 1.5f * R, 16, 16);

                Gl.glRotated(-90, 1, 1, 0);
                Gl.glTranslated(R*0.3f,R*0.3f , 0.55f * R);
                Glut.glutWireSphere(R*0.1f, 16, 16);

                Gl.glTranslated(0, -R * 0.6f, 0);
                Glut.glutWireSphere(R * 0.1f, 16, 16);

                Gl.glTranslated(0, R * 0.3f, -R * 0.1);
                Gl.glRotated(90, 1, 1, 1);
                Glut.glutWireCone(R * 0.1f, R*0.5f , 16, 16);

            }
            else
            {
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
                Glut.glutSolidCone(R * 0.1f, R*0.5f, 16, 16);

          
            }
        }
    }
}
