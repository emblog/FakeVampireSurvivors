using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class UnitySpreadSheetRequester : MonoBehaviour
{
	const string TableKey = @"1LxKIpWj4yJIgKo17n0neTPi_RtS0O8aodvCJ_dOmW4U";
	const string strURLBase = @"http://spreadsheets.google.com/a/google.com/tq?key={0}&gid={1}";

	StringBuilder m_cBuilder = new StringBuilder();

	public void Request<T>(int a_nTableID, System.Action<List<T>> a_fpOnResponse)
		where T : struct
	{
		StartCoroutine(_Request<T>(a_nTableID, a_fpOnResponse));
	}

	IEnumerator _Request<T>(int a_nTableID, System.Action<List<T>> a_fpOnResponse)
		where T : struct
	{
		string url = string.Format(strURLBase, TableKey, a_nTableID);

		UnityWebRequest www = UnityWebRequest.Get(url);

		yield return www.SendWebRequest();

		while (www.isDone == false)
		{
			yield return null;
		}

		List<T> liData = null;

		if (www.result == UnityWebRequest.Result.Success)
		{
			ParsingData<T>(www.downloadHandler.text, out liData);
		}

		if (a_fpOnResponse != null)
		{
			a_fpOnResponse(liData);
		}
	}

	bool ParsingData<T>(string s, out List<T> a_refContainer)
	{
		bool bResult = true;

		a_refContainer = null;

		try
		{
			// 필요없는 문자열 제거
			int nStart = s.IndexOf("(");
			int nEnd = s.IndexOf(");");
			++nStart;

			string data = s.Substring(nStart, nEnd - nStart);

			// 실제 값 파싱
			List<string> liColumnName = new List<string>();
			List<string> liValues = new List<string>();

			LitJson.JsonReader reader = new LitJson.JsonReader(data);
			var mapParsed = LitJson.JsonMapper.ToObject(reader);
			var map = mapParsed["table"];

			var liName = map["cols"];
			var liVal = map["rows"];

			// 테이블 명 캐싱
			for (int i = 0; i < liName.Count; ++i)
			{
				var m1 = liName[i];
				liColumnName.Add((string)m1["label"]);
			}

			// 전체 값 캐싱
			for (int i = 0; i < liVal.Count; ++i)
			{
				var m2 = liVal[i];
				var li = m2["c"];

				for (int j = 0; j < li.Count; ++j)
				{
					var v = li[j];

					string value = string.Empty;

					if (v.ContainsKey("f") == true)
					{
						value = (string)v["f"];
					}
					else
					{
						value = (string)v["v"];
					}

					if (value == string.Empty)
					{
						Debug.LogError("table error");
					}

					liValues.Add(value);
				}
			}

			int nColumnCount = liColumnName.Count;
			int nRowCount = liValues.Count / nColumnCount;

			if (liValues.Count % nColumnCount != 0)
			{
				Debug.LogError("empty table value exist");
				return false;
			}

			m_cBuilder.Clear();
			JsonWriter writer = new JsonWriter(m_cBuilder);
			writer.WriteArrayStart();

			int index = 0;
			for (int j = 0; j < nRowCount; ++j)
			{
				writer.WriteObjectStart();

				for (int i = 0; i < nColumnCount; ++i)
				{
					writer.WritePropertyName(liColumnName[i]);
					writer.Write(liValues[index++]);
				}

				writer.WriteObjectEnd();
			}

			writer.WriteArrayEnd();

			a_refContainer = JsonMapper.ToObject<List<T>>(m_cBuilder.ToString());
		}
		catch (Exception e)
		{
			Debug.LogError("FVS - Exception Occured" + e.Message);
			bResult = false;
		}

		return bResult;
	}
}