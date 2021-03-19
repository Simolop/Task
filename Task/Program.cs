using System;
using System.Collections.Generic;
using System.IO;

namespace GestioneDeiTask
{

    //enum LivelloImportanza
    //{
    //    Basso,
    //    Medio,
    //    Alto
    //}


    class Program
    {
        //Creo una classe Gestore per avere un posto che contenga tutti i task e ne crei di nuovi
        //Il gestore dei task viene gestita dalla mia applicazione , che è unica per tutti
        private static Gestore gestore = new Gestore();

        static void Main(string[] args)
        {
            Console.WriteLine("Gestione Task!");

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Crea task");
                Console.WriteLine("2. Definire livello di importanza");
                Console.WriteLine("3. Prospetto task inseriti");
                Console.WriteLine("4. Elimina Task");
                Console.WriteLine("5. Filtra Task per importanza");
                Console.WriteLine("6. Salva");
                Console.WriteLine("0. Esci");


                //per la scelta delle opzioni facciamo uno switch case
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        CreaTask();
                        break;
                    case '2':
                        DefinireImportanza();
                        break;
                    case '3':
                        ProspettoTaskInseriti();
                        break;
                    case '4':
                        EliminaTask();
                        break;
                    case '5':
                        //FiltraTask();
                        break;
                    case '6':
                        Salva();
                        break;
                    default:
                        Console.WriteLine(" Scelta non valida");
                        break;
                }
            } while (true);


            //Dictionary<int, LivelloImportanza> livello = new Dictionary<int, LivelloImportanza>();



        }

        //private static void FiltraTask()
        //{
            
        //}

        private static void DefinireImportanza()
        {
            Console.WriteLine();
            int id;
            do
                Console.Write("Numero del task di cui definire l'importanza: ");
            while (!int.TryParse(Console.ReadLine(), out id));

            if (gestore.Esiste(id))
            {
                Console.WriteLine("Scegli livello di importanza: Basso, Medio, Alto");
                do
                {


                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.B:
                            Console.WriteLine("Livello importanza basso");
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Livello importanza medio");
                            break;
                        case ConsoleKey.A:
                            Console.WriteLine("Livello importanza alto");
                            break;
                    }
                } while (true);
                
            }
            else
                    Console.WriteLine("Task inesistente");
        }
        

            private static void CreaTask()
            {
                Console.WriteLine("\nInserire attività: ");
                Task t = gestore.CreaTask(Console.ReadLine()); //chiama CreaTask in Gestore
                Console.WriteLine($"Task {t.ID} creato: {t.Descrizione}");
            }


            private static void ProspettoTaskInseriti()
            {
                Console.WriteLine($"Tutti i task inseriti: ");
                Console.WriteLine(gestore.Prospetto);
            }

            private static void EliminaTask()
            {
                Console.WriteLine();
                int id;
                do
                    Console.Write("Numero del task da eliminare: ");
                while (!int.TryParse(Console.ReadLine(), out id));

                //Se il task esiste eseguo l'operazione di eliminazione, altrimenti avviso l'utente che il numero inserito non corrisponde a nessun task
                if (gestore.Esiste(id))
                {
                    gestore.Elimina(id);
                    Console.WriteLine("Task eliminato correttamente");
                }
                else
                    Console.WriteLine("Task inesistente");
            }

            private static void Salva()
            {
                const string fileName = @"task.txt";

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    sw.WriteLine(gestore.Prospetto);

                    sw.Close();
                }
            }
        }
 


