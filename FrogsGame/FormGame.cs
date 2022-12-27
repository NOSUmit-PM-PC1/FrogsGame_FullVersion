using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogsGame
{
    public partial class FormGame : Form
    {
        Image imgFrogLeft, imgFrogRight, imgLeaf;
        int[] fieldStart = { 1, 1, 1, 1, 0, 2, 2, 2, 2 };
        int[] field;
        int indLeaf = 4;
        int step = 0;
        // для тестирования завершения игры
        //int[] fieldStart = { 2, 2, 2, 2, 1, 0, 1, 1, 1 };
        //int indLeaf = 5;

        public FormGame()
        {
            InitializeComponent();
        }

        void    newGame()
        {
            field = new int[fieldStart.Length];
            fieldStart.CopyTo(field, 0);
            indLeaf = 4;
            // для тестирования завершения игры
            //indLeaf = 5;
            step = 0;
            showFields();
        }
        private void dataGridViewFrogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Math.Abs(e.ColumnIndex - indLeaf) < 3)
            {
                field[indLeaf] = field[e.ColumnIndex];
                field[e.ColumnIndex] = 0;
                indLeaf = e.ColumnIndex;
                step += 1;
                showFields();
                if (isGameEnd())
                {
                    MessageBox.Show("Выиграл!");
                    FormEnterUserName formEnterUserName = new FormEnterUserName();
                    formEnterUserName.score = step;
                    formEnterUserName.ShowDialog();
                    FormShowResult formResult = new FormShowResult();
                    formResult.ShowDialog();
                    newGame();
                }

            }
            else
            {
                MessageBox.Show("Так ходить нельзя!");
            }
        }

        bool isGameEnd()
        {
            int[] fieldEnd = { 2, 2, 2, 2, 0, 1, 1, 1, 1 };

            for (int i = 0; i < field.Length; i++)
            {
                if (field[i] != fieldEnd[i])
                    return false;
            }
            return true;
        }

        void showFields()
        {
            for (int i = 0; i < field.Length; i++)
            {
                switch (field[i])
                {
                    case 1: dataGridViewFrogs[i, 0].Value = imgFrogLeft; break;
                    case 2: dataGridViewFrogs[i, 0].Value = imgFrogRight; break;
                    case 0: dataGridViewFrogs[i, 0].Value = imgLeaf; break;

                }
            }
            labelSteps.Text = step.ToString();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            imgLeaf = Image.FromFile("images/leaf.png");
            imgFrogLeft = Image.FromFile("images/frogLeft.png");
            imgFrogRight = Image.FromFile("images/frogRight.png");
            dataGridViewFrogs.Rows.Add();
            dataGridViewFrogs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.Width = imgLeaf.Width * 9;
            newGame();
        }
    }
}
