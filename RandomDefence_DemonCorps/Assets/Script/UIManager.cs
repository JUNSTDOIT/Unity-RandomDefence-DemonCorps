using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    TMP_Text _textWave;
    [SerializeField]
    TMP_Text _textWaveTime;
    [SerializeField]
    TMP_Text _textRunningTime;
    [SerializeField]
    TMP_Text _textWarning;
    [SerializeField]
    TMP_Text _textMoney;
    [SerializeField]
    Button _btnSummon;
    [SerializeField]
    Button _btnSale;
    [SerializeField]
    TMP_Dropdown _dropSaleSelect;
    [SerializeField]
    Button _btnReinforcement;
    [SerializeField]
    Button _btnSetting;
    float _runTimeSec = 0;
    int _runTimeMin = 0;
    MonCtrl[] _mons;
    int _randSpawn = 0;
    GameObject[] _units;
    int _money = 30;

    public void GetMoney()
    {
        _money++;
    }
    void Start()
    {
        _textWarning.enabled = false;
        _btnSummon.onClick.AddListener(RandomSpawn);
        _units = Resources.LoadAll<GameObject>("Prefab/Unit/");
        for(int i = 0; i < _units.Length; i++)
        {
            Debug.Log(_units[i].name);
        }
    }


    void Update()
    {
        RunTime();
        FindMonCount();
        Money();
    }
    void RunTime()
    {
        _runTimeSec += Time.deltaTime;

        _textRunningTime.text = "진행시간 : " + string.Format("{0:D2}:{1:D2}", _runTimeMin, (int)_runTimeSec);
        if((int)_runTimeSec > 59)
        {
            _runTimeSec = 0f;
            _runTimeMin++;
        }
    }
    void FindMonCount()
    {
        _mons = FindObjectsOfType<MonCtrl>();
        if (_mons != null && _mons.Length < 60)
            _textWarning.enabled = false;
        else
        {
            _textWarning.enabled = true;
            //Debug.Log(_mons.Length);
        }
    }
    void RandomSpawn()
    {
        if (_money < 10)
            return;
        else
        {
            _money -= 10;
            _randSpawn = Random.Range(0, 100000);
            if (_randSpawn >= 0 && _randSpawn < 19)
            {
                Debug.Log("1");
                GameObject nomal = Instantiate(_units[8]);
                nomal.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 19 && _randSpawn < 159)
            {
                Debug.Log("2");
                GameObject superior1 = Instantiate(_units[7]);
                superior1.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 159 && _randSpawn < 299)
            {
                Debug.Log("3");
                GameObject superior2 = Instantiate(_units[6]);
                superior2.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 299 && _randSpawn < 1599)
            {
                Debug.Log("4");
                GameObject rare = Instantiate(_units[5]);
                rare.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 1599 && _randSpawn < 6699)
            {
                Debug.Log("5");
                GameObject hero = Instantiate(_units[4]);
                hero.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 6699 && _randSpawn < 16899)
            {
                Debug.Log("6");
                GameObject legend = Instantiate(_units[3]);
                legend.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 16899 && _randSpawn < 33449)
            {
                Debug.Log("7");
                GameObject myth1 = Instantiate(_units[2]);
                myth1.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else if (_randSpawn >= 33449 && _randSpawn < 49999)
            {
                Debug.Log("8");
                GameObject myth2 = Instantiate(_units[1]);
                myth2.transform.position = new Vector3(0f, 0.5f, 0f);
            }
            else
            {
                Debug.Log("9");
                GameObject god = Instantiate(_units[0]);
                god.transform.position = new Vector3(0f, 0.5f, 0f);
            }
        }
    }
    void Money()
    {
        _textMoney.text = "소지금\n" + _money.ToString();
    }
}
