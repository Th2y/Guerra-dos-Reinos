using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    /// <summary>
    /// Lista de combina��es poss�veis para ganhar o jogo
    /// </summary>
    [SerializeField]
    private Combinacoes[] combinacoes;

    public void Update()
    {
        TipoJogador jogadorVencedor = ObterVencedor();
        if (jogadorVencedor != TipoJogador.Nenhum)
        {
            Debug.Log(jogadorVencedor + " venceu a partida.");
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
