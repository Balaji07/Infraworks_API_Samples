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

//credite to https://code.google.com/p/nettopologysuite/source/browse/trunk/NetTopologySuite.IO/NetTopologySuite.IO.GeoJSON/Converters/CoordinateConverters.cs?r=869

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace InfraworkApiLib.Models.Geometries.Converters
{
    public class AiwCoordinateConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WritePropertyName("coordinates");

            List<List<AiwCoordinate[]>> coordinatesss = value as List<List<AiwCoordinate[]>>;
            if (coordinatesss != null)
            {
                WriteJsonCoordinatesEnumerable2(writer, coordinatesss, serializer);
                return;
            }

            List<AiwCoordinate[]> coordinatess = value as List<AiwCoordinate[]>;
            if (coordinatess != null)
            {
                WriteJsonCoordinatesEnumerable(writer, coordinatess, serializer);
                return;
            }

            IEnumerable<AiwCoordinate> coordinates = value as IEnumerable<AiwCoordinate>;
            if (coordinates != null)
            {
                WriteJsonCoordinates(writer, coordinates, serializer);
                return;
            }

            AiwCoordinate coordinate = value as AiwCoordinate;
            if (coordinate != null)
            {
                WriteJsonCoordinate(writer, coordinate, serializer);
                return;
            }

        }

        private static void WriteJsonCoordinate(JsonWriter writer, AiwCoordinate coordinate, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            writer.WriteValue(coordinate.X);
            writer.WriteValue(coordinate.Y);
            if (null != coordinate.Z)
                writer.WriteValue(coordinate.Z);

            writer.WriteEndArray();
        }

        private static void WriteJsonCoordinates(JsonWriter writer, IEnumerable<AiwCoordinate> coordinates, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (AiwCoordinate coordinate in coordinates)
                WriteJsonCoordinate(writer, coordinate, serializer);
            writer.WriteEndArray();
        }

        private static void WriteJsonCoordinatesEnumerable(JsonWriter writer, IEnumerable<AiwCoordinate[]> coordinates, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (AiwCoordinate[] coordinate in coordinates)
                WriteJsonCoordinates(writer, coordinate, serializer);
            writer.WriteEndArray();
        }
        private static void WriteJsonCoordinatesEnumerable2(JsonWriter writer, List<List<AiwCoordinate[]>> coordinates, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (List<AiwCoordinate[]> coordinate in coordinates)
                WriteJsonCoordinatesEnumerable(writer, coordinate, serializer);
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();

            Debug.Assert(reader.TokenType == JsonToken.PropertyName);
            Debug.Assert((string)reader.Value == "coordinates");

            object result;
            if (objectType == typeof(AiwCoordinate))
                result = ReadJsonCoordinate(reader);
            else if (typeof(IEnumerable<AiwCoordinate>).IsAssignableFrom(objectType))
                result = ReadJsonCoordinates(reader);
            else if (typeof(List<AiwCoordinate[]>).IsAssignableFrom(objectType))
                result = ReadJsonCoordinatesEnumerable(reader);
            else if (typeof(List<List<AiwCoordinate[]>>).IsAssignableFrom(objectType))
                result = ReadJsonCoordinatesEnumerable2(reader);
            else throw new ArgumentException("unmanaged type: " + objectType);
            reader.Read();
            return result;

        }

        private static AiwCoordinate ReadJsonCoordinate(JsonReader reader)
        {
            reader.Read();
            if (reader.TokenType != JsonToken.StartArray) return null;

            AiwCoordinate c = new AiwCoordinate();
            reader.Read();
            Debug.Assert(reader.TokenType == JsonToken.Float);
            c.X = (Double)reader.Value;
            reader.Read();
            Debug.Assert(reader.TokenType == JsonToken.Float);
            c.Y = (Double)reader.Value;
            reader.Read();
            if (reader.TokenType == JsonToken.Float)
            {
                c.Z = (Double)reader.Value;
                reader.Read();
            }
            Debug.Assert(reader.TokenType == JsonToken.EndArray);

            return c;
        }

        private static AiwCoordinate[] ReadJsonCoordinates(JsonReader reader)
        {
            reader.Read();
            if (reader.TokenType != JsonToken.StartArray) return null;

            List<AiwCoordinate> coordinates = new List<AiwCoordinate>();
            while (true)
            {
                AiwCoordinate c = ReadJsonCoordinate(reader);
                if (c == null) break;
                coordinates.Add(c);
            }
            Debug.Assert(reader.TokenType == JsonToken.EndArray);
            return coordinates.ToArray();
        }

        private static List<AiwCoordinate[]> ReadJsonCoordinatesEnumerable(JsonReader reader)
        {
            reader.Read();
            if (reader.TokenType != JsonToken.StartArray) return null;

            List<AiwCoordinate[]> coordinates = new List<AiwCoordinate[]>();
            while (true)
            {
                AiwCoordinate[] res = ReadJsonCoordinates(reader);
                if (res == null) break;
                coordinates.Add(res);
            }
            Debug.Assert(reader.TokenType == JsonToken.EndArray);
            return coordinates;
        }

        private static List<List<AiwCoordinate[]>> ReadJsonCoordinatesEnumerable2(JsonReader reader)
        {
            reader.Read();
            if (reader.TokenType != JsonToken.StartArray) return null;
            List<List<AiwCoordinate[]>> coordinates = new List<List<AiwCoordinate[]>>();

            while (true)
            {
                List<AiwCoordinate[]> res = ReadJsonCoordinatesEnumerable(reader);
                if (res == null) break;
                coordinates.Add(res);
            }
            Debug.Assert(reader.TokenType == JsonToken.EndArray);
            return coordinates;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(AiwCoordinate) ||
                   objectType == typeof(AiwCoordinate[]) ||
                   objectType == typeof(List<AiwCoordinate[]>) ||
                   objectType == typeof(List<List<AiwCoordinate[]>>) ||
                   typeof(IEnumerable<AiwCoordinate>).IsAssignableFrom(objectType) ||
                   typeof(IEnumerable<IEnumerable<AiwCoordinate>>).IsAssignableFrom(objectType) ||
                   typeof(IEnumerable<IEnumerable<IEnumerable<AiwCoordinate>>>).IsAssignableFrom(objectType);
        }
    }
}