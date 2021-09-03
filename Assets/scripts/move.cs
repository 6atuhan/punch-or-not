using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class move : MonoBehaviour
{

    Animator animator;
    float sagsol;
    public float hiz=10;
    public int puan = 0;
    public GameObject canvas;
    public Text skor;
    public int hedef=5;
    public GameObject Partikle;

    rasgeleZorluk rasgelezorluk;
    zorlukHareket zorlukhareket;
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rasgelezorluk = GameObject.Find("Zorluklar").GetComponent<rasgeleZorluk>();
        zorlukhareket = GameObject.FindGameObjectWithTag("zorluðumuz").GetComponent<zorlukHareket>();
    }
    public int hiztemp=10;
    public void hizarttir()
    {
        hiztemp += 2;
    }

    public bool oyunbasladý = false;
    public bool spawnbasladý = false;
    public bool çarptý = false;
    void Update()
    {
        skor.text = "KIRILAN CAM : " + puan.ToString();
        sagsol = Input.GetAxis("Horizontal");
        oyunubaslat();
        sagsolhareket();
        if (oyunbasladý == true)
        {
             animator.SetTrigger("koþ");
        }
        if(hiztemp>=50)
        {
            hiztemp = 50;
        }
    }
    public Text oyunsonu;
    public GameObject oyunsonupanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cam")
        {
            animator.SetTrigger("omuzat");
            hizarttir();
        }
        
        if (other.gameObject.name == "duvar")
        {
            animator.SetTrigger("düþtü");
            rasgelezorluk.CancelInvoke();
            çarptý = true;
            animator.SetTrigger("danset");
            transform.position = new Vector3(0, 0, -5.55f);
            Partikle.SetActive(true);
            oyunsonu.text = "KIRILAN CAM  " + puan.ToString();
            oyunsonupanel.SetActive(true);
        }
    }
    public void Tekrar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Window")
        {
            puan++;
        }
    }

    private void sagsolhareket()
    {
        float xhareket= sagsol* hiz;
        transform.position += new Vector3(xhareket, 0,0)*Time.deltaTime;


        if (transform.position.x > 2)
        { transform.position = new Vector3(2, -0.03519893f, -5.77f); }
        if (transform.position.x < -2)
        { transform.position = new Vector3(-2, -0.03519893f, -5.77f); }
        
        if (sagsol>0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 0), 0.06f);
        }
        if (sagsol < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -45, 0), 0.06f);
        }
        if (sagsol == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.06f);
        }
    }

    void oyunubaslat()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive( false);
            animator.SetTrigger("koþ");
            oyunbasladý = true;
            spawnbasladý = true;

        }
    }
}
