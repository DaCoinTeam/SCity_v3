using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private Vector3 _spawnPosition;

    [Range(0f, 5f)]
    [SerializeField]
    private float _spawnRandomRange = 1f;

    private IEnumerator Start()
    {
        if (IsOwner)
        {
            yield return new WaitForEndOfFrame();
            transform.position = GetPlayerSpawnPosition();
        }
    }

    private Vector3 GetPlayerSpawnPosition()
    {
        return new()
        {
            x = Random.Range(
                _spawnPosition.x - _spawnRandomRange,
                _spawnPosition.z + _spawnRandomRange
                ),
            y = _spawnPosition.y,
            z = Random.Range(
                _spawnPosition.z - _spawnRandomRange,
                _spawnPosition.z + _spawnRandomRange
                )
        };
    }
}