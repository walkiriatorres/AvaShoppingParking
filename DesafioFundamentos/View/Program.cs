using DesafioFundamentos.Models.Classes;
using DesafioFundamentos.View;

Console.OutputEncoding = System.Text.Encoding.UTF8;

TelaUsuario telaUsuario = new TelaUsuario(); 
Estacionamento es = telaUsuario.ExibirMenuConfiguracao();
telaUsuario.ExibirMenuPrincipal(es);