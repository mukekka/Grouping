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
        }//打印数组，测试用途
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
            //PrintArr(arr);//输出打乱后的数组元素
        }//随机打乱数组

        public void yxti1()
        {//遍历空号表和可用座号表，如果可用座号表某项与空号重合，则将其剔除
            for (int i = 0; i < listBox1.Items.Count; i++)//遍历空号表<----------------重点：空号表要在外循环
            {
                for (int j = 0 ; j < listBox4.Items.Count; j++)//遍历可用座号表
                {
                    if (listBox4.Items[j].Equals(listBox1.Items[i]))//若相同
                        listBox4.Items.RemoveAt(j);//删去
                }
            }
            //若先循环可用座号表，可用座号表变化的时候会漏掉后面的数(若相邻两个数，前者大于后者(4,3)，会遗漏掉前者)
        }//空号
        public void yxti2()
        {//遍历带头人表和可用座号表，如果可用座号表某项与带头人重合，则将其剔除
            for (int i = 0; i < listBox2.Items.Count; i++)//遍历带头人表<----------------重点：带头人表要在外循环
            {
                for (int j = 0; j < listBox4.Items.Count; j++)//遍历可用座号表
                {
                    if (listBox4.Items[j].Equals(listBox2.Items[i]))//若相同
                    {
                        listBox4.Items.RemoveAt(j);//删去
                    }
                }
            }
        }//带头人

        public void quis2()//去除空号表与带头人表重复的
        {
            for (int i = 0; i < listBox1.Items.Count; i++)//遍历空号表
            {
                for (int j = i + 1; j < listBox2.Items.Count; j++)//遍历带头人表
                {
                    if (listBox1.Items[i].Equals(listBox2.Items[j]))//若空号表某项与某个带头人相同
                    {
                        listBox1.Items.RemoveAt(i);//去除
                    }
                }
            }
        }
        public void quis()
        {
            try//跳过错误
            {
                quis2();
                for (int i = 0; i < listBox1.Items.Count; i++)//遍历空号人表
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)//遍历带头人表
                    {
                        if (listBox1.Items[i].Equals(listBox2.Items[j]))//如果某项重复
                        {
                            listBox1.Items.RemoveAt(i);//去除
                        }
                    }
                }
                for (int i = 0; i < listBox1.Items.Count; i++)//遍历空号表
                {
                    for (int j = i + 1; j < listBox1.Items.Count; j++)//遍历空号表
                    {
                        if (listBox1.Items[i].Equals(listBox1.Items[j]))//如果某项重复
                        {
                            listBox1.Items.RemoveAt(i);//去除
                        }
                    }
                }
                for (int i = 0; i < listBox2.Items.Count; i++)//遍历带头人表
                {
                    for (int j = i + 1; j < listBox2.Items.Count; j++)
                    {
                        if (listBox2.Items[i].Equals(listBox2.Items[j]))//如果某项重复
                        {
                            listBox2.Items.RemoveAt(i);//重合则删除
                        }
                    }
                }
            }
            catch
            {

            }
        }//剔除重复值

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 0)//若带头人数量为0
            {
                MessageBox.Show("带头人至少输入一个");
            }
            else
            {
                listBox3.Items.Clear();//清空结果
                if (listBox4.Items.Count > 0)
                {
                    listBox4.Items.Clear();//清空可用座号
                }
                quis();//剔除重复值
                if (textBox1.Text == "" || textBox1.Text == "0")//若人数为0或空
                {
                    MessageBox.Show("人数不能为空或为零");
                    textBox1.Clear();
                }
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    listBox4.Items.Add(Convert.ToString(i + 1));//将全部座号填入表
                }
                yxti2();//剔除空号
                yxti1();//剔除座号

                int arlong = listBox4.Items.Count / listBox2.Items.Count;//求出平均每个带头人所带的组员数量
                int arlongy = listBox4.Items.Count % listBox2.Items.Count;//多出的组员，稍后分配

                int[] rfuu = new int[listBox4.Items.Count];//定义一个长度等于可用座号表长度的数组
                int ptr = 0;
                for (int i = 0; i < listBox4.Items.Count; i++)//
                {
                    rfuu[i] = Convert.ToInt32(listBox4.Items[i]);//将可用座号中的值依次填入数组
                }
                RandomArr(rfuu);//随机打乱数组内的值

                List<string> listzh = new List<string>();//定义一个string类型的表
                
                for (int i = 0; i < listBox2.Items.Count; i++)//按带头人人数循环
                {
                    string jle = "";//初始化座号表
                    for (int j = ptr; j < ptr + arlong; j++)//平均每个带头人要带的人数
                    {
                        jle += rfuu[j].ToString() + ",";//填入座号和逗号
                    }
                    jle = jle.Substring(0, jle.Length - 1);
                    ptr += arlong;//保存数组指针
                    listzh.Add("第"+(i+1)+"组—"+listBox2.Items[i].ToString()+" : "+jle);//把组号、带头人、“:”、分好的座号填入表
                }
                foreach (string s in listzh)//遍历listzh表
                {
                    listBox3.Items.Add(s);//填入结果
                }
                //输出剩余的座号
                string doyu = "剩余的座号：";
                for (int i = ptr; i < rfuu.Length; i++)//
                {
                    doyu += rfuu[i].ToString() + ",";
                }
                doyu = doyu.Substring(0, doyu.Length - 1);
                listBox3.Items.Add(doyu);
            }
        }//完成

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
            else if (listBox1.Items.Count > Convert.ToInt32(textBox1.Text) - 1)
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
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
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
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//允许输入数字和退格
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//允许输入数字和退格
                e.Handled = true;
            else if(e.KeyChar == 0xDA)//13,10,回车键的ASCII码
            {
                button2.PerformClick();
            }
            if (textBox1.Text == "")
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//允许输入数字和退格
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
        }//去重

        private void button9_Click(object sender, EventArgs e)//随机功能
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
                File.WriteAllLines(@".\分组.txt", str);
                MessageBox.Show("创建完成");
            }
            else
            {
                MessageBox.Show("无内容");
            }
        }//导出为文本
    }
}