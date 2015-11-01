using UnityEngine;
using System.Collections;

public class Guarda : MonoBehaviour {
    int puntMax;

    public int GetPuntuacion()
    {
        return puntMax;
    }

    public void SetPuntuacion(int p)
    {
        puntMax = p;
    }
    // Use this for initialization
    void Start () {
        puntMax = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
