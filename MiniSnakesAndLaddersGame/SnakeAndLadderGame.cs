using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSnakesAndLaddersGame {
    public partial class SnakeAndLadderGame : Form {

        //Snake and Ladder Position Array
        private int[] mSnakesAndLadders;

        //Players Postions
        private int mPlayer1Postion;
        private int mPlayer2Postion;

        //Random
        private Random mRnd = new Random();
        private static readonly object syncLock = new object();

        public SnakeAndLadderGame() {
            InitializeComponent();
            InitializeForm();
            //Initialize Palyer Position.
            mPlayer1Postion = 0;
            mPlayer2Postion = 0;

            //Die button
            rollBtnPly1.Enabled = false;
            rollBtnPly2.Enabled = false;
        }

        private void rollBtnPly1_Click(object sender, EventArgs e) {
            //initialize palyser Button
            rollBtnPly1.Enabled = false;
            rollBtnPly2.Enabled = true;

            doRollTheDie("Player1", mPlayer1Postion);
            
        }

        private void rollBtnPly2_Click(object sender, EventArgs e) {
            //initialize palyser Button
            rollBtnPly1.Enabled = true;
            rollBtnPly2.Enabled = false;

            doRollTheDie("Player2", mPlayer2Postion);
        }

        private void startBtn_Click(object sender, EventArgs e) {
            //initialize palyser Button
            rollBtnPly1.Enabled = true;
            rollBtnPly2.Enabled = false;

            //Initialize Palyer Position.
            mPlayer1Postion = 0;
            mPlayer2Postion = 0;

            //Generate Snakes and Ladders
            mSnakesAndLadders = generateSnakesAndLadders();

            //initialize Labels
            InitializeForm();

            //Set snakes and ladders
            Control[] cs;
            //Show Labels
            //Snake Head1
            cs = this.Controls.Find("head_" + mSnakesAndLadders[0], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Green,"Head1");

            }
            //Snake Tail1
            cs = this.Controls.Find("tail_" + mSnakesAndLadders[1], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Green,"Tail1");

            }
            //Snake Head2
            cs = this.Controls.Find("head_" + mSnakesAndLadders[2], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Black,"Head2");

            }
            //Snake Tail2
            cs = this.Controls.Find("tail_" + mSnakesAndLadders[3], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Black,"Tail2");

            }
            //Snake Head3              
            cs = this.Controls.Find("head_" + mSnakesAndLadders[4], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Brown,"Head3");

            }
            //Snake Tail3
            cs = this.Controls.Find("tail_" + mSnakesAndLadders[5], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Brown,"Tail3");

            }
            //Ladder Top1
            cs = this.Controls.Find("top_" + mSnakesAndLadders[6], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Pink,"Top1");

            }
            //Ladder Bottom1
            cs = this.Controls.Find("bottom_" + mSnakesAndLadders[7], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Pink,"Bottom1");

            }
            //Ladder Top2
            cs = this.Controls.Find("top_" + mSnakesAndLadders[8], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Orange,"Top2");

            }
            //Ladder Bottom2
            cs = this.Controls.Find("bottom_" + mSnakesAndLadders[9], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Orange,"Bottom2");

            }
            //Ladder Top3
            cs = this.Controls.Find("top_" + mSnakesAndLadders[10], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Purple,"Top3");

            }
            //Ladder Bottom3
            cs = this.Controls.Find("bottom_" + mSnakesAndLadders[11], true);
            if (cs.Length > 0) {
                changeLblStatus(cs, true, System.Drawing.Color.Purple,"Bottom3");

            }
            
        }

        private void doRollTheDie(String playerString, int position) {
            int dieNum = getRandomNum(1, 7);
            position += dieNum;
            richTextBox1.Text = playerString + " got Number: " + dieNum + "\n" + richTextBox1.Text;

            //init postions
            if (playerString == "Player1") {
                initFormPlayer1();
            } else if (playerString == "Player2") {
                initFormPlayer2();
            }

            if (position <= 30) {
                for (int i = 0; i < 12; i++) {
                    if (position == mSnakesAndLadders[i]) {
                        switch (i) {
                            case 0: //Snake head1
                                position = mSnakesAndLadders[1];
                                richTextBox1.Text = playerString + " got Snake1, You've got got backward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;
                            case 2://Snake head2
                                position = mSnakesAndLadders[3];
                                richTextBox1.Text = playerString + " got Snake2, You've got got backward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;
                            case 4://Snake head3
                                position = mSnakesAndLadders[5];
                                richTextBox1.Text = playerString + " got Snake3, You've got go backward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;
                            case 7://Ladder Top1
                                position = mSnakesAndLadders[6];
                                richTextBox1.Text = playerString + " got Ladder1, You've got go forward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;
                            case 9://Ladder Top2
                                position = mSnakesAndLadders[8];
                                richTextBox1.Text = playerString + " got Ladder2, You've got go forward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;
                            case 11://Ladder Top3
                                position = mSnakesAndLadders[10];
                                richTextBox1.Text = playerString + " got Ladder3, You've got go forward! To the No: " + position + "!\n" + richTextBox1.Text;
                                break;

                        }
                    }

                }
                //Move the label
                Control[] cs;
                if (playerString == "Player1") {
                    cs = this.Controls.Find("player1_" + position, true);
                    ((Label)cs[0]).Visible = true;
                    mPlayer1Postion = position;

                } else if (playerString == "Player2") {
                    cs = this.Controls.Find("player2_" + position, true);
                    ((Label)cs[0]).Visible = true;
                    mPlayer2Postion = position;
                }


            } else {
                richTextBox1.Text = playerString + " is won!!!!\n" + richTextBox1.Text;
                if (playerString == "Player1") {
                    player1_30.Visible = true;
                    player1_30.BackColor = Color.Yellow;
                    rollBtnPly2.Enabled = false;
                } else if (playerString == "Player2") {
                    player2_30.Visible = true;
                    player2_30.BackColor = Color.Yellow;
                    rollBtnPly2.Enabled = false;
                }
            }
        }

        private void changeLblStatus(Control[] cs, bool visible, Color color, String name) {
            ((Label)cs[0]).Visible = visible;
            ((Label)cs[0]).ForeColor = System.Drawing.Color.White;
            ((Label)cs[0]).BackColor = color;
            if (name !="" && name != null) {
                ((Label)cs[0]).Text = name;
            }

        }

        private void closeBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private int getRowNum(int position) {

            if (1 <= position && position < 7) {
                return 1;
            } else if (7 <= position && position < 13) {
                return 7;
            } else if (13 <= position && position < 19) {
                return 13;
            } else if (19 <= position && position < 25) {
                return 19;
            } else if (25 <= position && position < 31) {
                return 25;
            }

            return 0;
        }

        private int getRandomNum(int min, int max) {
            if (min < max) {
                lock (syncLock) {
                    return mRnd.Next(min, max);
                }
            } else {
                return 0;
            }
        }

        private int[] generateSnakesAndLadders() {
            int[] snakeAndLadders = new int[12];

            //To decide snake head 1 position
            //Snake's head is never be lowest rows
            //To decide snake tail 1 position
            //Snake's tail is never be highest rows
            snakeAndLadders[0] = getRandomNum(7, 31);
            snakeAndLadders[1] = getRandomNum(1, getRowNum(snakeAndLadders[0]));

            //To decide snake head 2 position
            //Snake's head is never be lowest rows
            //To decide snake tail 2 position
            //Snake's tail is never be highest rows
            snakeAndLadders[2] = getRandomNum(7, 31);
            while (snakeAndLadders[2] == snakeAndLadders[0] || snakeAndLadders[2] == snakeAndLadders[1]) {
                snakeAndLadders[2] = getRandomNum(7, 31);
            }

            snakeAndLadders[3] = getRandomNum(1, getRowNum(snakeAndLadders[2]));
            while (snakeAndLadders[3] == snakeAndLadders[0] || snakeAndLadders[3] == snakeAndLadders[1]) {
                snakeAndLadders[3] = getRandomNum(1, getRowNum(snakeAndLadders[2]));
            }

            //To decide snake head 3 position
            //Snake's head is never be lowest rows
            //To decide snake tail 3 position
            //Snake's tail is never be highest rows
            snakeAndLadders[4] = getRandomNum(7, 31);
            while (snakeAndLadders[4] == snakeAndLadders[0] || snakeAndLadders[4] == snakeAndLadders[1] ||
                snakeAndLadders[4] == snakeAndLadders[2] || snakeAndLadders[4] == snakeAndLadders[3]) {
                snakeAndLadders[4] = getRandomNum(7, 31);
            }

            snakeAndLadders[5] = getRandomNum(1, getRowNum(snakeAndLadders[4]));
            while (snakeAndLadders[5] == snakeAndLadders[0] || snakeAndLadders[5] == snakeAndLadders[1] ||
                snakeAndLadders[5] == snakeAndLadders[2] || snakeAndLadders[5] == snakeAndLadders[3]) {
                snakeAndLadders[5] = getRandomNum(1, getRowNum(snakeAndLadders[4]));
            }

            //To decide ladder top 1 position
            //lLdder's top is never be lowest rows
            //To decide ladder bottom 1 position
            //Ladder's bottom is never be lowest rows
            snakeAndLadders[6] = getRandomNum(7, 31);
            while (snakeAndLadders[6] == snakeAndLadders[0] || snakeAndLadders[6] == snakeAndLadders[1] ||
                snakeAndLadders[6] == snakeAndLadders[2] || snakeAndLadders[6] == snakeAndLadders[3] ||
                snakeAndLadders[6] == snakeAndLadders[4] || snakeAndLadders[6] == snakeAndLadders[5]) {
                snakeAndLadders[6] = getRandomNum(7, 31);
            }

            snakeAndLadders[7] = getRandomNum(1, getRowNum(snakeAndLadders[6]));
            while (snakeAndLadders[7] == snakeAndLadders[0] || snakeAndLadders[7] == snakeAndLadders[1] ||
                snakeAndLadders[7] == snakeAndLadders[2] || snakeAndLadders[7] == snakeAndLadders[3] ||
                snakeAndLadders[7] == snakeAndLadders[4] || snakeAndLadders[7] == snakeAndLadders[5]) {
                snakeAndLadders[7] = getRandomNum(1, getRowNum(snakeAndLadders[6]));
            }

            //To decide ladder top 2 position
            //lLdder's top is never be lowest rows
            //To decide ladder bottom 2 position
            //Ladder's bottom is never be lowest rows
            snakeAndLadders[8] = getRandomNum(7, 31);
            while (snakeAndLadders[8] == snakeAndLadders[0] || snakeAndLadders[8] == snakeAndLadders[1] ||
                snakeAndLadders[8] == snakeAndLadders[2] || snakeAndLadders[8] == snakeAndLadders[3] ||
                snakeAndLadders[8] == snakeAndLadders[4] || snakeAndLadders[8] == snakeAndLadders[5] ||
                snakeAndLadders[8] == snakeAndLadders[6] || snakeAndLadders[8] == snakeAndLadders[7]) {
                snakeAndLadders[8] = getRandomNum(7, 31);
            }

            snakeAndLadders[9] = getRandomNum(1, getRowNum(snakeAndLadders[8]));
            while (snakeAndLadders[9] == snakeAndLadders[0] || snakeAndLadders[9] == snakeAndLadders[1] ||
                snakeAndLadders[9] == snakeAndLadders[2] || snakeAndLadders[9] == snakeAndLadders[3] ||
                snakeAndLadders[9] == snakeAndLadders[4] || snakeAndLadders[9] == snakeAndLadders[5] ||
                snakeAndLadders[9] == snakeAndLadders[6] || snakeAndLadders[9] == snakeAndLadders[7]) {
                snakeAndLadders[9] = getRandomNum(1, getRowNum(snakeAndLadders[8]));
            }

            //To decide ladder top 3 position
            //lLdder's top is never be lowest rows
            //To decide ladder bottom 3 position
            //Ladder's bottom is never be lowest rows
            snakeAndLadders[10] = getRandomNum(7, 31);
            while (snakeAndLadders[10] == snakeAndLadders[0] || snakeAndLadders[10] == snakeAndLadders[1] ||
                snakeAndLadders[10] == snakeAndLadders[2] || snakeAndLadders[10] == snakeAndLadders[3] ||
                snakeAndLadders[10] == snakeAndLadders[4] || snakeAndLadders[10] == snakeAndLadders[5] ||
                snakeAndLadders[10] == snakeAndLadders[6] || snakeAndLadders[10] == snakeAndLadders[7] ||
                snakeAndLadders[10] == snakeAndLadders[8] || snakeAndLadders[10] == snakeAndLadders[9]) {
                snakeAndLadders[10] = getRandomNum(7, 31);
            }

            snakeAndLadders[11] = getRandomNum(1, getRowNum(snakeAndLadders[10]));
            while (snakeAndLadders[11] == snakeAndLadders[0] || snakeAndLadders[11] == snakeAndLadders[1] ||
                snakeAndLadders[11] == snakeAndLadders[2] || snakeAndLadders[11] == snakeAndLadders[3] ||
                snakeAndLadders[11] == snakeAndLadders[4] || snakeAndLadders[11] == snakeAndLadders[5] ||
                snakeAndLadders[11] == snakeAndLadders[6] || snakeAndLadders[11] == snakeAndLadders[7] ||
                snakeAndLadders[11] == snakeAndLadders[8] || snakeAndLadders[11] == snakeAndLadders[9]) {
                snakeAndLadders[11] = getRandomNum(1, getRowNum(snakeAndLadders[10]));
            }

            richTextBox1.Text = "";
            richTextBox1.Text += "Snake Head   1: " + snakeAndLadders[0].ToString() + "\n";
            richTextBox1.Text += "Snake Tail   1: " + snakeAndLadders[1].ToString() + "\n";
            richTextBox1.Text += "Snake Head   2: " + snakeAndLadders[2].ToString() + "\n";
            richTextBox1.Text += "Snake Tail   2: " + snakeAndLadders[3].ToString() + "\n";
            richTextBox1.Text += "Snake Head   3: " + snakeAndLadders[4].ToString() + "\n";
            richTextBox1.Text += "Snake Tail   3: " + snakeAndLadders[5].ToString() + "\n";
            richTextBox1.Text += "Ladder Top    1: " + snakeAndLadders[6].ToString() + "\n";
            richTextBox1.Text += "Ladder bottom 1: " + snakeAndLadders[7].ToString() + "\n";
            richTextBox1.Text += "Ladder Top    2: " + snakeAndLadders[8].ToString() + "\n";
            richTextBox1.Text += "Ladder bottom 2: " + snakeAndLadders[9].ToString() + "\n";
            richTextBox1.Text += "Ladder Top    3: " + snakeAndLadders[10].ToString() + "\n";
            richTextBox1.Text += "Ladder bottom 3: " + snakeAndLadders[11].ToString() + "\n";

            return snakeAndLadders;

        }

        private void InitializeForm() {
            //player1
            initFormPlayer1();
            //player2
            initFormPlayer2();
            //head
            initSnakeAndLadderLbl("head_");
            //tail
            initSnakeAndLadderLbl("tail_");
            //top
            initSnakeAndLadderLbl("top_");
            //bottom
            initSnakeAndLadderLbl("bottom_");
        }

        private void initFormPlayer1() {
            initSnakeAndLadderLbl("player1_");            
        }

        private void initFormPlayer2() {
            initSnakeAndLadderLbl("player2_");
        }

        private void initSnakeAndLadderLbl(String lblname) {
            for (int i = 1; i < 31; i++) {
                Control[] cs = this.Controls.Find(lblname + i, true);
                ((Label)cs[0]).Visible = false;
            }
        }
        
    }
}
