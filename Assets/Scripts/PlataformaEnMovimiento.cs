using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEnMovimiento : MonoBehaviour
{
    public GameObject ObjetoAmover;

    public Transform StartPoint;
    public Transform EndPoint;

    public float Velocidad;

    private Vector3 MoverHacia;

    public HoplitaColocado hop;
    public ArpaColocada arpa;

    // Start is called before the first frame update
    void Start()
    {
        MoverHacia = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(hop.hoplita == true && arpa.arpaColocada == true)
        {
            ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

            if (ObjetoAmover.transform.position == EndPoint.position)
            {
                MoverHacia = StartPoint.position;
            }

            if (ObjetoAmover.transform.position == StartPoint.position)
            {
                MoverHacia = EndPoint.position;
            }
        }

    }
}
