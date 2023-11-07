# Funkční specifikace

- verze: 1.2
- datum: 7. listopadu 2023
- autor: Filip Komárek

## O tomto dokumentu

Účel tohoto dokumentu je specifikovat funkční požadavky.
Dokument je určen pro uživatele, kteří chtějí lépe pochopit fungování tohoto programu.

## Použití
Aplikace ukáže uživateli dnešní image of the day od agentury NASA a dovolí mu podívat se na obrázky z předchozích dnů. Dále mu ukáže popis k obrázku a umožní mu pomocí dvou tlačítek stáhnout nebo sdílet obrázek.

## Architektura software
Aplikace si buď vezme aktuální datum nebo datum od uživatele a pomocí NASA API, kde si stáhne JSON s veškerými informacemi. Z toho si získá odkaz na fotku a popis obrázku, jenž pak zobrazí.

Aplikace také bude obsahovat dvě tlačítka: tlačítko na sdílení a tlačítko na stažení.

Tlačítko na stažení uloží obrázek z odkazu do zařízení uživatele do složky Downloads.

Tlačítko sdílení udělá systémové vyskakovací okno pro sdílení obrázku. Bude zde (ještě před vyskočením systémového dialogu) také na výběr, jestli se má poslat obrázek jako soubor nebo jako odkaz na web.

## Otevřené otázky
- vzhled
- možnost nastavení si vlastního API Key