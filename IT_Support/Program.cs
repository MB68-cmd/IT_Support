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

            bool spielLaeuft = true;
            Raum aktuellerRaum = flur;


            Console.WriteLine("******************************************");
            Console.WriteLine("Willkommen zum IT-Support-Simulator!");
            Console.WriteLine("******************************************");
            Console.ReadLine();



            // SPIEL SCHLEIFE

            // SPIEL-SCHLEIFE
            while (spielLaeuft)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Du bist hier: {aktuellerRaum.Name}");
                Console.WriteLine(aktuellerRaum.Beschreibung);



                // Liste für das Menü der verfügbaren Ausgänge
                var wege = new List<string>(aktuellerRaum.Ausgaenge.Keys);    // Hier werden die verfügbaren Ausgänge des aktuellen Raums in eine Liste umgewandelt, damit sie im Menü angezeigt werden können.
                var ding = aktuellerRaum.GegenstaendeImRaum;                  // Hier wird die Liste der Gegenstände im aktuellen Raum in eine Variable gespeichert, um sie später anzuzeigen.

                Console.WriteLine("wohin willst du?");

                // Menü für die verfügbaren Ausgänge

                for (int i = 0; i < wege.Count; i++)
                {
                    Raum ziel = aktuellerRaum.Ausgaenge[wege[i]];   // Hier wird der Zielraum für den aktuellen Ausgang aus dem Dictionary der Ausgänge des aktuellen Raums abgerufen.
                    Console.WriteLine($"{i + 1}. {wege[i]} -> {ziel.Name}");   // Hier wird die Nummer, die Richtung und der Name des Zielraums für jeden verfügbaren Ausgang angezeigt.
                    Console.ReadLine(); 
                }



            }
        }
    }
}