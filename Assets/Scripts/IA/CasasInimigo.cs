using UnityEngine;
using UnityEngine.UI;

public class CasasInimigo : MonoBehaviour
{
    [SerializeField]
    private Image bola;
    [SerializeField]
    private Image xis;

    [SerializeField]
    private Casas casasJogador;
    [SerializeField]
    private Sortear sortear;

    public void Jogar()
    {
        if (sortear.tabuleiro.jogadorDeX)
        {
            casasJogador.tipoJogador = TipoJogador.Bola;
            bola.gameObject.SetActive(true);
        }
        else
        {
            casasJogador.tipoJogador = TipoJogador.Xis;
            xis.gameObject.SetActive(true);
        }
        sortear.PassarVez();
        sortear.sortear[0].interactable = true;
        sortear.sortear[0].gameObject.SetActive(true);
    }
}
