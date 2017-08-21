using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine.UI;
using Forca;


public class GerenciadorPalavras : MonoBehaviour
{

    ListaDePalavras minhalista = new ListaDePalavras();
    public List<GameObject> objetos;
    public List<GameObject> objetosLetrasErradas;
    List<Vector3> posicoes;
    List<Vector3> posicoesErradas;
    List<Vector3> posicoesTracos;
    //public string[] palavras;
    public static int vidas = 10;
    public int quantidadeDeTentativas = 2;
    public int indexLetraDaPalavraErrada = 0;
    private string texto;
    private string EntradaUser = "";
    private string palavraAdivinhada = "";
    private string palavraDigitada = "";
    private string palavraEscolhida = "";
    public static float progressoPercentual = 0;
    static int quantidadeItens = 14;
    public static int quantidadeItensDesbloqueados = 0;
    public static bool[] controleItensLiberados = new bool[quantidadeItens];
    public static bool[] exibirInformativo = new bool[quantidadeItens];
    public string[] letrasErradas;
    public static bool charExiste = false;
    public static bool acertou = false;
    public static bool itemAdicionado = false;
    public GameObject canvasGameObject;
    

    public GameObject panelGanhou;
    public GameObject panelPerdeu;
    public GameObject panelScroolItens;


    /*os objetos para serem salvos ao reload o level prescisam ser statics*/

    private void Start()
    {


        if (SelectNivel.level.Equals("facil"))
        {
            CarregaLIstaFaceis();
            carregaposicoes();
            carregaposicoesErradas();
            carregaposicoesTracos();
            sortPalavra();
            Debug.Log("Nivel facil selecionado");


        }
        else
        {
            CarregaLIstaDificil();
            carregaposicoes();
            carregaposicoesErradas();
            carregaposicoesTracos();
            sortPalavra();
            Debug.Log("Nivel dificil selecionado");
        }



        //instanciaelementos ();


    }





    void Update()
    {
        iniciaGame();
        progressoPercentual = (float)((float)quantidadeItensDesbloqueados / (float)quantidadeItens) * 100.0f;
    }



    /*  private void OnGUI()
      {
          if (vidas > 0 && palavraAdivinhada != palavraEscolhida)
          {
              GUILayout.Label("Vidas: "+vidas.ToString());
              GUILayout.Box(palavraAdivinhada);
              EntradaUser = GUILayout.TextField(EntradaUser, GUILayout.Width(200));

              if (GUILayout.Button("tente essa letra"))
              {
                  if (EntradaUser.Length == 1 )
                  {
                      checarCAractere(EntradaUser[0]);                
                      }
                  else if (EntradaUser.Length > 1)
                  {
                      if (palavraEscolhida == EntradaUser)
                          palavraAdivinhada = EntradaUser;
                  }
              }
          }
          else {
              if (vidas > 0)
              {
                  GUILayout.Box("Voc� ganhou");

              }
              else
              {
                  GUILayout.Box("Voc� Perdeu!!");

              }
          }
      }*/


    private void checarCAractere(char c)
    {
        charExiste = false;


        for (int i = 0; i < palavraEscolhida.Length; i++)
        {
            if (palavraEscolhida[i] == c && palavraEscolhida[i] != '-')
            {
                charExiste = true;
                Debug.Log("Letra ou palavra existe :" + palavraEscolhida[i]);
                string temporaria = palavraAdivinhada.Substring(0, i);
                palavraAdivinhada = temporaria + c.ToString() + palavraAdivinhada.Substring(i + 1, palavraAdivinhada.Length - i - 1);

                //	Instantiate (objetos[12],posicoes[0],Quaternion.Euler(0,0,0));
                Instantiate(objetos[palavraEscolhida[i] - 64], posicoes[i], Quaternion.Euler(0, 0, 0));
                texto = "";
            }
            else if (palavraEscolhida[i] == '-')
            {
                charExiste = true;
                Debug.Log("Letra ou palavra existe :" + palavraEscolhida[i]);
                string temporaria = palavraAdivinhada.Substring(0, i);
                palavraAdivinhada = temporaria + c.ToString() + palavraAdivinhada.Substring(i + 1, palavraAdivinhada.Length - i - 1);

                //	Instantiate (objetos[12],posicoes[0],Quaternion.Euler(0,0,0));
                Instantiate(objetos[0], posicoes[i], Quaternion.Euler(0, 0, 0));
                texto = "";
            }
             
            
        }
        if (!charExiste && c !='-')
        {
            Instantiate(objetosLetrasErradas[c - 64], posicoesErradas[indexLetraDaPalavraErrada], Quaternion.Euler(0, 0, 0));
            Debug.Log("Letra ou palavra não existe !!");
            texto = "";
            indexLetraDaPalavraErrada++;
            vidas--;
        }
        if (!charExiste && c == '-')
        {
            Instantiate(objetosLetrasErradas[0], posicoesErradas[indexLetraDaPalavraErrada], Quaternion.Euler(0, 0, 0));
            Debug.Log("Letra ou palavra não existe !!");
            texto = "";
            indexLetraDaPalavraErrada++;
            vidas--;
        }
    }

    public void CarregaLIstaFaceis()
    {
        minhalista = new ListaDePalavras();
        minhalista.Palavras = new List<Palavra>();
        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(1, 1, "NASCENTE", "_", "_", 8, "Afloramento do lençol freático na superfície do solo, que dá origem a cursos d’água (regatos, ribeirões e rios) ou a uma fonte de água de acúmulo (represa)");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(2, 1, "PAU BRASIL", "_", "_", 10, "Nome da árvore que foi declarada Árvore Nacional do Brasil pela Lei 6.607 de 7 de dezembro de 1978, e deu nome ao país.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(3, 1, "AQUECIMENTO GLOBAL", "_", "_", 18, "Processo de aumento da temperatura média dos oceanos e do ar perto da superfície da Terra causado pelas emissões humanas de gases do efeito estufa.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(4, 2, "RELEVO", "_", "_", 6, "Conjunto das formas da crosta terrestre, manifestando-se desde o fundo dos oceanos até as terras emersas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(5, 2, "CAATINGA", "_", "_", 8, "Bioma exclusivamente brasileiro, rico em biodiversidade e com vegetação típica de regiões semiáridas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(6, 2, "ATMOSFERA", "_", "_", 9, "Camada de ar ao redor da Terra que mantém e protege a vida terrestre, composta quase na totalidade por oxigênio e nitrogênio.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(7, 2, "BIODEGRADAVEL", "_", "_", 13, "Nome dado a todo material que pode ser decomposto pela ação de microorganismos do solo, da água e do ar.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(8, 3, "DESERTIFICACAO", "_", "_", 14, "Processo de transformação de terras não-desérticas em deserto, como resultado, em geral, de pastagem excessiva, uso excessivo das águas subterrâneas, desmatamento e etc.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(9, 3, "EXTINCAO", "_", "_", 8, "Nome do processo relativo ao desaparecimento definitivo de uma espécie de ser vivo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(10, 3, "FOTOSSINTESE", "_", "_", 12, "Processo realizado pelas plantas para a produção de energia necessária para a sua sobrevivência pela síntese da luz solar.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(11, 3, "HABITAT", "_", "_", 7, "Ambiente particular ou lugar onde um organismo ou espécies tendem a viver.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(12, 3, "POPULACAO ", "_", "_", 9, "Conjunto de indivíduos de uma mesma espécie que vivem em determinada região:");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(13, 3, "VERTEBRADOS", "_", "_", 11, "Animais que, como os seres humanos, possuem coluna vertebral.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(14, 3, "LITOSFERA", "_", "_", 9, "Camada sólida mais externa do planeta rochoso e é constituída por rochas e solo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(15, 3, "CAATINGA ", "_", "_", 8, "Bioma predominante na Região Nordeste.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(16, 3, "MATA ATLANTICA", "_", "_", 14, "Bioma predominante no litoral Brasileiro.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(17, 3, "EROSAO", "_", "_", 6, "Nome do processo relativo ao desaparecimento definitivo de uma espécie de ser vivo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(18, 3, "AGRESTE", "_", "_", 7, "- Sub-região do Nordeste caracterizada por uma área de transição entre o Sertão semiárido e a zona de Mata Atlântica.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(19, 3, "SUL", "_", "_", 3, "Região brasileira caracterizada por ser a mais fria do país?");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(20, 3, "MATA CILIAR", "_", "_", 11, "Formação vegetal localizada nas margens dos córregos, lagos, represas e nascentes.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(21, 3, "BREJO", "_", "_", 5, "Representam as áreas encharcadas ou pantanosas que se encontram próximo aos cursos d’água.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(22, 3, "ANO", "_", "_", 3, "Espaço de tempo gasto pela terra no movimento completo de translação em volta do sol.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(23, 3, "AQUIFERO", "_", "_", 8, "Formação geológica subterrânea que funciona como reservatório de água, sendo alimentado pelas chuvas que se infiltram no subsolo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(24, 3, "ARCO-IRIS", "_", "_", 9, "Um ou mais arcos concêntricos, constituídos por faixas coloridas, produzidos pela luz solar ou lunar quando incidente sobre uma cortina de gotas d'água em suspensão ou queda livre na atmosfera.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(25, 3, "ZONA RURAL", "_", "_", 10, "Área do município, excluídas as áreas urbanas, onde são desenvolvidas, predominantemente, atividades agrícolas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(26, 3, "AREIA", "_", "_", 5, "Grãos de quartzo que derivam da desagregação ou da decomposição das rochas ricas em sílica.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(27, 3, "MOVEDICA", "_", "_", 8, "Nome da areia fina, a média, fluidificada por conter muita água, que reage prontamente à pressão ou peso, podendo engolfar homens ou animais.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(28, 3, "MATA ATLANTICA", "_", "_", 14, "Bioma com influência do Oceano Atlântico e de floresta tropical úmida no qual restam apenas 8,5 % de remanescentes florestais acima de 100 hectares do que existia originalmente no Brasil. ");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(29, 3, "CERRADO", "_", "_", 7, "Segundo maior bioma da América do Sul, de clima tropical e vegetação de campos, com árvores isoladas, de troncos retorcidos e folhas encerradas, reconhecido como a savana mais rica do mundo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(30, 3, "CAATINGA", "_", "_", 8, "Único bioma exclusivamente brasileiro, de clima semiárido com drenagens intermitentes.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(31, 3, "BIOSFERA", "_", "_", 8, "Zona de transição entre a Terra e a atmosfera, dentro da qual é encontrada a maior parte das formas de vida terrestre.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(32, 3, "OZONIO", "_", "_", 6, "Camada da atmosfera que protege a Terra, rica em um gás composto por três átomos de hidrogênio, que filtra grande parte da radiação ultravioleta emitida pelo sol. ");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(33, 3, "CELULA", "_", "_", 6, "Constitui a unidade estrutural dos tecidos dos seres vivos.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(34, 3, "CHORUME", "_", "_", 7, "Líquido escuro e com alta carga poluidora, resultante da decomposição do lixo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(35, 3, "CLIMA", "_", "_", 5, "Estado da atmosfera expresso principalmente por meio de temperaturas, chuvas, isolação, nebulosidade etc.");

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(36, 3, "CLORACAO", "_", "_", 8, "Processo de tratamento de água, que consiste na aplicação de cloro em água de abastecimento público ou despejos, para desinfecção.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(37, 3, "COLIFORMES", "_", "_", 10, "Bactérias do grupo coli encontrada no trato intestinal dos homens e animais, comumente utilizada como indicador de poluição na água por matéria orgânica de origem animal.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(38, 3, "COMBUSTIVEL", "_", "_", 11, "Nome dado à substância que é oxidada em uma reação de combustão.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(39, 3, "EFEITO ESTUFA", "_", "_", 13, "Efeito do dióxido de carbono resultante da queima de combustíveis fósseis na temperatura média da Terra.");

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(40, 3, "ETANOL", "_", "_", 6, "Produto combustível derivado da cana de açúcar, mas também pode ser obtido de cereais.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(41, 3, "EVAPORACAO", "_", "_", 10, "Processo físico pelo qual um líquido, como a água, passa para o estado gasoso.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(42, 3, "EXTINCAO", "_", "_", 8, "Desaparecimento de determinada espécie, devido a processos naturais ou provocados pelo homem, como a caça e a pesca desmedidas, o manejo incorreto do solo e o desmatamento.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(43, 3, "FAUNA", "_", "_", 5, "Conjunto das espécies animais determinado ecossistema.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(44, 3, "FLORA", "_", "_", 15, "Conjunto da vegetação de determinado ecossistema.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(45, 3, "CICLO DA AGUA", "_", "_", 13, "Movimento contínuo da agua pressente nos oceanos, continentes e na atmosfera.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(46, 3, "EROSAO PLUVIAL", "_", "_", 14, "Fenômeno de destruição dos agregados do solo pelo impacto das gotas de chuva.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(47, 3, "ICEBERG", "_", "_", 7, "Grande bloco de gelo, de origem continental, que flutua no mar.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(48, 3, "LIQUEFACAO", "_", "_", 10, "A conversão de uma substância gasosa num líquido.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

    }

    public void CarregaLIstaDificil()
    {
        minhalista = new ListaDePalavras();
        minhalista.Palavras = new List<Palavra>();
        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(1, 1, "ASSOREAMENTO", "_", "_", 12, "Acúmulo de sedimentos em um curso d’água.)");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(2, 1, "PLANALTO", "_", "_", 8, "- Nome dado a uma forma de relevo formado por uma superfície elevada em relação ao nível do mar, com cume quase nivelado, geralmente devido à erosão eólica ou pelas águas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(3, 1, "NOVO CODIGO FLORESTAL", "_", "_", 21, "Nome da lei brasileira que trata da proteção da vegetação nativa, sancionada em 2012.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(4, 2, "BIOMA", "_", "_", 5, "Conjunto de diferentes ecossistemas, que possuem certo nível de homogeneidade. São as comunidades biológicas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(5, 2, "SALOBRA", "_", "_", 7, "Água que apresenta mais sais dissolvidos (cloretos) que a água doce e menos que a água do mar. Pode originar-se da mistura de ambas como nos estuários ou pela ação do homem na construção de barreiros e represas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(6, 2, "ATERRO SANITARIO", "_", "_", 16, "Local para a disposição final de resíduos sólidos no solo, fundamentado em critérios de saneamento, engenharia e normas operacionais específicas, permitindo a confinação segura do lixo, em termos de controle da poluição ambiental.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(7, 2, "BACIA HIDROGRAFICA", "_", "_", 18, "Toda a área drenada por um determinado curso d’água e seus tributários, delimitada pelos pontos mais altos do relevo. Esses pontos mais altos são chamados de divisores de águas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(8, 3, "DESERTIFICACAO", "_", "_", 14, "Processo de transformação de terras não-desérticas em deserto, como resultado, em geral, de pastagem excessiva, uso excessivo das águas subterrâneas, desmatamento e etc.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(9, 3, "BIODIESEL ", "_", "_", 9, "Combustível produzido com o uso de óleos vegetais de sementes oleaginosas como dendê, mamona, castanha, girassol, castanha de caju e soja.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(10, 3, "COMPOSTAGEM", "_", "_", 11, "Processo de tratamento em que a matéria orgânica putrescível (restos de alimentos, aparas e podas de jardins, folhas etc.) contida no resíduo é degradada biologicamente, obtendo-se um produto humificado que pode ser utilizado como adubo orgânico.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(11, 3, "LIXAO", "_", "_", 5, "Forma inadequada de disposição final de resíduos sólidos, sem nenhum critério técnico, caracterizado pela descarga do lixo diretamente sobre o solo, sem qualquer tratamento prévio, colocando em risco o meio ambiente e a saúde pública.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(12, 3, "RECICLAGEM ", "_", "_", 10, "Retorno de materiais descartados (papel, vidro, latas etc.) ao sistema de produção para a fabricação de novos bens, com o objetivo de economizar recursos e energia.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(13, 3, "AGROTOXICOS", "_", "_", 11, "Defensivos químicos usados na agricultura.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(14, 3, "MANGUEZAL", "_", "_", 9, "Ecossistema encontrado em vários pontos do litoral brasileiro, típico de áreas costeiras alagadas em regiões de clima tropical ou subtropical que se localiza entre o ambiente terrestre e o ambiente marinho.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(15, 3, "MUNDAU", "_", "_", 6, "Nome da Bacia Hidrográfica em que o Município de Garanhuns está inserido.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(16, 3, "AMAZONICA", "_", "_", 9, "Maior bacia hidrográfica do Brasil e do Mundo?");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(17, 3, "CORDILHEIRA DOS ANDES", "_", "_", 21, "Região caracterizada por ser uma cadeia montanhosa formada por um sistema contínuo de montanhas ao longo da costa ocidental da América do Sul.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(18, 3, "RESERVA ECOLOGICA", "_", "_", 17, "Área cujo objetivo é a proteção e a manutenção das florestas, demais formações de vegetação natural, públicas ou particulares, e espaços considerados de preservação permanente.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(19, 3, "AGROECOLOGIA", "_", "_", 12, "Ciência que estuda as relações entre a agricultura e o meio ambiente, buscando a integração equilibrada da atividade agrícola com a proteção do meio ambiente.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(20, 3, "BAIA", "_", "_", 4, "Porção do oceano, mar ou lago que adentra pelo continente, caracterizando-se por apresentar uma linha de costa com a concavidade voltada para o exterior. Pode ser do tipo aberta ou fechada.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(21, 3, "EFLUENTE", "_", "_", 8, "Resíduo líquido, de origem doméstica ou industrial, com potencialidade de causar poluição.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(22, 3, "ABIOTICO", "_", "_", 8, "Ambiente com condições não biológicas (estruturais, energéticas, químicas e outras) que atuam sobre indivíduos e populações.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(23, 3, "HALOFITAS", "_", "_", 9, "Designação de plantas que toleram grandes concentrações de sal no solo.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(24, 3, "ANAEROBIO", "_", "_", 9, "Ambiente no qual não existe disponível qualquer forma de oxigênio.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(25, 3, "AREA DEGRADADA", "_", "_", 14, "Nome dado a uma porção do meio ambiente que por ação própria da natureza ou por uma ação do homem perdeu sua capacidade natural de geração de benefícios.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(26, 3, "TECTONICA ", "_", "_", 9, "Nome da atividade natural que se dá pelo deslocamento que ocorre na superfície da terra devido ao movimento do material que está subjacente à superfície, ou crosta.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(27, 3, "BACIA HIDROGRAFICA.", "_", "_", 18, "Área limitada por divisores de água, dentro da qual são drenados os recursos hídricos, através de um curso de água, como um rio e seus afluentes.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(28, 3, "BIOGAS", "_", "_", 6, "Gás produzido na fase de gaseificação do processo de degradação anaeróbia de matéria orgânica.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(29, 3, "FOZ", "_", "_", 3, "Extremidade onde o rio descarrega suas águas no mar. ");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(30, 3, "GEISER", "_", "_", 6, "Fonte termal, intermitente, em forma de esguicho, de origem vulcânica, que lança água e vapor a alturas que podem ultrapassar 60m .");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(31, 3, "GRUTA", "_", "_", 5, "Galeria rochosa formada pela ação da água no decorrer de milhões de anos. Às vezes usada como sinônimos de cavernas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(32, 3, "CLIMA", "_", "_", 5, "Estado da atmosfera expresso principalmente por meio de temperaturas, chuvas, isolação, nebulosidade etc.");

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(33, 3, "IBAMA", "_", "_", 5, "Órgão executor da Política de Meio Ambiente em nível nacional. Criado em 1989.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(34, 3, "INTEMPERISMO", "_", "_", 12, "Conjunto de processos atmosféricos e biológicos que causam a desintegração e modificação das rochas e dos solos.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(35, 3, "JARDIM BOTANICO", "_", "_", 15, "Unidade de conservação que visa à preservação e propagação de espécies da flora e também à educação do público visitante dessas áreas.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(36, 3, "JUSANTE", "_", "_", 7, "Área posterior a outra, tomando-se por base a direção da corrente fluvial pela qual é banhada.");

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(37, 3, "LA NINA", "_", "_", 7, "Fenômeno natural responsável pelo resfriamento anômalo das águas superficiais do oceano Pacífico Equatorial, Central e Oriental.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(38, 3, "LATITUDE", "_", "_", 10, "Ângulo medido entre o plano do Equador e a normal a um ponto qualquer sobre a superfície elipsoidal de referência, variando de 0° a 90°, com o sinalpositivo no Hemisfério Norte e negativo no Hemisfério Sul.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(39, 3, "LIQUEN", "_", "_", 6, "Associação permanente entre uma alga e um fungo, comumente encontrada nos troncos das árvores e sobre rochas");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(40, 3, "LITOSFERA", "_", "_", 9, "Parte da biosfera que consiste na camada superior de rochas que interagem com a hidrosfera e a atmosfera.");
        minhalista.Palavras.Add(minhalista.novaPalavra);

        minhalista.novaPalavra = new Palavra();
        minhalista.novaPalavra.setDados(41, 3, "LIXIVIACAO", "_", "_", 10, "Processo físico de lavagem das rochas e solos pelas águas das fortes chuvas (enxurradas) decompondo as rochas e extraindo nutrientes, tornando o solo mais pobre.");
        minhalista.Palavras.Add(minhalista.novaPalavra);


    }

    public void carregaposicoes()
    {
        posicoes = new List<Vector3>();
        Vector3 pos;
        pos = new Vector3(-6.88f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-5.81f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-4.73f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-3.66f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-2.6f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-1.53f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(-0.45f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(0.62f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(1.71f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(2.77f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(3.83f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(4.89f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(5.95f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(7.01f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(8.07f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(9.13f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(10.19f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(11.25f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(12.31f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(13.37f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(14.43f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(15.49f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(16.55f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(17.61f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(18.67f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(19.73f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(20.79f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(21.85f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(22.91f, 2.25f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(23.97f, 2.25f, 0f);
        posicoes.Add(pos);

    }



    public void carregaposicoesErradas()
    {
        posicoesErradas = new List<Vector3>();
        Vector3 pos;
        pos = new Vector3(-6.88f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-5.81f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-4.73f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-3.66f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-2.6f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-1.53f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(-0.45f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(0.62f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(1.71f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(2.77f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(3.83f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(4.89f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(5.95f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(7.01f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(8.07f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(9.13f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(10.19f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(11.25f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(12.31f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(13.37f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(14.43f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(15.49f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(16.55f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(17.61f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(18.67f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(19.73f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(20.79f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(21.85f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(22.91f, 0.5f, 0f);
        posicoesErradas.Add(pos);
        pos = new Vector3(23.97f, 0.5f, 0f);
        posicoesErradas.Add(pos);


    }



    public static Text AddTextToCanvas(string textString, GameObject canvasGameObject)
    {
        Text text = canvasGameObject.AddComponent<Text>();
        text.text = textString;
        text.transform.position = new Vector3(0,0,0);
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;
        text.fontSize = 28;
        text.fontStyle = FontStyle.Bold;
        text.alignment = TextAnchor.UpperCenter;
        return text;
    }

    public void sortPalavra()
    {
        palavraEscolhida = minhalista.Palavras[Random.Range(0, minhalista.Palavras.Count)].getPalavra();
        foreach (Palavra c in minhalista.Palavras)
        {
            if (c.palavra.Equals(palavraEscolhida))
            {
                var text = c.Pergunta.ToString();
                AddTextToCanvas(text, canvasGameObject);
                for (int i = 0; i< palavraEscolhida.Length; i++)
                {
                    Instantiate(objetos[0], posicoesTracos[i], Quaternion.Euler(0, 0, 0));
                }
               
            }
        }


        Debug.Log("palvra impressa do array: " + palavraEscolhida);
        palavraAdivinhada = new string(" "[0], palavraEscolhida.Length);


    }


    public void iniciaGame(){

        if (vidas > 0 && palavraAdivinhada != palavraEscolhida){
            foreach (char c in Input.inputString){
                //esse if verifica se foi digitado a barra de espaço
                if (c != "\b"[0] || c != "\n"[0] || c != "\r"[0]){
                    texto = c.ToString();
                    var teste = texto.ToUpper();
                    checarCAractere(teste[0]);
                }
            }
        }else {
            if (vidas > 0){
                acertou = true;
                panelScroolItens.SetActive(true);
                if (itemAdicionado) {
                    Application.LoadLevel(Application.loadedLevel);
                }
                itemAdicionado = false;
            }
            else{
                panelPerdeu.SetActive(true);
                Debug.Log("VC errou, tente novamente !!!");
                if (quantidadeDeTentativas == 2){
                    quantidadeDeTentativas = 1;
                }else if(quantidadeDeTentativas == 1) {
                    quantidadeDeTentativas = 0;
                }else if (quantidadeDeTentativas == 0) {
                    controleItensLiberados = new bool[quantidadeItens];
                }
            }
        }

    }


    public Texture[] icones;
    Vector2 scrollPosition = Vector2.zero;
    public void carregaposicoesTracos()
    {
        posicoesTracos = new List<Vector3>();
        Vector3 pos;
        pos = new Vector3(-6.88f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-5.81f, 1.5115f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-4.73f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-3.66f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-2.6f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-1.53f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(-0.45f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(0.62f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(1.71f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(2.77f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(3.83f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(4.89f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(5.95f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(7.01f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(8.07f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(9.13f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(10.19f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(11.25f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(12.31f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(13.37f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(14.43f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(15.49f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(16.55f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(17.61f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(18.67f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(19.73f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(20.79f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(21.85f, 1.511f, 0f);
        posicoesTracos.Add(pos);
        pos = new Vector3(22.91f, 1.511f, 0f);
        posicoes.Add(pos);
        pos = new Vector3(23.97f, 1.511f, 0f);
        posicoesTracos.Add(pos);

    }
}