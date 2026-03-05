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

            //test


            // VERBINDUNGEN ERSTELLEN
            //flur.Ausgaenge.Add("norden", buero);
            //flur.Ausgaenge.Add("osten", lager);
            //flur.Ausgaenge.Add("westen", serverraum);
            //flur.Ausgaenge.Add("süden", kantine);

            //buero.Ausgaenge.Add("süden", flur);

            // GEGENSTÄNDE ERSTELLEN & VERTEILEN
            Gegenstand tastatur = new Gegenstand("Goldene Tastatur", "Sehr wertvoll.");
            Gegenstand kaffee = new Gegenstand("Kaffee", "Gibt Energie.");
            Gegenstand kabel = new Gegenstand("LAN-Kabel", "Wichtig für den Server.");


            //SPIEL STARTEN



            Console.WriteLine("******************************************");
            Console.WriteLine("Willkommen zum IT-Support-Simulator!");
            Console.WriteLine("******************************************");
            Console.ReadLine();





        }
    }
}
