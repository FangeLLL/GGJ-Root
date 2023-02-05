using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    public GameObject[] backgroundPrefabs;
    private GameObject[] backgrounds;
    public Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
     backgrounds[0] = Instantiate(backgroundPrefabs[Random.Range(0, backgroundPrefabs.Length)], playerTrans.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBackground()
    {
        
    }


}
