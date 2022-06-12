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

    // �ڸ� data ����
    void GenerateData()
    {
        // key = scene number*100 + a
        subtitleData.Add(101, new string[] { "�� 2 �ѷ��濡�� ��������� ��� �ֽ��ϴ�.\n���츦 ���� ȣ��� ���� �������Դϴ�." });
        subtitleData.Add(102, new string[] { "ȣ�� : �츮�� ������ �� ���� ����� ���տ� ���� ���ֿ� �ɷȾ�!" });
        subtitleData.Add(103, new string[] { "�濡 ������ 3���� �ð� ������ ������ ���ָ� Ǯ �� �־�." });
        subtitleData.Add(104, new string[] { "Ȥ�� �װ� ���ָ� Ǫ�� �� ������ �� �ִ�?" });

        subtitleData.Add(201, new string[] { "" });
        subtitleData.Add(202, new string[] { "" });
        subtitleData.Add(203, new string[] { "" });
        subtitleData.Add(204, new string[] { "" });

        subtitleData.Add(301, new string[] { "������ �Ҳ��� ã�� ���� �ٿ��ּ���" });
        subtitleData.Add(302, new string[] { "����!" });
        subtitleData.Add(303, new string[] { "�޺��� ã�ҽ��ϴ�!" });

        subtitleData.Add(501, new string[] { "���� ���� ���̳� �Գ׿�." });
        subtitleData.Add(502, new string[] { "������ ������ ������!" });
        subtitleData.Add(503, new string[] { "�����ε� ȭ����!" });

        subtitleData.Add(801, new string[] { "���ٸ��� �ǳʺ�����" });
        subtitleData.Add(802, new string[] { "���ƿ�! �ٽ� ���ư� �����?" });
        subtitleData.Add(803, new string[] { "������ ������ ������!" });
    }

    // subtitleData return
    public string GetTalkData(int id, int talkIndex)
    {
        if (talkIndex == subtitleData[id].Length)
            return null;

        return subtitleData[id][talkIndex];
    }
}