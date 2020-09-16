using UnityEngine;

public interface ICollectible
{
    event System.Action<GameObject> OnCollected;
}
