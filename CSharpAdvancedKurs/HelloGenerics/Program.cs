using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Listen verwenden intern ein Array -> hat eine Default-Länge 4 Array-Felder 
            //Wenn diese 4 Felder gefüllt sind, wir das Array von der Größe verdoppelt
            List<string> stringListe = new List<string>();
            stringListe.Add("Max");
            stringListe.Add("Moritz");

            IDictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Peter");


            Hashtable hashtable = new Hashtable();

            hashtable.Add("hallo", 123);
            hashtable.Add(123, "hello");
            hashtable.Add(new StringBuilder(), 123);
            hashtable.Add(DateTime.Now, "test");


            DataStore<string> dataStore = new();
            dataStore.AddOrUpdate(0, "Hallo");
            dataStore.AddOrUpdate(1, "liebe");
            dataStore.AddOrUpdate(2, "Teilnehmer");
        }
    }

    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public T GetDataOrDefault(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T); // T == null
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }
    }
}
