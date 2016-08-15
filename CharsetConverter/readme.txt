CharsetConverter
Version: 1.2
http://charsetconverter.codeplex.com/


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
   - CharsetConverter.exe.config
   - LogFile.dll
   - license.txt
   - readme.txt
   

Konfiguration
=============
In der Datei CharsetConverter.exe.config kann der Backup-Pfad konfiguriert
werden.


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

Die eigentliche Konvertierung wird mit einem Klick auf den Button "OK" 
gestartet. Bei der Konvertierung werden die Originaldaten durch die 
konvertierten ersetzt. Der Zustand der Konvertierung wird durch ein Icon
gekennzeichnet, im Tooltip wird das Ergebnis beschrieben. Während das Programm 
läuft wird im Temp-Verzeichnis ein Logfile erstellt und laufend fort 
geschrieben. Sollte während der Konvertierung ein Fehler auftreten, bietet das 
Programm an das Logfile anzuzeigen. Die fehlerhaften Dateien können erneut zur 
Liste hinzugefügt werden.

Neben der Konvertierung des Zeichensatzes werden auch die Zeilenendzeichen 
auf den Windows-Standard gebracht. Soll nur der Zeilenumbruch korrigiert 
werden, kann ein identischer Eingangs- und Ausgangszeichensatz gewählt werden.

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

   - Windows-1252 / Westeuropäisch (Windows) / "ANSI"
   - iso-8859-15 / Lateinisch 9 (ISO)
   - ibm850 / Westeuropäisch (DOS) / "ASCII"
   - utf-16 / Unicode (UTF-16)
   - utf-8 / Unicode (UTF-8)


Feedback / Bug-Reports
======================
Feedback und Fehlerberichte sind entweder direkt an den Autor zu senden bzw. 
unter http://charsetconverter.codeplex.com/workitem/list/basic zu erfassen.
   

Copyright
=========
Copyright (c) 2012, Sven Gottwald
All rights reserved.

Das Programm wird unter der "New BSD License (BSD)" veröffentlicht, die Lizenz 
findet sich in der Datei license.txt.

Der Sourcecode kann von http://charsetconverter.codeplex.com bezogen werden.