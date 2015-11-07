using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private bool flag = false;

    private Vector3 endPoint;

    public float movementSpeed = 50.0f;

    private float yAxis;

    private Animation animations;

	// Use this for initializationt
	void Start ()
	{
	    animations = GetComponent<Animation>();
	    yAxis = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	    if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
	    {
	        RaycastHit hit;
	        Ray ray;

	        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        if (Physics.Raycast(ray, out hit))
	        {
	            flag = true;
	            endPoint = hit.point;
	            endPoint.y = yAxis;
	            gameObject.transform.LookAt(endPoint);
	        }
	    }

	    if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
	    {
	        animations.Play("Walk");
	        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint,
	            1/(movementSpeed*(Vector3.Distance(gameObject.transform.position, endPoint))));
	    }
        else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            animations.Play("Idle");
	        flag = false;
	    }
	}
}
