using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
            //PrintArr(arr);//输出打乱后的数组元素
        }//随机打乱数组
        List<int> arr = new List<int>();
        int len;
        int len2;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "0"|| textBox1.Text == "")
            {
                MessageBox.Show("人数不能为0");
                textBox1.Clear();
            }
            else
            {
                int[] ranlist = new int[Convert.ToInt32(textBox1.Text)];
                for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
                {
                    ranlist[i-1] = i;
                }
                RandomArr(ranlist);
                foreach (int s in ranlist)
                {
                    arr.Add(s);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="")
            {
                MessageBox.Show("人数不能为空");
            }
            else
            {
                if (button1.Text == "开始")
                {
                    timer1.Enabled = true;
                    button1.Text = "停止";
                }
                else if(arr.Count == 0)
                {
                    MessageBox.Show("没有可用的数了\n请输入新的数");
                    timer1.Enabled=false;
                    button1.Text = "开始";
                }
                else
                {
                    label2.Text = arr.Last().ToString();
                    arr.Remove(arr.Last());

                    timer1.Enabled = false;
                    button1.Text = "开始";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int ir = Convert.ToInt32(textBox1.Text);
            label2.Text = Convert.ToString(ran.Next(0, ir));
        }
    }
}
