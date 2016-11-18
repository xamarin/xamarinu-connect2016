using Newtonsoft.Json;

namespace eXam
{
    public class QuizQuestion
	{
        public string Id { get; set; }
        public string Question { get; set; }
		public bool Answer { get; set; }
		public string Explanation { get; set; }
	}
}