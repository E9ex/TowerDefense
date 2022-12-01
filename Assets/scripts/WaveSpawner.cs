
using UnityEngine;
using System.Collections;
using TMPro;
using Unity.UI;


public class WaveSpawner : MonoBehaviour
{
    public Transform enemyprefab;

    public Transform spawnpoint;
    
    public float timebetweenwaves = 3f;
    private float _countDown = 3f;
    private int _wavenumber = 1;
    public TextMeshProUGUI wavecountdowntext;

        private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = timebetweenwaves;// ilk 2 saniye bitiyor sonrasında 5f likten saymaya basliyor.
        }
        _countDown -= Time.deltaTime;
        _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);
        wavecountdowntext.text = string.Format("{0:00.00}", _countDown);
    }

    
        IEnumerator SpawnWave()
        {
            _wavenumber++;
            PlayerStats.rounds++;
            for (int i = 0; i < _wavenumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }           
           

            
        }

        void SpawnEnemy()
        {
            Instantiate(enemyprefab,spawnpoint.position,spawnpoint.rotation);
        }
        
    
}
