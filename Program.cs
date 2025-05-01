/*
       AINDA É UM PROGRAMA BASE
    Fazer uns stats de acordo com o treino da pessoa
    A cada treino a pessoa coloca o que treinou e aumenta o stat correspondente
    A cada ponto de stats alcançando (n° de stats) chega em uma transformação de DB

    StatsPoint += Nivel += Transformação += Stats
*/

using GymStats.PointsData;


var infoStats = Stats.Load();
var infoPoints = DistPoints.Load();

while (true) 
{
    void Treinar(Action<Stats> aplicarTreino)
    {
        aplicarTreino(infoStats);
        infoStats.Save();
        infoStats.PoitsToNivel();
    }

    Console.WriteLine("\n- - -Choose an option : \n1- View Stats \n2- Add Stats Points \n3- Reset all points \n4- Admin \n5- Exit");
    int option = int.Parse(Console.ReadLine());

    switch (option) 
    {
        case 1:
            Console.WriteLine($"--Your Stats \n| Stat Points (Power) = {infoStats.StatPoints}\n| Race = {infoPoints.Race}\n| Transformation = {infoPoints.Transformation}");
            break;
        
        case 2:
            Console.WriteLine("\n--Wich training you did?\n1- Biceps & Back \n2- Triceps & Chest \n3- Shoulders & Forearm \n4- Legs & Abs");
            int training = int.Parse(Console.ReadLine());

            switch (training) 
            {
                case 1:
                    Treinar(stats => {
                        stats.Biceps += 25;
                        stats.Back += 20;
                    });
                    break;
                case 2:
                    Treinar(stats => {
                        stats.Triceps += 20;
                        stats.Chest += 20;
                    });
                    break;
                case 3:
                    Treinar(stats => {
                        stats.Shoulders += 20;
                        stats.Forearm += 25;
                    });
                    break;
                case 4:
                    Treinar(stats => {
                        stats.Legs += 25;
                        stats.Abs += 23;
                    });
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            break;

        case 3:
            Console.WriteLine("Are you sure you want to reset all your stats? (yes/no)");
            string confirm = Console.ReadLine().ToLower();

            if (confirm == "yes")
            {
                infoStats.ResetPoints();
                Console.WriteLine("All stats have been reset.");
            }
            else
            {
                Console.WriteLine("Reset cancelled.");
            }
            break;
        case 4:
            Console.WriteLine("Digit the points amounts that you want to set");
            int setStatPoint = int.Parse(Console.ReadLine());

            Treinar(stats => {
                stats.Biceps = setStatPoint;
                stats.Triceps = setStatPoint;
                stats.Chest = setStatPoint;
                stats.Legs = setStatPoint;
                stats.Back = setStatPoint;
                stats.Shoulders = setStatPoint;
                stats.Forearm = setStatPoint;
                stats.Abs = setStatPoint;
            });
            infoStats.Save();
            break;
        case 5:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}
