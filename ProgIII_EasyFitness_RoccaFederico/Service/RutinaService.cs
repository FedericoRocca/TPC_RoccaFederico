﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgIII_EasyFitness_RoccaFederico.Models;
using DataGateway;

namespace ProgIII_EasyFitness_RoccaFederico.Service
{
    public class RutinaService
    {
        public bool newRutina(RutinaModel _rutina)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery(
                    "insert into Rutinas " +
                    "values ('" + _rutina.idPersona + "', '" + _rutina.idEntrenamiento + "', '" + _rutina.descripcion + "', '" + _rutina.nombre + "');");
                data.sendStatement();
                if (data.getAffectedRows() <= 0)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RutinaModel> getRutinasByPersonaID(personaModel _persona)
        {
            try
            {
                DDBBGateway data = new DDBBGateway();
                data.prepareQuery("select * from Rutinas where idPersona = '" + _persona.id +"'");
                data.sendQuery();
                List<RutinaModel> listRutinas = new List<RutinaModel>();
                while( data.getReader().Read() )
                {
                    RutinaModel aux = new RutinaModel();
                    aux.id = long.Parse(data.getReader()["id"].ToString());
                    aux.idPersona = long.Parse(data.getReader()["idPersona"].ToString());
                    aux.idEntrenamiento = long.Parse(data.getReader()["idEntrenamiento"].ToString());
                    aux.descripcion = data.getReader()["descripcion"].ToString();
                    aux.nombre = data.getReader()["nombre"].ToString();
                    listRutinas.Add( aux );
                }
                return listRutinas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}