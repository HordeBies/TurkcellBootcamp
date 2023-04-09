while (true)
{
    // char.
    Console.WriteLine("Lutfen sifrenizi girin:");
    var password = Console.ReadLine();
    if (string.IsNullOrEmpty(password))
    {
        Console.WriteLine("Kabul edilebilir bir sifre girmediniz");
        continue;
    }
    bool hasNumeric = false, hasLetter = false, hasSymbol = false;

    foreach (var character in password)
    {
        if (char.IsLetter(character)) hasLetter = true;
        else if (char.IsDigit(character)) hasNumeric = true;
        else if(char.IsSymbol(character)) hasSymbol = true;
    }

    int securityLevel = 0;
    //TODO: start checking from security level 3 and move to below, thus decrease repeated comparisons
    if ((hasNumeric != hasLetter) && (!hasSymbol)) // ( has only numeric OR has only letter ) AND dont have any symbol
    {
        securityLevel = 1;
    }
    if (hasNumeric && hasLetter && !hasSymbol)
    {
        securityLevel = 2;
    }
    if (hasNumeric && hasLetter && hasSymbol)
    {
        securityLevel = 3;
    }
    if (securityLevel == 0)
    {
        Console.WriteLine("Sifrenizin güvenlik seviyesini hesaplayamıyorum chat gpt'ye sorabilirsiniz.");
        continue;
    }
    //Never should hit dict[0]
    Dictionary<int, string> securityLevelMap = new() { {0, "HATALI" }, { 1, "ZAYIF" }, { 2, "ORTA" }, { 3, "GUCLU" } };
    Console.WriteLine($"Sifreniz: {securityLevelMap[securityLevel]}");
}