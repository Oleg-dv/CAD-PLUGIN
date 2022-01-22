using System;
using System.Drawing;
using System.Windows.Forms;
using KompasWrapper;
using System.IO;
using System.Diagnostics;
using Coupling;
using Microsoft.VisualBasic.Devices;

namespace CouplingUI
{
    /// <summary>
    /// Форма задания параметров для дальнейшего построения модели
    /// </summary>
    public partial class MainForm : Form
    {
        //TODO: RSDN
        /// <summary>
        /// Поле параметров
        /// </summary>
        private readonly CouplingParameters _couplingParameters;

        public MainForm()
        {
            InitializeComponent();
            _couplingParameters = SettingManager.LoadFile(SettingManager._directoryPath);

            couplingDiameterTextBox.Text = Convert.ToString(_couplingParameters.CouplingDiameter);
            centralHoleDiameterTextBox.Text = Convert.ToString(_couplingParameters.CentralHoleDiameter);
            smallHolesDiameterTextBox.Text = Convert.ToString(_couplingParameters.SmallHolesDiameter);
            couplingWidthTextBox.Text = Convert.ToString(_couplingParameters.CouplingWidth);
            countOfSmallHolesComboBox.Text = Convert.ToString(_couplingParameters.CountOfSmallHoles);

            centralHoleDiameterLabel.Text = 
                ChangeTextLabel(CouplingParameters.MIN_CENTRAL_HOLE_DIAMETER,
                    _couplingParameters.MaxCenterHoleDiameter);
            smallHolesDiameterLabel.Text = 
                ChangeTextLabel(CouplingParameters.MIN_SMALL_HOLES_DIAMETER,
                    _couplingParameters.MaxSmallHoleDiameter);
        }

        //TODO: RSDN
        /// <summary>
        /// Событие, при нажатии на кнопку "Build".
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void BuildButtonClick(object sender, EventArgs e)
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

            var couplingBuilder = new CouplingBuilder();
            couplingBuilder.CreateModel(_couplingParameters);

            SettingManager.SaveFile(_couplingParameters, SettingManager._directoryPath);

            buildButton.Enabled = true;

            //StressTesting();
        }

        //TODO: RSDN
        /// <summary>
        /// Событие, при выходе с TextBox.
        /// </summary>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        /// <param name="sender">Объект, который вызвал метод</param>
        private void TextBoxLeave(object sender, EventArgs e)
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

        //TODO: RSDN
        /// <summary>
        /// Событие, при выходе из ComboBox.
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void CountOfSmallHolesComboBoxLeave(object sender, EventArgs e)
        {
            try
            {
                _couplingParameters.CountOfSmallHoles = 
                    Convert.ToInt32(countOfSmallHolesComboBox.SelectedItem);
                smallHolesDiameterLabel.Text =
                    ChangeTextLabel(CouplingParameters.MIN_SMALL_HOLES_DIAMETER,
                        _couplingParameters.MaxSmallHoleDiameter);
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
                       ChangeTextLabel(CouplingParameters.MIN_SMALL_HOLES_DIAMETER,
                           _couplingParameters.MaxSmallHoleDiameter);

                    centralHoleDiameterLabel.Text =
                       ChangeTextLabel(CouplingParameters.MIN_CENTRAL_HOLE_DIAMETER,
                           _couplingParameters.MaxCenterHoleDiameter);
                     break;

                 case nameof(centralHoleDiameterTextBox):
                     _couplingParameters.CentralHoleDiameter = value;

                    smallHolesDiameterLabel.Text =
                       ChangeTextLabel(CouplingParameters.MIN_SMALL_HOLES_DIAMETER,
                           _couplingParameters.MaxSmallHoleDiameter);
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

        /// <summary>
        /// Нагрузочное тестирование
        /// </summary>
        private void StressTesting()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var builder = new CouplingBuilder();

            int countModel = 0;
            using (StreamWriter writer = new StreamWriter("C:/TestSAPR/log.txt", true))
            {
                while (true)
                {
                    builder.CreateModel(_couplingParameters);
                    var computerInfo = new ComputerInfo();
                    var usedMemory = computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory;
                    countModel++;
                    writer.WriteLineAsync($"{countModel}\t{stopWatch.ElapsedMilliseconds}\t{usedMemory}");
                    writer.Flush();
                }
            }
        }
    }
}