namespace IT_Support
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // RÄUME ERSTELLEN / HIER WERDEN OBJEKTE ERSTELLT
            Raum flur = new Raum("Flur", "Ein langer, heller Flur.");
            Raum buero = new Raum("Büro", "Dein Schreibtisch, voll mit Zetteln.");
            Raum lager = new Raum("Lager", "Überall Kartons mit alten Tastaturen und Kabeln.");
            Raum serverraum = new Raum("Serverraum", "Es ist laut,d ie LEDs blinken rot!");
            Raum kantine = new Raum("Kantine", "Es riecht nach Essen und Kaffee.");
            Raum chefBuero = new Raum("Chef-Büro", "Luxus Raum mit goldenem Namensschild.");
            Raum werkstatt = new Raum("Werkstatt", "Hier liegt fast alles an Werkzeug.");

            // VERBINDUNGEN ERSTELLEN
            flur.Ausgaenge.Add("norden", buero);
            flur.Ausgaenge.Add("osten", lager);
            flur.Ausgaenge.Add("westen", serverraum);
            flur.Ausgaenge.Add("süden", kantine);

            buero.Ausgaenge.Add("süden", flur);
            buero.Ausgaenge.Add("norden", chefBuero);

            lager.Ausgaenge.Add("westen", flur);
            lager.Ausgaenge.Add("norden", werkstatt);

            serverraum.Ausgaenge.Add("osten", flur);
            kantine.Ausgaenge.Add("norden", flur);
            chefBuero.Ausgaenge.Add("süden", buero);
            werkstatt.Ausgaenge.Add("süden", lager);

            // GEGENSTÄNDE ERSTELLEN
            Gegenstand tastatur = new Gegenstand("Goldene Tastatur", "Sehr wertvoll.");
            Gegenstand kaffee = new Gegenstand("Kaffee", "Gibt Energie.");
            Gegenstand kabel = new Gegenstand("LAN-Kabel", "Wichtig für den Server.");


            // GEGENSTÄNDE IN RÄUME LEGEN
            chefBuero.GegenstaendeImRaum.Add(tastatur);  
            kantine.GegenstaendeImRaum.Add(kaffee);
            lager.GegenstaendeImRaum.Add(kabel);



            //SPIEL STARTEN

            bool spielLäuft = true;
            Raum aktuellerRaum = flur;


            Console.WriteLine("******************************************");
            Console.WriteLine("Willkommen zum IT-Support-Simulator!");
            Console.WriteLine("******************************************");
            Console.ReadLine();



            // SPIEL SCHLEIFE

            while (spielLäuft)  
            {
                Console.WriteLine("===================");
                Console.WriteLine($"Du bist im {flur.Name}.");
                Console.WriteLine(flur.Beschreibung);
                Console.WriteLine("Ausgänge:");
                foreach (var ausgang in flur.Ausgaenge)
                {
                    Console.WriteLine($"- {ausgang.Key} führt zum {ausgang.Value.Name}");
                }

                
            }

        }
    }
}
