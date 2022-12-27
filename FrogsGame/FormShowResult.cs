using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogsGame
{
    public partial class FormShowResult : Form
    {
        public FormShowResult()
        {
            InitializeComponent();
        }

        private void FormShowResult_Load(object sender, EventArgs e)
        {
            string[] listResult = new string[100];
            StreamReader fileResult = new StreamReader("result.txt");
            int i = 0;
            while(!fileResult.EndOfStream)
            {
                string s = fileResult.ReadLine();
                listResult[i++] = s;
                if (i == 100) break;
            }
            fileResult.Close();
            Array.Sort(listResult);
            for (int j = 0; j < 100; j++)
            {
                if (listResult[j] != null)
                    listBoxResult.Items.Add(listResult[j]);
            }
          
        }
    }
}
