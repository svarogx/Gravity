using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour {

    public GameObject centerObject;
    public bool isGravity = true;

    private Vector3 centerPoint;
    private float gConstant;
    private float mass;

    // Use this for initialization
    void Start () {
        centerPoint = centerObject.GetComponent<Transform>().position;
        mass = centerObject.GetComponent<CenterProperties>().mass;
        gConstant = centerObject.GetComponent<CenterProperties>().gConstant;
        StartCoroutine("GravitySystem");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GravitySystem() {
        float deltaX, deltaY, difScalar, gForce;
        while (true) {
            deltaX = GetComponent<Transform>().position.x - centerPoint.x;
            deltaY = GetComponent<Transform>().position.y - centerPoint.y;
            difScalar = (GetComponent<Transform>().position - centerPoint).magnitude;
            Debug.Log(difScalar);
            difScalar = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));
            Debug.Log(difScalar);
            gForce = gConstant * mass / Mathf.Pow(difScalar, 2);
            if (isGravity) {

            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
