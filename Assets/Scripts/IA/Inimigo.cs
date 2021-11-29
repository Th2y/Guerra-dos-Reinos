using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int casaJogar;
    [SerializeField]
    private int maxTentativas = 7;
    [SerializeField]
    private int numMaxTentativas = 7;
    public bool iniciarJogada = false;

    [SerializeField]
    private AssociacaoCasas associacaoCasas;
    [SerializeField]
    private Tabuleiro tabuleiro;

    public void Jogar()
    {
        if (tabuleiro.jogadas != tabuleiro.maxJogadas && !tabuleiro.jaTerminou)
        {
            if (tabuleiro.jogadorDeX)
            {
                //Verificar se existe alguma possibilidade de vencer
                if (Verificar(TipoJogador.Bola))
                {
                    associacaoCasas.casasInimigo[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Verificar se existe alguma possibilidade de perder
                else if (Verificar(TipoJogador.Xis))
                {
                    associacaoCasas.casasInimigo[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Fazer uma jogada aleatória em qualquer casa vazia
                else
                    JogadaAleatoria();
            }
            else
            {
                //Verificar se existe alguma possibilidade de vencer
                if (Verificar(TipoJogador.Xis))
                {
                    associacaoCasas.casasInimigo[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Verificar se existe alguma possibilidade de perder
                else if (Verificar(TipoJogador.Bola))
                {
                    associacaoCasas.casasInimigo[casaJogar].Jogar();
                    iniciarJogada = false;
                }

                //Fazer uma jogada aleatória em qualquer casa vazia
                else
                    JogadaAleatoria();
            }
        }
        else
            Debug.Log("O jogo já acabou!");
    }

    private void JogadaAleatoria()
    {
        casaJogar = Random.Range(0, 8);

        if (associacaoCasas.casasJogador[casaJogar].tipoJogador == TipoJogador.Nenhum)
        {
            maxTentativas = numMaxTentativas;
            associacaoCasas.casasInimigo[casaJogar].Jogar();
            iniciarJogada = false;            
        }
        else if (maxTentativas > 0)
        {
            maxTentativas--;
            JogadaAleatoria();            
        }
            
        else
            Debug.Log("Inimigo sem opções!");
    }

    private bool Verificar(TipoJogador tipo)
    {
        for (int i = 0; i < 8; i++)
        {
            if (tabuleiro.combinacoes[i].casas[0].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[1].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[2].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[0].numCasa;
                    return true;
                }
            }
            else if (tabuleiro.combinacoes[i].casas[1].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[0].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[2].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[1].numCasa;
                    return true;
                }
            }
            else if (tabuleiro.combinacoes[i].casas[2].tipoJogador == TipoJogador.Nenhum)
            {
                if (tabuleiro.combinacoes[i].casas[0].tipoJogador == tipo && tabuleiro.combinacoes[i].casas[1].tipoJogador == tipo)
                {
                    casaJogar = tabuleiro.combinacoes[i].casas[2].numCasa;
                    return true;
                }
            }
        }

        return false;
    }

    public void Jogada()
    {
        iniciarJogada = true;
    }
}