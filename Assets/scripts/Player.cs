using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    
    public List<LevelRange> levelRanges;
    

    // Start is called before the first frame update
    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
        currentHealth = maxHealth;


    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(10);
    //    }
    //}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }


}
