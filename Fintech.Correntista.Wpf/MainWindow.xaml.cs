using Fintech.Modelos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Fintech.Repositorios.SqlServer;
using System.IO;
using System.Threading.Tasks;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly MovimentoRepositorio repositorio = new (Properties.Settings.Default.CaminhoArquivoMovimento);
        private readonly MovimentoRepositorio repositorio = new (Properties.Settings.Default.StringConexao);

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Cliente ClienteSelecionado { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);

            var banco = new Banco();
            banco.Nome = "Banco 1";
            banco.Numero = 1;

            bancoComboBox.Items.Add(banco);
            bancoComboBox.Items.Add(new Banco {Nome = "Banco 2", Numero = 2 });

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);

            clientesDataGrid.ItemsSource = Clientes;
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //var endereco = new Endereco();
            Endereco endereco = new();
            endereco.Cep = cepTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;
            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Numero = numeroTextBox.Text;

            var cliente = new Cliente();
            cliente.Cpf = cpfTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);
            cliente.Endereco = endereco;
            cliente.Nome = nomeTextBox.Text;
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            //int x;

            Clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso.");
            LimparControlesCliente();
            clientesDataGrid.Items.Refresh();
            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesCliente()
        {
            cpfTextBox.Text = "";
            nomeTextBox.Text = string.Empty;
            dataNascimentoTextBox.Text = null;
            sexoComboBox.SelectedIndex = -1;
            logradouroTextBox.Clear();
            numeroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedIndex == -1)
            {
                return;
            }

            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
                limiteTextBox.Clear();
            }
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";
            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;
            var clienteSelecionado = botaoClicado.DataContext;

            ClienteSelecionado = (Cliente)clienteSelecionado;
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            //var conta = new Conta();

            Conta conta = null;

            switch ((TipoConta)tipoContaComboBox.SelectedItem)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    //conta.Limite;
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            //ClienteSelecionado.Contas = new List<Conta>();

            ClienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso.");
            LimparControlesConta();
            clientesDataGrid.Items.Refresh();
            clientesTabItem.Focus();
            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contaComboBox.ItemsSource = ClienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            LimparControlesOperacoes();

            operacoesTabItem.Focus();
        }

        private void LimparControlesOperacoes()
        {
            contaComboBox.SelectedIndex = -1;
            operacaoComboBox.SelectedIndex = -1;
            valorTextBox.Clear();
            movimentacaoDataGrid.ItemsSource = null;
            saldoTextBox.Clear();
        }

        private async void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contaComboBox.SelectedIndex == -1)
            {
                return;
            }

            mainSpinner.Visibility = Visibility.Visible;

            var conta = (Conta)contaComboBox.SelectedItem;

            //conta.Movimentos = repositorio.Selecionar(conta.Agencia.Numero, conta.Numero);
            conta.Movimentos = await repositorio.SelecionarAsync(conta.Agencia.Numero, conta.Numero);

            mainSpinner.Visibility = Visibility.Hidden;

            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            saldoTextBox.Text = conta.Saldo.ToString("c");
        }

        private void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)contaComboBox.SelectedItem;
                var operacao = (Operacao)operacaoComboBox.SelectedItem;
                var valor = Convert.ToDecimal(valorTextBox.Text);

                var movimento = conta.EfetuarOperacao(valor, operacao);

                repositorio.Inserir(movimento);

                movimentacaoDataGrid.ItemsSource = conta.Movimentos;
                movimentacaoDataGrid.Items.Refresh();

                saldoTextBox.Text = conta.Saldo.ToString("c");
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show($"O arquivo {ex.FileName} não foi encontrado.");
                //Logar(ex); - log4Net
            }
            catch (DirectoryNotFoundException)
            {
                //new FileInfo().Extension;
                //foreach (var arquivo in Directory.GetFiles(""))
                //{
                //    var info = new FileInfo(arquivo).Extension;
                //}

                MessageBox.Show($"O diretório {Properties.Settings.Default.CaminhoArquivoMovimento} não foi encontrado.");
                //Logar(ex); - log4Net
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"O arquivo {Properties.Settings.Default.CaminhoArquivoMovimento} está com o atributo Somente Leitura.");
                //Logar(ex); - log4Net
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eita! Algo deu errado e em breve teremos uma solução.");
                //Logar(ex);
            }
            //finally
            //{
            //    // É executado sempre! Mesmo que haja algum return no código.
            //}
        }
    }
}