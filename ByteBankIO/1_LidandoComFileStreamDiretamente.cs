using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var numeroDeBytesLidos = -1;

                var buffer = new byte[1024];//1KB

                while (numeroDeBytesLidos != 0)
                {
                    //public override in Read(byte[] array, int offset, int count);
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }
                //Devoluções:
                // O número total de bytes lidos do buffer. Isso poderá ser menor que o número de
                // bytes solicitados se esse número de bytes não estiver disponível no momento, ou
                // zero, se o final do fluxo for atingido

                fluxoDoArquivo.Close();

                Console.ReadLine();
            }
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();

            //public virtual string GetString(byte[] bytes, int index, int count);
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(' ');
            //}
        }
    }
}