using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Entity PlayerJetpack;

    List<Entity> Entities;

	void Start () {
        Entities = new List<Entity>();

        Entity[] ent = FindObjectsOfType<Entity>();

        for (int i = 0; i < ent.Length; i++) {
            Entities.Add(ent[i]);
        }
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
