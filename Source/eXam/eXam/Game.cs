using System;
using System.Collections.Generic;

namespace eXam
{
	public class Game
	{
		public List<QuizQuestion> 	Questions 	{ get; private set; }
		public bool?[] 				Responses 	{ get; private set; }

		public QuizQuestion 		CurrentQuestion { get { return Questions [QuestionIndex]; } }
		public bool? 				CurrentResponse { get { return Responses [QuestionIndex]; } }
		int 						QuestionIndex 	{ get; set; }

		public int NumberOfQuestions 
		{
			get	{ return (Questions == null) ? 0 : Questions.Count; }
		}

		public Game (List<QuizQuestion> questions)
		{
			Questions = questions;
			Responses = new bool?[Questions.Count];
		}

		public bool NextQuestion ()
		{
			if (QuestionIndex < NumberOfQuestions - 1)
			{
				QuestionIndex++;

				return true;
			}

			return false;
		}

		public void Restart ()
		{
			QuestionIndex = 0;

			Responses = new bool?[Questions.Count];
		}

		public void OnTrue ()
		{
			Responses [QuestionIndex] = true;
		}

		public void OnFalse ()
		{
			Responses [QuestionIndex] = false;
		}

		public int GetNumberOfCorrectResponses ()
		{
			int count = 0;

			for (int i = 0; i < Responses.Length; i++)
			{
				if (IsQuestionCorrect (i) == true)
					count++;
			}

			return count;
		}

		bool IsQuestionCorrect (int index)
		{
			if (index < 0 || index >= NumberOfQuestions)
				return false;
			
			if (Responses [index] == null)
				return false;
			
			if (Responses [index].Value == Questions [index].Answer)
				return true;
			
			return false;
		}
	}
}