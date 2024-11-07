using System;
using TMPro;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HareketEt();  // Hareket fonksiyonunu çağırıyoruz.
        Zipla();      // Zipla fonksiyonunu çağırıyoruz.
    }

    private void HareketEt()
    {
        // Karakteri yön tuşları ile yatay eksende hareket ettirme
        float yatayHareket = Input.GetAxis("Horizontal") * hiz;
        karakterRb.linearVelocity = new Vector2(yatayHareket, karakterRb.linearVelocity.y); // Yatay hareket sırasında y ekseni hızını koru
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Engel"))
        {
            metin.text = "Oyun Bitti!";  // Engel ile temas ettiğinde "Oyun Bitti!" yazdırıyoruz.
        }
        else if (other.CompareTag("Puan"))
        {
            skor += 1;  // Skoru 1 artırıyoruz.
            metin.text = "Skor: " + skor;  // Güncellenen skoru metin objesine yazdırıyoruz.
        }
    }

    void Zipla()
    {
        // Space tuşuna basıldığında yukarı yönde kuvvet uygulayarak karakterin zıplamasını sağlıyoruz.
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(karakterRb.linearVelocity.y) < 0.01f) // Y ekseninde hareket yoksa zıplama yap
        {
            karakterRb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse);
        }
    }
}
