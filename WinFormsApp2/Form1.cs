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
            try // ����������� ����� ���� �������� � �������
            {

                str = textBox1.Text;

            }
            catch (FormatException) // ��� ������, ������� �������������
            {
                MessageBox.Show("������������ ����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // ��������� ���������� �����, ���� ����� �����-�� ������
            }
            Properties.Settings.Default.str = str;
            Properties.Settings.Default.Save();
            if (Logic.exam(str) == 1)
            {
                str = Logic.delSymb(str);
                label2.Text = "������� ���������� �������� ��� ����: " + Logic.searchNeigh(str);
            }
            else
            {
                MessageBox.Show("������� 1 �����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���� �����������. ����������, ������� � ��� ���������� �������� ����. ������� �� ���������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
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