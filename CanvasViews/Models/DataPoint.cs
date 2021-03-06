﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ASPNET_MVC_Samples.Models
{
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public void setId(string _id)
        {
            this.id = _id;
        }

        public string getId()
        {
            return this.id;
        }

        public void setY(double _y)
        {
            this.Y = _y;
        }

        public void setLabel(string _label)
        {
            this.Label = _label;
        }

        public void setIndexLabel(string _indexlabel)
        {
            this.indexLabel = _indexlabel;
        }

        public void setName(string _name)
        {
            this.name = _name;
        }

        public DataPoint() { }

        public List<DataPoint> obtenerLista(int _nObjects)
        {
            List<DataPoint> listaDataPoints = new List<DataPoint>();
            for (int i = 0; i < _nObjects; i++)
            {
                DataPoint objDataPoint = new DataPoint();
                listaDataPoints.Add(objDataPoint);
            }
            return listaDataPoints;
        }

        [DataMember(Name = "label")]
        public string Label = null;

        [DataMember(Name = "indexLabel")]
        public string indexLabel = null;

        [DataMember(Name = "name")]
        public string name = null;

        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        [DataMember(Name = "id")]
        private string id = null;
    }


    public class clsStaticDataPoints
    {
        private static clsStaticDataPoints objStaticDataPoints = new clsStaticDataPoints();
        private List<List<DataPoint>> ListasDataPoints;

        private clsStaticDataPoints()
        {
            ListasDataPoints = new List<List<DataPoint>>();
        }

        public static clsStaticDataPoints obtenerclsStaticDataPoints()
        {
            return objStaticDataPoints;
        }

        public List<List<DataPoint>> getListasDataPoints()
        {
            return ListasDataPoints;
        }
    }
}