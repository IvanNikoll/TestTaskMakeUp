using UnityEngine;

public class MakeUpItemController : MonoBehaviour
{
    public void MoveItem(MakeupItem item, Transform target)
    {
        item.transform.position = target.position;
    }
}
