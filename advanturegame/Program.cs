using System.Data;
using System.Security;

namespace advanturegame
{
    internal class Program
    {
       

        static void DisplayInformation(string team, string statusfan, string statusteam, int reservemoter, int moterschade)
        {
            Console.SetCursorPosition(Console.WindowWidth - 50, 0);
            Console.WriteLine($"Team: {team}");

            Console.SetCursorPosition(Console.WindowWidth - 50, 1);
            Console.WriteLine($"Status Fan: {statusfan}");

            Console.SetCursorPosition(Console.WindowWidth - 50, 2);
            Console.WriteLine($"Status Team: {statusteam}");

            Console.SetCursorPosition(Console.WindowWidth - 50, 3);
            Console.WriteLine($"Reserve Motor: {reservemoter}/3");

            Console.SetCursorPosition(Console.WindowWidth - 50, 4);
            Console.WriteLine($"Motorschade: {moterschade}/100");
        }
        static void Main(string[] args)
        {
            string team;
            string statusfan;
            string statusteam;
            int reservemoter;
            int moterschade;
            string carfailurekans;






            Console.WriteLine("he racer je komt net uit de formule 2 en wilt je zelf gaan bewijzen in de f1 je hebt een paar contract offers gekregenvan een paar teams kies het team waar je bij wilt\n");
            Console.WriteLine("je zult in dit spel een paar stats krijgen je doel is natuurlijk om weereld kampioen te worden er zullen ook stats zijn \nvoor je status van de fans en status van je team als deze te laag komen is er een kans om naar een lager team gezet geworden of je word ontslagen \n");
            Console.WriteLine("A: Ferrari        (je zult veel fans hebben maar het team staat beknd om soms foutjes te maken)");
            Console.WriteLine("B: Redbull Racing (het team is heel betrouwbaar maar je moet ook hooge verwachtingen voldoen )");
            Console.WriteLine("C: Porsche F1     (het is een nieuw f1 team dus het is nog onduidleijk wat ze kunnen maar ze beloven heel veel)\n");
            var input1 = Console.ReadLine();
            

            if (input1 == "a")
            {
                Console.Clear();
                team = "Ferrari";
                Console.WriteLine("je hebt ferrari gekozen");
                statusteam = "gemideld";
                statusfan = "hoog";
                reservemoter = 3;
                moterschade = 10;
                carfailurekans = "gemmideld";


            }

            if (input1 == "b")
            {
                Console.Clear();
                team = "Redbull Racing";
                Console.WriteLine("je heb Redbull Racing gekozen");
                Console.WriteLine("tijdens pre season testing ging alles goed met de auto maar je team genoot max verstappen was wel veel sneller dan jou dus je gaat het zwaar krijgen dit seizoen ");
                statusteam = "Laag";
                statusfan = "gemiddeld";
                reservemoter = 3;
                moterschade = 3;
                carfailurekans = "laag";
            }


            if (input1 == "c")
            {
                

                Console.Clear();
                team = "Porsche F1";
                Console.WriteLine("je hebt Porsche F1 gekozen\n");
                Console.WriteLine("tijdens pre season testing liep het vrij spoel ze zagen wel dat ze een moelijke keuze moesten gaan maken je hebt meer top snelheid nodig\n dus je zou de moter kunnen opvoeren hierbij zit wel een kans dat hij sneller kapot gaat wil je dit doen \n");
                Console.WriteLine("JA");
                Console.WriteLine("NEE");
                var input2 = Console.ReadLine();
                
                statusteam = "gemiddeld";
                statusfan = "gemiddeld";
                reservemoter = 3;
                moterschade = 5;
                carfailurekans = "gemmideld";

                Console.Clear();

                DisplayInformation(team, statusfan, statusteam,  reservemoter,moterschade);


                Console.ReadKey();


            }


            




        }
    }
}