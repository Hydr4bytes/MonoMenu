using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoneworksPointer : MonoBehaviour
{
	public Camera pointerCam;
	public float rayLength = 5f;

	private Ray ray { get; set; }
	private RaycastHit hit { get; set; }

	private void Awake() => pointerCam = GetComponent<Camera>();

	private void Update() => ray = pointerCam.ScreenPointToRay(Input.mousePosition);

	private void OnDrawGizmos() => Handles.DrawLine(ray.origin, ray.direction * rayLength);
}
