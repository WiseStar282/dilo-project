using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //tombol bergerak keatas
    public KeyCode upButton = KeyCode.W;
    //tombol bergerak kebawah
    public KeyCode downButton = KeyCode.S;
    //kecepatan gerak
    public float speed = 10.0f;
    //batas atas bawah game
    public float yBoundary = 9.0f;
    //rigidbody raket
    private Rigidbody2D rigidBody2D;
    //skor
    private int score;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //===============KONTROL RAKET======================================================
        //dapatkan kecepatan raket sekarang
        Vector2 velocity = rigidBody2D.velocity;
        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (ke atas)
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke bawah)
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        // Jika pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else velocity.y = 0.0f;
        // Masukkan kembali kecepatannya ke rigidBody2D.
        rigidBody2D.velocity = velocity;

        //=================BATAS RAKET====================================================
        //dapatkan posisi raket sekarang
        Vector3 position = transform.position;
        //Jika raket melebihi batas atas (yBoundary), kembalikan ke batas atas
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        //Jika raket melebihi batas bawah(-yBoundary), kembalikan ke batas bawah
        if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        //masukkan kembali posisi raket
        transform.position = position;
    }
        //=======================SKOR=================
        // Menaikkan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }
        // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }
    // Mendapatkan nilai skor
    public int Score
    {
        get 
        {
            return score; 
        }
    }

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;
     
    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
    //ketika terjadi tumbukan dengan bola, rekam titik kontaknya
    void OncollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.name.Equals("ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
