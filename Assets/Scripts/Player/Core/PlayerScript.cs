using UnityEngine;
using System.Collections;
using Assets.Scripts.Player.Core;

public class PlayerScript : MonoBehaviour {

    private bool flag = false;
    private bool aggro = false;

    private Vector3 endPoint;

    public float movementSpeed = 1.0f;

    private Animation animations;

    protected SkillSet skillset;

	// Use this for initialization
	void Start ()
	{
	    animations = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

	    GetInputs();

	    if (flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
	    {
            animations.Stop("Idle");
	        animations.PlayQueued("Walk");
	        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint,
	            1/(movementSpeed*(Vector3.Distance(gameObject.transform.position, endPoint))));
	    }
        else if (flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
        {
            animations.PlayQueued("Idle");
            flag = false;
        }
        else
        {
            animations.Stop("Walk");
            animations.PlayQueued("Idle");
        }
	}

    private void GetInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            AttackMove(Input.mousePosition);
        }

        if (Input.GetButtonDown("qSkill"))
        {
            UseSkill(skillset.getQ());
        }

        if (Input.GetButtonDown("wSkill"))
        {
            UseSkill(skillset.getW());
        }

        if (Input.GetButtonDown("eSkill"))
        {
            UseSkill(skillset.getE());
        }

        if (Input.GetButtonDown("rSkill"))
        {
            UseSkill(skillset.getR());
        }
    }

    private void Move(Vector3 position)
    {
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out hit))
        {
            flag = true;
            endPoint = hit.point;
            gameObject.transform.LookAt(endPoint);
        }
    }

    private void AttackMove(Vector3 position)
    {
        aggro = true;
        Move(position);
    }

    private void UseSkill(Skill skill)
    {
        flag = false;
        animations.Stop();
        animations.PlayQueued("Attack");
    }
}
