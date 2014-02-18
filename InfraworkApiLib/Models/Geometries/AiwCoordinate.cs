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

//credite to https://github.com/jbattermann/GeoJSON.Net 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Autodesk.Adn.InfrworksService.Models.Geometries
{
    
    public class AiwCoordinate
    {
        private double?[] Coordinates { get; set; }

        public AiwCoordinate()
        {
            this.Coordinates = new double?[3];

        }

        public AiwCoordinate(double x, double y, double? z = null)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public AiwCoordinate(string x, string y, string z = null)
            : this()
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }

            if (y == null)
            {
                throw new ArgumentNullException("y");
            }

            if (string.IsNullOrWhiteSpace(x))
            {
                throw new ArgumentOutOfRangeException("x", "May not be empty.");
            }

            if (string.IsNullOrWhiteSpace(y))
            {
                throw new ArgumentOutOfRangeException("y", "May not be empty.");
            }

            double lat;
            double lng;

            if (!double.TryParse(x, NumberStyles.Float, CultureInfo.InvariantCulture, out lat))
            {
                throw new ArgumentOutOfRangeException("x", "x must be a proper lat (+/- double) value, e.g. '38.889722'.");
            }

            if (!double.TryParse(y, NumberStyles.Float, CultureInfo.InvariantCulture, out lng))
            {
                throw new ArgumentOutOfRangeException("y", "y must be a proper lon (+/- double) value, e.g. '-77.008889'.");
            }

            this.X = lat;
            this.Y = lng;

            if (z == null)
            {
                this.Z = null;
            }
            else
            {
                double alt;
                if (!double.TryParse(z, NumberStyles.Float, CultureInfo.InvariantCulture, out alt))
                {
                    throw new ArgumentOutOfRangeException("z", "z must be a proper z (m(eter) as double) value, e.g. '6500'.");
                }

                this.Z = alt;
            }
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>The x.</value>
        public double X
        {
            get
            {
                return this.Coordinates[0].GetValueOrDefault();
            }

            set
            {
                this.Coordinates[0] = value;
            }
        }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>The y.</value>
        public double Y
        {
            get
            {
                return this.Coordinates[1].GetValueOrDefault();
            }

            set
            {
                this.Coordinates[1] = value;
            }
        }

        /// <summary>
        /// Gets the z.
        /// </summary>
        public double? Z
        {
            get
            {
                return this.Coordinates[2];
            }

            set
            {
                this.Coordinates[2] = value;
            }
        }


    }
}
