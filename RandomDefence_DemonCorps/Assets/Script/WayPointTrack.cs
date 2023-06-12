//==================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//==================================================================
public class WayPointTrack : MonoBehaviour
{
    //------------------------------
    [ Header("[ 트랙 라인 색깔.. ]"), SerializeField ]
    Color _lineColor = Color.yellow;
    //------------------------------
    [Header("[ 렌더러 토글.. ]"), SerializeField]
    bool _isRender = true;
    //------------------------------
    [Header("[ 웨이 포인트 트랜스폼 배열.. ]"), SerializeField]
    Transform[] _wayPts;
    //------------------------------

    private void OnDrawGizmos()
    {
        //  웨이 포인트 트랜스폼 캐싱..
        _wayPts = GetComponentsInChildren<Transform>();

        //  라인 색 지정..
        Gizmos.color = _lineColor;

        //  다음 웨이포인트 인덱스..
        //  GetComponentsInChildren
        //  -   특정 게임오브젝트의 자식 오브젝트들로부터 특정 컴포넌트들의 참조값들을 반환..
        //  -   해당 게임오브젝트에게도 동일한 컴포넌트가 있다면 반환값에 포함..
        //      -   nextIdx 를 1로 초기화한 이유..
        int nextIdx = 1;
        Vector3 currPos = _wayPts[nextIdx].position;
        Vector3 nextPos;

        for( int idx = 0; idx < _wayPts.Length; ++idx )
        {
            nextPos = (++nextIdx >= _wayPts.Length ) ? _wayPts[1].position : _wayPts[nextIdx].position;
            //  씬 안에 선 그리기..
            Gizmos.DrawLine(currPos, nextPos);
            currPos = nextPos;

            //  렌더러 토글..
            Renderer rnd = _wayPts[idx].GetComponent<Renderer>();
            if (rnd != null) rnd.enabled = _isRender;

        }// for( int idx = 0; idx < _wayPts.Length; ++idx )

    }// private void OnDrawGizmos()
    //------------------------------

}// public class WayPointTrack : MonoBehaviour
 //==================================================================