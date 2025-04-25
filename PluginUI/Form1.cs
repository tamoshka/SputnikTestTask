using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AutoCADInstrument;

namespace PluginUI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Экземпляр обёртки Wrapper.
        /// </summary>
        private Wrapper wrapper = new Wrapper();

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка для отражения относительно плоскости XOY.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonMirrorXOY_Click(object sender, EventArgs e)
        {
            wrapper.MirrorXOY();
        }

        /// <summary>
        /// Кнопка для отражения относительно плоскости YOZ.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonMirrorYOZ_Click(object sender, EventArgs e)
        {
            wrapper.MirrorYOZ();
        }

        /// <summary>
        /// Кнопка для отражения относительно плоскости XOZ.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonMirrorXOZ_Click(object sender, EventArgs e)
        {
            wrapper.MirrorXOZ();
        }

        /// <summary>
        /// Кнопка масштабирования.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonScale_Click(object sender, EventArgs e)
        {
            if (TextBoxScale.BackColor == Color.Green)
            {
                wrapper.Scale(double.Parse(TextBoxScale.Text));
            }
        }

        /// <summary>
        /// Кнопка для поворота относительно оси OX.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonRotateOX_Click(object sender, EventArgs e)
        {
            if (TextBoxRotateOX.BackColor == Color.Green)
            {
                wrapper.RotateOX(double.Parse(TextBoxRotateOX.Text));
            }
        }

        /// <summary>
        /// Кнопка для поворота относительно оси OY.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonRotateOY_Click(object sender, EventArgs e)
        {
            if (TextBoxRotateOY.BackColor == Color.Green)
            {
                wrapper.RotateOY(double.Parse(TextBoxRotateOY.Text));
            }
        }

        /// <summary>
        /// Кнопка для поворота относительно оси OZ.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonRotateOZ_Click(object sender, EventArgs e)
        {
            if (TextBoxRotateOZ.BackColor == Color.Green)
            {
                wrapper.RotateOZ(double.Parse(TextBoxRotateOZ.Text));
            }
        }

        /// <summary>
        /// Обработчик выхода из текстБоксов.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            double min = Double.MinValue;
            if (textbox == TextBoxScale)
            {
                min = 0;
            }
            double max = Double.MaxValue;
            Validate(textbox, min, max);
        }

        /// <summary>
        /// Валидация значений в текстБоксах (хоть и не правильно, но здесь также устанавливаются цвета для текстБоксов, по хорошему это вынести в отдельный метод).
        /// </summary>
        /// <param name="textBox">ТекстБокс.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        private void Validate(System.Windows.Forms.TextBox textBox, double min, double max)
        {
            try
            {
                double value = double.Parse(textBox.Text);
                if (value < min || value > max)
                {
                    throw new Exception();
                }
                textBox.BackColor = Color.Green;
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(FormatException))
                {
                    textBox.BackColor = SystemColors.Window;
                }
                else
                {
                    textBox.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// Кнопка для перемещения.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonMoveAll_Click(object sender, EventArgs e)
        {
            if (TextBoxMoveX.BackColor != Color.Red && TextBoxMoveY.BackColor != Color.Red && TextBoxMoveZ.BackColor != Color.Red)
            {
                double x = 0;
                if (TextBoxMoveX.BackColor == Color.Green)
                {
                    x = double.Parse(TextBoxMoveX.Text);
                }
                double y = 0;
                if (TextBoxMoveY.BackColor == Color.Green)
                {
                    y = double.Parse(TextBoxMoveY.Text);
                }
                double z = 0;
                if (TextBoxMoveZ.BackColor == Color.Green)
                {
                    z = double.Parse(TextBoxMoveZ.Text);
                }
                wrapper.Move(x, y, z);
            }
        }

        /// <summary>
        /// Кнопка для проекции вида спереди.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonProject_Click(object sender, EventArgs e)
        {
            wrapper.FrontView();
        }

        /// <summary>
        /// Кнопка для перспективной проекции.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonCentralProject_Click(object sender, EventArgs e)
        {
            if (textBoxCentralX.BackColor != Color.Red && textBoxCentralY.BackColor != Color.Red && textBoxCentralZ.BackColor != Color.Red)
            {
                double x = 0;
                if (textBoxCentralX.BackColor == Color.Green)
                {
                    x = double.Parse(textBoxCentralX.Text);
                }
                double y = 0;
                if (textBoxCentralY.BackColor == Color.Green)
                {
                    y = double.Parse(textBoxCentralY.Text);
                }
                double z = 0;
                if (textBoxCentralZ.BackColor == Color.Green)
                {
                    z = double.Parse(textBoxCentralZ.Text);
                }

                wrapper.CentralView(x, y, z);
            }
        }

        /// <summary>
        /// Кнопка для косоугольной проекции.
        /// </summary>
        /// <param name="sender">Объект.</param>
        /// <param name="e">Событие.</param>
        private void buttonObliqueView_Click(object sender, EventArgs e)
        {
            if (textBoxObliqueAngle.BackColor == Color.Green)
            {
                wrapper.ObliqueView(double.Parse(textBoxObliqueAngle.Text));
            }
        }
    }
}
