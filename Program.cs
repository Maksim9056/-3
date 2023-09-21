

using Bogus;
using Bogus.DataSets;

namespace КТ_3
{
   
    internal class Program
    {
        static void Main()
        {
            try
            {
                Global global = new Global();

                global.CreateDataBase();

                for (int i = 0;i< 10; i++)
                {
                    Faker faker = new Faker("ru");

          
                         User user = new User(faker.Name.FirstName(), Convert.ToInt32(faker.Random.Int(1,100).ToString()));

                    global.CreateUser(user); 
                }
                
                global.Select();

                Console.ReadLine();
            }
            catch (Exception E)
            {

                Console.WriteLine(E.Message);
            }
        }
    }
}