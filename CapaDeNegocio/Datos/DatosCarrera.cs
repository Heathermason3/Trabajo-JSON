using CapaDeNegocio.Clases;
using Crud;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CapaDeNegocio.Datos
{
    internal class DatosCarrera : IAccesoADatos<Carrera>
    {
        private static List<Carrera> listaCarreras;
        private static int lastId;

        private static void Read()
        {

            try
            {

                string path = "C:\\Users\\Pedro\\Desktop\\WebEscuelaJson-main\\CapaDeNegocio\\Datos\\carreras.json";
                string json = File.ReadAllText(path);
                listaCarreras = JsonSerializer.Deserialize<List<Carrera>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {

            try
            {
                string path = "C:\\Users\\Pedro\\Desktop\\WebEscuelaJson-main\\CapaDeNegocio\\Datos\\carreras.json";
                string json = JsonSerializer.Serialize(listaCarreras);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            listaCarreras.Clear();
        }
        public void Add(Carrera data)
        {
            Read();
            string pathID = @"C:\Users\Pedro\Desktop\WebEscuelaJson-main\CapaDeNegocio\Datos\CarreraLastId.txt";
            lastId = int.Parse(File.ReadAllText(pathID));
            data.ID = ++lastId;
            File.WriteAllText(pathID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            Carrera data1 = data;
            listaCarreras.Add(data1);
            Write();
            Clear();




        }

        public void Erase(Carrera data)
        {
            Read();
            foreach (Carrera u in listaCarreras)
            {
                if (data.ID == u.ID)
                {
                    listaCarreras.Remove(data);
                    Write();
                    Clear();
                    return;


                }

            }
            Clear();
            throw new Exception("No se encontró la carrera a elimnar");



        }

        public Carrera Find(Carrera data)
        {
            Read();
            foreach (Carrera c in listaCarreras)
            {
                if (data.ID == c.ID)
                {
                    Clear();
                    return c;

                }

            }
            Clear();
            throw new Exception("No se encontró la carrera");
        }

        public void Modify(Carrera data)
        {
            Read();
            for (int i = 0; i < listaCarreras.Count; i++)
            {
                if (listaCarreras[i].ID == data.ID)
                {
                    listaCarreras[i].Nombre = data.Nombre;
                    Write();
                    Clear();
                    return;

                }
            }
            throw new Exception("No se puede modificar la carrera : no se encuentra en la lista");


        }

        public string List()
        {
            Read();
            string json = JsonSerializer.Serialize(listaCarreras);
            return json;
        }
    }
}
