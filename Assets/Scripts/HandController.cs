using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour
{
    [SerializeField] private Transform handRestPosition;
    [SerializeField] private RectTransform faceRectTransform;
    [SerializeField] private MakeUpItemContext itemContext;
    private MakeupItem _heldItem;
    private Vector3 _offset = new Vector3(0.5f, 0.5f, 0);
    private float _moveSpeed = 20f;
    private float _returnSpeed = 40f;
    private bool _isDragging;

    private void Update()
    {
        CheckDragging();
        DragItem();
        StopDragging();
    }

    public void PickUpItem(MakeupItem item)
    {
        _heldItem = item;
        _heldItem.SetPickedUp(true);
        StartCoroutine(MoveHandToItem(item));
    }

    private void StopDragging()
    {
        if (Input.GetMouseButtonUp(0) && _isDragging)
        {
            _isDragging = false;

            if (IsCursorOverFace())
            {
                if (_heldItem is IApplicable applicable)
                    applicable.Apply(Input.mousePosition);
            }
            StartCoroutine(ReturnItemAndHand());
        }
    }

    private void DragItem()
    {
        if (_isDragging && _heldItem != null)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;
            transform.position = mouseWorld - _offset;
            _heldItem.transform.position = transform.position + _offset;
        }
    }

    private void CheckDragging()
    {
        if (_heldItem != null && !_isDragging && Input.GetMouseButtonDown(0))
            _isDragging = true;
    } 

    private IEnumerator MoveHandToItem(MakeupItem item)
    {
        while (Vector3.Distance(transform.position, item.transform.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, item.transform.position, _moveSpeed * Time.deltaTime);
            yield return null;
        }

        Vector3 dragPos = itemContext.GetItemPosition(false, item.ItemType).position;
        while (Vector3.Distance(transform.position, dragPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, dragPos, _moveSpeed * Time.deltaTime);
            item.transform.position = transform.position + _offset;
            yield return null;
        }
    }

    private IEnumerator ReturnItemAndHand()
    {
        if (_heldItem == null)
            yield break;

        Vector3 targetItemPos = itemContext.GetItemPosition(true, _heldItem.ItemType).position - _offset;

        while (Vector3.Distance(transform.position, targetItemPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetItemPos, _returnSpeed * Time.deltaTime);
            _heldItem.transform.position = transform.position + _offset;
            yield return null;
        }

        _heldItem.SetPickedUp(false);
        _heldItem = null;
        float t = 0f;
        Vector3 startPos = transform.position;

        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, handRestPosition.position, t);
            yield return null;
        }
    }

    private bool IsCursorOverFace()
    {
        return RectTransformUtility.RectangleContainsScreenPoint(
            faceRectTransform,
            Input.mousePosition,
            Camera.main
        );
    }
}