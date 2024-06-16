using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
public class ExtremeKartlar : MonoBehaviour
{
    public GameObject[] kartUIListesi; // Her kart türü için UI öðelerini tutan dizi
    public Button kartButton;

    private List<string> kartTurleri = new List<string> { "Tür1", "Tür2", "Tür3", "Tür4", "Tür5", "Tür6",  };
    private List<int> kartSayilari = new List<int> { 2, 2, 2, 2, 2, 18 };

    private List<GameObject> karisikKartlar = new List<GameObject>(); // Karýþýk kart listesi
    private int siradakiKartIndex = 0;

    public TextMeshProUGUI Counter;

    void Start()
    {
        KarisikKartlariOlustur(); // Karýþýk kart listesini oluþtur
        KartlariKaristir(); // Kartlarý karýþtýr

        // Baþlangýçta tüm kart UI'larýný devre dýþý býrak
        foreach (GameObject ui in kartUIListesi)
        {
            ui.SetActive(false);
        }
    }

    void KarisikKartlariOlustur()
    {
        // Her kart türü için UI öðelerini karýþýk sýrayla listeye ekle
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
        // Kartlarý karýþtýr (Fisher-Yates shuffle algoritmasý)
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
            // Kartý ilgili UI'da göster
            karisikKartlar[siradakiKartIndex].SetActive(true);

           
           

            // Eger son kartsa, butonu devre disi birak
            if (siradakiKartIndex >= karisikKartlar.Count)
            {
                kartButton.interactable = false; // Butonu devre disi birak
            }
        }
    }
}
