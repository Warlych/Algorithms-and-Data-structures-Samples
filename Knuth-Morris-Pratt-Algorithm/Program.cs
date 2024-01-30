using Knuth_Morris_Pratt_Algorithm;

string input = "heelowoeerld";
string pattern = "el";

var result = KnuthMorrisPrattAlgorithm.Search(input, pattern);

Console.WriteLine("Подстрока: " + string.Join(", ", result));