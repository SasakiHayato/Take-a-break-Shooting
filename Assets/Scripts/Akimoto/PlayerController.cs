using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Field
    /// <summary>移動速度</summary>
    [SerializeField] float _speed = default;
    /// <summary>入力からどれくらい離れたら入力されたとするかの距離</summary>
    [SerializeField] float _moveDist = default;
    /// <summary>入力の中心点からどれくらい離れたら入力場所をMousePositionに近づけるかの距離</summary>
    [SerializeField] float _inputDist = default;
    /// <summary>入力された位置</summary>
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
            // プレイヤーの入力受付
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
            // 中心点をずらす処理
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
