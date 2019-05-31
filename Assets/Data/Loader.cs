using Ludio.Data.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ludio.Data
{
    public abstract class Loader
    {
        public abstract List<Program> LoadPrograms();
    }

    public class LocalLoader : Loader
    {
        private static LocalLoader _instance;

        public static LocalLoader INSTANCE
        {
            get
            {
                if (_instance == null)
                    _instance = new LocalLoader();

                return _instance;
            }
        }
        private LocalLoader() { }

        private List<Program> Programs { get; set; }

        public override List<Program> LoadPrograms()
        {
            if (Programs != null) return Programs;

            Programs = new List<Program>
            {
                LoadScratch(),
            };
            return Programs;
        }

        private Program LoadScratch()
        {
            Program Scratch = new Program("SCRATCH", "#E9730BFF");
            
            Scratch.Add(LoadRocketRacer(Scratch));
            Scratch.Add(LoadTutorial2(Scratch));

            Training Open = new Training(Scratch, "Open Scratch");
            Open.Add("Open je favoriete internet browser bv. Chrome, Firefox of Safari");
            Open.Add("Ga naar scratch.mit.edu");
            Open.Add("Klik op 'Maak' of 'Probeer het'");

            Scratch.Open = Open;

            return Scratch;
        }

        private Tutorial LoadRocketRacer(Program p)
        {
            Tutorial RocketRacer = new Tutorial("Ruimtevaarders", p);

            Training training = new Training(RocketRacer, "Herhaal 'Neem 20 stappen en draai 15 graden' wanneer de groene vlag wordt aangeklikt");

            training.Add("Sleep 'neem 10 stappen' uit het blauwe Beweging menu in het programmeerveld");
            training.Add("Laat de raket niet 10 naar 20 stappen nemen");
            training.Add("Laat hem daarna 15 graden draaien door dit blok eronder te plaatsen");
            training.Add("Zet de gebeurtenis 'wanneer de groene vlag wordt aangeklikt' erboven");
            training.Add("Herhaal het stappen nemen en het draaien door het gele herhaal blok om de 2 blauwe blokken te zetten");

            RocketRacer.Add(training);

            RocketRacer.Add("Klik op de groene vlag en zie de raket rondjes vliegen");

            Training training2 = new Training(RocketRacer, "Bestuur de raket met de pijltjes toesten door de snelheid en de rotatie met behulp van variabelen aan te passen");

            training2.Add("Maak om de raket te besturen 2 oranje variabelen aan (alleen voor de sprite van de raket) en noem ze snelheid en rotatie");
            training2.Add("Sleep het ronde snelheid blok op de 20 van neem 20 stappen om de snelheid tijdens het spel aan te kunnen passen");
            training2.Add("Vervang de 15 in het blauwe 15 graden draaien blok met de rotatie variabele");
            training2.Add("Maak snelheid en rotatie 0 wanneer de groene vlag wordt ingedrukt");
            training2.Add("Verander de rotatie met 1 wanneer het rechter pijltje ingedrukt wordt");
            training2.Add("Kopieer de groep door met de rechtermuis knop op het bruine blok te klikken");
            training2.Add("Pas de kopie zo aan dat de rotatie met 1 verlaagd wordt wanneer het linker pijltje ingedrukt is");
            training2.Add("Doe hetzelfde voor de snelheid met de pijltjes omhoog en omlaag");

            RocketRacer.Add(training2);
            RocketRacer.Add("Klik op de groene vlag en beweeg de raket met de pijltjes toetsen");

            Training training3 = new Training(RocketRacer, "voeg een score variabele toe en verhoog die als het 'speler1' bericht ontvangen is");

            training3.Add("Maak een nieuwe variabele voor de raket en noem hem score");
            training3.Add("Sleep het blokje 'wanneer ik signaal ... ontvang' in het programmeerveld");
            training3.Add("Verander 'bericht 1' naar 'speler1'");
            training3.Add("Plaats 'verander score met 1' eronder");

            RocketRacer.Add(training3);
            RocketRacer.Add("Klik op de groene vlag en versla de aliens van jou kleur!");
            RocketRacer.Add("Kopieer de raket sprite door met de rechtermuis knop er op te drukken en kopieren te selecteren");
            RocketRacer.Add("Bestuur de nieuwe raket met ASWD en reageer op het 'speler2' bericht");
            return RocketRacer;
        }

        private Tutorial LoadTutorial2(Program p)
        {
            Tutorial Tut2 = new Tutorial("Voetballen", p);
            Tut2.Add("Dit is de voetbal tutorial");
            return Tut2;
        }
    }
}
