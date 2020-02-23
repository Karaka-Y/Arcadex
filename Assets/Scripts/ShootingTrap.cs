using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for shooting traps. It represent as an object that shoots with something in one of four directions (left-right-up-down)
//it sets shoot direction and shoots using the coroutine
public class ShootingTrap : MonoBehaviour
{
    //reference to prefab, it is a projectile that will be created and thrown by adding a force to it
    [SerializeField] private GameObject projectilePrefab;
    private GameObject _projectile;
    public float projectileSpeed = 3.0f;
    public float shootFrequency = 2.0f;
    public float destroyDelay = 3.0f;
    private Vector2 shootDirection;
    // Start is called before the first frame update
    void Start()
    {
        //when scene is loaded traps begins to fire with that two functions
        ShootDirection();
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //first function - choosing the shoot direction. I made the trap sprite that turned to the left
    //but i need trap that can shoot in four directions, so, when i rotate the sprite in the scene
    // it sets proper shoot direction based on transform rotation of the sprite (Game object)
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
        //secont function, it waits some time (we can choose it in Inspector) and instantiate the saw prefab
        IEnumerator Shoot (){
            yield return new WaitForSeconds(shootFrequency);
            _projectile = Instantiate(projectilePrefab) as GameObject;
            _projectile.transform.position = this.transform.position;
            _projectile.transform.rotation = this.transform.rotation;

            //after instantiating the projectile we move it towards the shoot direction
            _projectile.GetComponent<Rigidbody2D>().AddForce(shootDirection * projectileSpeed);

            //then we destroy the projectile after choosen time of life is gone
            Destroy(_projectile, destroyDelay);

            //and starts the new coroutine to shoot again
            StartCoroutine("Shoot");
        }
    }
