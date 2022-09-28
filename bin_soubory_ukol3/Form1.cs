using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bin_soubory_ukol3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\texty.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox1.AppendText(br.ReadChar().ToString()); //z nějakýho důvodu mi přestal po včerejšku fungovat .ReadString()
            }

            br.Close();
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\texty.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);

            for(int i = 0; i < textBox1.Lines.Count(); i++)
            {
                string radek = textBox1.Lines[i];
                char[] radek2 = radek.ToCharArray();

                for (int y = 0; y < radek2.Length; y++)
                {
                    if (radek2[y] == '.')
                    {
                        radek2[y] = '!';
                    }

                    if (radek2[y] == '!')
                    {
                        bw.Write(radek2[y].ToString() + Environment.NewLine);
                    }
                    else
                    {
                        bw.Write(radek2[y].ToString());
                    }
                }
            }

            bw.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"..\..\texty.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs2);

            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox2.AppendText(br.ReadString()); //tady mi funguje, nechápu proč
            }

            br.Close();
            fs.Close();
        }
    }
}
