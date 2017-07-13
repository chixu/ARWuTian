using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {


	public static List<T> ReorderArray<T>(List<T> list){
		List<T> res = new List<T> ();
		List<int> idxes = IntArray(list.Count);
		for (int i = 0; i < list.Count; i++) {
			int idx = UnityEngine.Random.Range (0, idxes.Count - 1);
			res.Add (list [idxes[idx]]);
			idxes.RemoveAt (idx);
		}
		return res;
	}

	public static List<int> IntArray(int num){
		List<int> res = new List<int> ();
		for (int i = 0; i < num; i++)
			res.Add (i);
		return res;
	}

	public static List<int> RandomIntArray(int num){

		return ReorderArray<int> (IntArray (num));
	}
}
