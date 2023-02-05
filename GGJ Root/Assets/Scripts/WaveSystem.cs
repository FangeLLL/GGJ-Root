using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    public GameObject SwordEnemy, GunEnemy;
    public GameObject[] obstacles;
    public Transform cameraTransform;
    public int level,hardness,amount_sword,amount_gun,totalEnemy;
    public float rangeX, rangeY;
    public GameObject waveText;



    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        generateWave();
    }

    public void generateWave()
    {
        if (totalEnemy == 0)
        {
            StartCoroutine(ShowWave());
            hardness = level * 25;
            amount_sword = Random.Range(0, hardness / 5);
            amount_gun = (hardness - (amount_sword * 5)) / 5;
            totalEnemy = amount_gun + amount_sword;

            Vector2[] enemyPos = new Vector2[amount_gun + amount_sword];

            for (int i = 0; i < amount_gun + amount_sword; i++)
            {
                switch (Random.Range(0, 4))
                {
                    case 0:
                        // Left
                        enemyPos[i] = new Vector2(cameraTransform.position.x - rangeX, transform.position.y + Random.Range(-rangeY, rangeY + 1));
                        break;
                    case 1:
                        // Right
                        enemyPos[i] = new Vector2(cameraTransform.position.x + rangeX, transform.position.y + Random.Range(-rangeY, rangeY + 1));
                        break;
                    case 2:
                        // Up
                        enemyPos[i] = new Vector2(transform.position.x + Random.Range(-rangeX, rangeX + 1), cameraTransform.position.y + rangeY);
                        break;
                    case 3:
                        // Down
                        enemyPos[i] = new Vector2(transform.position.x + Random.Range(-rangeX, rangeX + 1), cameraTransform.position.y - rangeY);
                        break;
                }
            }

            for (int i = 0; i < amount_sword; i++)
            {
                Instantiate(SwordEnemy, enemyPos[i], cameraTransform.rotation);
            }

            for (int i = amount_sword; i < amount_gun + amount_sword; i++)
            {
                Instantiate(GunEnemy, enemyPos[i], cameraTransform.rotation);
            }

            level++;
        }

    }

    private IEnumerator ShowWave()
    {
        waveText.SetActive(true);
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + level.ToString();
        yield return new WaitForSeconds(.5f);
        waveText.GetComponent<TextMeshProUGUI>().fontSize = 50;
        yield return new WaitForSeconds(1);
       waveText.GetComponent<TextMeshProUGUI>().fontSize = 36;
        yield return new WaitForSeconds(1);
       waveText.SetActive(false);
    }
}
