using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MachineLearningApp.Helpers
{
    internal class IO
    {
        // Hardcoded messages

        private readonly string img =
            """      
                 ^ ^ 
                (O,O)
                (   )
               - "-" - 

           """;

        private readonly string welcomeMsg =
           """
           Hi i'm The Review Birb. I am learning how to discern positivity and negativity from written reviews.

           """;

        private readonly string reviewPrompt =
            """
            Please leave a review for a recent food or entertainment experience:

            """;

        private readonly string mainMenu =
            """

            ------ MAIN MENU ------
            [0] Leave a review
            [1] Quit

            """;

        private readonly string checkMsg = 
            """
            Was my assessment of your review correct? (y/n)
            """;

        private readonly string continueMenu =
            """

            ------ CONTINUE ------
            [0] Return to main menu
            [1] Quit

            """;

        private readonly string input = ">";

        private readonly string filePath = "ENTER_YELP_LEBELLED.TXT_PATH_HERE";

        /// <summary>
        /// Prints a message based on the passed in PRINT_STRINGS
        /// </summary>
        /// <param name="printType"></param>
        public void Print(PRINT_STRINGS printType)
        {
            switch(printType)
            {
                case PRINT_STRINGS.WELCOME:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(img);
                    Console.ResetColor();
                    Console.WriteLine(welcomeMsg);
                    break;

                case PRINT_STRINGS.MAIN:
                    Console.WriteLine(mainMenu);
                    break;

                case PRINT_STRINGS.REVIEW:
                    Console.WriteLine(reviewPrompt);
                    break;

                case PRINT_STRINGS.CONTINUE:
                    Console.WriteLine(continueMenu);
                    break;

                case PRINT_STRINGS.INPUT:
                    Console.Write(input);
                    break;

                case PRINT_STRINGS.CHECK:
                    Console.Write(checkMsg);
                    break;
            }
        }

        /// <summary>
        /// Takes an input and validates based on the passed in INPUT_TYPES
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public string TakeInput(INPUT_TYPES inputType)
        {
            Print(PRINT_STRINGS.INPUT);
            var input = Console.ReadLine();

            while (input == null)
            {
                Console.WriteLine("Response cannot be empty please try again:\n");
                input = Console.ReadLine();
            }

            if (inputType == INPUT_TYPES.MENU)
            {
                while (!input.Equals("0") && !input.Equals("1"))
                {
                    Console.WriteLine("Response must be a 1 or a 0. Please try again:\n");
                    input = Console.ReadLine();
                }

                if (input.ToString() == "1")
                {
                    // Train the model before exiting
                    Console.WriteLine("Updating training model...");
                    MLModel1.Train();
                    Console.WriteLine("Goodbye :)\n\n");
                    Environment.Exit(0);
                }
            }
            else if(inputType == INPUT_TYPES.YN)
            {
                while (!input.ToLower().Equals("y") && !input.ToLower().Equals("n"))
                {
                    Console.WriteLine("Response must be a Y or an N. Please try again:\n");
                    input = Console.ReadLine();
                }
            }

            Console.WriteLine();
            return input;
        }

        /// <summary>
        /// Write a new review to yelp_labelled.txt
        /// </summary>
        /// <param name="review"></param>
        /// <param name="correctPredictionLabel"></param>
        public void WriteReviewToTrainingFile(string review, string correctPredictionLabel)
        {
            try
            {
                string newLine = $"{review}\t{correctPredictionLabel}";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(newLine);
                }

                Console.WriteLine("Saved new review to training dataset.");
            } catch (DirectoryNotFoundException e) {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
