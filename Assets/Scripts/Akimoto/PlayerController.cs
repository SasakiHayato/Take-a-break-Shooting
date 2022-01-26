using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Field
    /// <summary>�ړ����x</summary>
    [SerializeField] float _speed = default;
    /// <summary>���͂���ǂꂭ�炢���ꂽ����͂��ꂽ�Ƃ��邩�̋���</summary>
    [SerializeField] float _moveDist = default;
    /// <summary>���͂̒��S�_����ǂꂭ�炢���ꂽ����͏ꏊ��MousePosition�ɋ߂Â��邩�̋���</summary>
    [SerializeField] float _inputDist = default;
    /// <summary>���͂��ꂽ�ʒu</summary>
    private Vector2 _defpos = default;
    #endregion

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _defpos = Input.mousePosition;
        }
        else if (Input.GetButton("Fire1"))
        {
            // �v���C���[�̓��͎�t
            float distX = _defpos.x - Input.mousePosition.x;
            float distY = _defpos.y - Input.mousePosition.y;
            float moveX = 0;
            float moveY = 0;
            if (distX > _moveDist)
            {
                moveX = -1;
            }
            if (distX < -_moveDist)
            {
                moveX = 1;
            }
            if (distY > _moveDist)
            {
                moveY = -1;
            }
            if (distY < -_moveDist)
            {
                moveY = 1;
            }
            Vector2 v = new Vector2(moveX, moveY).normalized;
            transform.Translate(v * _speed);
            // ���S�_�����炷����
            //float mouseX = 0;
            //float mouseY = 0;
            //if (distX > _inputDist)
            //{
            //    mouseX = Input.mousePosition.x + _inputDist;
            //}
            //if (distX < -_inputDist)
            //{
            //    mouseX = Input.mousePosition.x - _inputDist;
            //}
            //if (distY > _inputDist)
            //{
            //    mouseY = Input.mousePosition.y + _inputDist;
            //}
            //if (distY < -_inputDist)
            //{
            //    mouseY = Input.mousePosition.y - _inputDist;
            //}
        }
    }
    private void Fire()
    {

    }
}
