using UnityEngine;

[System.Serializable]
public class Combinacoes
{
    /// <summary>
    /// Lista de c�lulas que formam uma combina��o
    /// </summary>
    [SerializeField]
    private Casas[] casas;

    public bool EstaCompleta()
    {
        TipoJogador tipoJogador = this.casas[0].TipoJogador;
        if (tipoJogador != TipoJogador.Nenhum)
        {
            foreach (Casas casas in this.casas)
            {
                // Alguma c�lula possui um "marcador" diferente
                if (casas.TipoJogador != tipoJogador)
                {
                    return false;
                }
            }
            // Todos os marcadores s�o iguais (X ou O)
            return true;
        }
        // Uma ou mais c�lulas n�o est�o marcadas
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    public TipoJogador ObterTipoJogadorVencedor()
    {
        // Se a combina��o est� completa
        if (EstaCompleta())
        {
            // Retorna o tipo do jogador vencedor
            TipoJogador tipoJogador = this.casas[0].TipoJogador;
            return tipoJogador;
        }

        // Retorna o valor padr�o, informando que ningu�m venceu
        return TipoJogador.Nenhum;
    }
}