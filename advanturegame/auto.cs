using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanturegame
{
    
        public class Auto
        {
            // Eigenschappen (Properties)
            public string Team { get; set; }
            public string StatusFan { get; set; }
            public string StatusTeam { get; set; }
            public int ReserveMoter { get; set; }
            public int MoterSchade { get; set; }
            
            public int CarSpeed { get; set; }

            // Constructor om een Auto-object te maken
            public Auto(string team, string statusFan, string statusTeam, int reserveMoter, int moterSchade,  int carSpeed)
            {
                Team = team;
                StatusFan = statusFan;
                StatusTeam = statusTeam;
                ReserveMoter = reserveMoter;
                MoterSchade = moterSchade;
             
                CarSpeed = carSpeed;
            }
        }

    }

