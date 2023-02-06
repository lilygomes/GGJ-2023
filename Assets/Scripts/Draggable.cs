using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// based on https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDragHandler.html

[RequireComponent(typeof(Image))]

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler {
	public bool dragOnSurfaces = true;

	private RectTransform _draggingPlane;

	public void OnBeginDrag(PointerEventData eventData) {
		var canvas = GetParentCanvas(gameObject);
		if (canvas == null)
			return;

		if (dragOnSurfaces)
			_draggingPlane = transform as RectTransform;
		else
			_draggingPlane = canvas.transform as RectTransform;

		SetDraggedPosition(eventData);
	}

	private void SetDraggedPosition(PointerEventData eventData) {
		if (dragOnSurfaces &&
		    eventData.pointerEnter != null &&
		    eventData.pointerEnter.transform as RectTransform != null &&
		    eventData.pointerEnter.layer == 10) // Checks that object is on Layer 10: Draggable
			_draggingPlane = eventData.pointerEnter.transform as RectTransform;

		var rectTransform = _draggingPlane.GetComponent<RectTransform>();
		
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(_draggingPlane, eventData.position, eventData.pressEventCamera, out globalMousePos)) {
			rectTransform.position = globalMousePos;
			rectTransform.rotation = _draggingPlane.rotation;
		}
	}

	public void OnDrag(PointerEventData eventData) {
		SetDraggedPosition(eventData);
	}

	// public void OnEndDrag(PointerEventData eventData) {
	// 	throw new System.NotImplementedException();
	// }

	public static Canvas GetParentCanvas(GameObject obj) {
		if (obj == null)
			return null;
		var comp = obj.GetComponent<Canvas>();
		// Find canvas on parent object of component
		Transform parentTransform = obj.transform.parent;
		while (parentTransform != null && comp == null) {
			comp = parentTransform.gameObject.GetComponent<Canvas>();
			parentTransform = parentTransform.parent;
		}

		return comp;
	}
}
