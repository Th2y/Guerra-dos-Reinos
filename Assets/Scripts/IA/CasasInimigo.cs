using UnityEngine;
using UnityEngine.UI;

public class CasasInimigo : MonoBehaviour
{
    [SerializeField]
    private Image bola;

    [SerializeField]
    private Casas casasJogador;
    [SerializeField]
    private Sortear sortear;

    public void Jogar()
    {
        casasJogador.tipoJogador = TipoJogador.Bola;
        bola.gameObject.SetActive(true);
        sortear.PassarVez();
        sortear.sortear[0].interactable = true;
    }
}
