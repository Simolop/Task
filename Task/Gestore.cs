using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneDeiTask
{
    public class Gestore
    {
        private int _ID;

        //uso le mappe per poter contenere tutti i task
        private Dictionary<int, Task> _task = new Dictionary<int, Task>();

        public string Prospetto
        {
            get
            {
                string s = ""; //deve contenere tutti i task inseriti
                foreach (Task t in _task.Values) //mi ritorna l'elenco dei valori
                    s += t.Prospetto + '\n';

                return s;
            }
        }

        
        public Task CreaTask(string descrizione)
        {
            Task t = new Task(++_ID, descrizione);

            //associo ad ogni id il task corrispondente
            _task.Add(t.ID, t);

            return t;
        }



        //Deve dirmi se esiste l'id così da dirmi se esiste il task corrispondente
        public bool Esiste(int id)
        {
            return _task.ContainsKey(id);
        }


        public void Elimina(int id)
        {
            _task.Remove(id);
        }

        
    }
}
