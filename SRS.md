# Space Image - Specifikace požadavků
Filip Komárek  
verze 1.0  
2023/06/11

## Úvod

## Účel dokumentu
Tento dokument popisuje účel, způsob fungování a základní požadavky tohoto software.

## Pro koho je dokument určený
Pro vývojáře a uživatele software

## Kontakty
Email: filip@fkomarek.eu  
Telegram: fkomarek  
Discord: filip2cz  
Mastodon: @filip2cz@mastodon.arch-linux.cz  
Instagram: @filip2czprivate  
SINET: hyper -> 9385 -> 2000

## Produkt jako celek
Program bude aplikace pro Android (potenciálně v budoucnu i pro iOS a Windows Phone), která ukáže uživateli Image of the day od organizace NASA. Uživatel bude mít také možnost zobrazit si Image of the day z minulosti.

## Funkce
Program se připojí na API organizace NASA, odkud si stáhne odkaz na obrázek, který po té zobrazí v aplikaci i s popisem k obrázku. Dále umožní uživateli stáhnout obrázek a nebo ho sdílet.

## Uživatelské skupiny
Běžní uživatelé bez technické zdatnosti

## Provozní prostředí
Mobilní telefon

## Uživatelské prostředí
Jednoduchá jednostránková aplikace, jenž zobrazí obrázek a bude obsahovat také možnost výběru data pro zobrazení starších obrázků. Dále bude obsahovat text a tlačítko na stažení a sdílení.

## Omezení návrhu a implementace
Software bude vyvíjen primárně pro systém Android 13, měl by ale fungovat i na starších verzích a novějších verzích.

## Předpoklady a závislosti
Pro provoz aplikace je třeba pouze připojení k internetu, není třeba žádný doplňující software

## Vlastnosti systému
- připojení k internetu
- kompatabilní operační systém, viz. omezení návrhu implementace

## Nefunkční požadavky
- připojení k internetu