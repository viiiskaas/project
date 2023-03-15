using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private Text _countText;
    [SerializeField] private Text _winText;
    private Rigidbody _rigidBody;
    private int _count;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _count = 0;
        SetScoreText();
        _winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidBody.AddForce(movement * _speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        _countText.text = "Count: " + _count.ToString();
        if (_count >= 8)
        {
            _winText.text = "You win!";
        }
    }
}
