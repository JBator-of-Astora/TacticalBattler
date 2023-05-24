using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters {
    abstract public class Character
    {

        GameObject model;

        int max_health;
        int max_speed;

        public Character(int health_p, int speed_p, string modelPath) {

            GameObject temp = Resources.Load(modelPath) as GameObject;
            model = GameObject.Instantiate(temp);
            
            max_health = health_p;
            max_speed = speed_p;
        }
    }

    public class TestCharacter: Character 
    {
        public TestCharacter(int health_p, int speed_p):base(health_p, speed_p, "Capsule") {}
    }

}
