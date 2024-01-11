using QB.Model;

namespace QB.UiConsole
{
    public class ConsoleUI
    {
        public static void DisplayQuestions(List<Question> questions)
        {
            if (questions != null && questions.Count > 0)
            {
                Console.WriteLine("Parsed Questions:");


                foreach (var question in questions)
                {
                    Console.WriteLine($"Question: {question.Title}");
                    Console.WriteLine($"Topic: {question.Topic}");
                    Console.WriteLine($"Subtopic: {question.SubTopic}");
                    Console.WriteLine("Options:");
  
                    foreach (var option in question.Options!)
                    {
                        Console.WriteLine($"{option.Title} {(option.IsCorrect ? "(Correct)" : "")}");
                    
                    }

                    Console.WriteLine(new string('-', 30));
                      
                }
            }
            else
            {
                Console.WriteLine("No questions were parsed.");
            }
        }
    }
}
