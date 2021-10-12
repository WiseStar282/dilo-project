using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideWall : MonoBehaviour
{
    //pemain akan mendapat skor jika objek lain bercollider (bola)
    // menyentuh dinding ini
    public PlayerControl player;
    // Skrip GameManager untuk mengakses skor maksimal
    [SerializeField]
    private GameManager gameManager; 
    //akan dipanggil ketika bola menyentuh dinding
    void OnTriggerEnter2D (Collider2D anotherCollider)
    {
         // Jika objek tersebut bernama "ball":
        if (anotherCollider.name == "ball")
        {
            // Tambahkan skor ke pemain
            player.IncrementScore();
 
            // Jika skor pemain belum mencapai skor maksimal...
            if (player.Score < gameManager.maxScore)
            {
                // ...restart game setelah bola mengenai dinding.
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
