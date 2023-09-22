using System;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Security;
using System.Text.Json;

namespace advanturegame
{
    internal class Program
    {
        const int COUNT_RACERS = 20;
        static Auto mijnAuto = null;
      
        static void DisplayInformation(string team, string statusfan, string statusteam, int reservemoter, int moterschade)
        {
            Console.SetCursorPosition(Console.WindowWidth - 60, 0);
            Console.WriteLine("Doel: eerste worden in het werld kampioenaschap");

            Console.SetCursorPosition(Console.WindowWidth - 60, 1);
            Console.WriteLine($"Team: {team}");

            Console.SetCursorPosition(Console.WindowWidth - 60, 2);
            Console.WriteLine($"Status Fan: {statusfan}");

            Console.SetCursorPosition(Console.WindowWidth - 60, 3);
            Console.WriteLine($"Status Team: {statusteam}");

            Console.SetCursorPosition(Console.WindowWidth - 60, 4);
            Console.WriteLine($"Reserve Motor: {reservemoter}/3");

            Console.SetCursorPosition(Console.WindowWidth - 60, 5);
            Console.WriteLine($"Motorschade: {moterschade}/100");
        }
        static int[] GeneratePositions(int carSpeed)
        {
            if (carSpeed < 1 || carSpeed >10)
            {
                throw new ArgumentException("Car speed moet tussen 1 en 10 liggen.");
            }

            int[] positions = new int[COUNT_RACERS];
            double[] positionChances = new double[COUNT_RACERS];

            for (int i = 1; i < COUNT_RACERS; i++)
            {
                
                positionChances[i] = (carSpeed / 10.0) * (1.0 / (i + 1));
            }

            for (int i = 1; i < COUNT_RACERS; i++)
            {
                double randomValue = new Random().NextDouble();

                double cumulativeChance = 0;

                for (int j = 1; j < COUNT_RACERS; j++)
                {
                    cumulativeChance += positionChances[j];

                    if (randomValue <= cumulativeChance)
                    {
                        positions[i] = j + 1;
                        break;
                    }
                }
            }

            return positions;
        }

        static void motervervangen()
        {
            Console.WriteLine("wil je je moter vervangen voor de volgende race ");
            Console.WriteLine("JA");
            Console.WriteLine("NEE");
            var input5 = Console.ReadLine();
            if (input5 == "ja")
            {
                mijnAuto.ReserveMoter -= 1;
                mijnAuto.MoterSchade = 0;
            }
            Console.Clear();

            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            
        }

        static int CalculatePositionModifier(TimeSpan reactionTime)
        
        {
            
            if (reactionTime.TotalMilliseconds < 200)
            {
                return -2; 
            }
            else if (reactionTime.TotalMilliseconds < 220)
            {
                return -1; 
            }
            else if (reactionTime.TotalMilliseconds < 250)
            {
                return +0; 
            }
            else if (reactionTime.TotalMilliseconds < 300)
            {
                return +1; 
            }
            else if (reactionTime.TotalMilliseconds < 450)
            {
                return +2; 
            }
            else
            {
                return +5; 
            }
        }

        static void Main(string[] args)
        {

            
            Console.WriteLine("he racer je komt net uit de formule 2 en wilt je zelf gaan bewijzen in de f1 je hebt een paar contract offers gekregenvan een paar teams kies het team waar je bij wilt\n");
            Console.WriteLine("je zult in dit spel een paar stats krijgen je doel is natuurlijk om weereld kampioen te worden er zullen ook stats zijn \nvoor je status van de fans en status van je team als deze te laag komen is er een kans om naar een lager team gezet geworden of je word ontslagen \n");
            Console.WriteLine("A: Ferrari        (je zult veel fans hebben maar het team staat beknd om soms foutjes te maken)");
            Console.WriteLine("B: Redbull Racing (het team is heel betrouwbaar maar je moet ook hooge verwachtingen voldoen )");
            Console.WriteLine("C: Porsche F1     (het is een nieuw f1 team dus het is nog onduidleijk wat ze kunnen maar ze beloven heel veel)\n");
            var input1 = Console.ReadLine();
            
            if (input1 == "a")
            {
                mijnAuto = new Auto("Ferrari", "hoog", "gemideld", 3, 12, 3);

                Console.Clear();
                Console.WriteLine("je hebt ferrari gekozen");
                Console.WriteLine("tijdens pre season testing ging alles goed behalve werd het duidelijk dat de moter snel schade op liep hou dit in de gaten geduurdend het seizoen\n je kunt verder gaan naar de eerste race click enter om door te gaan");
                Console.ReadKey();
                Console.Clear();

                DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);



            }

            if (input1 == "b")
            {
               mijnAuto = new Auto("Redbull Racing", "gemideld", "laag", 3, 4,  4);

               
                Console.Clear();
                Console.WriteLine("je heb Redbull Racing gekozen");
                Console.WriteLine("tijdens pre season testing ging alles goed met de auto maar je team genoot max verstappen was wel veel sneller dan jou dus je gaat het zwaar krijgen dit seizoen\n je kunt verder gaan naar de eerste race click enter om door te gaan ");
                Console.ReadKey();
                Console.Clear();

                DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);
            }


            if (input1 == "c")
            {

                mijnAuto = new Auto("Porsche F1", "gemideld", "gemiddeld", 3, 6,  2);
       
                Console.Clear();
                Console.WriteLine("je hebt Porsche F1 gekozen\n");
                Console.WriteLine("tijdens pre season testing liep het vrij spoel ze zagen wel dat ze een moelijke keuze moesten gaan maken je hebt meer top snelheid nodig\n dus je zou de moter kunnen opvoeren hierbij zit wel een kans dat hij sneller kapot gaat wil je dit doen \n");
                Console.WriteLine("JA");
                Console.WriteLine("NEE");

                var input2 = Console.ReadLine();

                if(input2 == "ja")
                {
                    mijnAuto.MoterSchade =+5;
                    mijnAuto.CarSpeed = 6;
                }
                

                Console.Clear();

                DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);


            }

            Console.WriteLine("je begint nu met de eerste qwalificatie van het jaar nu ga je zien hoe snel je auto is\nje krijgt al wel een moelijke keuzen je weet nog niet hoe zwaar de competitie gaat zijn ga je je moter voor dit weekend een beetje opschroeven voor iets mee performence maar ook iets meer schade");
            Console.WriteLine("JA");
            Console.WriteLine("NEE");

            var input3 = Console.ReadLine();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            if (input3 == "ja")
            {
                mijnAuto.MoterSchade += 12;
                mijnAuto.CarSpeed  ++;
            }

            if (input3 == "nee")
            {
                mijnAuto.MoterSchade += 5;
                
            }
            Console.Clear();

            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            int[] positions = GeneratePositions(mijnAuto.CarSpeed);
            Random random = new Random();
            int position = positions[random.Next(20)];
            
            // start race 1
            GeneratePositions(mijnAuto.CarSpeed);

            if (input3 == "ja")
            {
                mijnAuto.CarSpeed--;
            }

            Console.WriteLine($"Je bent P{position} geworden");
            Console.WriteLine("Click op enter om de race te beginnen zorg dat je klaar staat voor de start ");
            Console.ReadLine();

            int lightDelay = random.Next(3000, 7000); 
            Console.WriteLine("Wacht seconden tot het licht aangaat en click op enter...");
            Thread.Sleep(lightDelay);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Licht is aan!");
            Console.ReadLine();

            stopwatch.Stop();
            TimeSpan reactionTime = stopwatch.Elapsed;
            Console.WriteLine($"Je reactietijd was: {reactionTime.TotalMilliseconds} milliseconden");

            position = CalculatePositionModifier(reactionTime);
            if (position == 0)
            {

                position = 1;   
            }
            
            Console.WriteLine($"je bent P{position}");
            Console.WriteLine("Met nog 15 ronden te gaan en iedereen op oude hardbanden, sta jij voor een cruciale beslissing: overschakelen naar zachte banden voor een snelheid van 1:34.300 per ronde en een pitstop van 21 seconden, of trouw blijven aan de harde banden met een gemiddelde rondetijd van 1:40:010. Wat wordt jouw strategie op de safety car je hebt 45 seconden om een keuze te maken ");
            Console.WriteLine("A :BOX BOX");
            Console.WriteLine("B :Blijf rijden");
            var output4 = Console.ReadLine();

            if (output4 == "a") 
            {
                if (position < 1)
                {

                    position = 1;
                    
                }
                position--;
                Console.WriteLine($"je hebt doe goede keuze gemaakt en uiteindelijk 1 plek gewonnen je staat P{position}");
            }
            else
            {
                position++;
                Console.WriteLine($"het scheelde niet veel maar je bent een plek verloren je staat nu P{position}");
            }

            Console.WriteLine($"FINISH!! je bent P{position} geworden");
            mijnAuto.MoterSchade += 20;
            Console.WriteLine("klik op enter om door te gaan");
            Console.ReadKey();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            Console.WriteLine("je moter heeft schade opgelopen je hebt heel het seizoen 3 moters zodra je moter boven de 70 komt zal je snelheid minderen je hebt 3 moteren dit seizoen benut ze goed ");
            motervervangen();

            Console.WriteLine("klik op enter om door te gaan naar de volgende race");

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);


            Console.WriteLine("monaco is de volgende race de qwalificatie is hier het belangrijkste aangezien je hier bijna niet kan inhalen daarom moet je goed je auto afstellen je krijgt vragen die je goed beantwoord word je auto sneller ");
            Console.WriteLine("heb je in monaco veel downforce nodig of heb je hier juist liever minder downforce");
            Console.WriteLine("A: veel downforce");
            Console.WriteLine("B: weinig downforce");
            var antwoord1 =Console.ReadLine();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            Console.WriteLine("hoe veel liter benzine gebruikt een formula 1 auto per race ");
            Console.WriteLine("A: 180");
            Console.WriteLine("B: 100");
            Console.WriteLine("C: 150");
            Console.WriteLine("D: 220");
            var antwoord2 = Console.ReadLine();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            Console.WriteLine("wat is de beste techniek om in het regen snel te rijden");
            Console.WriteLine("A: naast de race lijn te rijden");
            Console.WriteLine("B: driften ");
            Console.WriteLine("C: zagt remmen");
            Console.WriteLine("D: veel curb gebruiken ");

            var antwoord3= Console.ReadLine();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);


            Console.WriteLine("hoe veel soorten banden zijn er in de f1");
            Console.WriteLine("A: 3");
            Console.WriteLine("B: 6");
            Console.WriteLine("C: 4");
            Console.WriteLine("D: 2");

            var antwoord4 = Console.ReadLine();

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);


            Console.WriteLine("wat betekend een geele met rood gestreepte vlag ");
            Console.WriteLine("A: dat je zachter moet rijden ");
            Console.WriteLine("B: dat je niet mag inhalen");
            Console.WriteLine("C: dat het glad is ");
            Console.WriteLine("D: dat je auto kapot is");

            mijnAuto.MoterSchade += 10;

            var antwoord5 = Console.ReadLine();
            int punten = 0;
            if (antwoord1 == "a")
            {
                punten++;
            }
            if (antwoord2 == "c")
            {
                punten++;
            }
            if (antwoord3 == "a")
            {
                punten++;
            }
            if (antwoord4 == "b")
            {
                punten++;
            }
            if (antwoord5 == "c")
            {
                punten++;
            }

            if(punten == 5)
            {
                mijnAuto.CarSpeed+=2;

            }
            if (punten == 4)
            {
                mijnAuto.CarSpeed ++;
            }
            if (punten == 3)
            {
                mijnAuto.CarSpeed+=0;
            }
            if (punten == 2)
            {
                mijnAuto.CarSpeed-=1;
            }
            if (punten == 1)
            {
                mijnAuto.CarSpeed-=2;
            }
            if (punten == 0)
            {
                mijnAuto.CarSpeed -=3;
            }

            Console.WriteLine($"je had {punten} vragen goed");

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            GeneratePositions(mijnAuto.CarSpeed);
            if (punten == 5)
            {
                mijnAuto.CarSpeed--;

            }
            if (punten == 4)
            {
                mijnAuto.CarSpeed += 0;
            }
            if (punten == 3)
            {
                mijnAuto.CarSpeed++;
            }
            if (punten == 2)
            {
                mijnAuto.CarSpeed += 2;
            }
            if (punten == 1)
            {
                mijnAuto.CarSpeed += 3;
            }
            if (punten == 0)
            {
                mijnAuto.CarSpeed += 4;
            }
            Console.WriteLine($"Je bent P{position} geworden");
            Console.WriteLine("Click op enter om de race te beginnen zorg dat je klaar staat voor de start ");
            Console.ReadLine();

            lightDelay = random.Next(3000, 7000);
            Console.WriteLine("Wacht seconden tot het licht aangaat en click op enter...");
            Thread.Sleep(lightDelay);
            stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Licht is aan!");

            Console.ReadLine();
            stopwatch.Stop();
            reactionTime = stopwatch.Elapsed;

            Console.WriteLine($"Je reactietijd was: {reactionTime.TotalMilliseconds} milliseconden");

            position = CalculatePositionModifier(reactionTime);
            if (position == 0)
            {

                position = 1;
            }

            Console.WriteLine($"je bent P{position}");
            Console.WriteLine($"het was onmogelijk om inthalen zoals verwacht je bent p{position} geworden");
            Console.WriteLine("klik op enter om door te gaan ");
            Console.ReadLine();

            mijnAuto.MoterSchade += 22;

            Console.Clear();
            DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);

            static void motervervangen()
            {
                Console.WriteLine("wil je je moter vervangen voor de volgende race ");
                Console.WriteLine("JA");
                Console.WriteLine("NEE");
                var input5 = Console.ReadLine();
                if (input5 == "ja")
                {
                    mijnAuto.ReserveMoter -= 1;
                    mijnAuto.MoterSchade = 0;
                }
                Console.Clear();

                DisplayInformation(mijnAuto.Team, mijnAuto.StatusFan, mijnAuto.StatusTeam, mijnAuto.ReserveMoter, mijnAuto.MoterSchade);


            }

            Console.WriteLine("meer races komen er binnen kort aan :)");







        }
    }
    }
