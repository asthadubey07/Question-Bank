using QB.QuestionBankRepositroy;
using QB.UiConsole;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath =
                    "C://Users//ADwivedi//Desktop//QuestionBank//question-bank-master//sample-questions.md";

                QuizRepository quizRepository = new QuizRepository();

                var questions = quizRepository.ParseQuestionBank(filePath);
                ConsoleUI consoleUI = new ConsoleUI();
                ConsoleUI.DisplayQuestions(questions!);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
