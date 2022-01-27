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

    private static UIManager _instance = null;
    public static UIManager Instance => _instance;

    GameObject _canvas;

    GameObject _saveObj = null;
    Image _rightPanel = null;

    void Awake()
    {
        _instance = this;
        _canvas = GameObject.Find(_canvasName);
        SetRightPanel();
    }

    void SetRightPanel()
    {
        GameObject obj = new GameObject("RightPanel");
        _rightPanel = obj.AddComponent<Image>();
        _rightPanel.transform.SetParent(_canvas.transform);
        _rightPanel.raycastTarget = false;
        Color color = _rightPanel.color;
        color = Color.black;
        color.a = 0;
        _rightPanel.color = color;

        RectTransform rect = _rightPanel.GetRect();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
    }

    /// <summary>
    /// RightPanelのAlfa値が変更された際に呼ぶ。
    /// </summary>
    /// <param name="rate">Alfa値の割合</param>
    public void UpdateRightPanel(float rate)
    {
        float a = Mathf.Lerp(0, 0.7f, rate);
        Color color = _rightPanel.color;
        color.a = a;
        _rightPanel.color = color;
        _rightPanel.GetRect().SetAsLastSibling();
    }

    /// <summary>
    /// ステートが更新される際に呼ぶ。
    /// </summary>
    /// <param name="state">現在のGameState</param>
    public void UpdateGameState(GameState state)
    {
        SetPanel(_uiDatas.First(p => p.State == state), _canvas);
    }

    /// <summary>
    /// Debug用のUI表示
    /// </summary>
    /// <param name="id">GameStateの指定</param>
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
