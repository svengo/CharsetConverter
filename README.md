# CharsetConverter
CharsetConverter makes it easier to convert a bunch of files from one charset to another. Files are backuped and recoded. You will no longer need to convert one file after another. It's developed in VB.NET.

Most parts are in German.

Zusammenfassung
===============
CharsetConverter dient dazu, in einem Rutsch mehrere Dateien von einem
Zeichensatz in einen anderen zu konvertieren. Die Dateien können dabei in
unterschiedlichen Verzeichnissen liegen.

Installation
============
Die Anwendung benötigt das Microsoft .NET-Framework in der Version 4.0.

Zur Installation Kopieren Sie die folgenden Dateien in ein beliebiges
Verzeichnis der Festplatte:

- CharsetConverter.exe
- CharsetConverter.exe.manifest
- license.txt
- readme.txt

Konfiguration
=============
Es ist keine Konfiguration notwendig.

Verwendung
==========
Nach dem Aufruf des Programms müssen zunächst die zu konvertierenden Dateien
ausgewählt werden. Die Dateien können sowohl über die beiden "Hinzufügen"
Buttons im Programmfenster als auch per 'Drag and Drop' aus dem
Windows-Explorer in das freie Feld hinzugefügt werden. Auf diese Art können
sowohl einzelne Dateien als auch gesamte Verzeichnisse ausgewählt werden, bei
Verzeichnissen wird nur die erste Verzeichnisebene berücksichtigt.

Mit einem Klick auf den Button "Entfernen" werden die ausgewählten Einträge
aus der Dateiliste entfernt. Ein Klick auf "Liste leeren" löscht die gesamte
Liste.

Unter "Encoding" sind die Eingangs- und Ausgangszeichensätze auszuwählen. Der
in den Ausgangsdateien verwendete Zeichensatz ist vorher zu ermitteln, damit
das Programm korrekt funktionieren kann.

Standardmäßig wird bei der Konvertierung einer Datei ein Backup im
Unterverzeichnis "CharsetConverterBackups" erstellt, der Dateiname bleibt
dabei erhalten. Sollte die Konvertierung nicht wie gewünscht funktionieren,
können die Originaldateien durch einfaches kopieren wiederhergestellt werden.
Das Backup-Verzeichnis wird dabei immer als Unterverzeichnis im Verzeichnis
der Originaldatei angelegt. Die Erstellung eines Backups kann durch entfernen
des Hakens deaktiviert werden, vor dem Löschen des Hakens erfolgt eine
Sicherheitsabfrage. Die Erstellung eines Backups wird DRINGEND empfohlen.

Die eigentliche Konvertierung wird mit einem Klick auf den Button OK
gestartet. Bei der Konvertierung werden die Originaldaten durch die
konvertierten ersetzt. Vor dem Start muss eine Sicherheitsabfrage bestätigt
werden. Der Ablauf der Konvertierung wird in einem Logfenster dargestellt. Die
Ausgabe kann mit einem Klick auf den Button "Kopieren" in die Zwischenablage
kopiert werden. Ein Klick auf "Schließen" schließt das Fenster und kehrt zum
Hauptfenster zurück.

Über den Hilfe-Button oben rechts ("?") können die verwendete Programmversion
und das Copyright abgefragt werden.

Technischer Ablauf
==================
Die möglichen Kodierungen werden zur Laufzeit ermittelt. In anderen Umgebungen
werden so unter Umständen nicht alle Möglichkeiten angeboten.

Zunächst wird - wenn gewünscht - ein Backup erstellt.

Die Eingangsdatei wird mit dem angegebenen Zeichensatz zeilenweise ausgelesen
und zunächst in eine temporäre Datei mit dem gewünschten Zeichensatz
geschrieben. Intern werden die Daten immer im UTF-8 Format verarbeitet. Die
temporäre Datei wird bei Erfolg an die Stelle der Originaldatei kopiert, die
Originaldatei wird dabei überschrieben. Die temporäre Datei wird anschließend
gelöscht.

Unterstützte Zeichensätze
=========================
Das Programm unterstützt alle von .NET angebotenen Zeichensätze - sowohl zur
Ein- als auch zur Ausgabe. Eine vollständige Auflistung findet sich unter
http://msdn.microsoft.com/de-de/library/system.text.encoding.aspx.

In der Praxis dürften die folgenden Kodierungen besonders häufig vorkommen:

- ibm850 / Westeuropäisch (DOS) / "ASCII"
- Windows-1252 / Westeuropäisch (Windows) / "ANSI"
- iso-8859-15 / Lateinisch 9 (ISO)
- utf-16 / Unicode (UTF-16)
- utf-8 / Unicode (UTF-8)

Feedback / Bug-Reports
======================
Feedback und Fehlerberichte sind entweder direkt an den Autor zu senden bzw.
unter https://github.com/svengo/CharsetConverter/issues zu erfassen.

Copyright
=========
Copyright (c) 2012, Sven Gottwald
All rights reserved.

Das Programm wird unter der "New BSD License (BSD)" veröffentlicht, die Lizenz
findet sich in der Datei license.txt.
