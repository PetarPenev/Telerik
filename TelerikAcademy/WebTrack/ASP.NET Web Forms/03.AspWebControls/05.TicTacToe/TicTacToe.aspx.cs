using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.TicTacToe
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        private string[,] field;
        private const string playerToken = "O";
        private const string opponentToken = "X";
        private int turns;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["field"] != null)
            {
                LoadButtons();
            }

            if (Session["field"] == null)
            {
                this.field = new string[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        this.field[i, j] = string.Empty;
                    }
                }

                Session.Add("field", this.field);
                Session.Add("turns", 0);
            }
            else
            {
                this.field = (string[,])Session["field"];
                this.turns = (int)Session["turns"];
            }
        }

        protected void ProcessClick(object sender, EventArgs e)
        {
            Button buttonClicked = (Button)sender;
            var idAsString = buttonClicked.ID;
            List<char> positionString = idAsString.Skip(idAsString.Length - 2).Take(2).ToList();
            int row = (int)Char.GetNumericValue(positionString[0]);
            int column = (int)Char.GetNumericValue(positionString[1]);
            if (this.field[row, column] != string.Empty)
            {
                this.ResultBox.Text = "Cannot play on an already played field.";
                return;
            }

            buttonClicked.Enabled = false;
            this.field[row, column] = playerToken;
            buttonClicked.Text = playerToken;
            this.turns += 1;
            bool isPlayerWinning = CheckWin(playerToken);
            if (isPlayerWinning)
            {
                this.ResultBox.Text = "Congratulations! You won";
                this.TurnBox.Text = "Turns: " + this.turns;
                Session["field"] = this.field;
                Session["turns"] = this.turns;
                FreezeState();
                return;
            }

            ProcessOpponentPlay();


            bool isOpponentWinning = CheckWin(opponentToken);
            if (isOpponentWinning)
            {
                this.ResultBox.Text = "Oh, no! You lost.";
                this.TurnBox.Text = "Turns: " + this.turns;
                Session["field"] = this.field;
                Session["turns"] = this.turns;
                FreezeState();
                return;
            }

            bool isFullState = CheckIfFull();
            if (isFullState)
            {
                this.ResultBox.Text = "It is a tie.";
                this.TurnBox.Text = "Turns: " + this.turns;
                Session["field"] = this.field;
                Session["turns"] = this.turns;
                FreezeState();
                return;
            }

            this.ResultBox.Text = "Please make next move.";
            this.TurnBox.Text = "Turns: " + this.turns;
            Session["field"] = this.field;
            Session["turns"] = this.turns;
        }

        protected bool CheckWin(string token)
        {
            for (int i = 0; i < 3; i++)
            {
                if (this.field[i, 0] == token && this.field[i, 1] == token && this.field[i, 2] == token)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (this.field[0, i] == token && this.field[1, i] == token && this.field[2, i] == token)
                {
                    return true;
                }
            }

            if (this.field[0, 0] == token && this.field[1, 1] == token && this.field[2, 2] == token)
            {
                return true;
            }

            if (this.field[0, 2] == token && this.field[1, 1] == token && this.field[2, 0] == token)
            {
                return true;
            }

            return false;
        }

        protected void FreezeState()
        {
            this.Position00.Enabled = false;
            this.Position01.Enabled = false;
            this.Position02.Enabled = false;
            this.Position10.Enabled = false;
            this.Position11.Enabled = false;
            this.Position12.Enabled = false;
            this.Position20.Enabled = false;
            this.Position21.Enabled = false;
            this.Position22.Enabled = false;
        }

        protected bool CheckIfFull()
        {
            return !this.field.Cast<string>().Any(b => b == string.Empty);
        }

        protected void ProcessOpponentPlay()
        {
            bool isFull = CheckIfFull();
            if (isFull)
            {
                return;
            }

            Random rand = new Random();
            int row = rand.Next(0, 3);
            int col = rand.Next(0, 3);
            bool isFound = false;
            while (!isFound)
            {
                if (this.field[row, col] == string.Empty)
                {
                    this.field[row, col] = opponentToken;
                    Session["field"] = this.field;
                    var buttonSelected = (Button)this.FindControl("Position" + row + col);
                    buttonSelected.Text = opponentToken;
                    buttonSelected.Enabled = false;
                    isFound = true;
                }
                else
                {
                    row = rand.Next(0, 3);
                    col = rand.Next(0, 3);
                }
            }
        }

        protected void ClearGame(object sender, EventArgs e)
        {
            Session.Clear();
            this.Position00.Enabled = true;
            this.Position01.Enabled = true;
            this.Position02.Enabled = true;
            this.Position10.Enabled = true;
            this.Position11.Enabled = true;
            this.Position12.Enabled = true;
            this.Position20.Enabled = true;
            this.Position21.Enabled = true;
            this.Position22.Enabled = true;

            this.Position00.Text = "Empty";
            this.Position01.Text = "Empty";
            this.Position02.Text = "Empty";
            this.Position10.Text = "Empty";
            this.Position11.Text = "Empty";
            this.Position12.Text = "Empty";
            this.Position20.Text = "Empty";
            this.Position21.Text = "Empty";
            this.Position22.Text = "Empty";
        }

        protected void LoadButtons()
        {
            this.field = (string[,])Session["field"];
            this.turns = (int)Session["turns"];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.field[i,j] == string.Empty)
                    {
                        ((Button)this.FindControl("Position" + i + j)).Text = "Empty";
                    }
                    else
                    {
                        ((Button)this.FindControl("Position" + i + j)).Text = this.field[i, j];
                        ((Button)this.FindControl("Position" + i + j)).Enabled = false;
                    }
                }
            }

            this.TurnBox.Text = "Turns: " + this.turns;
        }
    }
}