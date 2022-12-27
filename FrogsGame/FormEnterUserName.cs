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
    public partial class FormEnterUserName : Form
    {
        public int score = 10000;
        public FormEnterUserName()
        {
            InitializeComponent();
        }

        private void buttonSaveUserName_Click(object sender, EventArgs e)
        {
            StreamWriter fileResult = new StreamWriter("result.txt", true);
            fileResult.WriteLine(score.ToString() + "\t" + textBoxUserName.Text);
            fileResult.Close();
            this.Close();
        }
    }
}
