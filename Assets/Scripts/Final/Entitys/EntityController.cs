using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    Entity _model;
    void Start()
    {
        _model = GetComponent<Entity>();
    }

    void Update()
    {
        if (_model.readyToMove)
        {
            _model.Run();
        }
    }
}
