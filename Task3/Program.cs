
class Currency
{
    public double Value { get; protected set; }

    public Currency(double value)
    {
        Value = value;
    }

    public static CurrencyUSD ToUSD(Currency currency, double exchangeRate)
    {
        return new CurrencyUSD(currency.Value / exchangeRate);
    }

    public static CurrencyEUR ToEUR(Currency currency, double exchangeRate)
    {
        return new CurrencyEUR(currency.Value / exchangeRate);
    }

    public static CurrencyRUB ToRUB(Currency currency, double exchangeRate)
    {
        return new CurrencyRUB(currency.Value / exchangeRate);
    }
}

class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }

    public static explicit operator CurrencyEUR(CurrencyUSD usd)
    {
        double exchangeRate = 0.93; 
        return new CurrencyEUR(usd.Value * exchangeRate);
    }

    public static explicit operator CurrencyRUB(CurrencyUSD usd)
    {
        double exchangeRate = 96.53; 
        return new CurrencyRUB(usd.Value * exchangeRate);
    }
    
    public override string ToString()
    {
        return $"{Value} USD";
    }
}

class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }

    public static explicit operator CurrencyUSD(CurrencyEUR eur)
    {
        double exchangeRate = 1.07;
        return new CurrencyUSD(eur.Value * exchangeRate);
    }
    
    public static explicit operator CurrencyRUB(CurrencyEUR eur)
    {
        double exchangeRate = 103.43;
        return new CurrencyRUB(eur.Value * exchangeRate);
    }
    
    public override string ToString()
    {
        return $"{Value} EUR";
    }
}

class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) : base(value) { }

    public static explicit operator CurrencyUSD(CurrencyRUB rub)
    {
        double exchangeRate = 0.01;
        return new CurrencyUSD(rub.Value * exchangeRate);
    }

    public static explicit operator CurrencyEUR(CurrencyRUB rub)
    {
        double exchangeRate = 0.0097;
        return new CurrencyEUR(rub.Value * exchangeRate);
    }
    
    public override string ToString()
    {
        return $"{Value} RUB";
    }
}



class Program
{
    static void Main(string[] args)
    {
        CurrencyUSD usd = new CurrencyUSD(100.0);
        CurrencyEUR eur = (CurrencyEUR)usd;
        CurrencyRUB rub = (CurrencyRUB)usd;
        Console.WriteLine(usd);
        Console.WriteLine(eur);
        Console.WriteLine(rub);
    }
}