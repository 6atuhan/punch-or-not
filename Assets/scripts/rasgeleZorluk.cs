using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rasgeleZorluk : MonoBehaviour
{
    move _move;
    [Header("Zorluklar")]
    public GameObject[] zorluklar;
    public GameObject spawnYeri;
    public int zorluksayisi=1;
    int spawnsayisi=0;
    void Start()
    {

        _move = GameObject.Find("Karakter").GetComponent<move>();
        
    }
    float �retmezamani=0.88f;
    private void uretmeyibaslat()
    {
        
        if (_move.spawnbaslad� == true)
        {
            InvokeRepeating("zorlukOlustur", 0, �retmezamani);
            _move.spawnbaslad� = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        uretmeyibaslat();
    }
    GameObject zorluk;
    public void zorlukOlustur()
    {
        int index = Random.Range(0, 7);
        zorluk = Instantiate(zorluklar[index], spawnYeri.transform.position, spawnYeri.transform.rotation);
        spawnsayisi++;

        
        
    }
}
