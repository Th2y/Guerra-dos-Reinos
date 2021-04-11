using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Carregamento : MonoBehaviour
{
    public static string cenaACarregar;
    public Image barraDeCarregamento;
    //public Text TextoProgresso;
    public Text[] carregandoText;
    private int progresso = 0;

    void Start()
    {
        StartCoroutine(CenaDeCarregamento(cenaACarregar));

        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.type = Image.Type.Filled;
            barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
            barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
    }

    IEnumerator CenaDeCarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        carregamento.allowSceneActivation = false;
        while (progresso < 89)
        {
            progresso = (int)(carregamento.progress * 100.0f);
            yield return null;
        }
        progresso = 100;
        yield return new WaitForSeconds(2);
        carregamento.allowSceneActivation = true;
    }

    void Update()
    {
        //if (TextoProgresso != null)
        //TextoProgresso.text = progresso + "%";

        if (barraDeCarregamento != null)
            barraDeCarregamento.fillAmount = (progresso / 100.0f);
    }
}
