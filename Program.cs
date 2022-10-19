
class Test
{
    public static void Main()
    {
        var köket = new KökProgram();
        köket.LäggtillApparatFörTest("Microwave oven", "Electrolux", true);
        köket.LäggtillApparatFörTest("Toaster", "Philips", false);
        köket.LäggtillApparatFörTest("Oven", "Electrolux", true);
        köket.LäsVal();
    }
}

public interface IKitchenAppliance
{
    string Type { get; set; }
    string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    void Use();
}
class KökApparat : IKitchenAppliance
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }

    public KökApparat(string type, string brand, bool isFunctioning)
    {
        Type = type;
        Brand = brand;
        IsFunctioning = isFunctioning;
    }
    public void Use()
    {
        if (IsFunctioning)
        {

            Console.WriteLine("Använder " + Type);
        }
        else
        {
            Console.WriteLine("Apparaten är trasig");
        }
    }
}

class KökProgram
{
    List<KökApparat> apparaterLista = new List<KökApparat>();

    public void LäsVal()
    {
        bool avsluta = true;
        while (avsluta)
        {
            HuvudMeny();
            try
            {
                int inmattning = Convert.ToInt32(Console.ReadLine());
                switch (inmattning)
                {
                    case 1:
                        AnvändApparat();
                        break;
                    case 2:
                        LäggTillKöksapparat();
                        break;
                    case 3:
                        ListaKöksapparater();
                        break;
                    case 4:
                        TaBortköksapparat();
                        break;
                    case 5:
                        avsluta = false;
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Inmattning måste vara en siffra av 1, 2, 3, 4, 5");
            }
        }

    }

    private void HuvudMeny()
    {
        Console.WriteLine("=========KÖKET=========");
        Console.WriteLine("1. Använd köksapparat");
        Console.WriteLine("2. Lägg till Köksapparat");
        Console.WriteLine("3. Lista köksapparater");
        Console.WriteLine("4. Ta bort köksapparat");
        Console.WriteLine("5. Avsluta");
        Console.WriteLine("Ange val:");
    }

    private void ListaKöksapparater()
    {
        foreach (var apparat in apparaterLista)
        {
            Console.WriteLine((apparaterLista.IndexOf(apparat) + 1) + ". " + apparat.Type);
        }
    }

    private void AnvändApparat()
    {
        while (true)
        {
            try
            {
                if (apparaterLista.Count == 0)
                {
                    Console.WriteLine("Inga apparater för att avnända");
                    break;
                }
                Console.WriteLine("Välj köksapparat:");
                ListaKöksapparater();
                Console.WriteLine("Ange val:");
                int inmattningUnderMeny = Convert.ToInt32(Console.ReadLine());
                if (!(inmattningUnderMeny > 0 && inmattningUnderMeny <= apparaterLista.Count))
                {
                    throw new Exception();
                }
                apparaterLista.ElementAt(inmattningUnderMeny - 1).Use();
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ditt val existerar inte i köksapparater. Försök igen");
            }
        }
    }
    private void LäggTillKöksapparat()
    {
        var typ = "";
        var märke = "";
        var skick = true;
        while (true)
        {
            try
            {

                Console.WriteLine("Ange typ");
                typ = Convert.ToString(Console.ReadLine());
                if (typ == null || typ.Equals(""))
                {
                    throw new Exception();
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Du måste ange typ av apparaten");
            }
        }

        while (true)
        {
            try
            {

                Console.WriteLine("Ange märke");
                märke = Convert.ToString(Console.ReadLine());
                if (märke == null || märke.Equals(""))
                {
                    throw new Exception();
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Du måste ange märke av apparaten");
            }
        }

        while (true)
        {
            try
            {

                Console.WriteLine("Ange om den fungerar (j/n)");
                var apparatSkick = Convert.ToString(Console.ReadLine());
                //if (apparatSkick == null || apparatSkick.Equals("") || !new[] { "j", "n" }.Contains(apparatSkick))
                if (apparatSkick == null || apparatSkick.Equals("") || !(apparatSkick.Equals("j") || apparatSkick.Equals("n")))
                {
                    throw new Exception();
                }
                if (apparatSkick.Equals("j"))
                {
                    skick = true;
                }
                else if (apparatSkick.Equals("n"))
                {
                    skick = false;
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Du måste ange skick av apparaten (j/n)");
            }
        }

        KökApparat apparat = new KökApparat(typ, märke, skick);
        apparaterLista.Add(apparat);
        Console.WriteLine("Tillagd!");
    }
    private void TaBortköksapparat()
    {
        while (true)
        {
            try
            {
                if (apparaterLista.Count == 0)
                {
                    Console.WriteLine("Inga apparater för att ta bort");
                    break;
                }
                ListaKöksapparater();
                Console.WriteLine("Välj köksapparat för att ta bort:");
                int inmattningUnderMeny = Convert.ToInt32(Console.ReadLine());
                if (!(inmattningUnderMeny > 0 && inmattningUnderMeny <= apparaterLista.Count))
                {
                    throw new Exception();
                }
                apparaterLista.RemoveAt(inmattningUnderMeny - 1);
                Console.WriteLine("Tagits bort");
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ditt val existerar inte i köksapparater. Försök igen");
            }
        }
    }

    public void LäggtillApparatFörTest(string type, string brand, bool isFunctioning)
    {
        apparaterLista.Add(new KökApparat(type, brand, isFunctioning));
    }
}
