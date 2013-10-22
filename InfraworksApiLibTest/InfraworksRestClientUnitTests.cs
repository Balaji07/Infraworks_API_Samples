﻿////////////////////////////////////////////////////////////////////////////////
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

using InfraworkApiLib.Client;
using InfraworkApiLib.Models;
using InfraworkApiLib.Models.Geometries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InfraworksApiLibTest
{
    [TestClass]
    public class InfraworksRestClientUnitTests
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void GetServicesTest()
        {

            InfraworksRestClient iwSvc = new InfraworksRestClient();
            List<InfraworksService> allServices = iwSvc.GetServices();

            Assert.IsNotNull(allServices,"null result, error happens.");
            Assert.AreEqual("Infraworks Web-Services API", allServices[0].name);

        }

        [TestMethod]
        public void GetModelsTest()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            List<ModelInfo> models = iwSvc.GetModels();

            Assert.IsNotNull(models, "null result, error happens.");
            Assert.AreEqual("San Francisco", models[0].name);
        }

        [TestMethod]
        public void GetModelByIdTest()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            ModelInfo model = iwSvc.GetModelById(1);

            Assert.IsNotNull(model, "null result, error happens.");
            Assert.AreEqual("San Francisco", model.name);
            Assert.AreEqual("http://api.infraworks.autodesk.com/data/models", model.parent);
            Assert.IsTrue(model.modelClasses.Count > 0);
            Assert.AreEqual("terrain_textures", model.modelClasses[0].name);
            Assert.AreEqual("http://api.infraworks.autodesk.com/data/models/1/terrain_textures/terrain_textures",model.modelClasses[0].href);
        }

        [TestMethod]
        public void GetClassesInModelTest()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            List<ModelClass> classes = iwSvc.GetClassesInModel(1);

            Assert.IsNotNull(classes, "null result, error happens.");
            Assert.IsTrue(classes.Count > 0);
            Assert.AreEqual("terrain_textures", classes[0].name);
            Assert.AreEqual("http://api.infraworks.autodesk.com/data/models/1/terrain_textures/terrain_textures", classes[0].href);


        }

        [TestMethod]
        public void GetItemsByClassTest()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            Collection terrain_TextureCollection = iwSvc.GetItemsByClass(1, "terrain_textures");

            Assert.IsNotNull(terrain_TextureCollection, "null result, error happens.");
            Assert.AreEqual("101", terrain_TextureCollection.type);
            Assert.IsTrue(terrain_TextureCollection.items.Count > 0);
            Assert.AreEqual( "http://api.infraworks.autodesk.com/data/models/1/terrain_textures/terrain_textures/1", terrain_TextureCollection.items[0].href);

        }

        [TestMethod]
        public void GetModelItem_Tree_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Tree tree = iwSvc.GetModelItem<Tree>(1, "trees", "trees", 1);
            Assert.IsNotNull(tree, "null result, error happens.");
            Assert.AreEqual("1", tree.id);
            Assert.AreEqual(AiwGeometryType.Point, tree.geometry.Type);
            Assert.AreEqual(-122.389268752158, (tree.geometry as AiwPoint).Coordinate.X);

        }

        [TestMethod]
        public void GetModelItem_Road_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Road road = iwSvc.GetModelItem<Road>(1, "roads", "roads", 2);
            Assert.IsNotNull(road, "null result, error happens.");
            Assert.AreEqual("2", road.id);
            Assert.AreEqual(AiwGeometryType.LineString, road.geometry.Type);
            Assert.IsTrue((road.geometry as AiwLineString).Coordinates.Length > 0);
            Assert.AreEqual("road_2", road.name);
            Assert.AreEqual(-122.41025187194973, (road.geometry as AiwLineString).Coordinates[0].X, 0.001);

        }

        [TestMethod]
        public void GetModelItem_Terrain_Texture_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            Terrain_Texture terrain_Texture = iwSvc.GetModelItem<Terrain_Texture>(1, "terrain_textures", "terrain_textures", 1);

            Assert.IsNotNull(terrain_Texture, "null result, error happens.");
            Assert.AreEqual("1", terrain_Texture.id);
            Assert.AreEqual(AiwGeometryType.Polygon, terrain_Texture.geometry.Type);
            Assert.IsTrue((terrain_Texture.geometry as AiwPolygon).LinearRings[0].Coordinates.Length > 0);

            Assert.AreEqual(-122.40065974864822, (terrain_Texture.geometry as AiwPolygon).LinearRings[0].Coordinates[0].X, 0.001 );


        }

        [TestMethod]
        public void GetModelItem_Terrain_Surface_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Terrain_Surface surface = iwSvc.GetModelItem<Terrain_Surface>(1, "terrain_surfaces", "terrain_surfaces", 1);
            Assert.IsNotNull(surface, "null result, error happens.");
            Assert.AreEqual("1", surface.id);
            Assert.AreEqual(AiwGeometryType.Polygon, surface.geometry.Type);
            Assert.IsTrue((surface.geometry as AiwPolygon).LinearRings[0].Coordinates.Length > 0);
            Assert.AreEqual(-122.39651068043577, (surface.geometry as AiwPolygon).LinearRings[0].Coordinates[0].X, 0.001);

            Assert.AreEqual(AiwGeometryType.NoGeometry, surface.offset.Type);

            Assert.AreEqual(AiwGeometryType.Matrix3d, surface.cell_orientation.Type);
            Assert.AreEqual(8.429137, (surface.cell_orientation as AiwMatrix3d).Vectors[0].Coordinate.X, 0.001);

            Assert.AreEqual(AiwGeometryType.Vector, surface.cells.Type);
            Assert.AreEqual(1402, (surface.cells as AiwVector).Coordinate.X, 0.001);
        }

        [TestMethod]
        public void GetModelItem_Markup_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Markup markup = iwSvc.GetModelItem<Markup>(1, "markup", "markup", 1);
            Assert.IsNotNull(markup, "null result, error happens.");
            Assert.AreEqual("1", markup.id);

            Assert.AreEqual(AiwGeometryType.LineString, markup.geometry.Type);
            Assert.IsTrue((markup.geometry as AiwLineString).Coordinates.Length > 0);
            Assert.AreEqual(-122.39744890341224, (markup.geometry as AiwLineString).Coordinates[0].X, 0.00000000001);

            Assert.AreEqual(AiwGeometryType.Vector, markup.scale.Type);
            Assert.AreEqual(1.4, (markup.scale as AiwVector).Coordinate.Y, 0.001);

        }

        [TestMethod]
        public void GetModelItem_Water_Area_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Water_Area water_area = iwSvc.GetModelItem<Water_Area>(1, "water_areas", "water_areas", 1);
            Assert.IsNotNull(water_area, "null result, error happens.");
            Assert.AreEqual("1", water_area.id);

            Assert.AreEqual(AiwGeometryType.Polygon, water_area.geometry.Type);
            Assert.AreEqual(-122.59862145026804, (water_area.geometry as AiwPolygon).LinearRings[0].Coordinates[0].X, 0.000001);

            Assert.AreEqual(AiwGeometryType.NoGeometry, water_area.model_scale.Type);
        }

        [TestMethod]
        public void GetModelItem_Coverage_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Coverage coverage = iwSvc.GetModelItem<Coverage>(1, "coverages", "coverages", 7);
            Assert.IsNotNull(coverage, "null result, error happens.");
            Assert.AreEqual("7", coverage.id);

            Assert.AreEqual(AiwGeometryType.Polygon, coverage.geometry.Type);
            Assert.AreEqual(-122.39240418068935, (coverage.geometry as AiwPolygon).LinearRings[0].Coordinates[0].X, 0.000001);

            Assert.AreEqual(AiwGeometryType.NoGeometry, coverage.model_scale.Type);

        }

        [TestMethod]
        public void GetModelItem_Pipeline_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            PipeLine pipeline = iwSvc.GetModelItem<PipeLine>(1, "pipelines", "pipelines", 1);
            Assert.IsNotNull(pipeline, "null result, error happens.");
            Assert.AreEqual("1", pipeline.id);
            Assert.AreEqual(AiwGeometryType.LineString, pipeline.geometry.Type);
            Assert.IsTrue((pipeline.geometry as AiwLineString).Coordinates.Length > 0);
            Assert.AreEqual(-122.54744280070685, (pipeline.geometry as AiwLineString).Coordinates[0].X, 0.001);

            Assert.AreEqual(AiwGeometryType.NoGeometry, pipeline.model_rotate.Type);

            
        }

        [TestMethod]
        public void GetModelItem_Railway_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            Railway railway = iwSvc.GetModelItem<Railway>(1, "railways", "railways", 16);
            Assert.IsNotNull(railway, "null result, error happens.");
            Assert.AreEqual("16", railway.id);
            Assert.AreEqual(AiwGeometryType.LineString, railway.geometry.Type);
            Assert.IsTrue((railway.geometry as AiwLineString).Coordinates.Length > 0);
            Assert.AreEqual(-122.38800243418041, (railway.geometry as AiwLineString).Coordinates[0].X, 0.001);

            Assert.AreEqual(AiwGeometryType.NoGeometry, railway.model_rotate.Type);


        }

        [TestMethod]
        public void GetModelItem_PipeConnector_Test()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();

            PipeConnector pipeConnector = iwSvc.GetModelItem<PipeConnector>(1, "pipe_connectors", "pipe_connectors", 1);
            Assert.IsNotNull(pipeConnector, "null result, error happens.");
            Assert.AreEqual("1", pipeConnector.id);
            Assert.AreEqual(AiwGeometryType.Point, pipeConnector.geometry.Type);
            Assert.AreEqual(-96.68496151718864, (pipeConnector.geometry as AiwPoint).Coordinate.X, 0.000001);

        }

    }
}
