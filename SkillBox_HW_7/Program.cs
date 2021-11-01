namespace SkillBox_HW_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Interface inInterface = new Interface();
            Repository repository = new Repository();
            
            repository.RequestPath();

            while (true)
            {
                inInterface.Menu();
            }
        }
    }
}