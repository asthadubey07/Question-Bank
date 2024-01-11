# question-bank

Create a console program to parse the file with following rules and load Questions class at the end. 

1. Each line that Starts with ## followed by space is considered "Topic" for all questions following this line until another line with # is detected. 
2. Each line Starts with ### followed by space is consiered "Sub-Topic" for all questions following this line 
3. Each line that starts with a number (without preceding tabspace) and followed by space is considered a Question and all lines following this line are considered options until another question line appears. 
4. Each line followed by a question is considered an option. 


`Question {
	string Id;
	string Title;
	List<Option> Options;
	string Topic;
	string Sub-Topic;	
}
class Option{
	String Id;
	string Title: 
	bool IsCorrect;
}`
