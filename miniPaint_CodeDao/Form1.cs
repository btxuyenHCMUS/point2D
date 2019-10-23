using System;
using System.Diagnostics;
using SharpGL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniPaint_CodeDao
{
    public partial class miniPaint : Form
    {
        //Đối tượng hình ảnh cha, dùng tính kế thừa trong hướng đối tượng để cài đặt
        public abstract class imageObject
        {
            public Point pStart, pEnd;
            public Color borderColor, bgroudColor;  //màu đường viền và màu nền;
            public float lineWidth;     //độ dày của nét vẽ
            public bool isBrush;        //Có tô màu nền

            //Contructor
            public imageObject()
            {
                borderColor = Color.White;
                bgroudColor = Color.Black;
                lineWidth = 1;
                isBrush = false;
            }
            //Cài đặt
            public void set(Point start, Point end)
            {
                pStart = start;
                pEnd = end;
            }
            //thiết đặt màu viền
            public void setBorderColor(Color borderUser)
            {
                borderColor = borderUser;
            }
            //thiêt đặt màu nền cho ảnh
            public void setbgroudColor(Color bgroud)
            {
                bgroudColor = bgroud;
            }
            //thiết đặt độ dày nét vẽ
            public void setLineWidth(float lie)
            {
                lineWidth = lie;
            }
            //thiết đặt tọa độ khi di chuyển chuột
            public virtual void setPoint(Point start, Point end) { }
            //3 hàm ảo để vẽ hình, tô màu và hiển thị controlPoint
            public virtual void drawObject(OpenGL gl) { }
            public virtual void brushObject(OpenGL gl) { }
            public virtual void viewControlPoint(OpenGL gl) { }
            //Hàm xoay ảnh
            public virtual void Affine(int degree) { }
            //Hàm di chuyển ảnh
            public virtual void move(int deltaX, int deltaY) { }
        }
        //Đường thẳng, kế thừa object hình ảnh, dùng thuật toán của sharpGl để vẽ
        public class Line : imageObject
        {
            private Point A, B;
            public Line() { }
            public override void setPoint(Point start, Point end)
            {
                A = start;
                B = end;
            }
            //ghi đề phương thức vẽ từ đối tượng cha
            public override void drawObject(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);

                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);

                gl.End();
                gl.LineWidth(lineWidth);
            }
            //Hiện control point
            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(1.0, 0, 0, 0);
                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);
                gl.End();
                gl.PointSize(lineWidth + 10);
            }
            //hàm xoay ảnh
            public override void Affine(int degree)
            {
                Point Atmp = A;
                Point Btmp = B;
                Point ct = A;
                ct.X = (A.X + B.X) / 2;
                ct.Y = (A.Y + B.Y) / 2;
                Atmp.X -= ct.X;
                Atmp.Y -= ct.Y;
                Btmp.X -= ct.X;
                Btmp.Y -= ct.Y;
                float grad = (float)((degree * 3.14) / 180);
                A.X = (int)(Math.Cos(grad) * Atmp.X - Math.Sin(grad) * Atmp.Y) + ct.X;
                A.Y = (int)(Math.Sin(grad) * Atmp.X + Math.Cos(grad) * Atmp.Y) + ct.Y;
                B.X = (int)(Math.Cos(grad) * Btmp.X - Math.Sin(grad) * Btmp.Y) + ct.X;
                B.Y = (int)(Math.Sin(grad) * Btmp.X + Math.Cos(grad) * Btmp.Y) + ct.Y;
            }
            //hàm tịnh tiến ảnh
            public override void move(int deltaX, int deltaY)
            {
                A.X += deltaX;
                A.Y += deltaY;
                B.X += deltaX;
                B.Y += deltaY;
            }
        }
        //Đối tượng hình chữ nhật, tương tự như đường thẳng
        public class Rectangle : imageObject
        {
            private Point A, B, C, D;
            public Rectangle() { }
            public override void setPoint(Point start, Point end)
            {
                A = start;
                C = end;
                B = start;
                B.X = end.X;
                D = end;
                D.X = start.X;
            }
            //Vẽ hình chữ nhật, với các phương thức ghi đè
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }

                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);
                gl.Vertex(C.X, gl.RenderContextProvider.Height - C.Y);
                gl.Vertex(D.X, gl.RenderContextProvider.Height - D.Y);

                gl.End();
                gl.LineWidth(lineWidth);
            }
            //Hiển thị controlPoint
            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(1.0, 0, 0, 0);
                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);
                gl.Vertex(C.X, gl.RenderContextProvider.Height - C.Y);
                gl.Vertex(D.X, gl.RenderContextProvider.Height - D.Y);
                gl.End();
                gl.PointSize(lineWidth + 10);
            }
            //Xoay ảnh
            public override void Affine(int degree)
            {
                Point Atmp = A, Btmp = B, Ctmp = C, Dtmp = D;
                Point ct = A;
                ct.X = (A.X + C.X) / 2;
                ct.Y = (A.Y + C.Y) / 2;
                Atmp.X -= ct.X;
                Atmp.Y -= ct.Y;
                Btmp.X -= ct.X;
                Btmp.Y -= ct.Y;
                Ctmp.X -= ct.X;
                Ctmp.Y -= ct.Y;
                Dtmp.X -= ct.X;
                Dtmp.Y -= ct.Y;
                float grad = (float)((degree * 3.14) / 180);
                A.X = (int)(Math.Cos(grad) * Atmp.X - Math.Sin(grad) * Atmp.Y) + ct.X;
                A.Y = (int)(Math.Sin(grad) * Atmp.X + Math.Cos(grad) * Atmp.Y) + ct.Y;
                B.X = (int)(Math.Cos(grad) * Btmp.X - Math.Sin(grad) * Btmp.Y) + ct.X;
                B.Y = (int)(Math.Sin(grad) * Btmp.X + Math.Cos(grad) * Btmp.Y) + ct.Y;
                C.X = (int)(Math.Cos(grad) * Ctmp.X - Math.Sin(grad) * Ctmp.Y) + ct.X;
                C.Y = (int)(Math.Sin(grad) * Ctmp.X + Math.Cos(grad) * Ctmp.Y) + ct.Y;
                D.X = (int)(Math.Cos(grad) * Dtmp.X - Math.Sin(grad) * Dtmp.Y) + ct.X;
                D.Y = (int)(Math.Sin(grad) * Dtmp.X + Math.Cos(grad) * Dtmp.Y) + ct.Y;
            }
            //Hàm di chuyển ảnh
            public override void move(int deltaX, int deltaY)
            {
                A.X += deltaX;
                A.Y += deltaY;
                B.X += deltaX;
                B.Y += deltaY;
                C.X += deltaX;
                C.Y += deltaY;
                D.X += deltaX;
                D.Y += deltaY;
            }
        }
        //Đối tượng hình tam giác cân
        public class Triangle : imageObject
        {
            private Point A, B, C;
            public Triangle() { }
            public override void setPoint(Point start, Point end)
            {
                A.X = (start.X + end.X) / 2;
                A.Y = start.Y;
                B = end;
                C.X = start.X;
                C.Y = end.Y;
            }
            //Vẽ hình dựa vào thuật toán của sharpGL
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }

                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);
                gl.Vertex(C.X, gl.RenderContextProvider.Height - C.Y);

                gl.End();
                gl.LineWidth(lineWidth);
            }
            //Hiển thị controlPoint
            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(255 / 255.0, 0, 0, 0);
                gl.Vertex(A.X, gl.RenderContextProvider.Height - A.Y);
                gl.Vertex(B.X, gl.RenderContextProvider.Height - B.Y);
                gl.Vertex(C.X, gl.RenderContextProvider.Height - C.Y);
                gl.End();
                gl.PointSize(lineWidth + 10);
            }
            //Xoay ảnh
            public override void Affine(int degree)
            {
                Point Atmp = A, Btmp = B, Ctmp = C;
                Point ct = A;
                ct.X = A.X;
                ct.Y = (A.Y + C.Y) / 2;
                Atmp.X -= ct.X;
                Atmp.Y -= ct.Y;
                Btmp.X -= ct.X;
                Btmp.Y -= ct.Y;
                Ctmp.X -= ct.X;
                Ctmp.Y -= ct.Y;
                float grad = (float)((degree * 3.14) / 180);
                A.X = (int)(Math.Cos(grad) * Atmp.X - Math.Sin(grad) * Atmp.Y) + ct.X;
                A.Y = (int)(Math.Sin(grad) * Atmp.X + Math.Cos(grad) * Atmp.Y) + ct.Y;
                B.X = (int)(Math.Cos(grad) * Btmp.X - Math.Sin(grad) * Btmp.Y) + ct.X;
                B.Y = (int)(Math.Sin(grad) * Btmp.X + Math.Cos(grad) * Btmp.Y) + ct.Y;
                C.X = (int)(Math.Cos(grad) * Ctmp.X - Math.Sin(grad) * Ctmp.Y) + ct.X;
                C.Y = (int)(Math.Sin(grad) * Ctmp.X + Math.Cos(grad) * Ctmp.Y) + ct.Y;
            }
            //Hàm tịnh tiến ảnh
            public override void move(int deltaX, int deltaY)
            {
                A.X += deltaX;
                A.Y += deltaY;
                B.X += deltaX;
                B.Y += deltaY;
                C.X += deltaX;
                C.Y += deltaY;
            }
        }
        //Đổi tượng hình tròn bằng thuật toán midPoint
        public class Circle : imageObject
        {
            public int R;       //bán kình của hình trong (R>0)
            public Point Center;    //Tọa độ tâm
            public Circle() { }
            //tính toán các trị dựa vào 2 điểm đầu vào
            public override void setPoint(Point start, Point end)
            {
                Center.X = (start.X + end.X) / 2;
                Center.Y = (start.Y + start.Y) / 2;
                if (Math.Abs(start.X - Center.X) >= Math.Abs(start.Y - Center.Y))
                    R = Math.Abs(start.X - Center.X);
                else R = Math.Abs(start.Y - Center.Y);
            }
            //phương thức hiển thị 8 điểm đặc biết đối xưng trong hình tròn
            private void put8Pixel(OpenGL gl, int x, int y)
            {
                gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y + y + R));
                gl.Vertex(Center.X + y, gl.RenderContextProvider.Height - (Center.Y + x + R));
                gl.Vertex(Center.X + y, gl.RenderContextProvider.Height - (Center.Y - x + R));
                gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y + R));
                gl.Vertex(Center.X - x, gl.RenderContextProvider.Height - (Center.Y - y + R));
                gl.Vertex(Center.X - y, gl.RenderContextProvider.Height - (Center.Y - x + R));
                gl.Vertex(Center.X - y, gl.RenderContextProvider.Height - (Center.Y + x + R));
                gl.Vertex(Center.X - x, gl.RenderContextProvider.Height - (Center.Y + y + R));
            }
            //Vẽ đối tượng bằng cách cài đặt thuật toán Midpoint
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_POINTS);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }

                int a = 0, b = R;
                put8Pixel(gl, a, b);
                int p = 1 - R;
                while (a < b)
                {
                    if (p < 0)
                        p += 2 * a + 3;
                    else
                    {
                        p += 2 * (a - b) + 5;
                        b--;
                    }
                    a++;
                    put8Pixel(gl, a, b);
                }

                gl.End();
                gl.PointSize(lineWidth);
            }
            //hiển thị controlPoint
            public override void viewControlPoint(OpenGL gl)
            {
                //gl.Begin(OpenGL.GL_LINE_LOOP);
                //gl.Color(1.0, 0, 0, 0);
                //gl.Vertex(Center.X, gl.RenderContextProvider.Height - Center.Y);
                //gl.Vertex(Center.X + R, gl.RenderContextProvider.Height - (Center.Y + R));
                //gl.Vertex(Center.X, gl.RenderContextProvider.Height - (Center.Y + R + R));
                //gl.Vertex(Center.X - R, gl.RenderContextProvider.Height - (Center.Y + R));
                //gl.End();
                //gl.PointSize(10);
            }
            //
            public override void move(int deltaX, int deltaY)
            {
                Center.X += deltaX;
                Center.Y += deltaY;
            }
        }
        //Đối tượng hình ellipse
        public class Ellipse : imageObject
        {
            public int Rx, Ry;      //bán kính 1, bán kính 2
            public Point Center;
            public Ellipse() { }
            //Chuyển đổi các giá trị
            public override void setPoint(Point start, Point end)
            {
                Center.X = (start.X + end.X) / 2;
                Center.Y = (start.Y + end.Y) / 2;
                Rx = Math.Abs(start.X - Center.X);
                Ry = Math.Abs(start.Y - Center.Y);
            }
            //Xuất 4 điểm đối xứng
            private void put4Pixel(OpenGL gl, int x, int y)
            {
                gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y + y));
                gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y));
                gl.Vertex(Center.X - x, gl.RenderContextProvider.Height - (Center.Y + y));
                gl.Vertex(Center.X - x, gl.RenderContextProvider.Height - (Center.Y - y));
            }
            //Vẽ hình ellipse dựa vào thuật toán midpoint
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_POINTS);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }

                int a = 0, b = Ry;
                put4Pixel(gl, a, b);
                int fx = 0, fy = 2 * Rx * Rx * Ry;
                float fp = Ry * Ry - Rx * Rx * Ry + 1 / 4 * Rx * Rx;
                while (fx < fy)
                {
                    if (fp < 0)
                    {
                        a++;
                        put4Pixel(gl, a, b);
                        fx = 2 * Ry * Ry * (a - 1) + 2 * Ry * Ry;
                        fp = fp + fx + Ry * Ry;
                    }
                    else
                    {
                        a++;
                        b--;
                        put4Pixel(gl, a, b);
                        fx = 2 * Ry * Ry * (a - 1) + 2 * Ry * Ry;
                        fy = 2 * Rx * Rx * (b + 1) - 2 * Rx * Rx;
                        fp = fp + fx - fy + Ry * Ry;
                    }
                }
                fx = 2 * Rx * Rx * b;
                fy = 2 * Ry * Ry * a;
                fp = Ry * Ry * (a + 1 / 2) * (a + 1 / 2) + Rx * Rx * (b - 1) * (b - 1) - Rx * Rx * Ry * Ry;
                while (b != 0)
                {
                    if (fp > 0)
                    {
                        b--;
                        put4Pixel(gl, a, b);
                        fx = 2 * Rx * Rx * (b - 1) - 2 * Rx * Rx;
                        fp = fp - fx + Rx * Rx;
                    }
                    else
                    {
                        a++;
                        b--;
                        put4Pixel(gl, a, b);
                        fy = 2 * Ry * Ry * (a - 1) + 2 * Ry * Ry;
                        fx = 2 * Rx * Rx * (b + 1) - 2 * Rx * Rx;
                        fp = fp + fy - fx + Rx * Rx;
                    }
                }

                gl.End();
                gl.PointSize(lineWidth);
            }
            //view control
            public override void viewControlPoint(OpenGL gl)
            {
                //code
            }
            //hàm xoay ảnh
            public override void Affine(int degree)
            {
                if (degree == 90)
                {
                    int tmp = Rx;
                    Rx = Ry;
                    Ry = tmp;
                }
            }
            //
            public override void move(int deltaX, int deltaY)
            {
                Center.X += deltaX;
                Center.Y += deltaY;
            }
        }
        //Đối tượng hình ngũ giác đều
        public class Pentagon : imageObject
        {
            private int R;
            private Point Center;
            public Pentagon() { }
            //Tính toán lại các giá trị
            public override void setPoint(Point start, Point end)
            {
                Center.X = (start.X + end.X) / 2;
                Center.Y = (start.Y + start.Y) / 2;
                if (Math.Abs(start.X - Center.X) >= Math.Abs(start.Y - Center.Y))
                    R = Math.Abs(start.X - Center.X);
                else R = Math.Abs(start.Y - Center.Y);
            }
            //Vẽ đối tượng
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }
                //Chuyển đồi từ độ sang radius
                float grad = (float)((72 * 3.14) / 180);
                gl.Vertex(Center.X, gl.RenderContextProvider.Height - (Center.Y - R));
                for (int i = 1; i < 5; i++)
                {
                    //Thực hiện xoay pixel từ điểm ảnh chuẩn sang các đỉnh khác
                    int x = (int)(-Math.Sin(i * grad) * R);
                    int y = (int)(Math.Cos(i * grad) * R);
                    gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y));
                }
                gl.End();
                gl.LineWidth(lineWidth);
            }
            //Xuất các giá trị control
            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(1.0, 0, 0, 0);
                //Chuyển đổi từ độ sang Radian
                float grad = (float)((72 * 3.14) / 180);
                gl.Vertex(Center.X, gl.RenderContextProvider.Height - (Center.Y - R));
                for (int i = 1; i < 5; i++)
                {
                    //Thực hiện phép xoay pixel
                    int x = (int)(-Math.Sin(i * grad) * R);
                    int y = (int)(Math.Cos(i * grad) * R);
                    gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y));
                }
                gl.End();
                gl.PointSize(lineWidth + 10);
            }
            //
            public override void move(int deltaX, int deltaY)
            {
                Center.X += deltaX;
                Center.Y += deltaY;
            }
        }
        //Đối tượng hình lục giác đều
        public class Hexagon : imageObject
        {
            public int R;
            public Point Center;
            public Hexagon() { }
            //Chuyển đổi hệ tọa độ
            public override void setPoint(Point start, Point end)
            {
                Center.X = (start.X + end.X) / 2;
                Center.Y = (start.Y + start.Y) / 2;
                if (Math.Abs(start.X - Center.X) >= Math.Abs(start.Y - Center.Y))
                    R = Math.Abs(start.X - Center.X);
                else R = Math.Abs(start.Y - Center.Y);
            }
            //Vẽ đối tượng
            public override void drawObject(OpenGL gl)
            {
                if (isBrush == false)
                {
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    gl.Color(borderColor.R / 255.0, borderColor.G / 255.0, borderColor.B / 255.0, 0);
                }
                else
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(bgroudColor.R / 255.0, bgroudColor.G / 255.0, bgroudColor.B / 255.0, 0);
                }
                //chuyển đổi từ độ sang radius
                float grad = (float)((60 * 3.14) / 180);
                gl.Vertex(Center.X, gl.RenderContextProvider.Height - (Center.Y - R));
                for (int i = 1; i < 6; i++)
                {
                    //Xuay pixel
                    int x = (int)(-Math.Sin(i * grad) * R);
                    int y = (int)(Math.Cos(i * grad) * R);
                    gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y));
                }
                gl.End();
                gl.LineWidth(lineWidth);
            }
            //view control point
            public override void viewControlPoint(OpenGL gl)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(1.0, 0, 0, 0);
                float grad = (float)((60 * 3.14) / 180);
                gl.Vertex(Center.X, gl.RenderContextProvider.Height - (Center.Y - R));
                for (int i = 1; i < 6; i++)
                {
                    int x = (int)(-Math.Sin(i * grad) * R);
                    int y = (int)(Math.Cos(i * grad) * R);
                    gl.Vertex(Center.X + x, gl.RenderContextProvider.Height - (Center.Y - y));
                }
                gl.End();
                gl.PointSize(lineWidth + 10);
            }
            //
            public override void move(int deltaX, int deltaY)
            {
                Center.X += deltaX;
                Center.Y += deltaY;
            }
        }

        //Khu vực khai báo các biến toàn cục để thao tác với ứng dụng
        //Biển kiểm soát con tỏ chuột, biến cho phép affine hình, biến tô màu nền cho hình
        bool mouseClick, changeObject, brushObject, drawObject;
        private int shShape;        //Biến chọn đối tượng vẽ: đường thẳng, hình chữ nhật, ...
        private Point pStart, pEnd; //2 biến điểm control màng hình
        private Color userColor;    //Biến lưu trữ màu
        private float lineWidth;    //Biến lưu trữ độ dày nét vẽ
        private int count, nowId, idViewPoint;      //Biến số lượng hình vẽ, biến kiểm soát hình nào được chọn, biến hiện controlPoint
        private Stopwatch st = new Stopwatch();
        //Mảng chính lưu các hình
        imageObject[] Arr_Object = new imageObject[1000];

        //Thiết đặt cài đặt mặt định khi khởi động app
        public miniPaint()
        {
            InitializeComponent();
            //Cài đặt đối tượng hình
            shShape = 0;            //mở đầu là vẽ đường thẳng
            pStart.X = pStart.Y = pEnd.X = pEnd.Y = 0;      //Ban đầu chưa có tọa độ
            userColor = Color.White;                //màu mặt định: white
            lineWidth = 1;                          //Nét vẽ mặt định: 1.0f
            //Cài đặt chế độ
            mouseClick = false;
            changeObject = false;
            drawObject = true;                      //Mở đầu là chế độ vẽ hình
            count = 0;                              //số lượng vẽ bằng 1
            nowId = -1;                             //Mở đầu chưa có đối tượng nào được chọn
            idViewPoint = count;
        }

        //Khi các button hình ảnh được chọn
        private void bt_Line_Click(object sender, EventArgs e)
        {
            shShape = 0;
        }
        private void bt_Rectangle_Click(object sender, EventArgs e)
        {
            shShape = 1;
        }
        private void bt_Triangle_Click(object sender, EventArgs e)
        {
            shShape = 2;
        }
        private void bt_Circle_Click(object sender, EventArgs e)
        {
            shShape = 3;
        }
        private void bt_Ellipse_Click(object sender, EventArgs e)
        {
            shShape = 4;
        }
        private void bt_Pentagon_Click(object sender, EventArgs e)
        {
            shShape = 5;
        }
        private void bt_Hexagon_Click(object sender, EventArgs e)
        {
            shShape = 6;
        }
        //Các button affine được chọn
            //Xoay 1 góc 30 độ
        private void bt_Affine30_Click(object sender, EventArgs e)
        {
            if (idViewPoint != -1 && changeObject == true)
                Arr_Object[idViewPoint].Affine(30);
        }
            //Xoay 1 góc 60 độ
        private void bt_Affine60_Click(object sender, EventArgs e)
        {
            if (idViewPoint != -1 && changeObject == true)
                Arr_Object[idViewPoint].Affine(60);
        }
            //Xoay một góc 90 độ
        private void bt_Affine90_Click(object sender, EventArgs e)
        {
            if (idViewPoint != -1 && changeObject == true)
                Arr_Object[idViewPoint].Affine(90);
        }
        //Khi các button chức năng được chọn
        private void bt_Clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= count; i++)
                Arr_Object[i] = null;
            idViewPoint = -1;
            count = 0;
        }
        private void bt_Undo_Click(object sender, EventArgs e)
        {
            if (count != 0)
            {
                if (idViewPoint >= count - 1)
                {
                    --idViewPoint;
                }
                count -= 1;
                Arr_Object[count + 1] = null;
            }
        }
            //Chế độ vẽ, di chuyển và tô màu
        private void bt_Draw_Click(object sender, EventArgs e)
        {
            drawObject = true;
            changeObject = false;
            brushObject = false;
        }
        private void bt_Change_Click(object sender, EventArgs e)
        {
            changeObject = true;
            drawObject = false;
            brushObject = false;
        }
        private void bt_Brush_Click(object sender, EventArgs e)
        {
            brushObject = true;
            changeObject = false;
            drawObject = false;
        }
        //Chế độ chọn màu, và thay đổi giá trị lineWidth
        private void bt_SelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                userColor = colorDialog.Color;
        }
        private void tb_LineWidth_Changed(object sender, EventArgs e)
        {
            if (tb_LineWidth.Text != "")
            {
                lineWidth = Convert.ToInt32(tb_LineWidth.Text);
            }
        }
        //Các sự kiện liên quan đến trỏ chuột
            //Khi có sự kiện nhấn chuột vào màng hình xảy ra
        private void ctrl_OpenGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            //Nếu ở chế độ affine, biên đổi
            if (changeObject == true)
            {
                for (int i = count - 1; i >= 0; i--)
                    if (e.Location.X <= Arr_Object[i].pEnd.X && e.Location.X >= Arr_Object[i].pStart.X && e.Location.Y <= Arr_Object[i].pEnd.Y && e.Location.Y >= Arr_Object[i].pStart.Y)
                    {
                        nowId = i;
                        break;
                    }
                if (nowId != -1)
                {
                    mouseClick = true;
                    pStart = e.Location;
                    pEnd = pStart;
                }
            }  
            //Nếu ở chế độ draw
            else
            {
                st.Reset();
                st.Start();
                mouseClick = true;
                pStart = e.Location;
                pEnd = pStart;
            }
        }
            //Khi di chuyển chuột trên màng hình
        private void ctrl_OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            //Nếu ở chế độ affine
            if (changeObject == true)
            {
                if (mouseClick == true)
                {
                    pEnd = e.Location;
                    //Di chuyển cả controlPoint
                    Arr_Object[nowId].pStart.X += pEnd.X - pStart.X;
                    Arr_Object[nowId].pStart.Y += pEnd.Y - pStart.Y;
                    Arr_Object[nowId].pEnd.X += pEnd.X - pStart.X;
                    Arr_Object[nowId].pEnd.Y += pEnd.Y - pStart.Y;
                    Arr_Object[nowId].move(pEnd.X - pStart.X, pEnd.Y - pStart.Y);
                    pStart = pEnd;
                }
            }
            //Ở chế độ vẽ bình thường
            else
            {
                if (mouseClick == true)
                {
                    pEnd = e.Location;
                    idViewPoint = count;
                }
            }
        }
            //Khi có thao tác nhả chuột trên màng hình
        private void ctrl_OpenGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawObject == true)
                count += 1;
            nowId = -1;
            mouseClick = false;
            //reset lại pStart, pEnd
            pStart.X = 0;
            pStart.Y = 0;
            pEnd.X = 0;
            pEnd.Y = 0;
            //Hiển thị thời gian
            st.Stop();
            tb_Time.Text = st.Elapsed.ToString();
        }
            //Thao tác click
        private void ctrl_OpenGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                if (e.Location.X <= Arr_Object[i].pEnd.X && e.Location.X >= Arr_Object[i].pStart.X && e.Location.Y <= Arr_Object[i].pEnd.Y && e.Location.Y >= Arr_Object[i].pStart.Y)
                {
                    idViewPoint = i;
                    //Nếu là chế độ to màu thì tô màu cho hình
                    if (brushObject == true)
                    {
                        Arr_Object[i].setbgroudColor(userColor);
                        Arr_Object[i].isBrush = true;
                    }
                    break;
                }
                if (i == 0) idViewPoint = -1;
            }
        }
        //Các hàm vẽ hình mặt định trong SharpGL
            //Hàm cài đặt
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //Khai báo biến OpenGL gl
            OpenGL gl = openGLControl.OpenGL;
            //Xóa màng hình, trả chế độ và load view
            gl.ClearColor(0, 0, 0, 0);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
        }
            //Hàm resied
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }
            //Hàm quan trọng, hàm vẽ chính
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            switch (shShape)
            {
                case 0: Arr_Object[count] = new Line(); break;
                case 1: Arr_Object[count] = new Rectangle(); break;
                case 2: Arr_Object[count] = new Triangle(); break;
                case 3: Arr_Object[count] = new Circle(); break;
                case 4: Arr_Object[count] = new Ellipse(); break;
                case 5: Arr_Object[count] = new Pentagon(); break;
                case 6: Arr_Object[count] = new Hexagon(); break;
                default: break;
            }

            if (drawObject == true)
            {
                Arr_Object[count].setPoint(pStart, pEnd);
                Arr_Object[count].set(pStart, pEnd);
                Arr_Object[count].setBorderColor(userColor);
                if (count > 0)
                    Arr_Object[count - 1].setLineWidth(lineWidth);
                else Arr_Object[count].setLineWidth(lineWidth);
            }
            for (int i = 0; i <= count; i++)
            {
                Arr_Object[i].drawObject(gl);
            }
            if (idViewPoint != -1)
                Arr_Object[idViewPoint].viewControlPoint(gl);
            gl.Flush();
        }
    }
}
