using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AutoCADInstrument
{
    public class Wrapper
    {
        /// <summary>
        /// Базовая точка отсчёта.
        /// </summary>
        private object basePoint;

        /// <summary>
        /// Центр фигуры.
        /// </summary>
        private object centerPoint;

        /// <summary>
        /// Координата x для центра фигуры.
        /// </summary>
        private double x;

        /// <summary>
        /// Координата y для центра фигуры.
        /// </summary>
        private double y;

        /// <summary>
        /// Координата z для центра фигуры.
        /// </summary>
        private double z;

        /// <summary>
        /// Экземпляр приложения.
        /// </summary>
        private AcadApplication acadApp;

        /// <summary>
        /// Экземпляр открытого документа.
        /// </summary>
        private AcadDocument acadDoc;

        /// <summary>
        /// Экземпляр последнего открытого документа.
        /// </summary>
        private AcadDocument lastDoc;

        /// <summary>
        /// Пространство моделей.
        /// </summary>
        private AcadModelSpace pyramid;

        /// <summary>
        /// Список граней пирамиды.
        /// </summary>
        private List<dynamic> faces = new List<dynamic>();

        /// <summary>
        /// Метод для подключения к AutoCAD.
        /// </summary>
        public void AutoCAD()
        {
            try
            {
                acadApp = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application");
            }
            catch
            {
                acadApp = new AcadApplication();
                acadApp.Visible = true;
            }
            Doc();
        }

        /// <summary>
        /// Метод для выбора активного документа (проверяет, является ли выбранный документ последним открытым).
        /// </summary>
        public void Doc()
        {
            acadDoc = acadApp.ActiveDocument;
            if (acadDoc != lastDoc)
            {
                lastDoc = acadDoc;
                Initialize();
            }
        }

        /// <summary>
        /// Инициализация пирамиды.
        /// </summary>
        public void Initialize()
        {
            x = 0;
            y = 0;
            z = 0;
            centerPoint = new double[] { x, y, z };
            basePoint = new double[] { 0, 0, 0 };
            double baseSize = 10.0;
            double topSize = 5.0;
            double height = 8.0;
            double[,] basePts = new double[3, 3];
            double[,] topPts = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                double angle = i * 2 * Math.PI / 3;
                basePts[i, 0] = baseSize * Math.Cos(angle);
                basePts[i, 1] = baseSize * Math.Sin(angle);
                basePts[i, 2] = 0;

                topPts[i, 0] = topSize * Math.Cos(angle);
                topPts[i, 1] = topSize * Math.Sin(angle);
                topPts[i, 2] = height;
            }
            pyramid = acadDoc.ModelSpace;

            var face = pyramid.Add3DFace(new double[] { basePts[0, 0], basePts[0, 1], basePts[0, 2] },
                         new double[] { basePts[1, 0], basePts[1, 1], basePts[1, 2] },
                         new double[] { basePts[2, 0], basePts[2, 1], basePts[2, 2] },
                         new double[] { basePts[0, 0], basePts[0, 1], basePts[0, 2] });
            faces.Add(face);
            for (int i = 0; i < 3; i++)
            {
                int j = (i + 1) % 3;
                face = pyramid.Add3DFace(new double[] { basePts[i, 0], basePts[i, 1], basePts[i, 2] },
                new double[] { basePts[j, 0], basePts[j, 1], basePts[j, 2] },
                new double[] { topPts[j, 0], topPts[j, 1], topPts[j, 2] },
                new double[] { topPts[i, 0], topPts[i, 1], topPts[i, 2] });
                faces.Add(face);
            }
            face = pyramid.Add3DFace(new double[] { topPts[0, 0], topPts[0, 1], topPts[0, 2] },
                         new double[] { topPts[1, 0], topPts[1, 1], topPts[1, 2] },
                         new double[] { topPts[2, 0], topPts[2, 1], topPts[2, 2] },
                         new double[] { topPts[0, 0], topPts[0, 1], topPts[0, 2] });
            faces.Add(face);
            acadApp.Update();
        }

        /// <summary>
        /// Перемещение пирамиды.
        /// </summary>
        public void Move(double newX, double newY, double newZ)
        {
            AutoCAD();
            x += newX;
            y += newY;
            z += newZ;
            centerPoint = new double[] { x, y, z };
            basePoint = new double[] { 0, 0, 0 };
            object newPoint = new double[] { newX, newY, newZ };
            for (int i = 0; i < faces.Count; i++)
            {
                faces[i].Move(basePoint, newPoint);
            }
        }

        /// <summary>
        /// Отражение пирамиды относительно XOY.
        /// </summary>
        public void MirrorXOY()
        {
            AutoCAD();
            z *= -1;
            centerPoint = new double[] { x, y, z };
            basePoint = new double[] { 0, 0, 0 };
            for (int i = 0; i < faces.Count; i++)
            {
                dynamic face = faces[i].Mirror3D(basePoint, new double[] { 100, 0, 0 }, new double[] { 0, 100, 0 });
                faces[i].Erase();
                faces[i] = face;
            }
        }

        /// <summary>
        /// Отражение пирамиды относительно YOZ.
        /// </summary>
        public void MirrorYOZ()
        {
            AutoCAD();
            x *= -1;
            centerPoint = new double[] { x, y, z };
            basePoint = new double[] { 0, 0, 0 };
            for (int i = 0; i < faces.Count; i++)
            {
                dynamic face = faces[i].Mirror3D(basePoint, new double[] { 0, 100, 0 }, new double[] { 0, 0, 100 });
                faces[i].Erase();
                faces[i] = face;
            }
        }

        /// <summary>
        /// Отражение пирамиды относительно XOZ.
        /// </summary>
        public void MirrorXOZ()
        {
            AutoCAD();
            y *= -1;
            centerPoint = new double[] { x, y, z };
            basePoint = new double[] { 0, 0, 0 };
            for (int i = 0; i < faces.Count; i++)
            {
                dynamic face = faces[i].Mirror3D(basePoint, new double[] { 100, 0, 0 }, new double[] { 0, 0, 100 });
                faces[i].Erase();
                faces[i] = face;
            }
        }

        /// <summary>
        /// Масштабирование пирамиды.
        /// </summary>
        /// <param name="scale">Коэффициент масштабирования.</param>
        public void Scale(double scale)
        {
            AutoCAD();
            centerPoint = new double[] { x, y, z };
            for (int i = 0; i < faces.Count; i++)
            {
                faces[i].ScaleEntity(centerPoint, scale);
            }
        }

        /// <summary>
        /// Поворот пирамиды относительно оси OX (Вращение).
        /// </summary>
        /// <param name="angle">Угол поворота.</param>
        public void RotateOX(double angle)
        {
            AutoCAD();
            double[,] matr_pov = new double[3, 3]
            {
                { 1, 0, 0 },
                { 0, (double)Math.Cos(angle), (double)-Math.Sin(angle) },
                { 0, (double)Math.Sin(angle), (double)Math.Cos(angle) }
            };
            double[,] center = new double[1, 3] { { x, y, z } };
            double[,] result = MultiplyMatrix(center, matr_pov);
            x = result[0, 0];
            y = result[0, 1];
            z = result[0, 2];
            centerPoint = new double[] { x, y, z };
            for (int i = 0; i < faces.Count; i++)
            {
                faces[i].Rotate3D(new double[] { 0, 0, 0 }, new double[] { 10000, 0, 0 }, angle);
            }
        }

        /// <summary>
        /// Поворот пирамиды относительно оси OY (Вращение).
        /// </summary>
        /// <param name="angle">Угол поворота.</param>
        public void RotateOY(double angle)
        {
            AutoCAD();
            double[,] matr_pov = new double[3, 3]
            {
                { (double)Math.Cos(angle), 0, (double)Math.Sin(angle) },
                { 0, 1, 0 },
                { (double)-Math.Sin(angle), 0, (double)Math.Cos(angle) }
            };
            double[,] center = new double[1, 3] { { x, y, z } };
            double[,] result = MultiplyMatrix(center, matr_pov);
            x = result[0, 0];
            y = result[0, 1];
            z = result[0, 2];
            centerPoint = new double[] { x, y, z };
            for (int i = 0; i < faces.Count; i++)
            {
                faces[i].Rotate3D(new double[] { 0, 0, 0 }, new double[] { 0, 10000, 0 }, angle);
            }
        }

        /// <summary>
        /// Поворот пирамиды относительно оси OZ (Вращение).
        /// </summary>
        /// <param name="angle">Угол поворота.</param>
        public void RotateOZ(double angle)
        {
            AutoCAD();
            double[,] matr_pov = new double[3, 3]
            {
                { (double)Math.Cos(angle), (double)-Math.Sin(angle), 0 },
                { (double)Math.Sin(angle), (double)Math.Cos(angle), 0 },
                { 0, 0, 1 }
            };
            double[,] center = new double[1, 3] { { x, y, z } };
            double[,] result = MultiplyMatrix(center, matr_pov);
            x = result[0, 0];
            y = result[0, 1];
            z = result[0, 2];
            centerPoint = new double[] { x, y, z };
            for (int i = 0; i < faces.Count; i++)
            {
                faces[i].Rotate3D(new double[] { 0, 0, 0 }, new double[] { 0, 0, 10000 }, angle);
            }
        }

        /// <summary>
        /// Метод для перемножения матриц.
        /// </summary>
        /// <param name="a">Первая матрица (слева).</param>
        /// <param name="b">Вторая матрица (справа).</param>
        /// <returns>Результат перемножения.</returns>
        private double[,] MultiplyMatrix(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Метод для представления Фронтальной проекции (вид спереди, отображается на плоскости XOY, для наглядности рекомендуется сдвинуть фигуру по оси OZ после использования).
        /// </summary>
        public void FrontView()
        {
            AutoCAD();
            var layerName = "ProjectionXY";
            acadDoc.Layers.Add(layerName);
            double[] verts = new double[60];
            for (int i = 0; i < faces.Count; i++)
            {
                double[] temp = faces[i].Coordinates;
                for (int k = 0; k < 12; k++)
                {
                    verts[i * 12 + k] = temp[k];
                }
            }
            var projectPoints = new double[]
            {
                verts[0], verts[2], 0,
                verts[3], verts[5], 0,
                verts[6], verts[8], 0,
                verts[9], verts[11], 0,
                verts[12], verts[14], 0,
                verts[15], verts[17], 0,
                verts[18], verts[20], 0,
                verts[21], verts[23], 0,
                verts[24], verts[26], 0,
                verts[27], verts[29], 0,
                verts[30], verts[32], 0,
                verts[33], verts[35], 0,
                verts[36], verts[38], 0,
                verts[39], verts[41], 0,
                verts[42], verts[44], 0,
                verts[45], verts[47], 0,
                verts[48], verts[50], 0,
                verts[51], verts[53], 0,
                verts[54], verts[56], 0,
                verts[57], verts[59], 0
            };
            pyramid.AddPolyline(projectPoints);
        }

        /// <summary>
        /// Метод для расчёта новых координат точек, после перспективной проекции.
        /// </summary>
        /// <param name="p">Массив вершин.</param>
        /// <param name="c">Координаты точки, из которой исходит центральная проекция.</param>
        /// <param name="z0">Плоскость проекции.</param>
        /// <returns></returns>
        private double[] ProjectPoint(double[] p, double[] c, double z0)
        {
            double k = (z0 - c[2]) / (p[2] - c[2]);
            return new double[]
            {
                c[0] + (p[0] - c[0]) * k,
                c[1] + (p[1] - c[1]) * k,
                z0
            };
        }

        /// <summary>
        /// Перспективная проекция пирамиды.
        /// </summary>
        /// <param name="x">Координата x центральной проекции.</param>
        /// <param name="y">Координата y центральной проекции.</param>
        /// <param name="z">Координата z центральной проекции.</param>
        public void CentralView(double x, double y, double z)
        {
            AutoCAD();
            var c = new double[] { x, y, z };
            double z0 = 0;
            var pp1 = ProjectPoint(new double[] { faces[0].Coordinates[0], faces[0].Coordinates[1], faces[0].Coordinates[2] }, c, z0);
            var pp2 = ProjectPoint(new double[] { faces[0].Coordinates[3], faces[0].Coordinates[4], faces[0].Coordinates[5] }, c, z0);
            var pp3 = ProjectPoint(new double[] { faces[0].Coordinates[6], faces[0].Coordinates[7], faces[0].Coordinates[8] }, c, z0);
            var pp4 = ProjectPoint(new double[] { faces[0].Coordinates[9], faces[0].Coordinates[10], faces[0].Coordinates[11] }, c, z0);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectPoint(new double[] { faces[1].Coordinates[0], faces[1].Coordinates[1], faces[1].Coordinates[2] }, c, z0);
            pp2 = ProjectPoint(new double[] { faces[1].Coordinates[3], faces[1].Coordinates[4], faces[1].Coordinates[5] }, c, z0);
            pp3 = ProjectPoint(new double[] { faces[1].Coordinates[6], faces[1].Coordinates[7], faces[1].Coordinates[8] }, c, z0);
            pp4 = ProjectPoint(new double[] { faces[1].Coordinates[9], faces[1].Coordinates[10], faces[1].Coordinates[11] }, c, z0);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectPoint(new double[] { faces[2].Coordinates[0], faces[2].Coordinates[1], faces[2].Coordinates[2] }, c, z0);
            pp2 = ProjectPoint(new double[] { faces[2].Coordinates[3], faces[2].Coordinates[4], faces[2].Coordinates[5] }, c, z0);
            pp3 = ProjectPoint(new double[] { faces[2].Coordinates[6], faces[2].Coordinates[7], faces[2].Coordinates[8] }, c, z0);
            pp4 = ProjectPoint(new double[] { faces[2].Coordinates[9], faces[2].Coordinates[10], faces[2].Coordinates[11] }, c, z0);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectPoint(new double[] { faces[3].Coordinates[0], faces[3].Coordinates[1], faces[3].Coordinates[2] }, c, z0);
            pp2 = ProjectPoint(new double[] { faces[3].Coordinates[3], faces[3].Coordinates[4], faces[3].Coordinates[5] }, c, z0);
            pp3 = ProjectPoint(new double[] { faces[3].Coordinates[6], faces[3].Coordinates[7], faces[3].Coordinates[8] }, c, z0);
            pp4 = ProjectPoint(new double[] { faces[3].Coordinates[9], faces[3].Coordinates[10], faces[3].Coordinates[11] }, c, z0);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectPoint(new double[] { faces[4].Coordinates[0], faces[4].Coordinates[1], faces[4].Coordinates[2] }, c, z0);
            pp2 = ProjectPoint(new double[] { faces[4].Coordinates[3], faces[4].Coordinates[4], faces[4].Coordinates[5] }, c, z0);
            pp3 = ProjectPoint(new double[] { faces[4].Coordinates[6], faces[4].Coordinates[7], faces[4].Coordinates[8] }, c, z0);
            pp4 = ProjectPoint(new double[] { faces[4].Coordinates[9], faces[4].Coordinates[10], faces[4].Coordinates[11] }, c, z0);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
        }

        /// <summary>
        /// Метод для преобразования угла из градусов в радианы.
        /// </summary>
        /// <param name="deg">Угол в градусах.</param>
        /// <returns>Угол в радианах.</returns>
        private double DegreeToRad(double deg) => deg * Math.PI / 180.0;

        /// <summary>
        /// Расчёт координат вершин после косоугольной проекции.
        /// </summary>
        /// <param name="point">Координаты вершин.</param>
        /// <param name="angleDeg">Угол наклона проекции.</param>
        /// <param name="scale">Коэффициент искажения.</param>
        /// <returns></returns>
        private double[] ProjectOblique(double[] point, double angleDeg, double scale = 1.0)
        {
            double alpha = DegreeToRad(angleDeg);
            double x = point[0];
            double y = point[1];
            double z = point[2];

            double x_proj = x + scale * z * Math.Cos(alpha);
            double y_proj = y + scale * z * Math.Sin(alpha);
            return new double[] { x_proj, y_proj, 0 };
        }

        /// <summary>
        /// Косоугольная проекция пирамиды.
        /// </summary>
        /// <param name="angle">Угол в градусах.</param>
        public void ObliqueView(double angle)
        {
            AutoCAD();
            var pp1 = ProjectOblique(new double[] { faces[0].Coordinates[0], faces[0].Coordinates[1], faces[0].Coordinates[2] }, angle);
            var pp2 = ProjectOblique(new double[] { faces[0].Coordinates[3], faces[0].Coordinates[4], faces[0].Coordinates[5] }, angle);
            var pp3 = ProjectOblique(new double[] { faces[0].Coordinates[6], faces[0].Coordinates[7], faces[0].Coordinates[8] }, angle);
            var pp4 = ProjectOblique(new double[] { faces[0].Coordinates[9], faces[0].Coordinates[10], faces[0].Coordinates[11] }, angle);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectOblique(new double[] { faces[1].Coordinates[0], faces[1].Coordinates[1], faces[1].Coordinates[2] }, angle);
            pp2 = ProjectOblique(new double[] { faces[1].Coordinates[3], faces[1].Coordinates[4], faces[1].Coordinates[5] }, angle);
            pp3 = ProjectOblique(new double[] { faces[1].Coordinates[6], faces[1].Coordinates[7], faces[1].Coordinates[8] }, angle);
            pp4 = ProjectOblique(new double[] { faces[1].Coordinates[9], faces[1].Coordinates[10], faces[1].Coordinates[11] }, angle);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectOblique(new double[] { faces[2].Coordinates[0], faces[2].Coordinates[1], faces[2].Coordinates[2] }, angle);
            pp2 = ProjectOblique(new double[] { faces[2].Coordinates[3], faces[2].Coordinates[4], faces[2].Coordinates[5] }, angle);
            pp3 = ProjectOblique(new double[] { faces[2].Coordinates[6], faces[2].Coordinates[7], faces[2].Coordinates[8] }, angle);
            pp4 = ProjectOblique(new double[] { faces[2].Coordinates[9], faces[2].Coordinates[10], faces[2].Coordinates[11] }, angle);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectOblique(new double[] { faces[3].Coordinates[0], faces[3].Coordinates[1], faces[3].Coordinates[2] }, angle);
            pp2 = ProjectOblique(new double[] { faces[3].Coordinates[3], faces[3].Coordinates[4], faces[3].Coordinates[5] }, angle);
            pp3 = ProjectOblique(new double[] { faces[3].Coordinates[6], faces[3].Coordinates[7], faces[3].Coordinates[8] }, angle);
            pp4 = ProjectOblique(new double[] { faces[3].Coordinates[9], faces[3].Coordinates[10], faces[3].Coordinates[11] }, angle);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
            pp1 = ProjectOblique(new double[] { faces[4].Coordinates[0], faces[4].Coordinates[1], faces[4].Coordinates[2] }, angle);
            pp2 = ProjectOblique(new double[] { faces[4].Coordinates[3], faces[4].Coordinates[4], faces[4].Coordinates[5] }, angle);
            pp3 = ProjectOblique(new double[] { faces[4].Coordinates[6], faces[4].Coordinates[7], faces[4].Coordinates[8] }, angle);
            pp4 = ProjectOblique(new double[] { faces[4].Coordinates[9], faces[4].Coordinates[10], faces[4].Coordinates[11] }, angle);
            pyramid.Add3DFace(pp1, pp2, pp3, pp4);
        }
    }
}