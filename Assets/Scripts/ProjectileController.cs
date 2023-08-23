using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string tagToDamage;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private ParticleSystem collisionParticle;
    [SerializeField] private int damageAmount;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.velocity * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("detected");
        if(col.gameObject.tag == this.tagToDamage)
        {
            var healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(this.damageAmount);

            var particles = Instantiate(this.collisionParticle);
            particles.transform.position = transform.position;
            particles.transform.rotation = Quaternion.LookRotation(-this.velocity);
            Destroy(gameObject);
            Debug.Log("destroy!");

        }
    }


}
