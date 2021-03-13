using UnityEngine;
using UnityEngine.UI;

public class CasasInimigo : MonoBehaviour
{
    [SerializeField]
    private Image bola;

    [SerializeField]
    private Casas casasJogador;

    public static CasasInimigo instancia;

    void Start()
    {
        instancia = this;
    }

    public void Jogar()
    {
        casasJogador.tipoJogador = TipoJogador.Bola;
        bola.gameObject.SetActive(true);
        Sortear.instancia.PassarVez();
        Sortear.instancia.sortear[0].interactable = true;
    }
}
