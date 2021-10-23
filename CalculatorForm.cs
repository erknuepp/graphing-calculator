namespace GraphingCalculator.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;

    public partial class CalculatorForm : Form
    {
        private double _answer; //Store result for preceeding calculation

        /// <summary>
        /// A key value pair to hold the equation and answer e.g. key: 1 + 1 = valuue: 2
        /// key is a string and vlue is a double
        /// </summary>
        private Dictionary<string, object> _history = new Dictionary<string, object>();

        public CalculatorForm()
        {
            InitializeComponent();
            _answer = 0;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void SplitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DaysNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (this.DaysNumericUpDown.ActiveControl != null)
            {
                if (DaysNumericUpDown.Value >= 0)
                    this.toDateTimePicker.Value = this.fromDateTimePicker.Value.AddDays((double)DaysNumericUpDown.Value);
                else
                    this.fromDateTimePicker.Value = this.toDateTimePicker.Value.AddDays(-1 * (double)DaysNumericUpDown.Value);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.DaysNumericUpDown.ActiveControl != null)
                return;
            int c = this.fromDateTimePicker.Value.CompareTo(this.toDateTimePicker.Value);
            int days = 0;
            DateTime temp;
            if (c > 0)
            {
                temp = this.toDateTimePicker.Value;
                while (!temp.Date.Equals(fromDateTimePicker.Value.Date))
                {
                    days--;
                    temp = temp.AddDays(1);
                }
            }
            else
            {
                temp = this.fromDateTimePicker.Value;
                while (!temp.Date.Equals(toDateTimePicker.Value.Date))
                {
                    days++;
                    temp = temp.AddDays(1);
                }
            }
            this.DaysNumericUpDown.Value = days;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (this.DaysNumericUpDown.ActiveControl != null)
                return;
            int c = this.fromDateTimePicker.Value.CompareTo(this.toDateTimePicker.Value);
            int days = 0;
            DateTime temp;
            if (c > 0)
            {
                temp = this.toDateTimePicker.Value;
                while (!temp.Date.Equals(fromDateTimePicker.Value.Date))
                {
                    days--;
                    temp = temp.AddDays(1);
                }
            }
            else
            {
                temp = this.fromDateTimePicker.Value;
                while (!temp.Date.Equals(toDateTimePicker.Value.Date))
                {
                    days++;
                    temp = temp.AddDays(1);
                }
            }
            this.DaysNumericUpDown.Value = days;
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "-";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EqualButton_Click(object sender, EventArgs e)
        {
            string stringToCalculate;
            if (inputTextBox.Text != "")
            {
                stringToCalculate = GetLastLineOfTextBox(inputTextBox);
                //TODO handle NaN?
                _answer = Convert.ToDouble(Calculate(stringToCalculate));
                _history[stringToCalculate] = _answer;
                Console.WriteLine(stringToCalculate);
                Console.WriteLine(_answer);
                inputTextBox.AppendText("\r\n" + _answer);
            }

        }

        private string GetLastLineOfTextBox(TextBox textBox)
        {
            return textBox.Lines[textBox.Lines.Length - 1];
        }

        private object Calculate(string text)
        {
            object result;
            try
            {
                result = new DataTable().Compute(text, "");
            }
            catch (Exception)
            {
                result = "NaN";
            }
            return result;
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += ".";
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "*";
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            inputTextBox.Text += "/";
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
            {
                var num = Convert.ToDouble(GetLastLineOfTextBox(inputTextBox));
                inputTextBox.Text = (num * num).ToString();
            }
        }

        private void ClearEntryButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text.LastIndexOf(Environment.NewLine) >= 0)
            {
                inputTextBox.Text = inputTextBox.Text.Remove(inputTextBox.Text.LastIndexOf(Environment.NewLine));
            }
            else
            {
                inputTextBox.Text = string.Empty;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = string.Empty;
            _answer = 0;            
        }

        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
            {
                double myNumber = Math.Sqrt(Convert.ToDouble(inputTextBox.Text));
                inputTextBox.Text = myNumber.ToString();
            }
        }

        private void InverseButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
            {
                double myNumber1 = Convert.ToDouble(GetLastLineOfTextBox(inputTextBox));
                inputTextBox.Text = (1.0 / myNumber1).ToString();
            }
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
            {
                double num = Convert.ToDouble(inputTextBox.Text);
                inputTextBox.Text = (num / 100).ToString();
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            double myNumber1 = System.Convert.ToDouble(inputTextBox.Text);
            inputTextBox.Text = (myNumber1 * -1).ToString();
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            int index = inputTextBox.Text.Length;
            index--;
            inputTextBox.Text = inputTextBox.Text.Remove(index);
            if (inputTextBox.Text == "")
            {
                inputTextBox.Text = "0";
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            double myNumber = System.Math.Log10(System.Convert.ToDouble(inputTextBox.Text));
            inputTextBox.Text = myNumber.ToString();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            double myNumber = System.Math.Sin(System.Convert.ToDouble(inputTextBox.Text));
            inputTextBox.Text = myNumber.ToString();
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            double myNumber = System.Math.Cos(System.Convert.ToDouble(inputTextBox.Text));
            inputTextBox.Text = myNumber.ToString();
        }

        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
            double myNumber = System.Math.Tan(System.Convert.ToDouble(inputTextBox.Text));
            inputTextBox.Text = myNumber.ToString();
        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();

        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void CalculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream st;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((st = dialog.OpenFile()) != null)
                {
                    var fileName = dialog.FileName;
                    var text = File.ReadAllText(fileName);
                    inputTextBox.Text = text;
                }
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void ClearCalculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "history.txt";
            var historyFile = File.Create(path);
            historyFile.Close();
        }

        private void SaveCalculatorHistoryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "txt files (*.txt)|.txt"
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK) {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (KeyValuePair<string, object> kvp in _history)
                    {
                        streamWriter.WriteLine(kvp.Key + kvp.Value);
                    }
                }
            }
        }
    }
}
    
    
