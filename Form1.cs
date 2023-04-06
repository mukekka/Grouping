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
        static void PrintArr(int[] te)
        {
            for (int i = 0; i < te.Length; i++)
            {
                MessageBox.Show(Convert.ToString( te[i]));
            }
        }//��ӡ����
        static void RandomArr(int[] arr)
        {
            Random r = new Random();//�����������󣬶������ñ���Ϊr
            for (int i = 0; i < arr.Length; i++)
            {
                int index = r.Next(arr.Length);//������0������0����arr.Length��������arr.Length��������
                int temp = arr[i];  //��ǰԪ�غ����Ԫ�ؽ���λ��
                arr[i] = arr[index];
                arr[index] = temp;
            }
            //PrintArr(arr);//������Һ������Ԫ��
        }//�����������

        public void yxti1()
        {//�����޳����ű�Ϳ������ű�����������ű�ĳ�����޳������غϣ������޳�
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i; j < listBox4.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox4.Items[j]))
                        listBox4.Items.Remove(listBox1.Items[i]);
                }
            }
        }//�޳�����
        public void yxti2()
        {//������ͷ�˱�Ϳ������ű�����������ű�ĳ�����ͷ���غϣ������޳�
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                for (int j = i; j < listBox4.Items.Count; j++)
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
                    {
                        listBox1.Items.Remove(listBox2.Items[j]);
                    }
                }
            }
        }
        public void quis()
        {
            try//��������
            {
                quis2();
                for (int i = 0; i < listBox1.Items.Count; i++)//�����޳����ű�ʹ�ͷ�˱�����޳����ű�ĳ�����ͷ���غϣ������޳�
                {
                    for (int j = i; j < listBox2.Items.Count; j++)
                    {
                        if (listBox1.Items[i].Equals(listBox2.Items[j]))
                        {
                            listBox1.Items.Remove(listBox2.Items[j]);
                        }
                    }
                }
                for (int i = 0; i < listBox1.Items.Count; i++)//�����޳����ű��غ���ɾ��
                {
                    for (int j = i + 1; j < listBox1.Items.Count; j++)
                    {
                        if (listBox1.Items[i].Equals(listBox1.Items[j]))
                        {
                            listBox1.Items.Remove(listBox1.Items[j]);
                        }
                    }
                }
                for (int i = 0; i < listBox2.Items.Count; i++)//������ͷ�˱��غ���ɾ��
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)
                    {
                        if (listBox2.Items[i].Equals(listBox2.Items[j]))
                        {
                            listBox2.Items.Remove(listBox2.Items[j]);
                        }
                    }
                }

            }
            catch
            {

            }
        }//�޳��ظ�ֵ

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count==0)//����ͷ������Ϊ0
            {
                MessageBox.Show("��ͷ����������һ��");
            }
            else
            {
                if (listBox4.Items.Count > 0)
                {
                    listBox4.Items.Clear();//��տ�������
                }
                quis();//�޳��ظ�ֵ
                if (textBox1.Text == "" || textBox1.Text == "0")//������Ϊ0���
                {
                    MessageBox.Show("��������Ϊ�ջ�Ϊ��");
                    textBox1.Clear();
                }
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    listBox4.Items.Add(Convert.ToString(i + 1));//��ȫ�����������
                }
                yxti2();//�޳���ͷ��
                yxti1();//�޳�����

                int arlong = listBox4.Items.Count / listBox2.Items.Count;//���ƽ��ÿ����ͷ����������Ա����
                int arlongy = listBox4.Items.Count % listBox2.Items.Count;//�������Ա���Ժ����

                int[] rfuu = new int[listBox4.Items.Count];//����һ�����ȵ��ڿ������ű��ȵ�����
                for (int i = 0; i < listBox4.Items.Count; i++)//
                {
                    rfuu[i] = Convert.ToInt32(listBox4.Items[i]);//�����������е�ֵ������������
                }
                RandomArr(rfuu);//������������ڵ�ֵ
                
                List<string> listzh = new List<string>();//����һ��string���͵ı�

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    
                    listzh.Add(Convert.ToString(listBox2.Items[i])+" : ");//�Ѵ�ͷ�˺͡�:�������
                }
                foreach (string s in listzh)//����listzh��
                {
                    listBox3.Items.Add(s);//������
                }

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

        private void button9_Click(object sender, EventArgs e)//�������
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
    }
}