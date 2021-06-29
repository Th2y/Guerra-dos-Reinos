using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CarregarFases : MonoBehaviour
{
    [SerializeField]
    private GameObject comprarVidas;

    [SerializeField]
    private Button[] faseAtual;
    private int numFaseAtual = 0;
    private string nomeDaFase;

    [SerializeField]
    private TextMeshProUGUI progressoText;
    private int progresso = 0;

    private void Start()
    {
        nomeDaFase = SceneManager.GetActiveScene().name;
        if(nomeDaFase == "Fases")
            Fase();
    }

    //Faz com que o jogo detecte a última fase que o jogador ganhou e deixe o botão da próxima maior
    private void Fase()
    {
        if (PlayerPrefs.HasKey("ProxFase"))
            numFaseAtual = PlayerPrefs.GetInt("ProxFase");
        else
            PlayerPrefs.SetInt("ProxFase", numFaseAtual);

        faseAtual[numFaseAtual].transform.localScale = new Vector3(1.2f, 1.2f, 1);
        for(int i = 0; i <= numFaseAtual; i++)
        {
            faseAtual[i].interactable = true;
        }            
    }

    public void EscolherFaseBonus5x5(int fase)
    {
        Time.timeScale = 1f;
        StartCoroutine(CenaDeCarregamento("FaseBonus5x5-" + fase));
    }

    public void EscolherFaseBonus8x8(int fase)
    {
        Time.timeScale = 1f;
        StartCoroutine(CenaDeCarregamento("FaseBonus8x8-" + fase));
    }

    public void EscolherFase(int fase)
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("Vidas") > 0)
            StartCoroutine(CenaDeCarregamento("Fase" + fase));
        else
            comprarVidas.SetActive(true);
    }

    public void VoltarASelecao()
    {
        Time.timeScale = 1f;
        StartCoroutine(CenaDeCarregamento("Fases"));
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        StartCoroutine(CenaDeCarregamento(nomeDaFase));
    }

    IEnumerator CenaDeCarregamento(string cena)
    {
        progressoText.gameObject.SetActive(true);

        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        carregamento.allowSceneActivation = false;
        while (progresso < 89)
        {
            progresso = (int)(carregamento.progress * 100.0f);
            progressoText.text = "Carregando... " + progresso + "%";
            yield return null;
        }
        progresso = 100;
        progressoText.text = "Carregando... " + progresso + "%";
        yield return new WaitForSeconds(2);
        progressoText.gameObject.SetActive(false);
        carregamento.allowSceneActivation = true;
    }
}
