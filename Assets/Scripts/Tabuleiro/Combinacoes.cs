using UnityEngine;

[System.Serializable]
public class Combinacoes
{
    // Lista de casas que formam uma combinação
    public Casas[] casas;

    public bool EstaCompleta()
    {
        TipoJogador tipoJogador = this.casas[0].TipoJogador;
        if (tipoJogador != TipoJogador.Nenhum && tipoJogador != TipoJogador.BloqueadoPeloJog && tipoJogador != TipoJogador.BloqueadoPelaIA)
        {
            foreach (Casas casas in this.casas)
            {
                // Alguma casa possui um "marcador" diferente
                if (casas.TipoJogador != tipoJogador)
                {
                    return false;
                }
            }
            // Todos os marcadores são iguais (X ou O)
            return true;
        }
        // Uma ou mais casas não estão marcadas
        return false;
    }

    public TipoJogador ObterTipoJogadorVencedor()
    {
        // Se a combinação está completa
        if (EstaCompleta())
        {
            // Retorna o tipo do jogador vencedor
            TipoJogador tipoJogador = this.casas[0].TipoJogador;
            return tipoJogador;
        }

        // Retorna o valor padrão, informando que ninguém venceu
        return TipoJogador.Nenhum;
    }
}