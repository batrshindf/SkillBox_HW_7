namespace SkillBox_HW_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Repository repository = new Repository();

            repository.RequestPath();

            while (true)
            {
                repository.Menu();
            }
        }
    }
}