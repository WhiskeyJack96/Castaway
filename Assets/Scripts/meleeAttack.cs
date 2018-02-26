using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour {
    public Collider2D weapon;
    public LayerMask mask;
    public int damage=5;
    public int n = 10;
    public float theta = 0f;
    public float length = 1f;
    private Collider2D col;

    public KeyCode attackButton = KeyCode.Mouse0;
    private bool canAttack = true;
    private float timer = .01f;


    // Use this for initialization
    void Start () {
		col = GetComponent<Collider2D>();
        weapon = transform.GetChild(0).GetComponent<Collider2D>();
        Bounds bounds = weapon.bounds;
        theta =2f* Mathf.Atan(2f * bounds.extents.y/bounds.extents.x);
        print(bounds.extents);
        length = 2f * bounds.extents.y / Mathf.Cos(theta/2f);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(attackButton) && canAttack){
            attack();
            StartCoroutine(cooldown(timer));
        }
	}

    void attack(){
        RaycastHit2D[] res = new RaycastHit2D[100];
        float playerRotation = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
        float initTheta = (-theta/2f)+playerRotation;
        float incrementTheta = theta/n;
        //print(initTheta + (n*incrementTheta));
        for(int i = 0;i < n;i++){
            int hit = col.Raycast(new Vector2(Mathf.Cos(initTheta + (i*incrementTheta)), Mathf.Sin(initTheta + (i*incrementTheta))),res,length,mask);
            //Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(initTheta + (i*incrementTheta)), Mathf.Sin(initTheta + (i*incrementTheta))),Color.red, 3f);
            if(hit>0){
                for(int j =0; j <hit;j++){
                    if(res[j].transform.gameObject.tag == "Resource")
                    {
                        res[j].transform.gameObject.GetComponent<EnemyHealth>().updateHealth(damage);
                    }
                    if(res[j].transform.gameObject.tag == "Enemy")
                    {
                       res[j].transform.gameObject.GetComponent<EnemyHealth>().updateHealth(damage);
                    }
                }
            }
        }
    }


    IEnumerator cooldown(float timer){
        canAttack = false;
        yield return new WaitForSeconds(timer);
        canAttack = true;
    }
}
