using UnityEngine;

public class NodeBuildSettings : MonoBehaviour
{
    private GameObject structure;

    public GameObject StructureInfo()
    {
        return structure;
    }

    public void StartBuild(GameObject[] structure, int structureIndex, float high, int cost)
    {
        if (this.structure == null && CoinController.SubtracCoin(cost))
        {
            Vector3 spawnPosition = new Vector3(transform.position.x,
                                            transform.position.y + high,
                                            transform.position.z);
            this.structure = Instantiate(structure[structureIndex],
                                        spawnPosition,
                                        Quaternion.identity);
        }
    }


}
