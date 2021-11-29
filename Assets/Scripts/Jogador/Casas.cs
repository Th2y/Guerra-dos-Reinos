using UnityEngine;
using UnityEngine.UI;

public class Casas : MonoBehaviour
{
    public int numCasa = 0;

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

    private void Start()
    {
        this.tipoJogador = TipoJogador.Nenhum;
    }

    public void Clicou()
    {
        if (!habilidades.usandoHabilidade || (habilidades.tipoHabilidade != "bloquear" && this.tipoJogador == TipoJogador.Nenhum))
        {
            if (sortear.tabuleiro.jogadorDeX)
            {
                xisImage.gameObject.SetActive(true);
                this.tipoJogador = TipoJogador.Xis;
            }
            else
            {
                bolaImage.gameObject.SetActive(true);
                this.tipoJogador = TipoJogador.Bola;
            }
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SortearNum();
        }
        else UsarHabilidade();
    }
    public void UsarHabilidade()
    {
        if (habilidades.tipoHabilidade == "bloquear")
        {
            this.tipoJogador = TipoJogador.BloqueadoPeloJog;
        }
        else if (habilidades.tipoHabilidade == "mudar")
        {
            if (sortear.tabuleiro.jogadorDeX)
            {
                bolaImage.gameObject.SetActive(false);
                xisImage.gameObject.SetActive(true);
                this.tipoJogador = TipoJogador.Xis;
            }
            else
            {
                bolaImage.gameObject.SetActive(true);
                xisImage.gameObject.SetActive(false);
                this.tipoJogador = TipoJogador.Bola;
            }
            sortear.PassarVez();
            interagir.Bloquear(false);
            sortear.SortearNum();
        }
        else if (habilidades.tipoHabilidade == "retirar")
        {
            if (sortear.tabuleiro.jogadorDeX)
                bolaImage.gameObject.SetActive(false);
            else
                xisImage.gameObject.SetActive(false);

            this.tipoJogador = TipoJogador.BloqueadoPelaIA;
            sortear.DiminuirJogadas();
        }
        habilidades.usandoHabilidade = false;
        for(int i = 0; i < sortear.habJogador.Length; i++)
        {
            sortear.habJogador[i].interactable = false;
            sortear.habJogador[i].gameObject.SetActive(false);
        }
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
