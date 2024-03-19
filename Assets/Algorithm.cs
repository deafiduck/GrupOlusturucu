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
    Button a;
    int random;
    public GameObject panel;
   public Text text;
   
    
    
    public void VerileriAyir(string girilenVeri)
    {
        girilenVeri = inputField.text;
        grup1.Clear();
        grup2.Clear();
        // Verileri virgülle ayýrarak diziye atama yap
        veriDizisi = girilenVeri.Split(',');

        Random();
        PrintScreen();
        // Gruplarý ekrana yazdýrma (opsiyonel)
        Debug.Log("Grup 1: " + string.Join(", ", grup1.ToArray()));
        Debug.Log("Grup 2: " + string.Join(", ", grup2.ToArray()));
    }
 
    void Random()
    {
         random = veriDizisi.Length ;
        float random1;
         random1 = float.Parse(random.ToString());
        for (int i=0; i < random; i++)
        {
            int karar = UnityEngine.Random.Range(1,3);
            if (karar == 1& grup1.Count < random1 / 2)
            {
                grup1.Add(veriDizisi[i]);
            }
            else if( grup2.Count<random1/2)
            {
                grup2.Add(veriDizisi[i]);
            }
        }

       
        
       
    }
    void PrintScreen()
    {
        panel.SetActive(true);

        
        text.text = "Birinci grup \n";

        
        for (int i = 0; i < grup1.Count; i++)
        {
            text.text += grup1[i] + " ";
        }

       
        text.text += "\nikinci grup \n";

       
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
