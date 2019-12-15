using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private GameObject _projectile;
    public float projectileSpeed = 3.0f;
    public float shootFrequency = 2.0f;
    public float destroyDelay = 3.0f;
    private Vector2 shootDirection;
    // Start is called before the first frame update
    void Start()
    {
        ShootDirection();
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void ShootDirection(){
        if (this.transform.rotation.eulerAngles.y == 0 && this.transform.rotation.eulerAngles.z == 0){
            shootDirection = Vector2.left;
        }
        else if (this.transform.rotation.eulerAngles.y == 180.0f && this.transform.rotation.eulerAngles.z == 0){
            shootDirection = Vector2.right;
        }
        else if(this.transform.rotation.eulerAngles.y == 0 && this.transform.rotation.eulerAngles.z == 90){
            shootDirection = Vector2.down;
        }
        else if (this.transform.rotation.eulerAngles.y == 0 && this.transform.rotation.eulerAngles.z == 270){
            shootDirection = Vector2.up;
        }
    }
        IEnumerator Shoot (){
            yield return new WaitForSeconds(shootFrequency);
            _projectile = Instantiate(projectilePrefab) as GameObject;
            _projectile.transform.position = this.transform.position;
            _projectile.transform.rotation = this.transform.rotation;
            _projectile.GetComponent<Rigidbody2D>().AddForce(shootDirection * projectileSpeed);
            Destroy(_projectile, destroyDelay);
            StartCoroutine("Shoot");
        }
    }
