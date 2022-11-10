using AbstractMethods.Entities;
using System.Globalization;

List<TaxPayer> TaxPayers = new List<TaxPayer>();
Console.Write("Enter the number of tax payers: ");
int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; i++) {
    Console.WriteLine($"Tax payer #{i} data: ");
    Console.Write("Individual or company (i/c)? ");
    char type = char.Parse(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Anual income: ");
    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    if(type == 'i') {
        Console.Write("Health expenditures: ");
        double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        TaxPayers.Add(new Individual(name, anualIncome, healthExpenditures));
    } else {
        Console.Write("Number of employees: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());
        TaxPayers.Add(new Company(name, anualIncome, numberOfEmployees));
    }
}
double sum = 0.0;
Console.WriteLine();
Console.WriteLine("TAXES PAID:");
foreach(TaxPayer t in TaxPayers) {
    sum += t.Tax();
    Console.WriteLine($"{t.Name}: $ " + t.Tax().ToString("F2", CultureInfo.InvariantCulture));
}
Console.WriteLine();
Console.WriteLine($"TOTAL TAXES: $ {sum.ToString("F2", CultureInfo.InvariantCulture)}");
   
