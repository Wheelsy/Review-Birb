using MachineLearningApp;
using MachineLearningApp.Helpers;

IO io = new IO();
string corrcetPrediction;

// Print welcome message
io.Print(PRINT_STRINGS.WELCOME);

// Repeat the sequence while the user has not selected an exit option
while (true)
{
    // Run main menu
    io.Print(PRINT_STRINGS.MAIN);
    io.TakeInput(INPUT_TYPES.MENU);

    // Get a review from the user
    io.Print(PRINT_STRINGS.REVIEW);
    var review = io.TakeInput(INPUT_TYPES.REVIEW);

    // Load sample data
    var sampleData = new MLModel1.ModelInput()
    {
        Col0 = @review,
    };

    // Load model and predict output
    var result = MLModel1.Predict(sampleData);

    // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
    var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
    Console.Write($"\nReading: {sampleData.Col0}\nBased on my current learning this review is: ");

    // Adjust colour to outcome
    if (result.PredictedLabel == 1)
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine($"{sentiment}\n");

    // Reset the colour
    Console.ResetColor();

    // Check if the prediction was correct and if not correct it
    io.Print(PRINT_STRINGS.CHECK);
    string yn = io.TakeInput(INPUT_TYPES.YN);
    if (result.PredictedLabel == 1)
    {
        corrcetPrediction = yn.ToLower() == "y" ? "1" : "0";
    }
    else
    {
        corrcetPrediction = yn.ToLower() == "y" ? "0" : "1";
    }

    // Write the review and the correct prediction to the training file
    io.WriteReviewToTrainingFile(review, corrcetPrediction);

    // Check if user wants to continue or quit
    io.Print(PRINT_STRINGS.CONTINUE);
    io.TakeInput(INPUT_TYPES.MENU);
}