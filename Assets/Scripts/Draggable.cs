using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// based on https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.EventSystems.IDragHandler.html

[RequireComponent(typeof(Image))]

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public bool dragOnSurfaces = true;

	private RectTransform _draggingPlane;

	public void OnBeginDrag(PointerEventData eventData) {
		var canvas = GetParentCanvas(gameObject);
		if (canvas == null)
			return;
	}

	public void OnDrag(PointerEventData eventData) {
		throw new System.NotImplementedException();
	}

	public void OnEndDrag(PointerEventData eventData) {
		throw new System.NotImplementedException();
	}

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
