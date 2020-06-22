using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;

    // Start is called before the first frame update
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
       {
            if (enemy != null)
            {
                return;
            }
            else {

                Debug.Log("You killed all enemies");
            }
        }
    }
}
