namespace SkillBox_HW_7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Interface inInterface = new Interface();
            
            inInterface.RequestPath();

            while (true)
            {
                inInterface.Menu();
            }
        }
    }
}