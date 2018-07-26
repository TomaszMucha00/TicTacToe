using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //x
        bool turn = true; // true = X turn, false = Y turn
        int turnCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Varimatras", "Tic Tac Toe");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn)
            {
                button.Text = "X";
            }
            else
            {
                button.Text = "0";
            }
            button.Enabled = false;
            turnCounter++;
            checkForWiner(button.Text);
            turn = !turn;
        }

        private void checkForWiner(string buttonText)
        {
            bool horizontal1 = A1.Text == A2.Text && A2.Text == A3.Text && A1.Text != "";
            bool horizontal2 = B1.Text == B2.Text && B2.Text == B3.Text && B1.Text != "";
            bool horizontal3 = C1.Text == C2.Text && C2.Text == C3.Text && C1.Text != "";
            bool vertical1 = A1.Text == B1.Text && B1.Text == C1.Text && A1.Text != "";
            bool vertical2 = A2.Text == B2.Text && B2.Text == C2.Text && A2.Text != "";
            bool vertical3 = A3.Text == B3.Text && B3.Text == C3.Text && A3.Text != "";
            bool cross1 = A1.Text == B2.Text && B2.Text == C3.Text && A1.Text != "";
            bool cross2 = C1.Text == B2.Text && B2.Text == A3.Text && A3.Text != "";
            bool horizontal = horizontal1 || horizontal2 || horizontal3;
            bool vertical = vertical1 || vertical2 || vertical3;
            bool cross = cross1 || cross2;
            bool isWinner = horizontal || vertical || cross;

            if (isWinner)
            {
                disableButtons();
                MessageBox.Show(buttonText + " is the winner", "Congratulations");
            }
            else
            {
                if (turnCounter == 9)
                {
                    MessageBox.Show("Draw", "Ups!");
                }
            }
        }

        private void disableButtons()
        {
            foreach (Control control in Controls)
            {
                try
                {
                    Button button = (Button)control;
                    button.Enabled = false;
                }
                catch (Exception) {}
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCounter = 0;
            foreach (Control control in Controls)
            {
                try
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                    button.Text = "";
                }
                catch (Exception) { }
            }
        }
    }
}
