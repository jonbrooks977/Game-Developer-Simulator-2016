public class Company 
{
	public string title;
	public int balance;
	public int fans;
	public Game[] Games;

	public string Report()
	{
		return (title + " has $" + balance + " and " + fans + " fans");
	}

	public class Employee : Company
	{
		public string name;
		public int codeSkill;
		public int artSkill;
		public int soundSkill;
		public int marketSkill;
		public int overallImprovement;
		public string currentTask;

		public string Analyze()
		{
			return (name + " has $" + balance + " and " + fans + " fans");
		}
	}

}
