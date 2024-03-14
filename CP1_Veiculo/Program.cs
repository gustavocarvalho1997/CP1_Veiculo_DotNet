class Program
{
    static void Main(string[] args)
    {
        Veiculo veiculoEscolhido = null;

        int opcao = 0;


        // Menu para escolher o tipo de veículo
        while (opcao != 3)
        {
            Console.WriteLine("Escolha o tipo de veículo:");
            Console.WriteLine("1 - Veículo de passeio");
            Console.WriteLine("2 - Veículo esportivo");
            Console.WriteLine("3 - Sair");
            Console.Write("Digite a opção desejada: ");
            opcao = Convert.ToInt16(Console.ReadLine());

            if (opcao == 1)
            {
                veiculoEscolhido = new VeiculoPasseio("XQR1258", "Fusca", "Volkswagen", 20000);
                break;
            }
            else if (opcao == 2)
            {
                veiculoEscolhido = new VeiculoEsportivo("URF7868", "Ferrari", "Ferrari", 1000000);
                break;
            }
            else if (opcao == 3)
            {
                Console.WriteLine("Saindo...");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }// while

        // Caso um veículo tenha sido escolhido no menu anterior apresenta os dados
        if (veiculoEscolhido != null)
        {
            Console.WriteLine("O Veículo escolhido foi: ");
            veiculoEscolhido.ImprimirDados();
        }// if

        // Menu para escolher a ação desejada
        int opcao2 = 0;
        while (opcao2 != 3 && veiculoEscolhido != null)
        {
            Console.WriteLine("Escolha a ação desejada:");
            Console.WriteLine("1 - Acelerar");
            Console.WriteLine("2 - Frear");
            Console.WriteLine("3 - Sair");
            Console.Write("Digite a opção desejada: ");
            opcao2 = Convert.ToInt16(Console.ReadLine());
            switch (opcao2)
            {
                case 1:
                    Console.Write("Digite o tempo de aceleração: ");
                    uint tempoAceleracao = Convert.ToUInt16(Console.ReadLine());
                    veiculoEscolhido.Acelerar(tempoAceleracao);
                    break;
                case 2:
                    Console.Write("Digite o tempo de frenagem: ");
                    uint tempoFrenagem = Convert.ToUInt16(Console.ReadLine());
                    veiculoEscolhido.Frear(tempoFrenagem);
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }// switch
        }// while 
    }// Main
}// Class




// Classe abstrata Veiculo
public abstract class Veiculo
{
    // Variáveis
    private string _placa;
    private string _modelo;
    private string _fabricante;
    private byte _aceleracao = 10;
    private byte frenagem = 18;
    private ushort _velocidadeMaxima = 150;
    private ushort _velocidadeMinima = 0;

    // Propriedades
    protected ushort Velocidade { get; set; }

    // Construtor
    public Veiculo(string placa, string modelo, string fabricante)
    {
        _placa = placa;
        _modelo = modelo;
        _fabricante = fabricante;
    }// Construtor

    // Métodos
    public virtual void Acelerar(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade < _velocidadeMaxima && (_velocidadeMaxima - Velocidade) >= _aceleracao)
            {
                Velocidade += _aceleracao;
            }
            else if ((_velocidadeMaxima - Velocidade) < _aceleracao)
            {
                Velocidade += (ushort)(_velocidadeMaxima - Velocidade);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Acelerar

    public virtual void Frear(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade > _velocidadeMinima && (Velocidade - _velocidadeMinima) >= frenagem)
            {
                Velocidade -= frenagem;
            }
            else if ((Velocidade - _velocidadeMinima) < frenagem)
            {
                Velocidade -= (ushort)(Velocidade - _velocidadeMinima);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Frear

    public virtual void ImprimirDados()
    {
        Console.WriteLine("Dados do veículo:");
        Console.WriteLine($"Placa: {_placa}");
        Console.WriteLine($"Modelo: {_modelo}");
        Console.WriteLine($"Fabricante: {_fabricante}");
        Console.WriteLine($"Velocidade: {Velocidade} km/h");
    }// ImprimirDados
}// Class

// Classe Veiculo Esportivo
public class VeiculoEsportivo : Veiculo
{
    // Variáveis
    private double _preco;
    private byte _aceleracao = 30;
    private byte _frenagem = 38;
    private ushort _velocidadeMaxima = 300;
    private ushort _velocidadeMinima = 0;

    // Construtor
    public VeiculoEsportivo(string placa, string modelo, string fabricante, double preco) : base(placa, modelo, fabricante)
    {
        _preco = preco;
    } // Construtor

    // Métodos
    public override void ImprimirDados()
    {
        base.ImprimirDados();
        Console.WriteLine($"Preço: {_preco}");

    }// ImprimirDados

    public override void Acelerar(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade < _velocidadeMaxima && (_velocidadeMaxima - Velocidade) >= _aceleracao)
            {
                Velocidade += _aceleracao;
            }
            else if ((_velocidadeMaxima - Velocidade) < _aceleracao)
            {
                Velocidade += (ushort)(_velocidadeMaxima - Velocidade);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Acelerar

    public override void Frear(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade > _velocidadeMinima && (Velocidade - _velocidadeMinima) >= _frenagem)
            {
                Velocidade -= _frenagem;
            }
            else if ((Velocidade - _velocidadeMinima) < _frenagem)
            {
                Velocidade -= (ushort)(Velocidade - _velocidadeMinima);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Frear
}// Class

// Classe Veiculo de Passeio
public class VeiculoPasseio : Veiculo
{
    // Variáveis
    private double _preco;
    private byte _aceleracao = 15;
    private byte _frenagem = 20;
    private ushort _velocidadeMaxima = 180;
    private ushort _velocidadeMinima = 0;

    // Construtor
    public VeiculoPasseio(string placa, string modelo, string fabricante, double preco) : base(placa, modelo, fabricante)
    {
        _preco = preco;
    }// Construtor

    // Métodos
    public override void Acelerar(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade < _velocidadeMaxima && (_velocidadeMaxima - Velocidade) >= _aceleracao)
            {
                Velocidade += _aceleracao;
            }
            else if ((_velocidadeMaxima - Velocidade) < _aceleracao)
            {
                Velocidade += (ushort)(_velocidadeMaxima - Velocidade);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Acelerar

    public override void Frear(uint segundos)
    {
        for (int i = 0; i < segundos; i++)
        {
            if (Velocidade > _velocidadeMinima && (Velocidade - _velocidadeMinima) >= _frenagem)
            {
                Velocidade -= _frenagem;
            }
            else if ((Velocidade - _velocidadeMinima) < _frenagem)
            {
                Velocidade -= (ushort)(Velocidade - _velocidadeMinima);
            }
            Console.WriteLine($"Velocidade atual: {Velocidade} km/h");
            Thread.Sleep(1000);
        }
    }// Frear

    public override void ImprimirDados()
    {
        base.ImprimirDados();
        Console.WriteLine($"Preço: {_preco}");
    }// ImprimirDados
}// Class