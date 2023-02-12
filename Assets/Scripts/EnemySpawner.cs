using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemyReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject SpawnEnemy;

    private int randomIndex;//Index of the mostreference array (Which Monster to Spawn)
    private int randomSide;//On what side the monster should randomly spawn

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, EnemyReference.Length); //random index number from 0 to number of total objects in array
            randomSide = Random.Range(0, 2);//0 and 1 or Left or Right

            //Would make copy and spawn monster
            SpawnEnemy = Instantiate(EnemyReference[randomIndex]);

            if (randomSide == 0)
            {
                SpawnEnemy.transform.position = leftPos.position;
                //This line would set random speed on the enemy
                SpawnEnemy.GetComponent<Enemies>().speed = Random.Range(4, 10);
            }
            else
            {
                SpawnEnemy.transform.position = rightPos.position;
                SpawnEnemy.GetComponent<Enemies>().speed = -Random.Range(4, 10);
                SpawnEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }//While Loop termination
    }//Coroutine
}
