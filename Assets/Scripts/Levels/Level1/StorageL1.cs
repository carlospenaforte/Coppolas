using UnityEngine;

public class StorageL1 : MonoBehaviour
{
    public Event bombMaker, table;

    private void Awake()
    {
        if (BombMakerL1.GetBombMaked())
        {
            Destroy(bombMaker);
            Destroy(table);
            Destroy(this);
        }
    }
}
