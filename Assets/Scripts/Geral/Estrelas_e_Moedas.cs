using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Estrelas_e_Moedas : MonoBehaviour
{
    //Variaveis
    [Header("Variaveis")]
    private int numMoedas;
    private string nomeDaCena;
    private string[] nomeDaCenaSplit;
    private int numFaseAtual;
    public EnumDificuldade dificuldade = EnumDificuldade.facil;

    //Moedas
    [Header ("Moedas")]
    [SerializeField]
    private TextMeshProUGUI textMoedas;

    //Fases normais
    [Header("Fases")]
    [SerializeField]
    private NumEstrelasMenu[] fasesNormais;
    [SerializeField]
    private NumEstrelasMenu[] fases5x5;
    [SerializeField]
    private NumEstrelasMenu[] fases8x8;

    //Estrelas em cada fase
    [Header("Estrelas em cada fase")]
    [SerializeField]
    private GameObject[] estrelasFase;    

    private void Start()
    {
        nomeDaCena = SceneManager.GetActiveScene().name;

        if (nomeDaCena == "Fases")
            ChamarNumMenu();
        else
        {
            nomeDaCenaSplit = nomeDaCena.Split('e');
            numFaseAtual = int.Parse(nomeDaCenaSplit[1]);
        }
    }

    private void ChamarNumMenu()
    {
        NumEstrelas();
        NumEstrelas5x5();
        NumEstrelas8x8();

        NumMoedas();
    }

    private void NumEstrelas()
    {
        for (int i = 0; i < fasesNormais.Length; i++)
        {
            int j = i + 1;
            if (PlayerPrefs.HasKey("EstrelasFase" + j))
            {
                int num = PlayerPrefs.GetInt("EstrelasFase" + j);
                if(num == 1 || num == 2 || num == 3)
                    fasesNormais[i].ExibirEstrelas(num);
                else if (PlayerPrefs.GetInt("EstrelasFase" + j) > 3)
                    PlayerPrefs.SetInt("EstrelasFase" + j, 3);
                else
                    PlayerPrefs.SetInt("EstrelasFase" + j, 0);
            }
            else
                PlayerPrefs.SetInt("EstrelasFase" + j, 0);
        }
    }

    //Corrigir depois
    private void NumEstrelas5x5()
    {
        for (int i = 0; i < fases5x5.Length; i++)
        {
            if (PlayerPrefs.HasKey("Estrelas5x5Fase" + i))
            {
                if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 1)
                    fases5x5[i].ExibirEstrelas(0);
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 2)
                    fases5x5[i].ExibirEstrelas(1);
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) == 3)
                    fases5x5[i].ExibirEstrelas(2);
                else if (PlayerPrefs.GetInt("Estrelas5x5Fase" + i) > 3)
                    PlayerPrefs.SetInt("Estrelas5x5Fase" + i, 3);
            }
            else
                PlayerPrefs.SetInt("Estrelas5x5Fase" + i, 0);
        }
    }

    //Corrigir depois
    private void NumEstrelas8x8()
    {
        for (int i = 0; i < fases8x8.Length; i++)
        {
            if (PlayerPrefs.HasKey("Estrelas8x8Fase" + i))
            {
                if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 1)
                    fases8x8[i].ExibirEstrelas(0);
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 2)
                    fases8x8[i].ExibirEstrelas(1);
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) == 3)
                    fases8x8[i].ExibirEstrelas(2);
                else if (PlayerPrefs.GetInt("Estrelas8x8Fase" + i) > 3)
                    PlayerPrefs.SetInt("Estrelas8x8Fase" + i, 3);
            }
            else
                PlayerPrefs.SetInt("Estrelas8x8Fase" + i, 0);
        }
    }

    private void NumMoedas()
    {
        if (PlayerPrefs.HasKey("Moedas"))
        {
            numMoedas = PlayerPrefs.GetInt("Moedas");
            if (numMoedas < 0)
            {
                numMoedas = 0;
                PlayerPrefs.SetInt("Moedas", numMoedas);
            }
            else if (numMoedas > 1000)
            {
                numMoedas = 1000;
                PlayerPrefs.SetInt("Moedas", numMoedas);
            }

            textMoedas.text = numMoedas.ToString();
        }
        else
        {
            numMoedas = 0;
            PlayerPrefs.SetInt("Moedas", numMoedas);
            textMoedas.text = numMoedas.ToString();
        }
    }

    public void DefinirEstrelasEMoedas(int num, bool venceu)
    {
        DefinirEstrelas(num);
        DefinirMoedas(num);
        DefinirProxFase(venceu);
    }

    private void DefinirProxFase(bool venceu)
    {
        int proxFase = PlayerPrefs.GetInt("ProxFase");
        if (venceu && numFaseAtual > proxFase)
            PlayerPrefs.SetInt("ProxFase", numFaseAtual);
    }

    private void DefinirEstrelas(int num)
    {
        for (int i = 0; i < num; i++)
        {
            estrelasFase[i].gameObject.SetActive(true);
        }        
    }

    private void DefinirMoedas(int num)
    {
        numMoedas = PlayerPrefs.GetInt("Moedas");
        if (num == 3)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(11, 15);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(13, 18);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(15, 20);
            else
                numMoedas += Random.Range(17, 22);
        }
        else if (num == 2)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(6, 10);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(7, 12);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(8, 14);
            else
                numMoedas += Random.Range(9, 16);
        }
        else if (num == 1)
        {
            if (dificuldade == EnumDificuldade.facil)
                numMoedas += Random.Range(2, 5);
            else if (dificuldade == EnumDificuldade.media)
                numMoedas += Random.Range(3, 6);
            else if (dificuldade == EnumDificuldade.dificil)
                numMoedas += Random.Range(4, 7);
            else
                numMoedas += Random.Range(5, 8);
        }

        textMoedas.text = numMoedas.ToString();
        PlayerPrefs.SetInt("Moedas", numMoedas);
    }

    public void MoedaAoPerder()
    {
        numMoedas = PlayerPrefs.GetInt("Moedas");
        PlayerPrefs.SetInt("Moedas", numMoedas++);
    }
}
