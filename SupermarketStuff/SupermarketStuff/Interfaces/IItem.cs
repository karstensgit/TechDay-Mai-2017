namespace SupermarketStuff.Interfaces
{
    // anstatt ein Interface zu implementieren bietet sich hier auch eine Struktur (struct) anstelle einer Klasse an
    // um eine Struktur zu benutzen, muesst ihr die Referenzen in den Klassen entsprechend anpassen

    public interface IItem
    {
        double GetPrice();
        string GetName();
        string ToString();
    }
}