using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThumbnailLoader : MonoBehaviour
{
    [SerializeField] private Image imagePrefab;
    [SerializeField] private List<Sprite> thumbnails;
    [SerializeField] private Transform group;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var sprite in thumbnails)
        {
            var img = Instantiate(imagePrefab, group);
            img.sprite = sprite;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
