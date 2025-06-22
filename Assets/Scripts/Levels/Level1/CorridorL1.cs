using UnityEngine;

public class CorridorL1 : MonoBehaviour
{
    public GameObject door, anton, player;

    private void Awake()
    {
       if (DetonatorL1.GetDoorExploded())
            DestroyThemAll();
    }

    private void Update()
    {
        if (DetonatorL1.GetDoorExploded())
            DestroyThemAll();
    }

    private void DestroyThemAll()
    {
        Destroy(door);
        Destroy(anton);
        Destroy(this);
    }
}
