using System;
using System.Collections.Generic;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        private const int MaxTurns = 10;

        public bool IsOver = false;

        private string Code { get; set; }

        private int CurrentTurn { get; set; }

        private bool HasWon { get; set; }

        public void Start()
        {
            this.Code = GenerateCode();
            this.CurrentTurn = 1;
            this.HasWon = false;
        }

        public void TakeTurn()
        {
            while (this.CurrentTurn <= MaxTurns)
            {
                string input = GetInput(MaxTurns, this.CurrentTurn);
                this.HasWon = CheckForWin(input, this.Code);
                if (this.HasWon) break;

                string pluses = "";
                string minuses = "";
                for (var i = 0; i < input.Length; i++)
                {
                    if(input[i] == this.Code[i])
                    {
                        pluses = pluses + "+";
                    }
                    else
                    {
                        if (this.Code.Contains(input[i]))
                        {
                            minuses = minuses + "-";
                        }
                    }                    
                }               
                Console.WriteLine(pluses + minuses);

                this.CurrentTurn = this.CurrentTurn + 1;
            }
            this.IsOver = true;
        } 

        public void End()
        {
            string message = this.HasWon ? "You successfully guessed the code {0}" : "You were not able to guess the code {0}";
            Console.WriteLine(message, this.Code);
            Console.ReadLine();
        }

        private string GenerateCode()
        {
            var random = new Random();
            return random.Next(1, 6).ToString() + random.Next(1, 6).ToString() + random.Next(1, 6).ToString() + random.Next(1, 6).ToString();
        }

        private string GetInput(int maxTurns, int currentTurn)
        {
            int turnsRemaining = maxTurns + 1 - currentTurn;
            Console.WriteLine("Please enter a 4 digit number containing numbers between 1 and 6");
            Console.WriteLine("You have {0} turns remaining.", turnsRemaining);
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!IsValidInput(input));
            return input;
        }

        private bool IsValidInput(string stringInput)
        {
            bool isValid = true;
            int intInput;
            bool isInt = int.TryParse(stringInput, out intInput);
            bool isValidLength = stringInput.Length == 4;
            if(isInt && isValidLength)
            {
                for (var i = 0; i < stringInput.Length; i++)
                {
                    int thisIndex = Convert.ToInt32(Convert.ToString(stringInput[i]));
                    if (thisIndex > 6 || thisIndex < 1)
                    {
                        Console.WriteLine("The code can only contain numbers between 1 and 6");
                        isValid = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("The code can only be 4 digits long and contain numbers between 1 and 6");
            }
            return isInt && isValidLength && isValid;
        }

        private bool CheckForWin(string input, string code)
        {
            return code == input;
        }
    }
}
