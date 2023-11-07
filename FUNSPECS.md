# Funkční specifikace

- verze: 1.1
- datum: 7. listopadu 2023
- autor: Filip Komárek

## O tomto dokumentu

Účel tohoto dokumentu je specifikovat funkční požadavky.
Dokument je určen pro uživatele, kteří chtějí lépe pochopit fungování tohoto programu.

## Použití
Aplikace ukáže uživateli dnešní image of the day od agentury NASA a dovolí mu podívat se na obrázky z předchozích dnů. D8le mu ukáže popis k obrázku a umožní mu pomocí dvou tlačítek stáhnout nebo sdílet obrázek.

## Architektura software
Aplikace si buď vezme aktuální datum nebo datum od uživatele a pomocí NASA API si získá odkaz na tuto fotku, kterou pak zobrazí společně s popisem obrázku.

## Otevřené otázky
- vzhled
- možnost nastavení si vlastního API Key