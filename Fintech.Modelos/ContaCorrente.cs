namespace Fintech.Modelos
{
    public class ContaCorrente : Conta //TODO: Herança.
    {
        public ContaCorrente() //TODO: Polimorfismo de sobrecarga.
        {
        }

        public ContaCorrente(Agencia agencia, int numero, string digitoVerificador) 
            : base(agencia, numero, digitoVerificador)
        {
            //Agencia = agencia;
            //Numero = numero;
            //DigitoVerificador = digitoVerificador;
        }

        public bool EmissaoChequeHabilitada { get; set; }
    }
}