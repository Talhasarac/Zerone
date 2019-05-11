using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {
	public LineRenderer LR;
	public float dragspeed;
	public Camera camera;
	SpringJoint2D SJ2D;
	Rigidbody2D grabbedobj = null;
	Vector3 LCLHTPNT;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse3d = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mouse2d = new Vector2 (mouse3d.x, mouse3d.y);
		if (Input.GetMouseButtonDown (0)) {

		

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

			// If it hits something...
			if (hit.collider != null) {
				
				grabbedobj = hit.collider.GetComponent<Rigidbody2D>();
			      SJ2D = 	grabbedobj.gameObject.AddComponent<SpringJoint2D> ();
				SJ2D.autoConfigureDistance = false;
				LCLHTPNT = grabbedobj.transform.InverseTransformPoint (hit.point);
				SJ2D.anchor = LCLHTPNT;
				SJ2D.enableCollision = true;
				SJ2D.distance = 0.5f;
				SJ2D.dampingRatio = 1f;
				SJ2D.frequency = 1;
				SJ2D.connectedBody = null;

			

				
				LR.enabled = true;
			}
		
		}
		if (Input.GetMouseButtonUp (0) && grabbedobj != null) {
			Destroy (SJ2D);
			LR.enabled = false;
			grabbedobj = null;

		}

		if (SJ2D != null) {
			SJ2D.connectedAnchor = mouse3d;
		
		} else {

			LR.enabled = false;
		}
	}

	void FixedUpdate() {
		Vector3 mouse3d = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mouse2d = new Vector2 (mouse3d.x, mouse3d.y);
		if (grabbedobj != null) {
			Vector2 dir = mouse2d - grabbedobj.position;
			dir *= dragspeed;


		}



	}
	void LateUpdate() {
		if (grabbedobj != null) {
			

			Vector3 worldanchor = grabbedobj.transform.TransformPoint (SJ2D.anchor);

			LR.SetPosition (0, new Vector3 (worldanchor.x,worldanchor.y,0));
			LR.SetPosition (1, new Vector3 (SJ2D.connectedAnchor.x,SJ2D.connectedAnchor.y, -1));

		}
	}

}
