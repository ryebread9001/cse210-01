

using System;
using System.Collections.Generic;


namespace cse210_01
{

    class Program
    {
        static void Main(string[] args)
        {
            
            int card = 0;
            int nextCard = 0;
            int score = 300;
            Random rnd = new Random();
            int num = rnd.Next(14);
            card = num;
            while (!IsGameOver(score))
            {
                
                Console.WriteLine($"Current card is: {card}");
                bool choice = GetMoveChoice(card);
                
                score = changeScore(card, nextCard, choice, score);
                Console.WriteLine($"Score: {score}");
                card = nextCard;
                nextCard = changeCard(nextCard);
                
                
            }
            
            DisplayWin(score);
            
            
            
        }

        

        static bool IsGameOver(int score)
        {
            return (score < 0);
        }

        

        static void DisplayWin(int score)
        {
            
            
            
        }


        
        
        static bool GetMoveChoice(int card)
        {
            Console.Write($"Will the next card be higher or lower than {card} (h or l)?: ");
            string move = Console.ReadLine();
            bool choice;
            if (move == "h") {
                choice = true;
            } else {
                choice = false;
            }
            return choice;
        }

        static int changeCard(int nextCard)
        {
            
            Random rnd = new Random();
            nextCard = rnd.Next(14);
            return nextCard;
            
        }

        static int changeScore(int card, int nextCard, bool choice, int score) 
        {
            if (choice) {
                if (nextCard < card) {
                    score -= 75;
                } else {
                    score += 100;
                }
            } else {
                if (nextCard > card) {
                    score -= 75;
                } else {
                    score += 100;
                }
            }
            return score;
        }
    }    
}