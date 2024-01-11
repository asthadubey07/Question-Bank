using QB.Model;
namespace QB.QuestionBankRepositroy
{
    public class QuizRepository
    {
        public List<Question>? ParseQuestionBank(string filePath)
        {
            var Questionlst = new List<Question>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string? currentTitle = null;
                    var currentOptions = new List<Option>();
                    string? currentTopic = null;
                    string? currentSubTopic = null;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var trimmedLine = line?.Trim();

                        if (IsTopicHeader(trimmedLine!, out var topic))
                        {
                            currentTopic = topic;
                            currentSubTopic = null;
                        }
                        else if (IsSubTopicHeader(trimmedLine!, out var subTopic))
                        {
                            currentSubTopic = subTopic;
                        }
                        else if (IsQuestionHeader(trimmedLine!, out var questionTitle))
                        {
                            AddQuestion(
                                Questionlst,
                                currentTitle,
                                currentOptions,
                                currentTopic,
                                currentSubTopic
                            );
                            currentTitle = questionTitle;
                            currentOptions = new List<Option>();
                        }
                        else if (!string.IsNullOrWhiteSpace(trimmedLine) && currentOptions != null)
                        {
                            var option = ParseOption(trimmedLine);
                            currentOptions.Add(option);
                        }
                    }

                    AddQuestion(
                        Questionlst,
                        currentTitle,
                        currentOptions,
                        currentTopic,
                        currentSubTopic
                    );
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found at path: {filePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            return Questionlst;
        }

        private static void AddQuestion(
            List<Question> questions,
            string? title,
            List<Option>? options,
            string? topic,
            string? subTopic
        )
        {
            var question = new Question
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Options = options,
                Topic = topic,
                SubTopic = subTopic
            };
            questions.Add(question);
        }

        private static Option ParseOption(string line)
        {
            var parts = line.Split(new[] { '.' }, 2);
            var optionNumber = parts[0]?.Trim();
            var optionText = parts[1]?.Trim();
            var isCorrect = optionText?.EndsWith("(Correct)", StringComparison.OrdinalIgnoreCase) == true;
            optionText = isCorrect
                ? optionText!.Substring(0, optionText.Length - "(Correct)".Length).Trim()
                : optionText;

            return new Option
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"{optionNumber}. {optionText}",
                IsCorrect = isCorrect
            };
        }

        private static bool IsTopicHeader(string line, out string? topic)
        {
            topic = null;
            if (line?.StartsWith("## ") == true)
            {
                topic = line.Substring(3);
                return true;
            }
            return false;
        }

        private static bool IsSubTopicHeader(string line, out string? subTopic)
        {
            subTopic = null;
            if (line?.StartsWith("### ") == true)
            {
                subTopic = line.Substring(4);
                return true;
            }
            return false;
        }

        private static bool IsQuestionHeader(string line, out string? questionTitle)
        {
            questionTitle = null;
            if (line?.Length > 2 && Char.IsDigit(line[0]) && line[1] == '.')
            {
                var parts = line.Split(new[] { '.' }, 2);
                questionTitle = parts?[1]?.Trim();
                return true;
            }
            return false;
        }
    }
}
