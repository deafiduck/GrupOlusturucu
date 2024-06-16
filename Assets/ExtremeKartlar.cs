using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class ExtremeKartlar : MonoBehaviour
{
    public GameObject[] kartUIListesi; // Her kart t�r� i�in UI ��elerini tutan dizi
    public Button kartButton;

    private List<string> kartTurleri = new List<string> { "T�r1", "T�r2", "T�r3", "T�r4", "T�r5", "T�r6",  };
    private List<int> kartSayilari = new List<int> { 2, 2, 2, 2, 2, 18 };

    private List<GameObject> karisikKartlar = new List<GameObject>(); // Kar���k kart listesi
    private int siradakiKartIndex = 0;

    public TextMeshProUGUI Counter;

    void Start()
    {
        KarisikKartlariOlustur(); // Kar���k kart listesini olu�tur
        KartlariKaristir(); // Kartlar� kar��t�r

        // Ba�lang��ta t�m kart UI'lar�n� devre d��� b�rak
        foreach (GameObject ui in kartUIListesi)
        {
            ui.SetActive(false);
        }
    }

    void KarisikKartlariOlustur()
    {
        // Her kart t�r� i�in UI ��elerini kar���k s�rayla listeye ekle
        for (int i = 0; i < kartTurleri.Count; i++)
        {
            for (int j = 0; j < kartSayilari[i]; j++)
            {
                karisikKartlar.Add(kartUIListesi[i]);
            }
        }
    }

    void KartlariKaristir()
    {
        // Kartlar� kar��t�r (Fisher-Yates shuffle algoritmas�)
        for (int i = 0; i < karisikKartlar.Count; i++)
        {
            GameObject temp = karisikKartlar[i];
            int randomIndex = Random.Range(i, karisikKartlar.Count);
            karisikKartlar[i] = karisikKartlar[randomIndex];
            karisikKartlar[randomIndex] = temp;
        }
    }

    
    public void KartiGoster()
    {
        Counter.text = (26-(siradakiKartIndex)).ToString();
        karisikKartlar[siradakiKartIndex].SetActive(false);
        siradakiKartIndex++; // Siradaki kart index'ini arttir
        if (siradakiKartIndex < karisikKartlar.Count)
        {
            // Kart� ilgili UI'da g�ster
            karisikKartlar[siradakiKartIndex].SetActive(true);

           
           

            // Eger son kartsa, butonu devre disi birak
            if (siradakiKartIndex >= karisikKartlar.Count)
            {
                kartButton.interactable = false; // Butonu devre disi birak
            }
        }
    }
}
