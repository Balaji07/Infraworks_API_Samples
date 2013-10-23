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

using InfraworkApiLib.Models.Geometries;
using InfraworkApiLib.Models.Geometries.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InfraworkApiLib.Models
{
    public class InfraworksService
    {
        public string name { get; set; }
        public string href { get; set; }
        public string description { get; set; }
    }


    public class ModelClass
    {
        public string name { get; set; }
        public string href { get; set; }
        public string type { get; set; }
    }

    public class ModelInfo
    {
        public string name { get; set; }
        public string id { get; set; }
        public string model_type { get; set; }
        public string parent { get; set; }
        public string href { get; set; }
        [JsonProperty("classes")]
        public List<ModelClass> modelClasses { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string href { get; set; }
    }

    public class Collection
    {
        public string type { get; set; }
        public string parent { get; set; }
        public List<Item> items { get; set; }
    }

    public class Terrain_Texture
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string user_data { get; set; }
        public string tooltip { get; set; }
        public string link { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? termination_date { get; set; }
        public string cs_code { get; set; }
        public object lod_level { get; set; }
        [JsonProperty(PropertyName = "geometry", Required = Required.Always)]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry offset { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry cells { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry cell_orientation { get; set; }


    }



    public class Terrain_Surface
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string user_data { get; set; }
        public string tooltip { get; set; }
        public string link { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? termination_date { get; set; }
        public string cs_code { get; set; }
        public string lod_level { get; set; }
        public int surface_type { get; set; }
        public int num_tris { get; set; }
        public double min_z { get; set; }
        public double max_z { get; set; }
        [JsonProperty(PropertyName = "geometry", Required = Required.Always)]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry offset { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry cells { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry cell_orientation { get; set; }
    }



    public class Markup
    {
        public string id { get; set; }
        public object name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public string asset_type { get; set; }
        public string line_color { get; set; }
        public double scale_fill { get; set; }
        public double smooth_param { get; set; }
        public int smooth_type { get; set; }
        public object spacing { get; set; }
        public object draw_control_poly { get; set; }
        public object height_offset { get; set; }
        public object instance_random_rot_z { get; set; }
        public object instance_scale_variance { get; set; }
        public object instance_spacing { get; set; }
        public object instance_spacing_variance { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry scale { get; set; }
    }


    public class Water_Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string user_data { get; set; }
        public string tooltip { get; set; }
        public string link { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? termination_date { get; set; }
        public double? elevation_offset { get; set; }
        public double? generalization { get; set; }
        public string tessellation { get; set; }
        public int? model_visible { get; set; }
        public int? model_split { get; set; }
        public double? spacing { get; set; }
        public double? spacing_variance { get; set; }
        public double? water_level { get; set; }
        public double? buffer_width { get; set; }
        public double? bank_width { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }

    public class Coverage
    {
        public string id { get; set; }
        public object name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public object elevation_offset { get; set; }
        public object generalization { get; set; }
        public object tessellation { get; set; }
        public object model_visible { get; set; }
        public object model_split { get; set; }
        public object spacing { get; set; }
        public object spacing_variance { get; set; }
        public object category { get; set; }
        public object buffer { get; set; }
        public object smooth_radius { get; set; }
        public object cost_method { get; set; }
        public object hard_cost { get; set; }
        public object soft_cost { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }


    public class Tree
    {
        public string id { get; set; }
        public object name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public object elevation_offset { get; set; }
        public object generalization { get; set; }
        public object tessellation { get; set; }
        public object model_visible { get; set; }
        public object model_split { get; set; }
        public object spacing { get; set; }
        public object spacing_variance { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }


    public class Road
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string user_data { get; set; }
        public string tooltip { get; set; }
        public string link { get; set; }
        public string creation_date { get; set; }
        public string termination_date { get; set; }
        public double? elevation_offset { get; set; }
        public double? generalization { get; set; }
        public string tessellation { get; set; }
        public int? model_visible { get; set; }
        public int? model_split { get; set; }
        public double? spacing { get; set; }
        public double? spacing_variance { get; set; }
        public string definition_id { get; set; }
        public double? elev_from { get; set; }
        public double? elev_to { get; set; }
        public double? max_slope { get; set; }
        public double? stacked_order_from { get; set; }
        public double? stacked_order_to { get; set; }
        public int? importance { get; set; }
        public string material_group { get; set; }
        public double? max_speed { get; set; }
        public int? lanes_forward { get; set; }
        public int? lanes_backward { get; set; }
        public int? reverse_direction { get; set; }
        public string function { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }


    public class PipeLine
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tag { get; set; }
        public string user_data { get; set; }
        public string tooltip { get; set; }
        public string link { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? termination_date { get; set; }
        public double? elevation_offset { get; set; }
        public double? generalization { get; set; }
        public double? tessellation { get; set; }
        public int? model_visible { get; set; }
        public int? model_split { get; set; }
        public double? spacing { get; set; }
        public double? spacing_variance { get; set; }
        public int? pipe_type { get; set; }
        public double? elev_from { get; set; }
        public double? elev_to { get; set; }
        public object networkname { get; set; }
        [JsonProperty("geometry")]
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry size { get; set; }
    }

    public class PipeConnector
    {
        public string id { get; set; }
        public object name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public object elevation_offset { get; set; }
        public object generalization { get; set; }
        public object tessellation { get; set; }
        public object model_visible { get; set; }
        public object model_split { get; set; }
        public object spacing { get; set; }
        public object spacing_variance { get; set; }
        public object connector_type { get; set; }
        public object height { get; set; }
        public object orientation { get; set; }
        public object cap_offset { get; set; }
        public object networkname { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry size { get; set; }
    }


    public class Railway
    {
        public string id { get; set; }
        public object name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public object elevation_offset { get; set; }
        public object generalization { get; set; }
        public object tessellation { get; set; }
        public object model_visible { get; set; }
        public object model_split { get; set; }
        public object spacing { get; set; }
        public object spacing_variance { get; set; }
        public object elev_from { get; set; }
        public object elev_to { get; set; }
        public object max_slope { get; set; }
        public object stacked_order_from { get; set; }
        public object stacked_order_to { get; set; }
        public object importance { get; set; }
        public object material_group { get; set; }
        public object lanes { get; set; }
        public object definition_id { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }


    public class CustomBuilding
    {
        public string id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public object tag { get; set; }
        public object user_data { get; set; }
        public object tooltip { get; set; }
        public object link { get; set; }
        public object creation_date { get; set; }
        public object termination_date { get; set; }
        public object elevation_offset { get; set; }
        public object generalization { get; set; }
        public object tessellation { get; set; }
        public int model_visible { get; set; }
        public int model_split { get; set; }
        public object spacing { get; set; }
        public object spacing_variance { get; set; }
        public object building_complex_id { get; set; }
        public object base_color { get; set; }
        public double roof_height { get; set; }
        public object roof_height_absolute { get; set; }
        public object roof_slope { get; set; }
        public object roof_material { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry geometry { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_scale { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_rotate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_translate { get; set; }
        [JsonConverter(typeof(AiwGeometryConverter))]
        public AiwGeometry model_transform { get; set; }
    }


}
