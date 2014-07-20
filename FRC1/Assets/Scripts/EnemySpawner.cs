using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	//Public properties
	public GameObject[] enemyPrefabs;

	public int maxEnemyOne = 10;
	public int maxEnemyTwo = 3;
	public int maxEnemyThree = 1;
	public float spawnRadiusFromPlayer = 100;
	public float spawnInterval = 1;

	//Private
	List<GameObject> lEnemyOne;
	List<GameObject> lEnemyTwo;
	GameObject enemyThree = null;
	Transform player;

	//Singleton
	static EnemySpawner instance;
	public static EnemySpawner getInstance()
	{
		//if (instance == null)
		//	instance = this;
		//else
		//	Destroy (gameObject);

		return instance;
	}

	//Methods
	void Start()
	{
		if (instance != null) {
			Destroy(gameObject);
			return;
		}

		instance = this;
		lEnemyOne = new List<GameObject> ( maxEnemyOne );
		lEnemyTwo = new List<GameObject> ( maxEnemyTwo );
		player = GameObject.Find ("Player").transform;
		
		StartCoroutine (CR_Spawn ());
	}

	IEnumerator CR_Spawn()
	{
		while(true)
		{
			if(lEnemyOne.Count < maxEnemyOne)
			{
				SpawnEnemy(0);
				yield return new WaitForSeconds(spawnInterval);
			}
			else if(lEnemyTwo.Count < maxEnemyTwo)
			{
				SpawnEnemy(1);
				yield return new WaitForSeconds(spawnInterval);
			}
			else if(enemyThree = null)
			{
				SpawnEnemy(2);
				yield return new WaitForSeconds(spawnInterval);
			}
			yield return 0;
		}
	}

	void SpawnEnemy(int index)
	{
		GameObject newEnemy = (GameObject)Instantiate (enemyPrefabs [index]);
		newEnemy.transform.position = new Vector3 (player.position.x + Random.Range (-spawnRadiusFromPlayer, spawnRadiusFromPlayer), 
		                                          player.position.y + Random.Range (-spawnRadiusFromPlayer, spawnRadiusFromPlayer), 0);
		newEnemy.transform.parent = transform;
		
		if (index == 0) {
			lEnemyOne.Add(newEnemy);
			GameplayUI.getInstance().UpdateEnemyCounter(index, lEnemyOne.Count);
		} 
		else if (index == 1) {
			lEnemyTwo.Add(newEnemy);
			GameplayUI.getInstance().UpdateEnemyCounter(index, lEnemyTwo.Count);
		} 
		else if (index == 2) {
			print ("ENEMYadsgdjjdgkl;glkjg;lkadgj;ldkj");
			enemyThree = newEnemy;
			GameplayUI.getInstance().UpdateEnemyCounter(index, 1);
		}
	}

	public void RemoveEnemy(int Type, GameObject enemy)
	{
            //throw new System.Exception();
            if (enemy.tag == "Enemy")
            {
                Enemy e = enemy.GetComponent<Enemy>();
                e.ChangeState(2);
            }

			GameplayUI.getInstance().UpdateEnemyCounter(Type, -1);
		
            if (Type == 0)
            {
                lEnemyOne.Remove(enemy);
				GameplayUI.getInstance().UpdateEnemyCounter(Type, lEnemyOne.Count);
            }
            else if (Type == 1)
            {
                lEnemyTwo.Remove(enemy);
				GameplayUI.getInstance().UpdateEnemyCounter(Type, lEnemyTwo.Count);
            }
            else if (Type == 2)
            {
                enemyThree = null;
				GameplayUI.getInstance().UpdateEnemyCounter(Type, 0);
            }
	}
}
