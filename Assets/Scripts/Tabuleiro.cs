using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tabuleiro : MonoBehaviour
{
    // Lista de combinações possíveis para ganhar o jogo
    [SerializeField]
    private Combinacoes[] combinacoes;

    [SerializeField]
    private GameObject painelVencedor;
    [SerializeField]
    private TextMeshProUGUI vencedor;

    public int jogadas = 0;

    public void Update()
    {
        TipoJogador jogadorVencedor = ObterVencedor();
        if (jogadorVencedor != TipoJogador.Nenhum)
        {
            painelVencedor.SetActive(true);

            if(jogadorVencedor == TipoJogador.Bola)
                vencedor.text = "O reino das " + jogadorVencedor.ToString() + " venceu a partida!";
            else if(jogadorVencedor == TipoJogador.Xis)
                vencedor.text = "O reino dos " + jogadorVencedor.ToString() + " venceu a partida!";
            else if(jogadas == 9)
                vencedor.text = "O reino das Bolas e dos Xis chegaram a um acordo e empataram a partida!";

            Time.timeScale = 0f;
        }
    }

    public TipoJogador ObterVencedor()
    {
        foreach (Combinacoes combinacao in this.combinacoes)
        {
            if (combinacao.EstaCompleta())
            {
                return combinacao.ObterTipoJogadorVencedor();
            }
        }
        return TipoJogador.Nenhum;
    }
}

/*
        void ChecarVencedor()
        {
            // Horizontais:

            string Vazio = turno ? "X" : "O";

            for (int i = 0; i <= 6; i += 3)
            {
                if (textos[i] == Vazio && textos[i] == textos[i + 1] && textos[i] == textos[i + 2])
                    Vencedor();
            }

            // Verticais:

            for (int i = 0; i <= 2; i++)
            {
                if (textos[i] == Vazio && textos[i] == textos[i + 3] && textos[i] == textos[i + 6])
                    Vencedor();
            }

            // Diagonais:

            if (textos[0] == Vazio && textos[0] == textos[4] && textos[0] == textos[8]) { Vencedor(); }; // Diagonal principal
            if (textos[2] == Vazio && textos[2] == textos[4] && textos[2] == textos[6]) { Vencedor(); }; // Diagonal secundária

            // Empate:

            if (rodadas == 9 && !fimDeJogo)
            {
                fimDeJogo = true;
                MessageBox.Show("Empate!");
            }

        }

        void Vencedor()
        {
            fimDeJogo = true;
            MessageBox.Show(String.Format("Jogador {0} venceu!", turno ? "X" : "O"));
        } 
*/
