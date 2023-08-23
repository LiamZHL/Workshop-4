using System.Collections;
using System.Collections.Generic;
// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathEffect;

    private MeshRenderer _renderer;

    [SerializeField] public string tagToDamage;

    private void Awake()
    {
        this._renderer = gameObject.GetComponent<MeshRenderer>();
    }

    // This method listens to HealthManager "onHealthChanged" events. The actual
    // event listening is set up within the editor interface. This is purely for
    // visuals currently, and takes a fractional value between 0 and 1.
    public void UpdateHealth(float frac)
    {
        this._renderer.material.color = Color.red * frac;
    }

    // Same as above, but listens to onDeath events.
    public void Kill()
    {
        var particles = Instantiate(this.deathEffect);
        particles.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("detected");
        if (col.gameObject.tag == this.tagToDamage)
        {
            //var healthManager = col.gameObject.GetComponent<HealthManager>();
            //healthManager.ApplyDamage(this.damageAmount);

            //var particles = Instantiate(this.collisionParticle);
            //particles.transform.position = transform.position;
            //particles.transform.rotation = Quaternion.LookRotation(-this.velocity);
            Destroy(gameObject);
            Debug.Log("destroy!");

        }
    }
}