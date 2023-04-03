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
        /*public List<int> Generate1()
        {
            Random random = new Random();
            List<int> result = new List<int>();
            int temp;
            while (result.Count < listBox2.Items.Count)
            {
                temp = random.Next(0, listBox3.Items.Count-1);
                if (!result.Contains(temp))
                {
                    result.Add(temp);
                }
            }
            return result;
        }*/
        static void PrintArr(int[] te)
        {
            for (int i = 0; i < te.Length; i++)
            {
                MessageBox.Show(Convert.ToString( te[i]));
            }
        }
        static void RandomArr(int[] arr)
        {
            Random r = new Random();//创建随机类对象，定义引用变量为r
            for (int i = 0; i < arr.Length; i++)
            {
                int index = r.Next(arr.Length);//随机获得0（包括0）到arr.Length（不包括arr.Length）的索引
                int temp = arr[i];  //当前元素和随机元素交换位置
                arr[i] = arr[index];
                arr[index] = temp;
            }
            PrintArr(arr);//输出打乱后的数组元素
        }

        public void yxti1()
        {//遍历剔除座号表和可用座号表，如果可用座号表某项与剔除座号重合，则将其剔除
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox4.Items.Count; j++)
                {
                    if (listBox1.Items[i].Equals(listBox4.Items[j]))
                        listBox4.Items.Remove(listBox1.Items[i]);
                }
            }
        }//剔除座号
        public void yxti2()
        {//遍历带头人表和可用座号表，如果可用座号表某项与带头人重合，则将其剔除
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                for (int j = i + 1; j < listBox4.Items.Count; j++)
                {
                    if (listBox2.Items[i].Equals(listBox4.Items[j]))
                        listBox4.Items.Remove(listBox2.Items[i]);
                }
            }
        }//带头人

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
            try//跳过错误
            {
                quis2();
                for (int i = 0; i < listBox1.Items.Count; i++)//遍历剔除座号表和带头人表，如果剔除座号表某项与带头人重合，则将其剔除
                {
                    for (int j = i; j < listBox2.Items.Count; j++)
                    {
                        if (listBox1.Items[i].Equals(listBox2.Items[j]))
                            listBox1.Items.Remove(listBox2.Items[j]);
                    }
                }
                for (int i = 0; i < listBox1.Items.Count; i++)//遍历剔除座号表，重合则删除
                {
                    for (int j = i + 1; j < listBox1.Items.Count; j++)
                    {
                        if (listBox1.Items[i].Equals(listBox1.Items[j]))
                            listBox1.Items.Remove(listBox1.Items[j]);
                    }
                }
                for (int i = 0; i < listBox2.Items.Count; i++)//遍历带头人表，重合则删除
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)
                    {
                        if (listBox2.Items[i].Equals(listBox2.Items[j]))
                            listBox2.Items.Remove(listBox2.Items[j]);
                    }
                }

            }
            catch
            {

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
                MessageBox.Show("人数不能为空或为零");
                textBox1.Clear();
            }
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                listBox4.Items.Add(Convert.ToString(i+1));
            }
            yxti1();
            yxti2();
            /*
            int arlong = listBox4.Items.Count / listBox2.Items.Count;
            int arlongy = listBox4.Items.Count % listBox2.Items.Count;
            int[] rfuu = new int[listBox3.Items.Count];
            for (int i = 0; i < listBox3.Items.Count; i++)
            {
                rfuu[i] = Convert.ToInt32(listBox3.Items[i]);
            }*/
            //RandomArr(rfuu);
        }

        private void button3_Click(object sender, EventArgs e)//左下一个
        {
            if (textBox3.Text == "0")
            {
                MessageBox.Show("座号不能为零");
                textBox3.Clear();
            }
            else if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(textBox1.Text))
            {
                MessageBox.Show("座号超出范围");
                textBox3.Clear();
            }
            else if (listBox1.Items.Count > Convert.ToInt32(textBox1.Text)-1)
            {
                MessageBox.Show("人数太多了");
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
                MessageBox.Show("没法再撤了(＞︿＜)");
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count-1);
                textBox3.Clear();
            }
        }//左撤回

        private void button2_Click(object sender, EventArgs e)//右下一个
        {
            if (textBox2.Text == "0")
            {
                MessageBox.Show("带头人不能为零");
                textBox2.Clear();
            }
            else if (Convert.ToInt32(textBox2.Text) > Convert.ToInt32(textBox1.Text))
            {
                MessageBox.Show("座号超出范围");
                textBox2.Clear();
            }
            else if (listBox2.Items.Count > Convert.ToInt32(textBox1.Text) - 1)
            {
                MessageBox.Show("人数太多了");
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
                MessageBox.Show("没法再撤了(＞︿＜)");
            }
            else
            {
                listBox2.Items.RemoveAt(listBox2.Items.Count - 1);
                textBox2.Clear();
            }
        }//右撤回

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
        }//去重
    }
}