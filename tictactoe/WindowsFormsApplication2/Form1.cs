/**
  * This is a TicTacToe game. The player can play against another player
  * or the computer. 
  *
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        bool playerTurn = true; //if true playerTurn=X player, if false playerTurn = Y player
        int turnCounter = 0; // counts the number of turns, max is 9
        bool winnerFound = true;
        bool buttonUndoWasClicked = false;
        bool buttonUndoIsEnabled = true;
        bool buttonPlayerWasClicked = false;
        bool buttonComputerWasClicked = false;
        bool buttonFrenchWasClicked = false;
        bool buttonEnglishWasClicked = true;
        String buttonName = "1";
        int playerWins = 0;
        int opponentWins = 0;
        int drawCounter = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
        /*
        * If the player choses to play against the computer, the labels are made visible
        */
        private void buttonComputer_Click(object sender, EventArgs e)
        {
            labelLevelOfDifficulty.Visible = true;
            radioButtonBeginner.Visible = true;
            radioButtonInter.Visible = true;
            radioButtonAdvanced.Visible = true;

        }

        /**
        * This method handles the event if the buttons are clicked. It checks 
        * for X or O and checks for the winner.
        */
        private void clickEventHandler(object sender, EventArgs e)
        {
            Button buttonClicked = (Button)sender;
            buttonName = buttonClicked.Name;
            MouseEventArgs me = (MouseEventArgs)e;



            if (buttonPlayerWasClicked)
            {

                if (playerTurn)
                {
                    buttonClicked.Text = "X";
                }
                else
                {
                    buttonClicked.Text = "O";
                }


                playerTurn = !playerTurn; // reverses the value
                buttonClicked.Enabled = false; //to disable the button

                turnCounter++; //increments the number of turns

                if (turnCounter > 4 && turnCounter <= 9)
                {
                    winnerCheck();
                    if (winnerFound == true)
                    {
                        disableButtons();
                    }
                    else if (winnerFound == false && turnCounter == 9)
                    {
                        MessageBox.Show("It is a draw!");
                        drawCounter++;
                        labelDrawsEnter.Text = drawCounter + "";

                    }
                }
                else
                    ;
            }
            else if (buttonComputerWasClicked)
            {
                if (radioButtonBeginner.Checked)
                {
                    if (playerTurn)
                        buttonClicked.Text = "X";

                    buttonClicked.Enabled = false; //to disable the button
                    Random random = new Random();
                    int randomNumber = random.Next(1, 10);
                    String buttonAI;
                    buttonAI = "button" + randomNumber;
                    int i = 9 - turnCounter;
                    while (i <= 9)
                    {
                        if ((Controls[buttonAI] as Button).Text == "" && (Controls[buttonAI] as Button).Enabled)
                        {
                            (Controls[buttonAI] as Button).Text = "O";
                            (Controls[buttonAI] as Button).Enabled = false;
                            i = 10;
                        }
                        else
                        {
                            randomNumber = random.Next(1, 10);
                            buttonAI = "button" + randomNumber;

                        }

                    }

                    turnCounter++;
                    if (turnCounter > 1 && turnCounter <= 5)
                    {
                        winnerCheck();
                        if (winnerFound == true)
                        {
                            disableButtons();
                        }
                        else if (winnerFound == false && turnCounter == 5)
                        {
                            MessageBox.Show("It is a draw!");
                            drawCounter++;
                            labelDrawsEnter.Text = drawCounter + "";
                        }
                    }
                    else
                        ;


                }
                else if (radioButtonInter.Checked)
                {
                    if (playerTurn)
                        buttonClicked.Text = "X";

                    buttonClicked.Enabled = false; //to disable the button
                    AIIntermediate();
                    turnCounter++;
                    if (turnCounter > 1 && turnCounter <= 5)
                    {
                        winnerCheck();
                        if (winnerFound == true)
                        {
                            disableButtons();
                        }
                        else if (winnerFound == false && turnCounter == 5)
                        {
                            MessageBox.Show("It is a draw!");
                            drawCounter++;
                            labelDrawsEnter.Text = drawCounter + "";

                        }


                    }
                    else
                        ;

                }
                else if (radioButtonAdvanced.Checked)
                {
                    if (playerTurn)
                        buttonClicked.Text = "X";

                    buttonClicked.Enabled = false; //to disable the button
                    AIAdvanced();
                    turnCounter++;
                    if (turnCounter > 1 && turnCounter <= 5)
                    {
                        winnerCheck();
                        if (winnerFound == true)
                        {
                            disableButtons();
                        }
                        else if (winnerFound == false && turnCounter == 5)
                        {
                            MessageBox.Show("It is a draw!");
                            drawCounter++;
                            labelDrawsEnter.Text = drawCounter + "       ";

                        }

                    }
                    else
                        ;
                }
                else
                {
                    if (buttonEnglishWasClicked)
                        MessageBox.Show("Please choose a difficulty level.");
                    else if (buttonFrenchWasClicked)
                        MessageBox.Show("S'il vous plaît choisir un niveau de difficulté.");

                }
            }

            else
            {
                if (buttonEnglishWasClicked)
                    MessageBox.Show("You need to choose an opponent.");
                else if (buttonFrenchWasClicked)
                    MessageBox.Show("Vous devez choisir un adversaire.");

            }

        }
        /**
        *  This method is for advanced level. It calls the block method method which calls the
        *  winMove method.
        */
        private void AIAdvanced()
        {

            block();

        }
        /**
        *  This method blocks the players moves by placing O vertically, horizontally or diagonally.
        */
        private void block()
        {
            if (button1.Text == "X" && button4.Text == "X" && button7.Enabled)
            {

                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }

            }
            else if (button1.Text == "X" && button5.Text == "X" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button4.Text == "X" && button7.Text == "X" && button1.Enabled)
            {

                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }
            else if (button1.Text == "X" && button7.Text == "X" && button4.Enabled)
            {
                if (button4.Text == "")
                {
                    button4.Text = "O";
                    button4.Enabled = false;
                }
            }
            else if (button1.Text == "X" && button2.Text == "X" && button3.Enabled)
            {
                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }


            }
            else if (button2.Text == "X" && button3.Text == "X" && button1.Enabled)
            {
                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }

            else if (button1.Text == "X" && button3.Text == "X" && button2.Enabled)
            {
                if (button2.Text == "")
                {
                    button2.Text = "O";
                    button2.Enabled = false;
                }
            }



            else if (button1.Text == "X" && button9.Text == "X" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }
            else if (button5.Text == "X" && button9.Text == "X" && button1.Enabled)
            {
                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }

            else if (button4.Text == "X" && button5.Text == "X" && button6.Enabled)
            {
                if (button6.Text == "")
                {
                    button6.Text = "O";
                    button6.Enabled = false;
                }

            }
            else if (button5.Text == "X" && button6.Text == "X" && button4.Enabled)
            {
                if (button4.Text == "")
                {
                    button4.Text = "O";
                    button4.Enabled = false;
                }
            }
            else if (button4.Text == "X" && button6.Text == "X" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }

            else if (button7.Text == "X" && button8.Text == "X" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button8.Text == "X" && button9.Text == "X" && button7.Enabled)
            {
                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }
            }
            else if (button7.Text == "X" && button9.Text == "X" && button8.Enabled)
            {
                if (button8.Text == "")
                {
                    button8.Text = "O";
                    button8.Enabled = false;
                }
            }

            else if (button2.Text == "X" && button5.Text == "X" && button8.Enabled)
            {
                if (button8.Text == "")
                {
                    button8.Text = "O";
                    button8.Enabled = false;
                }
            }
            else if (button5.Text == "X" && button8.Text == "X" && button2.Enabled)
            {
                if (button2.Text == "")
                {
                    button2.Text = "O";
                    button2.Enabled = false;
                }
            }
            else if (button2.Text == "X" && button8.Text == "X" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }

            else if (button3.Text == "X" && button6.Text == "X" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button6.Text == "X" && button9.Text == "X" && button3.Enabled)
            {
                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }
            }
            else if (button3.Text == "X" && button9.Text == "X" && button6.Enabled)
            {
                if (button6.Text == "")
                {
                    button6.Text = "O";
                    button6.Enabled = false;
                }
            }

            else if (button3.Text == "X" && button5.Text == "X" && button7.Enabled)
            {

                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }
            }
            else if (button5.Text == "X" && button7.Text == "X" && button3.Enabled)
            {

                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }

            }
            else if (button3.Text == "X" && button7.Text == "X" && button5.Enabled)
            {

                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }
            else
            {
                if (radioButtonInter.Checked)
                {

                    AIButtonsCheck(button5, button2, button3, button4, button1, button6, button7, button8, button9);
                }
                else if (radioButtonAdvanced.Checked)
                {
                    if (button5.Text == "")
                    {
                        button5.Text = "O";
                        button5.Enabled = false;
                    }
                    else
                    {
                        winMove();
                    }
                }
            }
        }
        /**
        *  This method calls the block method, which blocks the players win.
        */
        private void AIIntermediate()
        {
            block();


        }
        /**
        *  This method places O for the computer at the best place to win.
        */
        private void winMove()
        {
            if (button1.Text == "O" && button4.Text == "O" && button7.Enabled)
            {

                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }

            }
            else if (button1.Text == "O" && button5.Text == "O" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button4.Text == "O" && button7.Text == "O" && button1.Enabled)
            {

                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }
            else if (button1.Text == "O" && button7.Text == "O" && button4.Enabled)
            {
                if (button4.Text == "")
                {
                    button4.Text = "O";
                    button4.Enabled = false;
                }
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Enabled)
            {
                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }


            }
            else if (button2.Text == "O" && button3.Text == "O" && button1.Enabled)
            {
                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }

            else if (button1.Text == "O" && button3.Text == "O" && button2.Enabled)
            {
                if (button2.Text == "")
                {
                    button2.Text = "O";
                    button2.Enabled = false;
                }
            }



            else if (button1.Text == "O" && button9.Text == "O" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }
            else if (button5.Text == "O" && button9.Text == "O" && button1.Enabled)
            {
                if (button1.Text == "")
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                }
            }

            else if (button4.Text == "O" && button5.Text == "O" && button6.Enabled)
            {
                if (button6.Text == "")
                {
                    button6.Text = "O";
                    button6.Enabled = false;
                }

            }
            else if (button5.Text == "O" && button6.Text == "O" && button4.Enabled)
            {
                if (button4.Text == "")
                {
                    button4.Text = "O";
                    button4.Enabled = false;
                }
            }
            else if (button4.Text == "O" && button6.Text == "O" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }

            else if (button7.Text == "O" && button8.Text == "O" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button8.Text == "O" && button9.Text == "O" && button7.Enabled)
            {
                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }
            }
            else if (button7.Text == "O" && button9.Text == "O" && button8.Enabled)
            {
                if (button8.Text == "")
                {
                    button8.Text = "O";
                    button8.Enabled = false;
                }
            }

            else if (button2.Text == "O" && button5.Text == "O" && button8.Enabled)
            {
                if (button8.Text == "")
                {
                    button8.Text = "O";
                    button8.Enabled = false;
                }
            }
            else if (button5.Text == "O" && button8.Text == "O" && button2.Enabled)
            {
                if (button2.Text == "")
                {
                    button2.Text = "O";
                    button2.Enabled = false;
                }
            }
            else if (button2.Text == "O" && button8.Text == "O" && button5.Enabled)
            {
                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }

            else if (button3.Text == "O" && button6.Text == "O" && button9.Enabled)
            {
                if (button9.Text == "")
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
            else if (button6.Text == "O" && button9.Text == "O" && button3.Enabled)
            {
                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }
            }
            else if (button3.Text == "O" && button9.Text == "O" && button6.Enabled)
            {
                if (button6.Text == "")
                {
                    button6.Text = "O";
                    button6.Enabled = false;
                }
            }

            else if (button3.Text == "O" && button5.Text == "O" && button7.Enabled)
            {

                if (button7.Text == "")
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                }
            }
            else if (button5.Text == "O" && button7.Text == "O" && button3.Enabled)
            {

                if (button3.Text == "")
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                }

            }
            else if (button3.Text == "O" && button7.Text == "O" && button5.Enabled)
            {

                if (button5.Text == "")
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                }
            }
            else
                AIButtonsCheck(button5, button2, button3, button4, button1, button6, button7, button8, button9);


        }
        /**
        *  This method checks for the empty places.
        */
        private void AIButtonsCheck(Button btn1, Button btn2, Button btn3, Button btn4, Button btn5, Button btn6, Button btn7, Button btn8, Button btn9)
        {
            if (btn1.Text == "")
            {
                btn1.Text = "O";
                btn1.Enabled = false;
            }
            else if (btn2.Text == "")
            {
                btn2.Text = "O";
                btn2.Enabled = false;
            }
            else if (btn3.Text == "")
            {
                btn3.Text = "O";
                btn3.Enabled = false;

            }
            else if (btn4.Text == "")
            {
                btn4.Text = "O";
                btn4.Enabled = false;

            }
            else if (btn5.Text == "")
            {
                btn5.Text = "O";
                btn5.Enabled = false;

            }
            else if (btn6.Text == "")
            {
                btn6.Text = "O";
                btn6.Enabled = false;

            }
            else if (btn7.Text == "")
            {
                btn7.Text = "O";
                btn7.Enabled = false;
            }
            else if (btn8.Text == "")
            {
                btn8.Text = "O";
                btn8.Enabled = false;
            }
            else if (btn9.Text == "")
            {
                btn9.Text = "O";
                btn9.Enabled = false;
            }


        }// end method AIInter

        private void winnerCheck()
        {
            //check the winner in rows
            if (button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "")
            {
                winnerFound = true;
                assignPoints(button1);
            }
            else if (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "")
            {
                winnerFound = true;
                assignPoints(button4);

            }
            else if (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "")
            {
                winnerFound = true;
                assignPoints(button7);

            }

            //check the winner in columns
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "")
            {
                winnerFound = true;
                assignPoints(button1);

            }
            else if (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "")
            {
                winnerFound = true;
                assignPoints(button2);

            }
            else if (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "")
            {
                winnerFound = true;
                assignPoints(button3);

            }
            //check the winner in diagonals
            else if (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "")
            {
                winnerFound = true;
                assignPoints(button1);

            }
            else if (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != "")
            {
                winnerFound = true;
                assignPoints(button3);

            }
            else winnerFound = false;

        }
        /**
        *  This method assigns points to winners.
        */
        private void assignPoints(Button b)
        {
            if (b.Text == "X")
            {
                if (buttonEnglishWasClicked)
                    MessageBox.Show("You win this round!");
                else if (buttonFrenchWasClicked)
                    MessageBox.Show("Vous avez gagner!");
                playerWins++;
                labelPlayerWinsEnter.Text = playerWins + "       ";
            }
            else if (b.Text == "O")
            {
                if (buttonEnglishWasClicked)
                    MessageBox.Show("You lose!");
                else if (buttonFrenchWasClicked)
                    MessageBox.Show("Vous avez perdu :(");

                opponentWins++;
                labelOpponentWinsEnter.Text = opponentWins + "       ";
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void labelOpponent_Click(object sender, EventArgs e)
        {

        }

        private void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            playerTurn = true;
            turnCounter = 0;
            winnerFound = false;
            buttonPlayerWasClicked = false;
            buttonComputerWasClicked = false;
            radioButtonBeginner.Checked = false;
            radioButtonAdvanced.Checked = false;
            radioButtonInter.Checked = false;

            button1.Enabled = true;
            button1.Text = "";
            button2.Enabled = true;
            button2.Text = "";
            button3.Enabled = true;
            button3.Text = "";
            button4.Enabled = true;
            button4.Text = "";
            button5.Enabled = true;
            button5.Text = "";
            button6.Enabled = true;
            button6.Text = "";
            button7.Enabled = true;
            button7.Text = "";
            button8.Enabled = true;
            button8.Text = "";
            button9.Enabled = true;
            button9.Text = "";
            buttonUndo.Enabled = true;
            buttonUndoIsEnabled = true;


        }

        private void radioButtonBeginner_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonComputer_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButtonComputerEvent()
        {
            labelLevelOfDifficulty.Visible = true;
            radioButtonBeginner.Visible = true;
            radioButtonInter.Visible = true;
            radioButtonAdvanced.Visible = true;
            buttonComputerWasClicked = true;

        }

        private void radioButtonPlayer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            Button btnUndoClicked = (Button)sender;
            btnUndoClicked.Enabled = false;
            buttonUndoWasClicked = true;
            buttonUndoIsEnabled = false;
            if (buttonUndoWasClicked && !buttonUndoIsEnabled && !winnerFound)
            {

                buttonUndoWasClicked = false;
                (Controls[buttonName] as Button).Text = "";
                (Controls[buttonName] as Button).Enabled = true;

                turnCounter--;
                playerTurn = !playerTurn;

            }


        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            buttonPlayerWasClicked = true;
        }

        private void buttonComputer_Click_1(object sender, EventArgs e)
        {
            radioButtonComputerEvent();

        }

        private void buttonFre_Click(object sender, EventArgs e)
        {
            buttonFrenchWasClicked = true;
            buttonEnglishWasClicked = false;
            buttonNewGame.Text = "nouvelle partie";
            buttonComputer.Text = "Ordinateur";
            buttonExit.Text = "Finir";
            buttonUndo.Text = "Defaire";
            buttonPlayer.Text = "Joueur";
            labelLevelOfDifficulty.Text = "Niveau de difficulté?";
            labelOpponent.Text = "choisir votre adversaire";
            radioButtonBeginner.Text = "Débutant";
            radioButtonInter.Text = "intermédiaire";
            radioButtonAdvanced.Text = "avancé";
            labeldraw.Text = "Nul";
            labelPlayerWins.Text = "Vos Points";
            labelOpponentWin.Text = "Les points d'adversaire";


        }

        private void buttonEng_Click(object sender, EventArgs e)
        {
            buttonEnglishWasClicked = true;
            buttonFrenchWasClicked = false;
            buttonNewGame.Text = "new game";
            buttonComputer.Text = "Computer";
            buttonExit.Text = "Exit";
            buttonUndo.Text = "Undo";
            buttonPlayer.Text = "Player";
            labelLevelOfDifficulty.Text = "Level of difficulty?";
            labelOpponent.Text = "choose your opponent?";
            radioButtonBeginner.Text = "Beginner";
            radioButtonInter.Text = "Intermediate";
            radioButtonAdvanced.Text = "Advanced";
            labeldraw.Text = "Draws";
            labelPlayerWins.Text = "Your Points";
            labelOpponentWin.Text = "Opponent's Points";
        }

        private void labelDrawsEnter_Click(object sender, EventArgs e)
        {

        }

        /**
        *  This method handles the right click event.
        */
        private void rightClick(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                b.Text = "!";
            }

        }

        private void labelPlayerWinsEnter_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Figure it out by yourself! Good luck!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
