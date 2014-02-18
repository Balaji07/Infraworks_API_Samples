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

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Autodesk.Adn.InfrworksService.Models.Geometries
{
    public class AiwGeometry
    {
        [JsonProperty(PropertyName = "type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public AiwGeometryType Type { get; internal set; }

    }


    public class AiwPoint : AiwGeometry
    {
        public AiwPoint()
        {

        }

        public AiwPoint(AiwCoordinate coordinate)
        {
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinates is null");
            }

            this.Coordinate = coordinate;
            this.Type = AiwGeometryType.Point;
        }


        public AiwCoordinate Coordinate { get; internal set; }

    }

    public class AiwLineString : AiwGeometry
    {
        public AiwLineString(AiwCoordinate[] coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException("coordinates is null");
            }
            if (coordinates.Length < 2)
            {
                throw new ArgumentException("Coordinate number must larger than 2 for a linestring");
            }

            this.Coordinates = coordinates;
            this.Type = AiwGeometryType.LineString;
        }

        public AiwCoordinate[] Coordinates { get; internal set; }
    }

    public class AiwPolygon : AiwGeometry
    {
        public AiwPolygon(List<AiwLineString> loops)
        {
            if (loops == null)
            {
                throw new Exception("linestring coordinates for outerloop are expected for a polygon. ");
            }


            this.LinearRings = loops;
            this.Type = AiwGeometryType.Polygon;

        }

        public List<AiwLineString> LinearRings { get; set; }



    }



    public class AiwVector : AiwPoint
    {
        public AiwVector(AiwCoordinate coordinate)
        {
            if (coordinate == null)
            {
                throw new ArgumentNullException("coordinates for vector is null");
            }

            this.Coordinate = coordinate;
            this.Type = AiwGeometryType.Vector;
        }

    }

    public class AiwMatrix3d : AiwGeometry
    {
        public AiwMatrix3d(List<AiwVector> vectors)
        {

            if (vectors == null)
            {
                throw new Exception("coordinates for each vector  are expected for a Matrix3d . ");
            }


            this.Vectors = vectors;
            this.Type = AiwGeometryType.Matrix3d;
        }

        public List<AiwVector> Vectors { get; set; }

    }


    public class AiwNoGeometry : AiwGeometry
    {
        public AiwNoGeometry()
        {
            this.Type = AiwGeometryType.NoGeometry;
       
        }

      
    }


}
