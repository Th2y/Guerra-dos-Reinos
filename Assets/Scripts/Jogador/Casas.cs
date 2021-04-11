using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    [SerializeField]
    private Image xisImage;
    [SerializeField]
    private Image bolaImage;

    [SerializeField]
    private Interagir interagir;
    [SerializeField]
    private Sortear sortear;
    [SerializeField]
    private Habilidades habilidades;

    public TipoJogador tipoJogador;
    public static TipoJogador tipos;

    private void Awake()
    {
        this.tipoJogador = TipoJogador.Nenhum;
        tipos = tipoJogador;
    }

    public void Clicou()
    {
        if (!habilidades.usandoHabilidade || this.tipoJogador == TipoJogador.Nenhum)
        {
            xisImage.gameObject.SetActive(true);
            this.tipoJogador = TipoJogador.Xis;
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SorteioIA();
        }
        else UsarHabilidade();
    }
    public void UsarHabilidade()
    {
        if (habilidades.tipoHabilidade == "bloquear")
        {
            Debug.Log("Bloqueando...");
        }
        else if (habilidades.tipoHabilidade == "mudar")
        {
            Debug.Log("Mudando...");
            bolaImage.gameObject.SetActive(false);
            xisImage.gameObject.SetActive(true);
            this.tipoJogador = TipoJogador.Xis;
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SorteioIA();
        }
        else if (habilidades.tipoHabilidade == "retirar")
        {
            //Falta proibir que o jogador possa jogar na casa que ele acabou de retirar a peça
            Debug.Log("Retirando...");
            bolaImage.gameObject.SetActive(false);
            this.tipoJogador = TipoJogador.Nenhum;
        }
        habilidades.usandoHabilidade = false;
    }

    public TipoJogador TipoJogador
    {
        get
        {
            return this.tipoJogador;
        }
        set
        {
            this.tipoJogador = value;
        }
    }
}
