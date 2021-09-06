using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm_Input_Handler : MonoBehaviour
{
    public GameObject swarm_prefab;
    public float spawn_radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player
        float y_move = Input.GetAxis("Vertical");
        float x_move = Input.GetAxis("Horizontal");
        Vector2 force_direction = new Vector2(x_move, y_move);

        // Apply force to the Swarm
        UnityEngine.Rigidbody2D swarm_RB = this.GetComponent<Rigidbody2D>();
        swarm_RB.AddForce(force_direction);

        // Testing button to spawn more swarm members
        if (Input.GetKeyDown("space")){
            // calculate random position in the swarm
            Vector2 spawn_pos = new Vector2(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y);
            float x_offset = Random.Range(spawn_radius * -1, spawn_radius);
            float y_offset = Random.Range(spawn_radius * -1, spawn_radius);
            spawn_pos.x += x_offset;
            spawn_pos.y += y_offset;
            GameObject new_swarm_member = Instantiate(swarm_prefab, spawn_pos, Quaternion.identity);
            new_swarm_member.transform.parent = this.gameObject.transform;
        }

    }
}
