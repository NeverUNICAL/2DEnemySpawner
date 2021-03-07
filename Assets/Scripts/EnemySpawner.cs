using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private Enemy _template;
   
   private SpawnPoint[] _spawnPoints;

   private void Awake()
   {
      _spawnPoints = GetComponentsInChildren<SpawnPoint>();
   }

   private void Start()
   {
      var generateInJob = StartCoroutine(Generate());
   }

   private IEnumerator Generate()
   {
      foreach (var point in _spawnPoints)
      {
         Instantiate(_template, point.transform.position, quaternion.identity);
         
         yield return new WaitForSeconds(2F);
      }
   }
}
