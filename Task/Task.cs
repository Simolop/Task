using System;
using System.Collections.Generic;


namespace GestioneDeiTask
{
    public class Task
    {
        

        public int ID { get; private set; }

        public string Descrizione { get; }

        public DateTime DataTask { get; }


        //controllo data di scadenza 
        //l'ho lasciata tra le ultime cose da vedere e aggiungere ma non ho fatto in tempo


        //Costruttore
        public Task(int id, string descrizione)
        {
            Descrizione = descrizione;
            ID = id;
        }


        



        public string Prospetto //proprietà
        {
            get
            {
                return $"Task: {ID}, Descrizione: {Descrizione}, Data: {DataTask}";
            }
        }


        
    }
}

