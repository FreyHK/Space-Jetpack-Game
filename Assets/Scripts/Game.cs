using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Entity PlayerJetpack;

    public List<Entity> Entities = new List<Entity>();

	void Start () {
		
	}
	
	void Update () {
        //Tell entities to update
        for (int i = 0; i < Entities.Count; i++) {
            Entities[i].DoUpdate();
        }

        List<Entity> toRemove = new List<Entity>();
        //Get all dead entities
        for (int i = 0; i < Entities.Count; i++) {
            if (Entities[i].IsDead) {
                toRemove.Add(Entities[i]);
            }
        }

        //Destroy all dead entities
        for (int i = 0; i < toRemove.Count; i++) {
            Entities.Remove(toRemove[i]);
            Destroy(toRemove[i].gameObject);
            //TODO: possibility for effects?
        }
    }

    void FixedUpdate() {
        //Tell entities to update
        for (int i = 0; i < Entities.Count; i++) {
            Entities[i].UpdatePhysics();
        }
    }
}
