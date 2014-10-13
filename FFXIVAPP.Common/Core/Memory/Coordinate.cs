﻿// FFXIVAPP.Common
// Coordinate.cs
// 
// Copyright © 2007 - 2014 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using FFXIVAPP.Common.Core.Memory.Interfaces;

namespace FFXIVAPP.Common.Core.Memory
{
    public class Coordinate : ICoordinate
    {
        public Coordinate(double x = 0.00, double z = 0.00, double y = 0.00)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; set; }
        public double Z { get; set; }
        public double Y { get; set; }

        public Coordinate Rotate2D(float angle)
        {
            return new Coordinate
            {
                X = (float) (X * Math.Cos(angle) - Y * Math.Sin(angle)),
                Y = (float) (Y * Math.Cos(angle) + X * Math.Sin(angle)),
                Z = Z
            };
        }

        public Coordinate Subtract(Coordinate coordinate)
        {
            return new Coordinate
            {
                X = X - coordinate.X,
                Y = Y - coordinate.Y,
                Z = Z - coordinate.Z
            };
        }

        public Coordinate Add(Coordinate coordinate)
        {
            return new Coordinate
            {
                X = X + coordinate.X,
                Y = Y + coordinate.Y,
                Z = Z + coordinate.Z
            };
        }

        public Coordinate Add(float x, float y, float z)
        {
            return new Coordinate
            {
                X = X + x,
                Y = Y + y,
                Z = Z + z
            };
        }

        public Coordinate Scale(float scale)
        {
            return new Coordinate
            {
                X = X * scale,
                Y = Y * scale,
                Z = Z * scale
            };
        }

        public Coordinate Normalize()
        {
            var length = (float) Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            return new Coordinate
            {
                X = X / length,
                Y = Y / length,
                Z = Z / length
            };
        }

        public Coordinate Normalize(Coordinate origin)
        {
            var coordinate = Subtract(origin);
            return coordinate.Normalize();
        }

        public float AngleTo(Coordinate b)
        {
            var tmp = b.Subtract(this);
            return (float) Math.Atan2(tmp.X, tmp.Y);
        }

        public float DistanceTo(Coordinate coordinate)
        {
            return (float) Math.Sqrt(Math.Pow(X - coordinate.X, 2) + Math.Pow(Y - coordinate.Y, 2) + Math.Pow(Z - coordinate.Z, 2));
        }

        public float Distance2D(Coordinate coordinate)
        {
            return (float) Math.Sqrt(Math.Pow(X - coordinate.X, 2) + Math.Pow(Y - coordinate.Y, 2));
        }

        public override string ToString()
        {
            return X + ", " + Y + ", " + Z;
        }
    }
}