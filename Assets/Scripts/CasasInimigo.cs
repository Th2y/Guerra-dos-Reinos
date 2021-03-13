using UnityEngine;
using UnityEngine.UI;

public class CasasInimigo : MonoBehaviour
{
    [SerializeField]
    private Image bola;

    public static CasasInimigo instancia;

    void Start()
    {
        instancia = this;
    }

    public void Jogar()
    {
        if (Casas.instancia.tipoJogador == TipoJogador.Nenhum)
        {
            bola.gameObject.SetActive(true);
            Sortear.instancia.PassarVez();
            Sortear.instancia.sortear[0].interactable = true;
        }
        else
            Inimigo.instancia.Jogada();
    }
}
