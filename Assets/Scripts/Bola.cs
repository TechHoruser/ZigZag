using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bola : MonoBehaviour
{
    bool derecha;
    bool pausa;
    float tiempo;
    float velocidad;

    // Use this for initialization
    void Start () {
        velocidad = 0.1f;
        derecha = true;
        pausa = false;
        tiempo = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Juego Acabado
        if (this.transform.position.y <= 0)
        {

            GameObject ob = GameObject.Find("Terreno");
            Main m = (Main)ob.GetComponent(typeof(Main));
            if (!pausa)
            {
                tiempo = Time.realtimeSinceStartup - m.tiempo();
                pausa = true;
            }

            m.botoncillo.SetActive(true);
            ob = GameObject.Find("Text");
            Text t = ob.GetComponent<Text>();
            t.text = ("Puntuacion: " + m.puntuacion() + "\nPuntuacion Maxima: " + m.puntuacionMax() + "\nTiempo: " + tiempo);

            ob = GameObject.Find("Guardar");
            Guarda g = (Guarda)ob.GetComponent(typeof(Guarda));

            if (m.puntuacionMax() < m.puntuacion())
                g.SetPuntuacion(m.puntuacion());

            Time.timeScale = 0;
        }
        //En otro caso
        else
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
                derecha = !derecha;

            if (derecha)
                this.transform.Translate(new Vector3(velocidad, 0f, 0f));
            else
                this.transform.Translate(new Vector3(0f, 0f, velocidad));
        }
    }

    public void incrementarVelocidad()
    {
        velocidad += 0.01f;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.transform.parent.gameObject.name == "Obstaculo")
        {
            Destroy(c.gameObject);
            GameObject ob = GameObject.Find("Terreno");
            Main m = (Main)ob.GetComponent(typeof(Main));
            m.incrementarPuntuacion();
        }
    }
}
