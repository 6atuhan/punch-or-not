using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zorlukHareket : MonoBehaviour
{

    move _move;
    int hizimiz;
    void Start()
    {
        _move = GameObject.Find("Karakter").GetComponent<move>();
        hizimiz = _move.hiztemp;
    }

    // Update is called once per frame

    void Update()
    {
        transform.position += new Vector3(0, 0, -hizimiz) *Time.deltaTime;
        Destroy(this.gameObject, 7);
    }
}
