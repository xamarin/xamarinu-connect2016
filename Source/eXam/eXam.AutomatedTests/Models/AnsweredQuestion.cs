namespace eXam.AutomatedTests
{
	public class AnsweredQuestion
	{
		public string Text { get; set; }
		public bool Answer { get; set; }
		public bool WasCorrect { get; set; }

		public string ReviewText
		{
			get
			{
				return $"Question: {Text}";
			}
		}
	}
}
