
using UnityEngine;
using static UnityEngine.Random;

public class SoapSpawner : MonoBehaviour
{
    [SerializeField] private Transform soap1;
    [SerializeField] private Transform soap2;
    [SerializeField] private Transform soap3;
    [SerializeField] private Transform soap4;
    [SerializeField] private Transform soap5;
    [SerializeField] private Transform soap6;
    [SerializeField] private Transform soap7;

    private float goalHeight = 0.75f;
    
    public void SpawnSoap()
    {
        //hardcoded shitm fix
        //enable disabled soap gameobjects

        soap1.gameObject.SetActive(true);
        soap2.gameObject.SetActive(true);
        soap3.gameObject.SetActive(true);
        soap4.gameObject.SetActive(true);
        soap5.gameObject.SetActive(true);
        soap6.gameObject.SetActive(true);
        soap7.gameObject.SetActive(true);

        //random positions in defined area
        if(soap1 != null) soap1.transform.localPosition = new Vector3(Range(22f, 19f), goalHeight, Range(3f, 10f));
        if(soap2 != null) soap2.transform.localPosition = new Vector3(Range(-10f, 8f), goalHeight, Range(16f, 23f));
        if(soap3 != null) soap3.transform.localPosition = new Vector3(Range(-3f, -4f), goalHeight, Range(3f, 6f));
        if(soap4 != null) soap4.transform.localPosition = new Vector3(Range(-19f, -23f), goalHeight, Range(-6f, -7f));
        if(soap5 != null) soap5.transform.localPosition = new Vector3(Range(-7f, -22f), goalHeight, Range(-14f, -22f));
        if(soap6 != null) soap6.transform.localPosition = new Vector3(Range(-18f, -22f), goalHeight, Range(0f, 10f));
        if(soap7 != null) soap7.transform.localPosition = new Vector3(Range(7f, 22f), goalHeight, Range(-16f, -20f));
        
        //random rotation
        if(soap1 != null) soap1.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap2 != null) soap2.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap3 != null) soap3.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap4 != null) soap4.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap5 != null) soap5.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap6 != null) soap6.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);
        if(soap7 != null) soap7.transform.Rotate(0f, Range(0f, 360f), 0f, Space.Self);

    }
    

}
