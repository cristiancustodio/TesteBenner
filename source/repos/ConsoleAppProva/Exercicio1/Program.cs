using Exercicio1;
using Exercicio1.Validacao;

var network = new Network(new ArgumentoValidador(), 8);

network.Connect(1, 6);
network.Connect(2, 4);
network.Connect(4, 7);
network.Connect(5, 8);
network.Connect(6, 2);


var result = network.Query(1, 4);

Console.WriteLine("");
result = network.Query(4, 7);

Console.WriteLine("");
result = network.Query(1, 7);




