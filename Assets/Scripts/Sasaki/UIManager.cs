using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [SerializeField] string _canvasName;
    [SerializeField] List<UIData> _uiDatas = new List<UIData>();

    [System.Serializable]
    class UIData
    {
        public GameState State;
        public Image Panel;
    }

    GameObject _saveObj = null;

    /// <summary>
    /// �X�e�[�g���X�V�����ۂɌĂԁB
    /// </summary>
    /// <param name="state">���݂�GameState</param>
    public void UpdateGameState(GameState state)
    {
        GameObject canvas = GameObject.Find(_canvasName);
        SetPanel(_uiDatas.First(p => p.State == state), canvas);
    }

    /// <summary>
    /// Debug�p��UI�\��
    /// </summary>
    /// <param name="id">GameState�̎w��</param>
    public void DebugGetState(int id)
    {
        GameState state = (GameState)System.Enum.ToObject(typeof(GameState), id);
        GameObject canvas = GameObject.Find(_canvasName);
        SetPanel(_uiDatas.First(p => p.State == state), canvas);
    }

    void SetPanel(UIData uiData, GameObject canvas)
    {
        GameObject panel = Instantiate(uiData.Panel.gameObject);
        if (_saveObj != null)
        {
            Destroy(_saveObj);
            _saveObj = panel;
        }
        else
        {
            _saveObj = panel;
        }
        
        _saveObj.transform.SetParent(canvas.transform);
        RectTransform rect = _saveObj.GetRect();
        rect.localScale = Vector2.one;
        rect.anchoredPosition = Vector3.zero;
    }
}
