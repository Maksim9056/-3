

using Bogus;

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

                    User user = new User(faker.Name.Random.String2(20,"abcdefghijklmnopqrstuvwxyz").ToString(), Convert.ToInt32(faker.Random.Int(1,100).ToString()));

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