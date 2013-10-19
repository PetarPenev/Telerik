using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private Operators currentOperator;

        private decimal result;

        private string currentNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Clear();
                this.result = 0;
                ViewState.Add("result", this.result);
                this.currentOperator = Operators.Plus;
                ViewState.Add("operator", this.currentOperator);
                ViewState.Add("currentNumber", string.Empty);
            }
            else
            {
                this.result = (decimal)ViewState["result"];
                if (ViewState["operator"] != null)
                {
                    this.currentOperator = (Operators)ViewState["operator"];
                }

                if (ViewState["currentNumber"] != null)
                {
                    this.currentNumber = (string)ViewState["currentNumber"];
                }

            }
        }

        protected void AddNumber(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string idAsString = clickedButton.ID;
            int numberClicked = (int)Char.GetNumericValue(idAsString[idAsString.Length - 1]);

            if (this.currentNumber == "0")
            {
                this.currentNumber = numberClicked.ToString();
            }
            else
            {
                this.currentNumber = this.currentNumber + numberClicked;
            }

            ViewState["currentNumber"] = this.currentNumber;
            this.CalculatorDisplay.Text = this.currentNumber;
        }

        protected void CheckOperation(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (this.currentNumber == string.Empty)
            {
                Operators currentClickedOperator;
                switch (clickedButton.Text)
                {
                    case ("+"):
                        currentClickedOperator = Operators.Plus;
                        break;
                    case ("-"):
                        currentClickedOperator = Operators.Minus;
                        break;
                    case ("*"):
                        currentClickedOperator = Operators.Multiply;
                        break;
                    case ("/"):
                        currentClickedOperator = Operators.Divide;
                        break;
                    default:
                        currentClickedOperator = Operators.Sqrt;
                        break;
                }

                this.currentOperator = currentClickedOperator;
                ViewState["operator"] = this.currentOperator;
                return;
            }

            if (this.currentOperator != Operators.Empty)
            {
                if (this.currentNumber == string.Empty)
                {
                    this.currentNumber = "0";
                }

                decimal currentNumberInDecimal = decimal.Parse(this.currentNumber);
                decimal resultOfOperation = 0;
                switch (this.currentOperator)
                {
                    case (Operators.Plus):
                        resultOfOperation = this.result + currentNumberInDecimal;
                        break;
                    case (Operators.Minus):
                        resultOfOperation = this.result - currentNumberInDecimal;
                        break;
                    case (Operators.Multiply):
                        resultOfOperation = this.result * currentNumberInDecimal;
                        break;
                    case (Operators.Divide):
                        if (currentNumberInDecimal == 0)
                        {
                            this.CalculatorDisplay.Text = "Error. Please restart.";
                            return;
                        }

                        resultOfOperation = this.result / currentNumberInDecimal;
                        break;
                    case (Operators.Sqrt):
                        resultOfOperation = (decimal)Math.Sqrt((double)this.result);
                        break;
                     default:
                        this.CalculatorDisplay.Text = "Error. Please restart.";
                        return;
                }

                this.currentNumber = string.Empty;
                ViewState["currentNumber"] = this.currentNumber;
                this.result = resultOfOperation;
                ViewState["result"] = this.result;
                this.CalculatorDisplay.Text = this.result.ToString();


                if (clickedButton.ID == "SquareRootButton")
                {
                    this.result = (decimal)Math.Sqrt((double)this.result);
                    ViewState["result"] = this.result;
                    this.CalculatorDisplay.Text = this.result.ToString();
                    /*this.currentOperator = Operators.Sqrt;
                    ViewState["operator"] = this.currentOperator;*/
                    return;
                }

                Operators currentClickedOperator;
                switch (clickedButton.Text)
                {
                    case ("+"):
                        currentClickedOperator = Operators.Plus;
                        break;
                    case ("-"):
                        currentClickedOperator = Operators.Minus;
                        break;
                    case ("*"):
                        currentClickedOperator = Operators.Multiply;
                        break;
                    case ("/"):
                        currentClickedOperator = Operators.Divide;
                        break;
                    default:
                        currentClickedOperator = Operators.Sqrt;
                        break;
                }

                this.currentOperator = currentClickedOperator;
                ViewState["operator"] = this.currentOperator;
            }
        }

        protected void CalculateResult(object sender, EventArgs e)
        {
            if (this.currentNumber == string.Empty)
            {
                this.currentNumber = "0";
            }

            decimal currentNumberInDecimal = decimal.Parse(this.currentNumber);
            decimal resultOfOperation = 0;

            switch (this.currentOperator)
            {
                case (Operators.Plus):
                    resultOfOperation = this.result + currentNumberInDecimal;
                    break;
                case (Operators.Minus):
                    resultOfOperation = this.result - currentNumberInDecimal;
                    break;
                case (Operators.Multiply):
                    resultOfOperation = this.result * currentNumberInDecimal;
                    break;
                case (Operators.Divide):
                    if (currentNumberInDecimal == 0)
                    {
                        this.CalculatorDisplay.Text = "Error. Please restart.";
                        return;
                    }

                    resultOfOperation = this.result / currentNumberInDecimal;
                    break;
                case (Operators.Sqrt):
                    resultOfOperation = (decimal)Math.Sqrt((double)this.result);
                    break;
                default:
                    this.CalculatorDisplay.Text = "Error. Please restart.";
                    return;
            }

            this.CalculatorDisplay.Text = resultOfOperation.ToString();
            /*this.currentNumber = string.Empty;
            ViewState["currentNumber"] = this.currentNumber;
            this.result = 0;
            ViewState["result"] = this.result;
            this.currentOperator = Operators.Plus;
            ViewState["operator"] = this.currentOperator;*/
        }

        protected void ClearCalculator(object sender, EventArgs e)
        {
            ViewState["operator"] = Operators.Plus;
            ViewState["result"] = 0m;
            ViewState["currentNumber"] = string.Empty;
            this.CalculatorDisplay.Text = "0";
        }
    }
}