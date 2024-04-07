namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.str;
        }
        public class Logic
        {
            public static string delSymb(string str)
            {
                str = str.Replace(" ", String.Empty);
                str = str.Replace(",", String.Empty);
                str = str.Replace(":", String.Empty);
                str = str.Replace("-", String.Empty);
                str = str.ToLower();
                return str;
            }
            public static int searchNeigh(string str)
            {
                var count = 0;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (str[i] == str[i + 1])
                    {
                        count++;
                    }
                }
                return count;
            }
            public static int exam(string str)
            {
                var count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if ((str[i] == '.') || (str[i] == '!') || (str[i] == '?'))
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string str;
            try // оборачиваем кусок кода склонный к падению
            {

                str = textBox1.Text;

            }
            catch (FormatException) // тип ошибки, которую перехватываем
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // прерываем обработчик клика, если ввели какую-то ерунду
            }
            Properties.Settings.Default.str = str;
            Properties.Settings.Default.Save();
            if (Logic.exam(str) == 1)
            {
                str = Logic.delSymb(str);
                label2.Text = "Найдено одинаковых соседних пар букв: " + Logic.searchNeigh(str);
            }
            else
            {
                MessageBox.Show("Введите 1 предложение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дано предложение. Определить, сколько в нем одинаковых соседних букв. Пробелы не учитывать.", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
        }
    }
}