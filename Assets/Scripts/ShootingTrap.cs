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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
        IEnumerator Shoot (){
            yield return new WaitForSeconds(shootFrequency);
            _projectile = Instantiate(projectilePrefab) as GameObject;
            _projectile.transform.position = this.transform.position;
            _projectile.transform.rotation = this.transform.rotation;
            _projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
            Destroy(_projectile, destroyDelay);
            StartCoroutine("Shoot");
        }
    }
