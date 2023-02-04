using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyTreeStatInformer : MonoBehaviour
{
    public Text enemiesKilledText;
    public float enemieskilled;

    private void Start()
    {
        enemieskilled = Random.Range(1, 1000);
    }

    void Update()
    {
        enemiesKilledText.text = "Enemies Killed: " + enemieskilled;
    }

}
