using System.Text.RegularExpressions;
using Explorando_Marte_Niuco.Models;

System.Console.WriteLine("--| Explorando Marte - 2025 |--");

System.Console.WriteLine("Digite as domensões do planalto (Formato: 5 5):");
string? inputPlanalto = Console.ReadLine();
if (!Regex.IsMatch(inputPlanalto ?? "", @"^\d+\s+\d+$"))
    throw new ArgumentException("Formato inválido. Tente novamente mais tarde.");

var partesPlanalto = inputPlanalto!.Split(' ');
int xMax = int.Parse(partesPlanalto[0]);
int yMax = int.Parse(partesPlanalto[1]);
var planalto = new Planalto(xMax, yMax);


while(true)
{
    System.Console.WriteLine("Digite a posição inicial da Sonda (Formato: 1 2 N/E/S/W):");
    string? posicaoInicialSonda = Console.ReadLine();
    if (!Regex.IsMatch(posicaoInicialSonda ?? "", @"^\d+\s+\d+\s+[NSEW]"))
        throw new ArgumentException("Formato inválido. Tente novamente mais tarde.");

    var partesPosicaoInicialSonda = posicaoInicialSonda!.Split(' ');
    int x = int.Parse(partesPosicaoInicialSonda[0]);
    int y = int.Parse(partesPosicaoInicialSonda[1]);
    char direcao = char.Parse(partesPosicaoInicialSonda[2].ToUpper());

    System.Console.WriteLine("Digite o trajeto do plano de operação da sonda (Formato: MLRMMRMRMLMMR):");
    string? sequenciaComandos = Console.ReadLine()?.ToUpper();
    if (string.IsNullOrEmpty(sequenciaComandos) || !Regex.IsMatch(sequenciaComandos ?? "", @"^[LRM]+$"))
        throw new ArgumentException("Comandos com formato inválido. Use apenas L, R ou M. Tente novamente mais tarde.");

    


    System.Console.WriteLine("Iniciar operação com nova sonda? Digite Y para Sim ou qualquer outra tecla para Não:");
    var resposta = Console.ReadLine()?.ToUpper();
    if (resposta != "Y") break; 
}

System.Console.WriteLine("Obrigado.");
