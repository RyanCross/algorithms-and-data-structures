using System;
using AlgorithmsAndDataStructures.src.hashtable;
using AlgorithmsAndDataStructures.src.util;
using AlgorithmsAndDataStructures.src.sorting.quicksort;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace AlgorithmsAndDataStructures
{

    // Classes for reading in data from xivapi.com
    public class Rootobject
    {
        public Pagination Pagination { get; set; }
        public Result[] Results { get; set; }
    }
    public class Pagination
    {
        public int Page { get; set; }
        public int PageNext { get; set; }
        public object PagePrev { get; set; }
        public int PageTotal { get; set; }
        public int Results { get; set; }
        public int ResultsPerPage { get; set; }
        public int ResultsTotal { get; set; }
    }

    public class Result
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestHashTableWithFinalFantasyAPI();
        }

        static void TestQuickSort()
        {
            int[] TestDataSet1 = new int[] { -3, 2, -5, 3, 5, 8, 4, 0, 11, -10, 7 }; //note there are no duplicates
            Quicksort.Sort(0, TestDataSet1.Length - 1, TestDataSet1);
        }

        static void TestHashTableWithFinalFantasyAPI()
        {
            int initTableSize = 150;

            string baseUrl = "https://xivapi.com";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //https://xivapi.com/search?filters=ActionCategory.Name_en=Weaponskill&limit=100 - Get all skills that are weaponskills
            Rootobject weaponSkillSearch = client.GetFromJsonAsync<Rootobject>("search?filters=ActionCategory.Name_en=Weaponskill&limit" + 100).Result; //Result blocks the calling thread until task completion, making this a synchronous operation

            StringHashTable skills = new StringHashTable(initTableSize);
            for (int i = 0; i < weaponSkillSearch.Results.Length; i++)
            {
                skills.Insert(new StringKeyValuePair(weaponSkillSearch.Results[i].ID.ToString(), weaponSkillSearch.Results[i].Name));
            }

            TestHashTableDelete(skills, "51"); // Steel Cyclone, Index 7[1]
            TestHashTableDelete(skills, "347"); //Sticky Tongue, Index 7

            //TODO check comments around testing HashTable contains/deletes method around hashcode and equals, maybe implement some tests via a testing framework?

            client.Dispose();
        }

        static void TestHashTableDelete(StringHashTable ht, string keyToRemove)
        {
            ht.Delete(keyToRemove);
        }
    }
}
