using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {       
        public void yxti1()
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox4.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox4.Items[j]))
                        listBox4.Items.Remove(listBox1.Items[i]);
                }
            }
        }//�޳�����
        public void yxti2()
        {
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox4.Items.Count; j++)
                {
                    if (listBox2.Items[i].Equals(listBox4.Items[j]))
                        listBox4.Items.Remove(listBox2.Items[i]);
                }
            }
        }//��ͷ��

        public void quis2()
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i; j < listBox2.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox2.Items[j]))
                        listBox1.Items.Remove(listBox2.Items[j]);
                }
            }
        }
        public void quis()
        {
            quis2();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i; j < listBox2.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox2.Items[j]))
                        listBox1.Items.Remove(listBox2.Items[j]);
                }
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox1.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox1.Items[j]))
                        listBox1.Items.Remove(listBox1.Items[j]);
                }
            }
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox2.Items.Count; j++)
                {
                    if (listBox2.Items[i].Equals(listBox2.Items[j]))
                        listBox2.Items.Remove(listBox2.Items[j]);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox4.Items.Count>0)
            {
                listBox4.Items.Clear();
            }
            quis();
            if (textBox1.Text == ""||textBox1.Text == "0")
            {
                MessageBox.Show("��������Ϊ�ջ�Ϊ��");
                textBox1.Clear();
            }

            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                listBox4.Items.Add(Convert.ToString(i+1));
            }
            yxti1();
            yxti2();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)//����һ��
        {
            if (textBox3.Text == "0")
            {
                MessageBox.Show("���Ų���Ϊ��");
                textBox3.Clear();
            }
            else if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(textBox1.Text))
            {
                MessageBox.Show("���ų�����Χ");
                textBox3.Clear();
            }
            else if (listBox1.Items.Count > Convert.ToInt32(textBox1.Text)-1)
            {
                MessageBox.Show("����̫����");
                textBox3.Clear();
            }
            else
            {
                listBox1.Items.Add(textBox3.Text);
                textBox3.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("û���ٳ���(���䣼)");
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);
                textBox3.Clear();
            }
        }//�󳷻�

        private void button2_Click(object sender, EventArgs e)//����һ��
        {
            if (textBox2.Text == "0")
            {
                MessageBox.Show("��ͷ�˲���Ϊ��");
                textBox2.Clear();
            }
            else if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(textBox1.Text))
            {
                MessageBox.Show("���ų�����Χ");
                textBox2.Clear();
            }
            else if (listBox2.Items.Count > Convert.ToInt32(textBox1.Text) - 1)
            {
                MessageBox.Show("����̫����");
                textBox2.Clear();
            }
            else
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("û���ٳ���(���䣼)");
            }
            else
            {
                listBox2.Items.RemoveAt(listBox2.Items.Count - 1);
                textBox2.Clear();
            }
        }//�ҳ���

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
            if (textBox1.Text == "")
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
            if (textBox1.Text == "")
                e.Handled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*if (textBox1.Text == "")
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled= true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            quis();
        }//ȥ��
    }
}