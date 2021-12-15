using System;
using System.Drawing;
using System.Windows.Forms;

using KompasWrapper;

namespace CouplingUI
{
    /// <summary>
    /// Форма задания параметров для дальнейшего построения модели
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле параметров
        /// </summary>
        CouplingParameters _couplingParameters;

        public MainForm()
        {
            InitializeComponent();
            _couplingParameters = new CouplingParameters();

            
            countOfSmallHolesComboBox.SelectedIndex = 0;
            _couplingParameters.CountOfSmallHoles = 3;
        }

        /// <summary>
        /// Построить
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            Control thisTextBox = null;
            try
            {
                foreach (Control groupBox in Controls)
                {
                    if (groupBox is GroupBox)
                    {
                        foreach (Control textBox in groupBox.Controls)
                        {
                            if (textBox is TextBox)
                            {
                                thisTextBox = textBox;
                                ChangeParameterValue(textBox);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ShowMessage(thisTextBox, exception.Message);
                return;
            }

            buildButton.Enabled = false;

            CouplingBuilder couplingBuilder = new CouplingBuilder();
            couplingBuilder.CreateModel(_couplingParameters);

            buildButton.Enabled = true;
        }

        /// <summary>
        /// Запись параметров в обьект CouplingParameters
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender">Объект, который вызвал метод</param>
        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ChangeParameterValue(sender);
                ((TextBox)sender).BackColor = Color.White;
                ((TextBox)sender).ForeColor = Color.Black;
            }
            catch (FormatException exception)
            {
                ShowMessage(sender, exception.Message);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(sender, exception.Message);
            }
        }
        /// <summary>
        /// Выход из Combobox и внесение данных в параметры
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        /// <param name="e"></param>
        private void countOfSmallHolesComboBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _couplingParameters.CountOfSmallHoles = 
                    Convert.ToInt32(countOfSmallHolesComboBox.SelectedItem);
            }
            catch (FormatException exception)
            {
                ShowMessage(sender, exception.Message);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(sender, exception.Message);
            }
        }
        /// <summary>
        /// Изменение текста у Label
        /// </summary>
        /// <param name="min">Минимальное значение параметра</param>
        /// <param name="max">Максимальное значение параметра</param>
        /// <returns></returns>
        private string ChangeTextLabel(int min, double max)
        {
            return $@"от {min} мм до {max} мм";
        }

        /// <summary>
        /// Запись в обьект CouplingParameters данных
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        private void ChangeParameterValue(object sender)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');

             double value = Convert.ToDouble(((TextBox)sender).Text);

             switch (((TextBox)sender).Name)
             {
                 case nameof(couplingWidthTextBox):
                     _couplingParameters.CouplingWidth = value;
                     break;
                 case nameof(couplingDiameterTextBox):
                     _couplingParameters.CouplingDiameter = value;

                    smallHolesDiameterLabel.Text =
                       ChangeTextLabel(6, _couplingParameters.MaxSmallHoleDiameter);

                    centralHoleDiameterLabel.Text =
                       ChangeTextLabel(10, _couplingParameters.MaxCenterHoleDiameter);
                     break;

                 case nameof(centralHoleDiameterTextBox):
                     _couplingParameters.CentralHoleDiameter = value;

                    smallHolesDiameterLabel.Text =
                       ChangeTextLabel(6, _couplingParameters.MaxSmallHoleDiameter);
                     break;

                 case nameof(smallHolesDiameterTextBox):
                     _couplingParameters.SmallHolesDiameter = value;
                     break;
                 default: break;
             }            
        }
        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        /// <param name="message">Сообщение</param>
        private static void ShowMessage(object sender, string message)
        {
            MessageBox.Show(message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            ((TextBox)sender).Focus();
            ((TextBox)sender).BackColor = Color.MistyRose;
            ((TextBox)sender).ForeColor = Color.Red;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
