using Common;
using FindingAllNumberDivisions;

Console.WriteLine("Znajdowanie wszystkich podziałów liczby");

while (true)
{
    ConsoleExtensions.WriteSeparatorLine();
    var number = ConsoleExtensions.ObtainInt("liczbę");
    var result = new AllNumberDivisions(number);
    new ConsoleWriter(result).Write();
}

