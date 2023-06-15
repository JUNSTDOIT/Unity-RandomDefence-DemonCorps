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
    Button _btnSell;
    [SerializeField]
    TMP_Dropdown _dropSellSelect;
    [SerializeField]
    Button _btnReinforcement;
    float _runTimeSec = 0;
    int _runTimeMin = 0;
    MonCtrl[] _mons;
    int _randSpawn = 0;
    GameObject[] _units;
    int _money = 30;
    List<string> _dropOption = new List<string>();
    int _reinforcementLv = 0;
    int _reinforcementCost = 1;
    OBJAttack[] _fieldUnits;
    int _wave = 0;
    float _waveTime = 10f;
    int _monCount = 0;
    public void MonCount() => _monCount++;
    public int _ReinforcementLv => _reinforcementLv;

    public void GetMoney()
    {
        _money++;
    }
    void Start()
    {
        _textWarning.enabled = false;
        _btnSummon.onClick.AddListener(RandomSpawn);
        _units = Resources.LoadAll<GameObject>("Prefab/Unit/");
        _dropSellSelect.ClearOptions();
        _dropOption.Add("일반\n1");
        _dropOption.Add("고급\n5");
        _dropOption.Add("희귀\n15");
        _dropOption.Add("영웅\n30");
        _dropOption.Add("전설\n100");
        _dropOption.Add("신화\n500");
        _dropOption.Add("신\n999");
        _dropSellSelect.AddOptions(_dropOption);
        _btnReinforcement.onClick.AddListener(Reinforcement);
        _btnSell.onClick.AddListener(Sell);
    }


    void Update()
    {
        RunTime();
        GameResult();
        Money();
        Wave();
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
    void Reinforcement()
    {
        if (_money < _reinforcementCost)
            return;
        else
        {
            _money -= _reinforcementCost;
            _reinforcementLv++;
            _reinforcementCost += 2;
            _btnReinforcement.GetComponentInChildren<TMP_Text>().text = "+" + _reinforcementLv.ToString() + "\n강화\n" + _reinforcementCost.ToString();
        }
    }
    void Sell()
    {
        _fieldUnits = FindObjectsOfType<OBJAttack>();
        if(_fieldUnits != null)
        {
            for (int i = 0; i < _fieldUnits.Length; i++)
            {
                var results = _fieldUnits[i].name.Split('.');
                int type = int.Parse(results[0]);
                if(type == 1 && _dropSellSelect.value == 0)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 1;
                    break;
                }
                else if(type == 2 && _dropSellSelect.value == 1)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 5;
                    break;
                }
                else if (type == 3 && _dropSellSelect.value == 1)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 5;
                    break;
                }
                else if (type == 4 && _dropSellSelect.value == 2)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 15;
                    break;
                }
                else if (type == 5 && _dropSellSelect.value == 3)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 30;
                    break;
                }
                else if (type == 6 && _dropSellSelect.value == 4)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 100;
                    break;
                }
                else if (type == 7 && _dropSellSelect.value == 5)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 500;
                    break;
                }
                else if (type == 8 && _dropSellSelect.value == 5)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 500;
                    break;
                }
                else if (type == 9 && _dropSellSelect.value == 6)
                {
                    Destroy(_fieldUnits[i].gameObject);
                    _money += 999;
                    break;
                }
            }
        }
    }
    void Wave()
    {
        if (_wave == 0)
            _waveTime -= Time.deltaTime;
        else
        {
            _waveTime -= Time.deltaTime;
            _textWaveTime.text = ((int)_waveTime).ToString();
        }
        if (_waveTime <= 0f)
        {
            _wave++;
            _waveTime = 60f;
            _textWave.text = _wave.ToString();
        }
    }
    void GameResult()
    {
        _mons = FindObjectsOfType<MonCtrl>();
        if (_mons != null && _mons.Length < 60)
            _textWarning.enabled = false;
        else
        {
            _textWarning.enabled = true;
        }
        if (_mons != null && _mons.Length > 100)
        {
            Debug.Log("게임오버");
            Time.timeScale = 0;
        }
        else if (_wave == 6)
        {
            Debug.Log("게임오버");
            Time.timeScale = 0;
        }
        else if (_wave == 5 && _monCount == 500)
        {
            Debug.Log("게임승리");
            Time.timeScale = 0;
        }
    }
}
