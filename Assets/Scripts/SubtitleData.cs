using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleData : MonoBehaviour
{
    Dictionary<int, string[]> subtitleData;

    void Awake()
    {
        subtitleData = new Dictionary<int, string[]>();

        GenerateData();
    }

    // 자막 data 생성
    void GenerateData()
    {
        // key = scene number*100 + a
        subtitleData.Add(101, new string[] { "제 2 둘레길에는 도깨비들이 살고 있습니다.\n여우를 닮은 호비는 막내 도깨비입니다." });
        subtitleData.Add(102, new string[] { "호비 : 우리의 터전인 이 길이 사악한 마왕에 의해 저주에 걸렸어!" });
        subtitleData.Add(103, new string[] { "길에 숨겨진 3개의 시간 조각을 모으면 저주를 풀 수 있어." });
        subtitleData.Add(104, new string[] { "혹시 네가 저주를 푸는 걸 도와줄 수 있니?" });

        subtitleData.Add(201, new string[] { "" });
        subtitleData.Add(202, new string[] { "" });
        subtitleData.Add(203, new string[] { "" });
        subtitleData.Add(204, new string[] { "" });

        subtitleData.Add(301, new string[] { "정의의 불꽃을 찾아 불을 붙여주세요" });
        subtitleData.Add(302, new string[] { "성공!" });
        subtitleData.Add(303, new string[] { "햇빛을 찾았습니다!" });

        subtitleData.Add(501, new string[] { "벌써 길의 반이나 왔네요." });
        subtitleData.Add(502, new string[] { "현재의 조각을 얻었어요!" });
        subtitleData.Add(503, new string[] { "앞으로도 화이팅!" });

        subtitleData.Add(801, new string[] { "섭다리를 건너보세요" });
        subtitleData.Add(802, new string[] { "좋아요! 다시 돌아가 볼까요?" });
        subtitleData.Add(803, new string[] { "과거의 조각을 얻었어요!" });
    }

    // subtitleData return
    public string GetTalkData(int id, int talkIndex)
    {
        if (talkIndex == subtitleData[id].Length)
            return null;

        return subtitleData[id][talkIndex];
    }
}