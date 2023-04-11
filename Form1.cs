using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        static void PrintArr(int[] te)
        {
            foreach(int i in te)
            {
                MessageBox.Show(i.ToString());
            }
        }//��ӡ���飬������;
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
        {//�����պű�Ϳ������ű�����������ű�ĳ����պ��غϣ������޳�
            for (int i = 0; i < listBox1.Items.Count; i++)//�����պű�<----------------�ص㣺�պű�Ҫ����ѭ��
            {
                for (int j = 0 ; j < listBox4.Items.Count; j++)//�����������ű�
                {
                    if (listBox4.Items[j].Equals(listBox1.Items[i]))//����ͬ
                        listBox4.Items.RemoveAt(j);//ɾȥ
                }
            }
            //����ѭ���������ű��������ű�仯��ʱ���©���������(��������������ǰ�ߴ��ں���(4,3)������©��ǰ��)
        }//�պ�
        public void yxti2()
        {//������ͷ�˱�Ϳ������ű�����������ű�ĳ�����ͷ���غϣ������޳�
            for (int i = 0; i < listBox2.Items.Count; i++)//������ͷ�˱�<----------------�ص㣺��ͷ�˱�Ҫ����ѭ��
            {
                for (int j = 0; j < listBox4.Items.Count; j++)//�����������ű�
                {
                    if (listBox4.Items[j].Equals(listBox2.Items[i]))//����ͬ
                    {
                        listBox4.Items.RemoveAt(j);//ɾȥ
                    }
                }
            }
        }//��ͷ��

        public void quis2()//ȥ���պű����ͷ�˱��ظ���
        {
            for (int i = 0; i < listBox1.Items.Count; i++)//�����պű�
            {
                for (int j = i + 1; j < listBox2.Items.Count; j++)//������ͷ�˱�
                {
                    if (listBox1.Items[i].Equals(listBox2.Items[j]))//���պű�ĳ����ĳ����ͷ����ͬ
                    {
                        listBox1.Items.RemoveAt(i);//ȥ��
                    }
                }
            }
        }
        public void quis()
        {
            try//��������
            {
                quis2();
                for (int i = 0; i < listBox1.Items.Count; i++)//�����պ��˱�
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)//������ͷ�˱�
                    {
                        if (listBox1.Items[i].Equals(listBox2.Items[j]))//���ĳ���ظ�
                        {
                            listBox1.Items.RemoveAt(i);//ȥ��
                        }
                    }
                }
                for (int i = 0; i < listBox1.Items.Count; i++)//�����պű�
                {
                    for (int j = i + 1; j < listBox1.Items.Count; j++)//�����պű�
                    {
                        if (listBox1.Items[i].Equals(listBox1.Items[j]))//���ĳ���ظ�
                        {
                            listBox1.Items.RemoveAt(i);//ȥ��
                        }
                    }
                }
                for (int i = 0; i < listBox2.Items.Count; i++)//������ͷ�˱�
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)
                    {
                        if (listBox2.Items[i].Equals(listBox2.Items[j]))//���ĳ���ظ�
                        {
                            listBox2.Items.RemoveAt(i);//�غ���ɾ��
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
            if (listBox2.Items.Count == 0)//����ͷ������Ϊ0
            {
                MessageBox.Show("��ͷ����������һ��");
            }
            else
            {
                listBox3.Items.Clear();//��ս��
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
                yxti2();//�޳��պ�
                yxti1();//�޳�����

                int arlong = listBox4.Items.Count / listBox2.Items.Count;//���ƽ��ÿ����ͷ����������Ա����
                int arlongy = listBox4.Items.Count % listBox2.Items.Count;//�������Ա���Ժ����

                int[] rfuu = new int[listBox4.Items.Count];//����һ�����ȵ��ڿ������ű��ȵ�����
                int ptr = 0;
                for (int i = 0; i < listBox4.Items.Count; i++)//
                {
                    rfuu[i] = Convert.ToInt32(listBox4.Items[i]);//�����������е�ֵ������������
                }
                RandomArr(rfuu);//������������ڵ�ֵ

                List<string> listzh = new List<string>();//����һ��string���͵ı�
                
                for (int i = 0; i < listBox2.Items.Count; i++)//����ͷ������ѭ��
                {
                    string jle = "";//��ʼ�����ű�
                    for (int j = ptr; j < ptr + arlong; j++)//ƽ��ÿ����ͷ��Ҫ��������
                    {
                        jle += rfuu[j].ToString() + ",";//�������źͶ���
                    }
                    jle = jle.Substring(0, jle.Length - 1);
                    ptr += arlong;//��������ָ��
                    listzh.Add("��"+(i+1)+"�顪"+listBox2.Items[i].ToString()+" : "+jle);//����š���ͷ�ˡ���:�����ֺõ����������
                }
                foreach (string s in listzh)//����listzh��
                {
                    listBox3.Items.Add(s);//������
                }
                //���ʣ�������
                string doyu = "ʣ������ţ�";
                for (int i = ptr; i < rfuu.Length; i++)//
                {
                    doyu += rfuu[i].ToString() + ",";
                }
                doyu = doyu.Substring(0, doyu.Length - 1);
                listBox3.Items.Add(doyu);
            }
        }//���

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
            else if (listBox1.Items.Count > Convert.ToInt32(textBox1.Text) - 1)
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
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
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
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//�����������ֺ��˸�
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//�����������ֺ��˸�
                e.Handled = true;
            else if(e.KeyChar == 0xDA)//13,10,�س�����ASCII��
            {
                button2.PerformClick();
            }
            if (textBox1.Text == "")
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//�����������ֺ��˸�
                e.Handled = true;
            else if (e.KeyChar == 0xDA)
            {
                button3.PerformClick();
            }
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
                button3.Enabled = true;
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox3.Items.Count != 0)
            {
                string[] str = new string[listBox3.Items.Count];
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    str[i] = listBox3.Items[i].ToString();
                }
                File.WriteAllLines(@".\����.txt", str);
                MessageBox.Show("�������");
            }
            else
            {
                MessageBox.Show("������");
            }
        }//����Ϊ�ı�
    }
}