using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Algorithm : MonoBehaviour
{
    public InputField inputField;
    private string[] veriDizisi;
    private List<string> grup1 = new List<string>();
    private List<string> grup2 = new List<string>();
    public GameObject panel;
    public Text text;
    public Text Zar_text;
    public GameObject PlaceHolder;

    public void VerileriAyir()
    {
        string girilenVeri = inputField.text;
        grup1.Clear();
        grup2.Clear();

        // Verileri virgülle ayýrarak diziye atama yap
        veriDizisi = girilenVeri.Split(',');

        // Verileri random olarak iki gruba ayýrma
        for (int i = 0; i < veriDizisi.Length; i++)
        {
            // Rastgele bir gruba ekle, ancak grup boyutlarý arasýndaki farký göz önünde bulundur
            if (grup1.Count < grup2.Count)
            {
                grup1.Add(veriDizisi[i]);
            }
            else if (grup2.Count < grup1.Count)
            {
                grup2.Add(veriDizisi[i]);
            }
            else
            {
                // Eðer grup boyutlarý eþitse, rastgele bir gruba ekle
                int rastgeleGrup = UnityEngine.Random.Range(0, 2);
                if (rastgeleGrup == 0)
                {
                    grup1.Add(veriDizisi[i]);
                }
                else
                {
                    grup2.Add(veriDizisi[i]);
                }
            }
        }

        // Sonuçlarý ekrana yazdýrma
        PrintScreen();
    }
    public void ZarAt()
    {
        int zar1 = UnityEngine.Random.Range(1, 7);
        int zar2 = UnityEngine.Random.Range(1, 7);
        Debug.Log(zar1 + " , " + zar2);
        PrintScreenZar(zar1, zar2);
    }

    void PrintScreenZar(int zar1, int zar2)
    {
        PlaceHolder.SetActive(false);
        Zar_text.text = zar1 + " , " + zar2;
    }

    void PrintScreen()
    {
        panel.SetActive(true);

        text.text = "Birinci grup \n";
        for (int i = 0; i < grup1.Count; i++)
        {
            text.text += grup1[i] + " ";
        }

        text.text += "\nIkinci grup \n";
        for (int i = 0; i < grup2.Count; i++)
        {
            text.text += grup2[i] + " ";
        }
    }

    public void OnclickButton()
    {
        panel.SetActive(false);
        grup1.Clear();
        grup2.Clear();
        text.text = "";
    }

    public void Exit()
    {
        Application.Quit();
    }
}
