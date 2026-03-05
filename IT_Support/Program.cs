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
            chefBuero.GegenstaendeImRaum.Add(tastatur);  // Hier wird die goldene Tastatur im Chef-Büro platziert, damit der Spieler sie später finden und verwenden kann.
            kantine.GegenstaendeImRaum.Add(kaffee); // Hier wird der Kaffee in der Kantine platziert, damit der Spieler ihn später finden und verwenden kann.
            lager.GegenstaendeImRaum.Add(kabel); // Hier wird das Kabel in den Lagerraum gelegt, damit der Spieler es später finden und verwenden kann.



            //SPIEL STARTEN

            bool spielLaeuft = true;              // Hier wird eine boolesche Variable erstellt, die den Status des Spiels verfolgt. Solange diese Variable auf true gesetzt ist, läuft das Spiel weiter.
            Raum aktuellerRaum = flur;            // Hier wird der aktuelle Raum auf den Flur gesetzt, damit der Spieler dort startet und von dort aus die anderen Räume erkunden kann.
            Spieler spieler = new Spieler("");    // Hier wird ein neues Spieler-Objekt erstellt, das den Spieler repräsentiert. Der Name des Spielers wird als leerer String übergeben, da er später im Spiel festgelegt werden kann.


            Console.WriteLine("******************************************");
            Console.WriteLine("Willkommen zum IT-Support-Simulator!");         
            Console.WriteLine("******************************************");
            Console.ReadLine();



            // SPIEL-SCHLEIFE
            while (spielLaeuft)
            {
                Console.WriteLine("\n-----------------------------------");  
                Console.WriteLine($"Du bist hier: {aktuellerRaum.Name}");     // Hier wird der Name des aktuellen Raums angezeigt, damit der Spieler weiß, wo er sich befindet.
                Console.WriteLine(aktuellerRaum.Beschreibung);   // Hier wird der Name und die Beschreibung des aktuellen Raums angezeigt, damit der Spieler weiß, wo er sich befindet und was ihn dort erwartet.


                // Menü für die verfügbaren Gegenstände
                if (spieler.Inventar.Count > 0)   // Hier wird überprüft, ob der Spieler Gegenstände im Inventar hat. Wenn ja, wird "Inventar: " ausgegeben, gefolgt von den Namen der Gegenstände im Inventar.
                {
                    Console.Write("Inventar: ");  // Hier wird überprüft, ob der Spieler Gegenstände im Inventar hat. Wenn ja, wird "Inventar: " ausgegeben, gefolgt von den Namen der Gegenstände im Inventar.
                    foreach (var s in spieler.Inventar) Console.Write("[" + s.Name + "] ");  // Hier wird das Inventar des Spielers angezeigt, indem die Namen der Gegenstände im Inventar in eckigen Klammern aufgelistet werden. Wenn das Inventar leer ist, wird nichts angezeigt.
                    Console.WriteLine();  
                }

                // Liste für das Menü der verfügbaren Ausgänge
                var wege = new List<string>(aktuellerRaum.Ausgaenge.Keys);    // Hier werden die verfügbaren Ausgänge des aktuellen Raums in eine Liste umgewandelt, damit sie im Menü angezeigt werden können.
                var ding = aktuellerRaum.GegenstaendeImRaum;   // Hier wird die Liste der Gegenstände im aktuellen Raum in eine Variable gespeichert, um sie später anzuzeigen.

                Console.WriteLine("wohin willst du?");   

                // Menü für die verfügbaren Ausgänge
                for (int i = 0; i < wege.Count; i++)  // Hier wird eine Schleife verwendet, um die verfügbaren Ausgänge des aktuellen Raums anzuzeigen. Für jeden Ausgang wird die Nummer, die Richtung und der Name des Zielraums angezeigt, damit der Spieler entscheiden kann, wohin er gehen möchte.
                {
                    Raum ziel = aktuellerRaum.Ausgaenge[wege[i]];   // Hier wird der Zielraum für den aktuellen Ausgang aus dem Dictionary der Ausgänge des aktuellen Raums abgerufen.
                    Console.WriteLine($"{i + 1}. {wege[i]} -> {ziel.Name}");   // Hier wird die Nummer, die Richtung und der Name des Zielraums für jeden verfügbaren Ausgang angezeigt.
                }

                // Menü: Aufheben von Gegenständen im Raum

                for (int i = 0; i < ding.Count; i++)  // Hier wird eine Schleife verwendet, um die Gegenstände im aktuellen Raum anzuzeigen. Für jeden Gegenstand wird die Nummer, der Name und die Beschreibung angezeigt, damit der Spieler entscheiden kann, ob er einen Gegenstand aufheben möchte.
                {
                    Console.WriteLine($"{i + 1 + wege.Count}. [Gegenstand] {ding[i].Name} - {ding[i].Beschreibung}");   // Hier wird die Nummer, der Name und die Beschreibung jedes Gegenstands im aktuellen Raum angezeigt, damit der Spieler entscheiden kann, ob er einen Gegenstand aufheben möchte.
                }
                Console.WriteLine("0: Beenden");  // Hier wird die Option "0: Beenden" angezeigt, damit der Spieler das Spiel beenden kann, wenn er dies wünscht.
                Console.WriteLine("deine Wahl: ");  // Hier wird "deine Wahl: " ausgegeben, um den Spieler aufzufordern, eine Auswahl zu treffen, entweder einen Ausgang zu wählen, einen Gegenstand aufzuheben oder das Spiel zu beenden.
                string eingabe = Console.ReadLine();   // Hier wird die Eingabe des Spielers gelesen, damit sie später verarbeitet werden kann, um die gewünschte Aktion auszuführen.


                if (int.TryParse(eingabe, out int wahl))  // Hier wird überprüft, ob die Eingabe des Spielers eine gültige Zahl ist. Wenn ja, wird die Zahl in der Variable "wahl" gespeichert, damit sie später verwendet werden kann, um die gewünschte Aktion auszuführen.
                {
                    if (wahl == 0) spielLaeuft = false;   // Hier wird überprüft, ob die Wahl des Spielers "0" ist. Wenn ja, wird die Variable "spielLaeuft" auf false gesetzt, um die Spielschleife zu beenden und das Spiel zu verlassen.

                    // Logik: Gehen
                    else if (wahl > 0 && wahl <= wege.Count)   // Hier wird überprüft, ob die Wahl des Spielers eine gültige Zahl ist, die einem der verfügbaren Ausgänge entspricht. Wenn ja, wird der aktuelle Raum auf den Zielraum des gewählten Ausgangs gesetzt, damit der Spieler dorthin gehen kann.
                    {
                        aktuellerRaum = aktuellerRaum.Ausgaenge[wege[wahl - 1]];  // Hier wird der aktuelle Raum auf den Zielraum des gewählten Ausgangs gesetzt, damit der Spieler dorthin gehen kann. Die Wahl des Spielers wird um 1 reduziert, um den Index der Liste der verfügbaren Ausgänge zu erhalten, da die Anzeige der Ausgänge bei 1 beginnt, aber die Indizes in der Liste bei 0 beginnen.
                    }

                    // Logik: Aufheben
                    else if (wahl > wege.Count && wahl <= wege.Count + ding.Count)   // Hier wird überprüft, ob die Wahl des Spielers eine gültige Zahl ist, die einem der verfügbaren Gegenstände im Raum entspricht. Wenn ja, wird der gewählte Gegenstand zum Inventar des Spielers hinzugefügt und aus dem Raum entfernt, damit der Spieler ihn aufheben kann.
                    {
                        int index = wahl - wege.Count - 1;   // Hier wird der Index des gewählten Gegenstands berechnet, indem die Wahl des Spielers um die Anzahl der verfügbaren Ausgänge und um 1 reduziert wird, um den Index der Liste der Gegenstände im Raum zu erhalten, da die Anzeige der Gegenstände bei der Anzahl der Ausgänge + 1 beginnt, aber die Indizes in der Liste bei 0 beginnen.
                        Gegenstand aufgehoben = ding[index];   // Hier wird der gewählte Gegenstand aus der Liste der Gegenstände im Raum abgerufen, damit er später zum Inventar des Spielers hinzugefügt und aus dem Raum entfernt werden kann.

                        spieler.Inventar.Add(aufgehoben);   // Hier wird der gewählte Gegenstand zum Inventar des Spielers hinzugefügt, damit der Spieler ihn aufheben und später verwenden kann.
                        ding.RemoveAt(index);

                        Console.WriteLine($"\n>>> Du hast {aufgehoben.Name} eingepackt.");  // Hier wird eine Nachricht ausgegeben, die bestätigt, dass der Spieler den gewählten Gegenstand erfolgreich aufheben konnte, indem der Name des Gegenstands in die Nachricht eingefügt wird.
                    }
                    else Console.WriteLine("\nFalsche Zahl!");
                }
                else Console.WriteLine("\nBitte nur Zahlen tippen!");
            }
            Console.WriteLine("Programm beendet. Bis bald!");

        }
        
    }
}