using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.DevIl;

namespace lab4
{
    public partial class Form1 : Form
    {
        // вспомогательные переменные - в них будут храниться обработанные значения,
        // полученные при перетаскивании ползунков пользователем
        double a = 0, b = 0, c = -5, d = 0, zoom = 1; // выбранные оси
        int os_x = 1, os_y = 0, os_z = 0;
        // режим сеточной визуализации

        public uint[] mGlTextures = { 0, 0, 0, 0, 0, 0 };
        public int imageId = 0;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

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

        private void loadTextures()
        {
            // создаем изображение с индификатором imageId
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим
            Il.ilBindImage(imageId);

            string url;
            for (int i = 1; i <= 6; i++)
            {
                url = i + ".png";
                //url = i.ToString() + ".png";
                if (Il.ilLoadImage(url))
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
                            mGlTextures[i - 1] = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextures[i - 1] = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    }
                }
            }
            Il.ilDeleteImages(1, ref imageId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки glut
            Glut.glutInit();
            // инициализация режима экрана
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

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
            loadTextures();
            // активация таймера, вызывающего функцию для визуализации
            RenderTimer.Start();
        }

        // обрабатываем отклик таймера
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        // событие изменения значения
        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат
            a = (double)trackBarX.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label_dataX.Text = a.ToString();
        }
        // событие изменения значения
        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат
            b = (double)trackBarY.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label_dataY.Text = b.ToString();
        }
        // событие изменения значения
        private void trackBarZ_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат
            c = (double)trackBarZ.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label_dataZ.Text = c.ToString();
        }
        // событие изменения значения
        private void trackBarAngle_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат
            d = (double)trackBarAngle.Value;
            // подписываем это значение в label элементе под данным ползунком
            label_dataAngle.Text = d.ToString();
        }
        // событие изменения значения
        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            // переводим значение, установившееся в элементе trackBar в необходимый нам формат
            zoom = (double)trackBarZoom.Value / 1000.0;
            // подписываем это значение в label элементе под данным ползунком
            label_dataZoom.Text = zoom.ToString();
        }
        // изменения значения чекбокса
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        // изменение в элементах comboBox
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

            // включаем режим текстурирования
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[0]);
            Gl.glBegin(Gl.GL_QUADS);
            // Нижняя грань
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Верх право
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(1.0f, -1.0f, -1.0f);    // Верх лево
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(1.0f, -1.0f, 1.0f);    // Низ лево
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-1.0f, -1.0f, 1.0f);    // Низ право
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[1]);
            Gl.glBegin(Gl.GL_QUADS);
            // Задняя грань
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Низ право
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-1.0f, 1.0f, -1.0f);    // Верх право
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(1.0f, 1.0f, -1.0f);    // Верх лево
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(1.0f, -1.0f, -1.0f);    // Низ лево
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[2]);
            Gl.glBegin(Gl.GL_QUADS);
            // Верхняя грань
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-1.0f, 1.0f, -1.0f);    // Верх лево
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-1.0f, 1.0f, 1.0f);    // Низ лево
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(1.0f, 1.0f, 1.0f);    // Низ право
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(1.0f, 1.0f, -1.0f);    // Верх право
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[3]);
            Gl.glBegin(Gl.GL_QUADS);
            // Передняя грань
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-1.0f, -1.0f, 1.0f);    // Низ лево
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(1.0f, -1.0f, 1.0f);    // Низ право
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(1.0f, 1.0f, 1.0f);    // Верх право
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-1.0f, 1.0f, 1.0f);    // Верх лево
            Gl.glEnd();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[4]);
            Gl.glBegin(Gl.GL_QUADS);
            // Правая грань
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(1.0f, -1.0f, -1.0f);    // Низ право
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(1.0f, 1.0f, -1.0f);    // Верх право
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(1.0f, 1.0f, 1.0f);    // Верх лево
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(1.0f, -1.0f, 1.0f);    // Низ лево
            Gl.glEnd();


            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextures[5]);
            Gl.glBegin(Gl.GL_QUADS);
            // Левая грань
            Gl.glTexCoord2f(0.0f, 0.0f); Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Низ лево
            Gl.glTexCoord2f(1.0f, 0.0f); Gl.glVertex3f(-1.0f, -1.0f, 1.0f);    // Низ право
            Gl.glTexCoord2f(1.0f, 1.0f); Gl.glVertex3f(-1.0f, 1.0f, 1.0f);    // Верх право
            Gl.glTexCoord2f(0.0f, 1.0f); Gl.glVertex3f(-1.0f, 1.0f, -1.0f);    // Верх лево

            Gl.glEnd();
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            // возвращаем состояние матрицы
            Gl.glPopMatrix();
            // завершаем рисование
            Gl.glFlush();
            // обновляем элемент AnT
            AnT.Invalidate();
        }
    }
}
