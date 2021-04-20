using System;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int y = 16;
        int w = 45;
        int z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritméticasToolStripMenuItem_Click(object sender, EventArgs evento)
        {
            // este é um comentário
            /*Comentário*/
            /*
            Comentário
            */

            //aprovado = false;
            uint x = 42;
            int X = 18;
            
            var nome = "Vítor";
            string endereco;

            //if (endereco == "R. Tal")
            //{
            //    // instrução;
            //}

            char caractere = 'c';

            bool aprovado = true;
            aprovado = false;
            //aprovado = "sim"; // C# é uma linguagem estaticamente tipada.

            //DateTime dataNascimento = new DateTime(2000, 4, 16);
            var dataNascimento = new DateTime(2000, 4, 16);

            string @class = "3D";

            var a = 2;
            var b = 6;
            int c = 10, d = 13;

            var valor = 31.5m;
            float outroValor = 3.8f;
            double maisUmValor = 4.7;

            //var e = 26;
            
            resultadoListBox.Items.Add("a = " + a/*.ToString()*/);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            //resultadoListBox.Items.Add(string.Format("c = {0}, d = {1}", c, d));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");
            
            //resultadoListBox.Items.Add("---------------------------------------------------");
            resultadoListBox.Items.Add(new string('-', 50));

            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;

            resultadoListBox.Items.Add("x = " + x);

            //x = x - 3;
            x -= 3;
            //x = -3;

            resultadoListBox.Items.Add("x = " + x);
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}");
            resultadoListBox.Items.Add("a = " + a);

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}");
            resultadoListBox.Items.Add("a = " + a);
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (true)
            //{
            //    var j = 10;
            //}

            //j = 11;

            ExibirVariaveis();

            resultadoListBox.Items.Add($"w <= x = {w <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");
        }

        private void ExibirVariaveis()
        {
            resultadoListBox.Items.Add("x = " + x);
            resultadoListBox.Items.Add("y = " + y);
            resultadoListBox.Items.Add("w = " + w);
            resultadoListBox.Items.Add("z = " + z);
            
            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirVariaveis();

            resultadoListBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && x != z = {x == z && x != z}");
            resultadoListBox.Items.Add($"!(y > w) = {!(y > w)}");
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;

            ano = 2014;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(ano % 4 == 0 ? "Sim" : "Não")}.");

            ano = 2016;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}.");

            //var resposta = "";
            //if (DateTime.IsLeapYear(ano))
            //{
            //    resposta = "Sim";
            //}
            //else
            //{
            //    resposta = "Não";
            //}
        }
    }
}
