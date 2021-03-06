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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Autodesk.Adn.InfrworksService.Models.Geometries.Converters
{
    public class AiwGeometryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {

            return objectType == typeof(AiwGeometry);
                
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read(); //read "type"
            if (!(reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "type"))
            {
                throw new FormatException("json format exception, 'type' expected");
            }
            reader.Read(); //read value of "type"
            if (reader.TokenType != JsonToken.String)
            {
                throw new FormatException("json format exception,'type' value is expected to be string");
            }

            AiwGeometryType geometryType = (AiwGeometryType)Enum.Parse(typeof(AiwGeometryType),(string)reader.Value);

            AiwGeometry value = null;
            switch (geometryType)
            {
    
                case AiwGeometryType.Point:
                    serializer.Converters.Add(new AiwCoordinateConverter());
                    AiwCoordinate coordinate = serializer.Deserialize<AiwCoordinate>(reader);
                    
                    value = new AiwPoint(coordinate);
                    break;
                case AiwGeometryType.LineString:

                    serializer.Converters.Add(new AiwCoordinateConverter());
                    AiwCoordinate[] coordinates = serializer.Deserialize<AiwCoordinate[]>(reader);
                    value = new AiwLineString(coordinates);

                    break;
                case AiwGeometryType.Polygon:
                    serializer.Converters.Add(new AiwCoordinateConverter());
                    List<AiwCoordinate[]> linearRingCoordinates = serializer.Deserialize<List<AiwCoordinate[]>>(reader);

                    List<AiwLineString> linearRings = new List<AiwLineString>();
                    foreach (var item in linearRingCoordinates)
                    {
                        AiwLineString loop = new AiwLineString(item);
                        linearRings.Add(loop);

                    }
                    value = new AiwPolygon(linearRings);
                    
                    break;
                case AiwGeometryType.Vector:

                    serializer.Converters.Add(new AiwCoordinateConverter());
                    coordinate = serializer.Deserialize<AiwCoordinate>(reader);
                    
                    value = new AiwVector(coordinate);

                    break;
                case AiwGeometryType.Matrix3d:
                    serializer.Converters.Add(new AiwCoordinateConverter());
                    AiwCoordinate[] vectorCoordinates = serializer.Deserialize<AiwCoordinate[]>(reader);

                    List<AiwVector> vectors = new List<AiwVector>();
                    foreach (var item in vectorCoordinates)
                    {
                        AiwVector vector = new AiwVector(item);
                        vectors.Add(vector);

                    }
                    value = new AiwMatrix3d(vectors);

                    break;
                case AiwGeometryType.NoGeometry:
                    serializer.Converters.Add(new AiwCoordinateConverter());
                    coordinate = serializer.Deserialize<AiwCoordinate>(reader);

                    value = new AiwNoGeometry();

                    break;
                default:
                    break;
            }

            //serializer.Populate(reader,value);
            return value;

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
