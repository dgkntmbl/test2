using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    public int experienceGranted;
    public void Collect()
    {
        Player player = FindObjectOfType<Player>();
        player.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}
