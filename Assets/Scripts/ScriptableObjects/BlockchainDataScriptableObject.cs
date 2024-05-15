using UnityEngine;

[CreateAssetMenu(fileName = "BlockchainData", menuName = "ScriptableObject/BlockchainData")]
public class BlockchainDataScriptableObject: ScriptableObject
{
    public string Address;
    public float Balance;
}