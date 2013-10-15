////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Daniel Du 2013 - ADN/Developer Technical Services
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Geo.Abstractions.Interfaces;
//using Geo.Geometries;
//using Geo.IO.GeoJson;
using InfraworkApiLib.Models;
using Newtonsoft.Json;
using RestSharp;

namespace InfraworkApiLib.Client
{
    public class InfraworksRestClient
    {
        

        private RestClient m_client;


        public InfraworksRestClient()
        {
            if (m_client == null)
            {
                m_client = new RestClient(ConfidentialConsts.baseUrl);
            }
            
        }


        public List<InfraworksService> GetServices()
        {
            string resource = "/";
            RestRequest request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/vnd.autodesk.infraworks-v1+json"); //"Accept", "A" should be captalized

            IRestResponse<InfraworksService> response = m_client.Execute<InfraworksService>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Content;

                List<InfraworksService> allSvcs = JsonConvert.DeserializeObject<List<InfraworksService>>(json);
                return allSvcs;

            }
            else
            {
                return null;
            }
        }


        public List<Model> GetModels()
        {
            string resource = "/data/models";
            RestRequest request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/vnd.autodesk.infraworks-v1+json"); //"Accept", "A" should be captalized

            IRestResponse response = m_client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Content;

                List<Model> models = JsonConvert.DeserializeObject<List<Model>>(json);
                return models;

            }
            else
            {
                return null;
            }
        }

        public Model GetModelById(int modelId)
        {
            string resource = String.Format("/data/models/{0}", modelId);
            RestRequest request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/vnd.autodesk.infraworks-v1+json"); //"Accept", "A" should be captalized

            IRestResponse response = m_client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Content;

                Model model = JsonConvert.DeserializeObject<Model>(json);
                return model;

            }
            else
            {
                return null;
            }
        }

        public List<Class> GetClassesInModel(int modelId)
        {
            Model model = GetModelById(modelId);
            List<Class> classes = new List<Class>(); 

            foreach (var item in model.classes)
            {
                classes.Add(item);
            }

            return classes;
        }

        public Collection GetItemsByClass(int modelId, string className)
        {
            string resource = String.Format("/data/models/{0}/{1}/{2}", modelId,className,className);
            RestRequest request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/vnd.autodesk.infraworks-v1+json"); //"Accept", "A" should be captalized

            IRestResponse response = m_client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Content;

                Collection items = JsonConvert.DeserializeObject<Collection>(json);
                return items;

            }
            else
            {
                return null;
            }
          
        }


        public T GetModelItem<T>(int modelId, string class_type, string collection, int itemId)
        {
            string resource = String.Format("/data/models/{0}/{1}/{2}/{3}", modelId, class_type, collection, itemId);
            RestRequest request = new RestRequest(resource, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/vnd.autodesk.infraworks-v1+json"); //"Accept", "A" should be captalized

            IRestResponse response = m_client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string json = response.Content;

                T item = JsonConvert.DeserializeObject<T>(json);

                return item;

            }
            else
            {
                return default(T);
            }
        }

        public Terrain_Texture GetModelItem(int modelId, string class_type, string collection, int itemId)
        {
            Terrain_Texture item = GetModelItem<Terrain_Texture>(modelId, class_type, collection, itemId);

            ////parse GeoJSON
            //string geomJson = item.geometry_raw.ToString();
            //var reader = new GeoJsonReader();
            //Polygon geom = reader.Read(geomJson) as Polygon;

            //item.Geometry = geom;

            return item;

        }
    }
}
