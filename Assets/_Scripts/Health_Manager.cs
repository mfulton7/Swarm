using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Manager : MonoBehaviour
{
    public float max_health;
    public float current_health;
    public float growth_increment;

    public GameObject swarm_prefab;
    public float spawn_radius;

    public GameObject player_parent;


    public float strength;

    void take_damage(float incoming_damage)
    {
        current_health -= incoming_damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Food" && gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Health_Manager>().take_damage(strength);
            //current_health += strength;
            // calculate random position in the swarm
            Vector2 spawn_pos = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y);
            float x_offset = Random.Range(spawn_radius * -1, spawn_radius);
            float y_offset = Random.Range(spawn_radius * -1, spawn_radius);
            spawn_pos.x += x_offset;
            spawn_pos.y += y_offset;
            GameObject new_swarm_member = Instantiate(swarm_prefab, spawn_pos, Quaternion.identity);
            new_swarm_member.transform.parent = player_parent.transform;

        }

        else if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Player")
        {
            // deal damage to both parties
            print("Reducing Health");
            collision.gameObject.GetComponent<Health_Manager>().take_damage(strength);
        }

    }
}
