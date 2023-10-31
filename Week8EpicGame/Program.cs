string folderPath = @"C:\data\";

string heroFile = "heroes.txt";
string villianFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villianFile));
string[] weapons = { "gun", "magic wand", "sword", "wooden book" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}HP) with {heroWeapon} saves the day!");



string villian = GetRandomValueFromArray(villains);
string villianWeapon = GetRandomValueFromArray(weapons);
int villianHP = GetCharacterHP(villian);
int villianStrikeStrength = villianHP;
Console.WriteLine($"Today {villian} ({villianHP}HP) with {villianWeapon} tries to take over the world!");

while (heroHP > 0 && villianHP > 0)
{
    heroHP = heroHP - Hit(villian, villianStrikeStrength);
    villianHP = villianHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP {heroHP}");
Console.WriteLine($"Villain {villian} HP {villianHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villianHP > 0)
{ Console.WriteLine($"Dark side wins!"); }
else { Console.WriteLine("Draw!"); }


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string radnomStringFromArray = someArray[randomIndex];
    return radnomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    { return 10; }
    else
    { return characterName.Length; }

}

static int Hit(string characterName, int characterHp)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHp);
    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHp - 1)
    { Console.WriteLine($"{characterHp} made a critical hit!"); }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }

    return strike;

}



